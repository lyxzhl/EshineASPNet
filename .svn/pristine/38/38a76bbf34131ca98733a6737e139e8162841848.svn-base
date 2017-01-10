/*
 * name: page.detail.cart_btn.js
 * author: leoqqlv
 * usage:
**/
define("page.detail.cart_btn.35", function(require, exports, module) {
   
    function initCartBtn(event, item){
        if (item.bt_state > 0) {
            $('#sea_float_buy').addClass('xbtn_disabled');
        } else {
            if(config.lv & level.USE_NEW_CART){// 是否全量购物车浮层 17位
                
                $("body>.xcontent").delegate("a:contains('加入购物车')[id!='sea_float_buy']", "click", function(e){
                    var tag = 0;
                    $.each($('#sea_sale_attr_wrap .xoption_list'), function(index, item){
                        var _item = $(item);
                        _item.removeClass('xoption_list_error');
                        if(_item.find('.xoption_selected').size() == 0){
                            tag = 1;
                            setTimeout(function(){
                                _item.addClass('xoption_list_error');
                            }, 300);                            
                        }
                    });
                    if(tag > 0){
                        $(document).scrollTop(0);                        
                        e.preventDefault();
                        return false;
                    }
                    var href = $(this).attr("href");
                    if($(this).closest(".xpackage").length > 0){
                        var pkgpids = [itemInfo.pid]; // 取套餐里面的商品ids
                        $(".xtiein_goods_info a", $(".xpackage .x_mod_stab_con:visible")).each(function(){
                            var shref = $(this).attr("href");
                            pkgpids.push(shref.substring(shref.indexOf("item-")+5, shref.indexOf(".html")));
                        });
                        href += "&pkgpids="+pkgpids.join("@");
                    }
                    Cart.add(href, this);
                    e.preventDefault();
                    return false;
                });
                    
                $("#sea_float_buy").bind("click", function(e){
                    var tag = 0;
                    $.each($('#sea_sale_attr_wrap .xoption_list'), function(index, item){
                        var _item = $(item);
                        _item.removeClass('xoption_list_error');
                        if(_item.find('.xoption_selected').size() == 0){
                            tag = 1;
                            setTimeout(function(){
                                _item.addClass('xoption_list_error');
                            }, 300);
                        }
                    });
                    if(tag > 0){
                        $(document).scrollTop(0);                        
                        e.preventDefault();                        
                        return false;
                    }
                    var href = $("#btnAddCart").attr("href");
                    if(!href && $("#sea_buy_wrap .xbtn_buy").length > 0){
                        window.location.href = $("#sea_buy_wrap .xbtn_buy").attr("href");
                    }else{
                        
                        var temp_str = href;
                        if(temp_str.indexOf("?") > -1){
                            temp_str = temp_str.substr(temp_str.indexOf("?")+1);
                        }
                        var temp_arr = temp_str.split("&");
                        var temp_param = {};
                        for(var i = 0; i < temp_arr.length;i++){
                            var temp = temp_arr[i].split("=");
                            temp_param[temp[0]] = temp[1];
                        }
                        var oScroll = function(){
                            var stop = $(window).scrollTop();
                            var introduction = $('.grid_m_inner');
                            var introductionTop = introduction.offset().top;
                            var introductionBottom = introductionTop + introduction.height();
                            if (stop < introductionTop || stop > introductionBottom){
                                Cart.close();
                                $("#sea_float_buy").removeAttr("data-loading");
                            }
                        }
                        temp_param.onLoading = function(obj){
                            $(obj).css({"position":"fixed","top":"42px"});
                            $(window).bind('scroll', oScroll);
                        };
                        temp_param.onComplete = function(obj){
                            $(obj).css({"position":"fixed","top":"42px"});
                        };
                        
                        temp_param.onClose = function(obj){
                            $(window).unbind('scroll', oScroll);
                        };
                        
                        Cart.add(temp_param, this);
                    }
                });
                
                if($("#sea_buy_wrap .xbtn_buy").length > 0){
                    $("#sea_buy_wrap").delegate(".xbtn_buy", "click", function(e){
                        var tag = 0;
                        $.each($('#sea_sale_attr_wrap .xoption_list'), function(index, item){
                            var _item = $(item);
                            _item.removeClass('xoption_list_error');
                            if(_item.find('.xoption_selected').size() == 0){
                                tag = 1;
                                setTimeout(function(){
                                    _item.addClass('xoption_list_error');
                                }, 300);                            
                            }
                        });
                        if(tag > 0){
                            $(document).scrollTop(0);                        
                            e.preventDefault();
                            return false;
                        }
                    });
                }
                
            }else{
                $(document).delegate('#sea_float_buy', 'click', function() {
                    $('#sea_buy_wrap a').click();
                });
            }
        }
        
        var tempFun =  function(){
            // 做一次上报
            var ec = itemInfo.bt_state;
            // cart.js里面有依赖 若后台返回正常 但header.js或global.js未加载成功 
            if(ec == 0 && typeof (G.header) == "undefined"){
                ec = 2100015;
                $(".grid_m .xbase_row5 .xtips").append("<p>参考编号（"+ec+"）</p>");
            }
            var time = (new Date()).getTime() - timeStat[0].getTime(); // 这里记录下加载完成时间也不防 比填0好
            //(new Image()).src = "http://c.isdspeed.qq.com/code.cgi?domain=item.yixun.com&cgi="+encodeURIComponent("http://item.yixun.com/shoppingcart/localerror")+"&type="+(ec==0?1:2)+"&code="+ec+"&time="+time+"&rate=1";
            
            // added 2014-01-21 增加referer统计
            var referer = document.referrer;
            var r_code = 0;
            if(referer){
                referer = referer.replace(/^.*\/\//, '').replace(/\/.*/, '');
                if(referer.indexOf("yixun.com") > -1){
                    r_code = 0;
                }else if(referer.indexOf("baidu.com") > -1){
                    r_code = 1;
                }else if(referer.indexOf("google.com") > -1){
                    r_code = 2;
                }else{
                    r_code = 3;
                }
            }else{
                r_code = 500;
            }
            var tempSrc = [
                "http://c.isdspeed.qq.com/code.cgi?domain=item.yixun.com&key=cgi,type,code,time,rate",
                "&1_1="+encodeURIComponent("http://item.yixun.com/shoppingcart/localerror"),
                "&1_2="+(ec==0?1:2),
                "&1_3="+ec,
                "&1_4="+time,
                "&1_5=1",
                "&2_1="+encodeURIComponent("http://item.yixun.com/referrer"),
                "&2_2="+(r_code==0?1:2),
                "&2_3="+r_code,
                "&2_4="+time,
                "&2_5=1"
            ];
            (new Image()).src = tempSrc.join("");
            
            $(window).unbind("load", tempFun);
        }          
        $(window).bind("load", tempFun);
                
        // 添加库存预警
        if(parseInt(itemInfo.stock_num,10) > 0 && parseInt(itemInfo.stock_num,10) <= 10){
            $(".xnumber .xbase_col2").append('<span class="xnumber_quota">库存仅剩<strong>'+itemInfo.stock_num+'</strong>件</span>');
        }
        if(parseInt(itemInfo.buy_min, 10) > parseInt(itemInfo.stock_num,10)&& parseInt(itemInfo.stock_num,10) > 0){
            $(".xarea_desc").text("库存不足");
        }
        // 添加7天消法标 0表示支持7填退货 1表示不支持
        if(parseInt(itemInfo.not_support_seven,10) == 0){
            $(".xcontent_row2 .xbase_row5 .xtips").prepend('<p class="xtips_seven"><i class="xico xico_seven"></i>此商品支持七天无理由退货。</p>');
        } else {
            $(".xcontent_row2 .xbase_row5 .xtips").prepend('<p class="xtips_seven"><i class="xico xico_seven"></i>此商品不支持七天无理由退货。</p>');
        }
        //信用付
        var prid = G.util.cookie.get("loc").split("_");
        var prid_city = parseInt(prid[3],10);
        var prid_prov = parseInt(prid[2],10);
        // 广东全省、江苏、天津、上海这几个地方。aking和dvd确认下
        if(parseInt(itemInfo.bt_state,10)==0 &&( prid_prov == 440000 || prid_prov == 320000 || prid_city == 310100 || prid_city == 120100)){
            $("#xyf01").show();
            $("#xyf02").show();
        }else{
            $("#xyf01").remove();
            $("#xyf02").remove();
        }

    }
    
    $(document).bind('init', initCartBtn);
});/*  |xGv00|63727a8ce2849d45909ae53ffb1a6fd0 */