/*
 * name: page.detail.load_dashou.js
 * author: xeonluo
 * usage:
**/
define("page.detail.load_dashou.49", function(require, exports, module) {
    var image = require('common.image.7');
    var whId = itemInfo.whid;
    var uid = G.util.cookie.get("y_guid"); // 易迅id
    var gbRegionId = itemInfo.area_id; // 国际码
    var regionId = G.util.cookie.get("prid"); // 易迅地域码
    var chid = itemInfo.chid || (typeof window.chid!="undefined"?window.chid:0);
    regionId = regionId == ""?"2626":regionId.substr(0, regionId.indexOf("_"));
    // 获取所有搭配类型 
    var _url = "http://d.dashou.yixun.com/dashou/querydashoudata?whId="+whId+"&regionId="+regionId+"&gbRegionId="+gbRegionId+"&ids="+itemInfo.pid+"&sceneid=6001&uid="+uid+"&chid="+chid;
    var dashou = {
        init: function(event, item){
            // 初始化过 啥也不干
            if(itemInfo.bt_state != 0 || item.product_sale_model == 5 || $(".xcontent_row3 .xtiein").attr("data-loaded")){
                return;
            }
            
            /**
             * 随心配 is_collocate
                                套餐 is_package
                                延保 is_support_extend
                                赠品 is_with_present
                                赠券 is_have_coupon
             */
            var gift_type = 0;
            if(config.lv & level.DASHOU_GIFT){ // 赠品开关
                if(item.is_with_present == 1){
                    gift_type += 8;
                }
                if(item.is_have_coupon == 1){
                    gift_type += 16;
                }
            }
            if(gift_type != 0){
                dashou.loadDataByType(gift_type, dashou.loadGiftAndCoupon);
            }
            
             // 合约机直接跳走了  不显示搭售
            if(item.is_contract == 1){
                return;
            }
            var dashou_type = 0; 
            if((config.lv & level.DASHOU_EASYMATCH) && item.is_collocate == 1){// 随心配
                dashou_type += 1;
            }
            if((config.lv & level.DASHOU_PACKAGE) && item.is_package == 1){ // 套餐
                dashou_type += 2;
            }
            
            if(dashou_type != 0){ 
                dashou.loadDataByType(dashou_type, function(o){
                    dashou.loadEasyMatch(o);
                    dashou.loadPackage(o);
                    //显示区域
                    var tabs = $(".xcontent_row3 .xtiein").attr("data-loaded","true");
                    if($("div", tabs).length > 0){
                        $(".xcontent_row3").show();
                    }else{
                        //显示强烈推荐
                        if(config.lv & level.DASHOU_RECOMMEND){
                            dashou.getRecommendation(item);
                        }
                    }
                    dashou.eventAction();
                });
            }else if(config.lv & level.DASHOU_RECOMMEND){ // 推荐开关
                dashou.getRecommendation(item);
            }
            //if((config.lv & level.DASHOU_YANBAO) && item.is_support_extend == 1){// 延保
            if( config.lv & level.DASHOU_YANBAO ){// 延保
                dashou.loadDataByType(4, dashou.loadRepair);
            }
        },
        loadGiftAndCoupon: function(_json){
            // 赠品 组件 单品赠券
            var o = _json || {};
            // 赠品
            var oGift =  o.ZengpinData, giftHtml = []; // 随心配 套餐 赠品 推荐的主商品显示赠品相关;
            if(oGift && oGift.ret == 0 && oGift.MainArr[0]){
                var mainArr = oGift.MainArr[0];
                var giftList = mainArr.Zenpin;
                var length = giftList.length;
                var currGift = null;
                
                var subHtml = [];
                var ytag = 22850;
                for(var i = 0; i < length; i++){
                    currGift = giftList[i];
                    if(currGift.type == 0){ // 0 赠品 1组件
                        giftHtml.push('<li class="sea_pop_parent"><div class="x_mod_gift"><a href="http://item.yixun.com/item-'+currGift.product_id+'.html" target="_blank" class="x_mod_gift_img sea_pop_a" ytag="'+(++ytag)+'"><img src="'+image.getPicBySize(currGift.logoUrl, 30)+'" alt="'+currGift.name+'" onerror="this.src=\'http://static.gtimg.com/icson/images/detail/v2/30.jpg\'" /></a>');
                        // 如果长度大于30就设置title  
                        giftHtml.push('<a href="http://item.yixun.com/item-'+currGift.product_id+'.html" class="x_mod_gift_name sea_pop_a" target="_blank"'+(currGift.name.length>30?' title="'+currGift.name+'"':'')+' ytag="'+ytag+'">'+currGift.name.substr(0,30)+'</a>');
                        giftHtml.push('<span class="x_mod_gift_qty"><span>'+currGift.num+'</span>件</span>'); 
                        //giftHtml.push('<span class="x_mod_gift_price">价值<span class="mod_price"><i>&yen;</i>'+currGift.price+'</span></span></div>');
                        // start浮层
                        giftHtml.push('</div><div class="mod_hint mod_hint_weak x_mod_hint1 sea_pop_box" style="display:none;position:absolute;top:40px;">');
                        giftHtml.push('<div class="mod_hint_inner xhint_goods">');
                        giftHtml.push('<a href="http://item.yixun.com/item-'+currGift.product_id+'.html" target="_blank" class="xhint_goods_img" ytag="'+ytag+'"><img src="'+image.getPicBySize(currGift.logoUrl, 200)+'" alt="'+currGift.name+'"></a>');
                        //giftHtml.push('<p class="xhint_goods_price">价值<strong class="mod_price"><i>&yen;</i>'+currGift.price+'</strong></p>');
                        giftHtml.push('</div><i class="mod_hint_arrow1"></i></div>');
                        // end浮层
                        giftHtml.push('</li>');
                        
                        //floatHtml.push('<p class="xtiein_base_gift"><em class="mod_label mod_label_c3">赠</em><a href="http://item.yixun.com/item-'+currGift.product_id+'.html" title="'+currGift.name+'" target="_blank">'+currGift.name+'</a></p>');
                    }
                }
                
            }
            
            // 单品赠券
            var couponList = o.coupon; // 商详只有1个商品 
            if(couponList && couponList.length){
                var currCouponList = couponList[0].coupon_list;
                var length = currCouponList.length;
                
                // 有效起始日期
                var bDate = new Date(couponList[0].time_begin*1000);
                var eDate = new Date(couponList[0].time_end*1000);
                var begin_time = bDate.getFullYear() + "-"+(bDate.getMonth()+1)+"-"+bDate.getDate();
                var end_time = eDate.getFullYear() + "-"+(eDate.getMonth()+1)+"-"+eDate.getDate();
                
                for(var i = 0; i < length; i++){
                    var oCoupon = currCouponList[i];
                    giftHtml.push('<li class="sea_pop_parent"><div class="x_mod_gift"><a href="javascript:void(0)" class="x_mod_gift_img sea_pop_a" ytag="'+(++ytag)+'"><img src="http://static.gtimg.com//icson/images/detail/v2/discount_ticket.png" alt="'+oCoupon.coupon_name+'" /></a>'); 
                    giftHtml.push('<a href="javascript:void(0)" class="x_mod_gift_name sea_pop_a" '+(oCoupon.coupon_name.length>30?' title="'+oCoupon.coupon_name+'"':'')+' ytag="'+ytag+'">'+oCoupon.coupon_name+'</a>');
                    giftHtml.push('<span class="x_mod_gift_qty"><span>1</span>张</span>'); 
                    //giftHtml.push('<span class="x_mod_gift_price">价值<span class="mod_price"><i>&yen;</i>'+(oCoupon.coupon_amt / 100).toFixed(2)+'</span></span>');
                    // start浮层
                    giftHtml.push('</div><div class="mod_hint mod_hint_weak x_mod_hint2 sea_pop_box" style="display:none;position:absolute;top:40px;">');
                    giftHtml.push('<div class="mod_hint_inner xhint_rule"><dl><dt>详情：</dt>');
                    giftHtml.push('<dd>'+oCoupon.coupon_name+'<span class="c_tx3">（特价商品及虚拟商品除外）</span></dd></dl>');
                    giftHtml.push('<dl><dt>使用时间：</dt><dd>订单提交成功满7天并且签收订单，发送到“我的优惠券”</dd></dl>');
                    giftHtml.push('<dl><dt>活动有效期：</dt><dd>'+begin_time+'至'+end_time+'</dd></dl>');
                    giftHtml.push('</div><i class="mod_hint_arrow1"></i></div>');
                    // end浮层
                    giftHtml.push('</li>');
                    
                }
                
            }
            //渲染赠品内容
            if(giftHtml.length > 0){
                // 只展示前2项
                $(".xbase_row2").append('<dl class="xbase_item xgift"><dt class="xbase_col1">赠品</dt><dd class="xbase_col2"><ul class="xgift_list">'+giftHtml.join("")+'</ul></dd></dl>');
                
                // 多余2项展示显示全部
                var jGift = $(".xbase_row2 .xgift_list li");
                if(jGift.length > 2){
                    jGift.each(function(i){
                        if(i > 1){
                            $(this).hide();
                        }
                    });
                    
                    var moreHtml = '<li><a href="javascript:void(0)">共'+jGift.length+'件赠品 展示全部</a></li>';
                    $(moreHtml).insertAfter(jGift.eq(1)).find("a").click(function(){
                        $(this).parents("ul").find("li").show();
                        $(this).parent().remove();
                    });
                }
                
            }
        },
        loadEasyMatch: function(o){
            //  RelativityData 随心配相关数据
            if(o && o.retcode == 0){
                var easyMatch = o.RelativityData;
                if(easyMatch && easyMatch.ret == 0 && easyMatch.MainArr[0]){
                    var mainArr = easyMatch.MainArr[0];
                    var relativityClass = mainArr.RelativityClass;
                    
                    if(relativityClass && relativityClass.length == 0){
                        //没有随心配数据的处理
                        return;
                    }
                    
                    $(".xcontent_row3 .xtiein").append(this.getHtmlByType(relativityClass,1));
                    dashou.selectAction($(".xsxp"));
                }
            }
        },
        loadPackage: function(o){
            // 套餐
            if(o.retcode == 0){
                var packageData = o.PackageData;
                if(packageData && packageData.ret == 0 && packageData.MainArr[0]){
                    packageData =  packageData.MainArr[0];
                    var packageList = packageData.Package;
                    
                    if(packageList && packageList.length == 0){
                        //没有套餐数据的处理
                        return;
                    }
                    for(var i = 0; i < packageList.length;i++){
                        packageList[i].className = packageList[i].package_name;
                    }
                    
                    $(".xcontent_row3 .xtiein").prepend(this.getHtmlByType(packageList,2));
                    
                    // 这里真变态 套餐不需要展开全部 为了不在模板里面做太多的判断 这里特殊处理下
                    var J_expand = $(".xpackage .xtiein_expand");
                    if(J_expand.length){
                        var bd = J_expand.parents('.x_mod_stab').find('.x_mod_stab_bd');
                        bd.css('height', 'auto');
                        bd.children().height('auto');
                        J_expand.remove();
                    }
                    
                    // 绑定tab的事件
                    $(".xcontent_row3 .xpackage li[data-baseprice]").bind("mouseover", function(e){
                        var basePrice = (parseFloat($(this).attr("data-baseprice"), 10)/100).toFixed(2); // 原价 
                        var pkgprice = (parseFloat($(this).attr("data-pkgprice"), 10)/100).toFixed(2); // 套餐价
                        var diffPrice = (parseFloat($(this).attr("data-diffprice"), 10)/100).toFixed(2); // 差价
                        var mod_price = $(".xcontent_row3 .xpackage .xtiein_col5 .mod_price");
                        //mod_price.eq(0).html('<i>&yen;</i>'+basePrice);
                        mod_price.eq(0).html('<i>&yen;</i>'+pkgprice);
                        mod_price.eq(1).html('<i>&yen;</i>'+diffPrice);
                        
                        var yanbaoPid = $(".xbase_row3 .xrepair .xoption_selected").attr("data-pid");
                        $(".xcontent_row3 .xpackage .xbtn_s").attr("href","http://buy.yixun.com/cart.html?pnum=1&chid="+chid+"&pkgid="+$(this).attr("data-pkgid")+(yanbaoPid?"&repair="+yanbaoPid:""));
                        
                        // 主商品价格也要随着变化
                        $(".xpackage .xtiein_col1 .mod_price").html('<i>&yen;</i>'+$(this).attr("data-mprice"));
                        
                    }).eq(0).trigger("mouseover");
                    
                }
            }
        },
        
        loadRepair: function(o){
            // 延保
            if(o.retcode == 0){
                var yanbaoData = o.YanbaoData;
                if(yanbaoData && yanbaoData.ret == 0 && yanbaoData.MainArr[0]){
                    yanbaoData = yanbaoData.MainArr[0];
                    var repairList = yanbaoData.Yanbao;
                    var repairHtml = [];
                    for(var i = 0; i < repairList.length;i++){
                        var currRepair = repairList[i];
                        repairHtml.push('<li class="xoption" data-pid="'+currRepair.productId+'"><a href="#" ytag="'+(22801+i+1)+'">'+currRepair.warrantyYears+'年延保服务<span class="mod_price"><i>&yen;</i>'+((currRepair.Price)/100).toFixed(2)+'</span><i class="xoption_ico_selected"></i></a></li>');
                    }
                    
                    if(repairHtml.length > 0){
                        repairHtml.push('<li class="xrepair_lnk"><a href="http://st.yixun.com/help/yanbaofuwu.htm" target="_blank">延保服务介绍</a></li>');
                        $(".xbase_row3 dl.xnumber").before('<dl class="xbase_item xrepair"><dt class="xbase_col1">延长保修</dt><dd class="xbase_col2"><ul class="clearfix">'+repairHtml.join("")+'</ul></dd></dl>');
                        $(".xbase_row3 .xrepair .xoption").unbind().bind("click",function(event){
                            var oselect = $(this);
                            var yanbaoPid = 0;
                            if(oselect.hasClass("xoption_selected")){
                                oselect.removeClass("xoption_selected");
                            }else{
                                oselect.parent().find(".xoption_selected").removeClass("xoption_selected");
                                oselect.addClass("xoption_selected");
                                yanbaoPid = oselect.attr("data-pid");
                            }
                            if(itemInfo.bt_state == 0){
                                var v = $("#btnAddCart");
                                var shref = v.attr("href");
                                if(shref.indexOf("repair")>0){
                                    v.attr("href", shref.replace(/repair=\d+/,"repair="+yanbaoPid));
                                }else{
                                    v.attr("href",shref+"&repair="+yanbaoPid);
                                }
                            }
                            
                            event.preventDefault();
                        });
                    }
                }
            }
        },
        
        loadDataByType: function(_type, _callback){
            $.ajax({
                type : "GET",
                url  : _url,
                data: {
                  type: _type
                },
                dataType : 'jsonp',
                report: {
                    key: "retcode",
                    url: "http://d.dashou.yixun.com/dashou/querydashoudata?type="+_type,
                    formatUrl: false
                },
                success: _callback?_callback:function(){}
            });    
                    
        },
        
        /**
         * _type 1: 随心配 2:套餐 3:推荐
         */
        getHtmlByType: function(_data, _type){
            
            var label = "优惠套装";
            var _className = "xsxp";
            var childData = "arrRelativity";
            var cart_btn_ytag = 24204;
            if(_type == 2){
                label = "官方推荐";
                _className = "xpackage";
                childData = "pidlist";
                cart_btn_ytag = 24102;
            }else if(_type == 3){
                label = "人气搭配";
                _className = "xrecommend";
                childData = "recommend";
                cart_btn_ytag = 24404
            }
            
            var ds_html = [
                '<div class="'+_className+' xtiein_item clearfix"><div class="xtiein_hd">'+label+'</div><div class="xtiein_bd">',
                '<div class="xtiein_col1"><div class="xtiein_base"><div class="xtiein_base_img">',
                '<img src="'+image.getPicBySize(itemInfo.mainpic, 80)+'" alt="'+itemInfo.name+'" onerror="if(!$(this).attr(\'load-err\')){this.src=\'http://static.gtimg.com/icson/images/detail/v2/80.jpg\';$(this).attr(\'load-err\',\'load-err\');}"></div>',
                '<span class="xtiein_base_price">'+dashou.getMainPrice(1)+'<b></b></span>',
                '</div></div>',
                '<div class="xtiein_col2"><span class="xtiein_symbol">+</span></div>',
                '<div class="xtiein_col3"><div class="x_mod_stab">',
                '<div class="x_mod_stab_hd"><ul class="x_mod_stab_nav clearfix">',
            ];
            
            var maxNum = $(".ic_mini").length?6:8;// 窄版6 宽版8
            var products_html = ['<div class="x_mod_stab_bd">'];
            var has_expand = false; // 如果所有tab里面都没有大于一行的 就不显示展开全部了 窄版3 宽版4
            var pkg_names = [];
            for(var i = 0; i < _data.length && i < maxNum; i++){
                var tempData = _data[i];
                var data = tempData[childData];
                
                if(data.length > maxNum/2){
                    has_expand = true;
                }
                
                var pkg_property = "";
                if(_data[i].package_id){
                    if($.inArray(tempData.className, pkg_names) != -1){
                        continue;
                    }
                    pkg_names.push(tempData.className);
                    var mprice = ((tempData.main_product.price -  tempData.main_product.discount_price)/100).toFixed(2);
                    pkg_property = ' data-pkgid="'+tempData.package_id+'" data-baseprice="'+tempData.package_base_price+'" data-diffprice="'+tempData.package_discount_price+'" data-pkgprice="'+tempData.package_price+'" data-mprice="'+mprice+'"';
                }
                ds_html.push('<li'+(i==0?' class="current"':'')+pkg_property+'><a href="javascript:void(0);">'+tempData.className+'</a></li>');
                products_html.push('<div class="x_mod_stab_con" style="display: '+(i==0?'block':'none')+';"><ul class="xtiein_goods clearfix">');
                for(var j = 0;j < data.length && (j < maxNum || pkg_property != "");j++){ // 除套餐外 强烈推荐与随心配最多展示2行
                    var currData = data[j];
                    currData.product_id = currData.product_id || currData.pid;
                    products_html.push('<li><div class="xtiein_goods_img">');
                    
                    var curr_href = currData.href?currData.href:('http://item.yixun.com/item-'+currData.product_id+'.html');
                    var imgErrStr = ' onerror="if(!$(this).attr(\'load-err\')){this.src=\'http://static.gtimg.com/icson/images/detail/v2/80.jpg\';$(this).attr(\'load-err\',\'load-err\');}"';
                    products_html.push('<a href="'+curr_href+'" target="_blank"><img src="'+image.getPicBySize(currData.logoUrl, 80)+'" target="_blank" alt="'+currData.name+'" title="'+currData.name+'"/'+imgErrStr+'></a></div>');
                    products_html.push('<div class="xtiein_goods_info">');
                    
                    products_html.push('<p class="xtiein_goods_price">');
                    if(!pkg_property){
                        products_html.push('<i class="xico xico_chk" data-pid="'+currData.product_id+'" ytag="24201"></i>');
                    }else{
                        //套餐里面的字段意义跟随心配里面不一致 这里做个兼容 方便模版拼装
                        data[j].discount_price = data[j].price - data[j].discount_price;
                    }
                    products_html.push('<span class="mod_price"><i>&yen;</i>'+(currData.discount_price/100).toFixed(2)+'</span></p>');
                    var savePrice = ((currData.price - currData.discount_price)/100).toFixed(2);
                    if(_type != 3 && savePrice > 0){ // 对大于0进行判断 
                        products_html.push('<p class="xtiein_goods_save">节省<span class="mod_price"><i>&yen;</i>'+savePrice+'</span></p>');
                    }
                    products_html.push('<p class="xtiein_goods_name"><a href="'+curr_href+'" target="_blank" title="'+currData.name+'">'+currData.name+'</a></p>');
                    products_html.push('</div></li>');
                }
                products_html.push('</ul></div>');
            }
            products_html.push('</div>');
            
            ds_html.push('</ul>'+(has_expand?'<a href="javascript:void(0);" class="xtiein_expand">展开全部</a>':'')+'</div>');// end xtiein_col3
            ds_html.push(products_html.join(""));
            ds_html.push('</div></div><div class="xtiein_col4"><span class="xtiein_symbol">=</span></div>'); // xtiein_col4
            
            var defaultPrice = dashou.getMainPrice();
            var defaultSave = 0;
            var btn_cart_url = 'http://buy.yixun.com/cart.html?pid='+itemInfo.pid+'&pnum=1&chid='+chid;
            if(_data[0].package_id){
                defaultPrice = '<span class="mod_price"><i>&yen;</i>'+((_data[0].package_price/100).toFixed(2))+'</span>';
                defaultSave = (_data[0].package_discount_price/100).toFixed(2);
                btn_cart_url= 'http://buy.yixun.com/cart.html?pkgid='+_data[0].package_id+'&pnum=1&chid='+chid;
            }
            ds_html.push([
                '<div class="xtiein_col5"><div class="xtiein_total"><ul class="xtiein_total_list">',
                '<li class="xtiein_total_price"><span class="xtiein_total_list_tit">套餐价</span>',
                '<span class="xtiein_total_list_con">'+defaultPrice+'</span></li>',
                _type==3?"":('<li><span class="xtiein_total_list_tit">已节省</span><span class="xtiein_total_list_con xtiein_save_price"><span class="mod_price"><i>&yen;</i>'+defaultSave+'</span></span></li>'),
                _type==2?"":('<li><span class="xtiein_total_list_tit">已搭配</span><span class="xtiein_total_list_con"><span>0件</span><a href="#" class="xtiein_total_reset" style="display:none;" ytag="'+(_type==1?24203:24403)+'">[清除选择]</a></span></li>'),
                '</ul>',
                itemInfo.bt_state == 0?'<a href="'+btn_cart_url+'" class="xbtn xbtn_s" ytag="'+cart_btn_ytag+'">加入购物车</a>':'<a href="javascript:void(0);" class="xbtn xbtn_disabled xbtn_s" onclick="event.preventDefault();">加入购物车</a>',
                '</div></div>'
            ].join(""));
            
            ds_html.push('</div></div>');
            
            return ds_html.join("");
          
        },
        
        getRecommendation: function(item){
            var areaid = G.logic.constants.getLocationId().split('_'),
            current_locid = areaid[0] || 0;
            var locarr = G.util.cookie.get('loc').split('_');
            item.loc_id = locarr[locarr.length-1];
            item.current_locid = current_locid;
            var url = 'http://s2.smart.yixun.com/w/tf/gettfx?tfid=100009&biReserved='+item.whid+':' + item.current_locid + ','+item.loc_id + ','+item.whid + '-' + item.pid + ':' + item.c3ids + ',' + item.brand_no + ',' + item.category_id+ ',' + item.price+'&type=jsonp&tcdn=1';
            $.ajax({
                url: url,
                dataType: 'jsonp',
                report: {
                    key: "iRet",
                    url: "http://s2.smart.yixun.com/w/tf/gettfx?tfid=100009",
                    formatUrl: false
                },
                success: function(_json){
                    var o = _json ||{};
                    if(o.iRet == 0 && o.data && o.data.POS_RECOM){
                        var recommendData = o.data.POS_RECOM;
                        
                        var length = recommendData.length;
                        // 为配合模板需要 重新组装数据
                        for(var i = 0;i < length;i++){
                            var tempData = recommendData[i];
                            tempData.logoUrl = tempData.IMG;
                            tempData.pid = tempData.COMMODITYID;
                            tempData.discount_price = tempData.PRICE*100;
                            tempData.price = tempData.MARKETPRICE*100;
                            tempData.name = tempData.TITLE;
                            tempData.href = tempData.URL;
                        }
                        
                        $(".xcontent_row3 .xtiein").append(dashou.getHtmlByType([{recommend:recommendData,className:"人气搭配1"}],3));
                        dashou.selectAction($(".xrecommend"));
                        dashou.eventAction();
                        $(".xcontent_row3").show();
                    }
                }
            });
        },
        eventAction: function(){
            $('.x_mod_stab_nav li').bind('mouseover', function(e){
                if ($(this).hasClass('current')) {
                    return ;
                }
                $(this).addClass('current').siblings().removeClass('current');
                var navs = $(this).parent().find('> li');
                var idx = navs.index($(this));
                var bd = $(this).parents('.x_mod_stab').find('.x_mod_stab_bd');
                var curItem = bd.find('.x_mod_stab_con').eq(idx);
                var height = curItem.height();
                var bdHeight = bd.height();
                if (bd.height() != height) {
                    bd.css('height', bdHeight).stop().animate({
                        height: height
                    },500,'swing', function(){
                        bd.height('auto');
                    });
                }
                curItem.show().siblings().hide();

            });
            
            //收起、展开效果
            $('.xcontent_row3 .xtiein_expand').bind('click', function(e){
                e.preventDefault();
                var bd = $(this).parents('.x_mod_stab').find('.x_mod_stab_bd'), $this = $(this);
                if ($this.data('isExpanded')) {
                    $this.text('展开全部').data('isExpanded', false);
                    bd.stop().animate({
                        height: 110
                    },500,'swing', function(){
                        $this.text('展开全部').data('isExpanded', false);
                        bd.children().height(110);
                    });
                } else {
                    var height;
                    bd.css('height', 'auto');
                    bd.children().height('auto');
                    height = bd.height();
                    bd.height(110);
                    bd.stop().animate({
                        height: height
                    },500,'swing', function(){
                        $this.text('收起全部').data('isExpanded', true);
                        bd.height('auto');
                    });
                }
            });

            
            $(".xcontent_row3 .xtiein_col5 .xbtn_s").bind("mouseover", function(){
                // mouserover时候取下数量
                var v = $("#order_num").val();
                var shref = $(this).attr("href");
                shref = shref.replace(/pnum=\d+/, "pnum="+v);
                // 有ids的情况需要替换掉ids
                var ids = shref.match(/(?:^|&|\?| )ids=([^&]*)(?:&|$)/);
                var yanbaoPid = $(".xbase_row3 .xrepair .xoption_selected").attr("data-pid");
                if(ids){
                    var idsArr = ids[1].split(",");
                    // 带上多价id和延保id
                    idsArr[0] = itemInfo.pid+"|"+v+"|0|"+(itemInfo.min_price_id?itemInfo.min_price_id:"0")+(yanbaoPid?"|"+yanbaoPid:"");
                    shref = shref.replace(/ids=([^&]*)/, "ids="+idsArr.join(","));
                }else {
                    if(shref.indexOf("repair")>-1 && yanbaoPid){
                        shref = shref.replace(/repair=\d+/,"repair="+yanbaoPid);
                    }else{
                        shref += yanbaoPid?"&repair="+yanbaoPid:"";
                    }
                }
                $(this).attr("href", shref);
            });
            
            //数量发生变化时要更新
            $("#order_num").change(function(){
                var v = ~~$(this).val();
                if(v){
                    var totalValue = (((itemInfo.bt_state==6||itemInfo.price==99999900)?0:itemInfo.price) /100)*v; // 总价格
                    //var pids = [itemInfo.pid+"|"+v+"|0"];
                    // 强烈推荐跟随心配不可能同时出现 而套餐数据下面的选择器无匹配
                    var dom = $(".xcontent_row3 .xico_chk").parents(".xtiein_bd");
                    var selectedNum = 0;
                    $("i.xico_chk_checked",dom).each(function(){
                        var temp = $(this).parents("li").find(".mod_price");
                        totalValue += parseFloat(temp.eq(0).text().substr(1),10);
                       // pids.push($(this).attr("data-pid")+"|1|"+itemInfo.pid);
                        selectedNum++;
                    });
                    if(selectedNum == 0 && totalValue == 0){//这里需要考虑的是显示暂无报价的情况
                        $(".xtiein_total_price .xtiein_total_list_con",dom).html(dashou.getMainPrice());
                    }else{
                        $(".xtiein_total_price .xtiein_total_list_con",dom).html('<span class="mod_price"><i>&yen;</i>'+totalValue.toFixed(2)+"</span>");
                    }
                    //$(".xtiein_total_reset", dom).prev().text(selectedNum+"件");
                    
                }
            });
            
        },
        selectAction: function(dom){
            
            var soundObj = (function(file){
                var types = {
                    "mp3": "audio/mpeg",
                    "mp4": "audio/mp4",
                    "ogg": "audio/ogg",
                    "wav": "audio/wav"
                };
                var html5audio=document.createElement('audio')
                if (html5audio.canPlayType){ //check support for HTML5 audio
                    for (var i=0; i<arguments.length; i++){
                        var sourceel=document.createElement('source');
                        sourceel.setAttribute('src', arguments[i]);
                        if (arguments[i].match(/\.(\w+)$/i)){
                            sourceel.setAttribute('type', types[RegExp.$1]);
                        }
                        html5audio.appendChild(sourceel);
                    }
                    html5audio.load();
                    html5audio.playclip=function(){
                        html5audio.pause();
                        html5audio.currentTime=0;
                        html5audio.play();
                    }
                    return html5audio;
                }else{
                        return {
                            playclip:function(){}
                        };
                }
            })('http://static.gtimg.com/icson/media/detail/money.mp3');
            
            //添加到购物车
            function addGoods(goodsItem){

                var src = goodsItem.find('img').attr('src');
                var goodsCopy = $('<div class="xtiein_animate" />').append($('<img />').attr('src', src)).appendTo('body');
                var fromLeft = goodsItem.offset().left;
                var formTop = goodsItem.offset().top - goodsCopy.outerHeight();
                var cartBtn = goodsItem.parents('.xtiein_bd').find('.xtiein_total .xbtn');
                goodsCopy.css({
                    position: 'absolute',
                    zIndex: 100,
                    left: fromLeft,
                    top: formTop                 
                });
                var toTop = cartBtn.offset().top - goodsCopy.outerHeight();
                var toleft = cartBtn.offset().left + (cartBtn.outerWidth() - goodsCopy.outerWidth())/2;
                goodsItem.data({
                    onAnimate: true,
                    goodsCopy: goodsCopy
                });
                goodsCopy.animate({
                    left: toleft,
                    top: toTop
                }, 600, function(){
                    toTop = cartBtn.offset().top;
                    goodsCopy.animate({
                       top: toTop,
                       height: 0 
                   }, 400, function(){
                        try{
                            soundObj.playclip();
                        }catch(e){
                            
                        }
                        goodsCopy.remove();
                        goodsItem.removeData('onAnimate').removeData('goodsCopy');
                        var tips = $('<span class="xtiein_total_tips">+1</span>').appendTo(cartBtn.parent());
                        tips.css({
                            top: cartBtn.position().top - tips.outerHeight(),
                            left: cartBtn.position().left + cartBtn.outerWidth()/2
                        }).animate({
                            top: cartBtn.position().top - tips.outerHeight() -10
                        },400, function(){
                            tips.remove();
                        });
                   });
                });
            }
            
            //从购物车移除
            function removeGoods(goodsItem){
                if (goodsItem.data('onAnimate')) {
                    var goodsCopy = goodsItem.data('goodsCopy');
                    goodsCopy.stop().fadeOut(function(){
                        goodsCopy.remove();
                    });
                }
            }
            
            $('.xtiein_goods_price .xico_chk', dom).bind('click', function(e){
                var goodsItem = $(this).closest("li").find(".xtiein_goods_img");
                if ($(this).hasClass('xico_chk_checked')) {
                    removeGoods(goodsItem);
                    $(this).removeClass('xico_chk_checked');
                } else {
                    addGoods(goodsItem);
                    $(this).addClass('xico_chk_checked');
                }
                
                var selectedNum = 0; // 已选总数
                var saveValue = 0; // 总节约
                var v = ~~$("#order_num").val();
                var realPrice = itemInfo.price;
                try{
                    var promote_price = itemInfo.mult_price.promote_price.price;
                    realPrice = (promote_price == "0.00")?realPrice:promote_price*100;
                }catch(e){}
                var totalValue = ((realPrice == "99999900"?0:realPrice) /100)*v; // 总价格
                var pids = [itemInfo.pid+"|"+v+"|0"]; // 保存已经选择的id 第1个为默认商品
                
                $("i.xico_chk_checked",dom).each(function(){
                    var temp = $(this).parents("li").find(".mod_price");
                    totalValue += parseFloat(temp.eq(0).text().substr(1),10);
                    saveValue += parseFloat(temp.eq(1).text().substr(1),10);
                    pids.push($(this).attr("data-pid")+"|1|"+itemInfo.pid);
                    selectedNum++;
                });
                var clearDom = $(".xtiein_total_reset", dom);
                if(selectedNum > 0){
                    clearDom.show();
                }else{
                    clearDom.hide();
                }
                // 更新第5列的价格
                if(selectedNum == 0){
                    $(".xtiein_total_price .xtiein_total_list_con",dom).html(dashou.getMainPrice());
                }else{
                    $(".xtiein_total_price .xtiein_total_list_con",dom).html('<span class="mod_price"><i>&yen;</i>'+totalValue.toFixed(2)+"</span>");
                }
                $(".xtiein_save_price",dom).html('<span class="mod_price"><i>&yen;</i>'+saveValue.toFixed(2)+"</span>");
                clearDom.prev().text(selectedNum+"件");
                
                // 更新加入购物车的链接地址
                $(".xtiein_col5 .xbtn_s",dom).attr("href","http://buy.yixun.com/cart.html?chid="+chid+"&ids="+pids.join(","));
                
            });
            
            //清除选择绑定事件
            $(".xtiein_total_reset",dom).bind("click", function(event){
                event.preventDefault();
                $(".xtiein_total_price .mod_price",dom).html(dashou.getMainPrice());
                $(".xtiein_save_price .mod_price",dom).html('<i>&yen;</i>0.00');
                $(this).prev().text("0件");
                $("i.xico_chk_checked",dom).removeClass("xico_chk_checked");
                $(this).hide();
                $(".xtiein_col5 .xbtn_s", dom).attr("href","http://buy.yixun.com/cart.html?chid="+chid+"&ids="+[itemInfo.pid+"|"+(~~$("#order_num").val())+"|0"].join(","));
            });
            
        },
        /**
         * @param {Object} _num 主商品数量 缺省为输入框中的数量 
         */
        getMainPrice: function(_num){
            var realPrice = itemInfo.price;
            try{
                var promote_price = itemInfo.mult_price.promote_price.price;
                realPrice = (promote_price == "0.00")?realPrice:promote_price*100;
            }catch(e){}
            return (itemInfo.bt_state==6||itemInfo.price==99999900)?'<span class="xtiein_price_none">暂无报价</span>':'<span class="mod_price"><i>&yen;</i>'+((realPrice/100)*(_num?_num:~~$("#order_num").val())).toFixed(2)+'</span>';
        }
       
    };

    $(document).bind('init', dashou.init);
});/*  |xGv00|088565dcb97cce219acbabf05e9f14f5 */