/*
 * name: page.detail.daogou.js
 * author: 兔兔每天不加班
 * usage:
**/
define("page.detail.daogou.11", function(require, exports, module) {
    var daogou={
        coreattr:'',
    	c3name:'',
		categoryid:0,
		currentitem:0,
		brand_name:'',
		item_type:'',
		price:'0',
		ytag : [19900,19901,19902,19903,19904,19905,19906,19907,19908,19909],
		chid:0,
		
		initTop:function(event, item) {
			 if(  !(config.lv & level.DAOGOU) )	//开关
				return ;
			  //item 是数据岛，里面有所有需要的数据，这里写你的逻辑
			  //容器id为sea_daogou_top和sea_daogou_bottom
			// alert(item);//decodeURIComponent(item.category_attr)
			  
			  //需要修改为从商详获取
			  daogou.categoryid=  item.category_id;//28314;// 
			  //判断品类是否在5个大类中，不是的话则直接返回
			  if(daogou.categoryid != "28325" && daogou.categoryid != "28319" && daogou.categoryid != "28314" && daogou.categoryid != "28324" && daogou.categoryid != "247517" )
			  {
				return;
			  }
			  daogou.currentitem=item.pid;
			  daogou.brand_name=item.brand_name;
			  daogou.item_type=item.item_type;
			  if( item.bt_state == 6 )
				daogou.price='暂无报价';
			  else if( '0.00' != item.mult_price.promote_price.price )
				daogou.price=item.mult_price.promote_price.price;
			  else
				daogou.price=item.price;
			  daogou.chid=chid;//渠道id
			
			//需要修改为从当前页面实时获取
			var attr= decodeURIComponent(item.category_attr); //'42515:13|904:1|40946:1|55:1825|35620:2'; 
			var　UrlQueryCoreAttrByAttr="http://daogou.yixun.com/d/QueryCoreAttrByAttr?categoryid="+daogou.categoryid+'&attr='+attr+'&currentitem='+daogou.currentitem;

			daogou.c3name=('' != item.c3name)?item.c3name:(('' != item.c2name)?item.c2name:item.c1name);
			
			daogou.loadDaogou(UrlQueryCoreAttrByAttr, daogou.cbQueryCoreAttrByAttr);			
		},
		cbQueryCoreAttrByAttr:function(data){
			if( !data || !data.strCoreAttr  )
						return ;
			//初始化底部
			$(document).bind('scrollInit', daogou.initBottom);	
			
			daogou.coreattr=data.strCoreAttr;
			
			var urlsearch="http://daogou.yixun.com/landing.html?categoryid="+daogou.categoryid+"&coreattr="+daogou.coreattr+"&itemid="+daogou.currentitem+"&type=1"+'&brand_name='+escape(daogou.brand_name+' ' + daogou.item_type)+'&price='+daogou.price+'&chid='+ daogou.chid;//更多的链接
			
			var arrCore=daogou.parseAttrTex(data.strCoreTxt);//解析文本
			//处理顶部的
			var html='<div class="xconfig">	\
						<h3 class="xconfig_hd">本'+daogou.c3name+'的核心参数</h3>	\
						<div class="xconfig_bd">	\
							<ul class="xconfig_list">';
							
			if(arrCore[0] && ('' != arrCore[0].attrName)	&& ( '' != arrCore[0].optionName) )		
				html +='<li>	\
							<span class="xconfig_key">'+arrCore[0].attrName+'</span> \
							<span class="xconfig_val">'+arrCore[0].optionName+'</span> \
						</li>';
				
			if( arrCore[1] && ('' != arrCore[1].attrName)	&& ( '' != arrCore[1].optionName) )			
				html +='<li>	\
							<span class="xconfig_key">'+arrCore[1].attrName+'</span> \
							<span class="xconfig_val">'+arrCore[1].optionName+'</span> \
						</li>';
			if( arrCore[2] && ('' != arrCore[2].attrName)	&& ( '' != arrCore[2].optionName) )			
				html +='<li>	\
							<span class="xconfig_key">'+arrCore[2].attrName+'</span> \
							<span class="xconfig_val">'+arrCore[2].optionName+'</span> \
						</li>';					
			html+='		</ul> \
					<a target="_blank" class="xconfig_lk" ytag="'+daogou.ytag[0]+'" href="'+urlsearch+'">查看相似的'+daogou.c3name+' &gt;</a> \
				</div> \
			</div>';
					
			$('#sea_daogou_top').append(html);
			$('#sea_daogou_wrap').addClass('xextend_config');
			$('#sea_daogou_top').show();
			
		},
		initBottom:function(event, item) {
			 if(  !(config.lv & level.DAOGOU) )	//开关
				return ;
			
			$('#sea_daogou_bottom').show();						
			var urlSearchListByCoreAttr=
			'http://daogou.yixun.com/d/QuerySearchListByCoreAttr?categoryid='+daogou.categoryid+'&coreattr='+daogou.coreattr+'&currentitem='+daogou.currentitem+'&type=1';
			daogou.loadDaogou(urlSearchListByCoreAttr,daogou.cbQuerySearchListByCoreAttr);
			var QueryPromotionByCategory='http://daogou.yixun.com/d/QueryPromotionByCategory?categoryid='+daogou.categoryid;
			daogou.loadDaogou(QueryPromotionByCategory,daogou.cbQueryPromotionByCategory);
			
		},
		loadDaogou:function(url,callback){
			$.ajax({
					type : "GET",
					url  : url,
					data: {
					},
					dataType : 'jsonp',
					/*report: {
						key: "errCode",
						url: url,
						formatUrl: true
					},*/
					success: callback?callback:function(){}
			});   
		},
		//解析组合的文本
		parseAttrTex:function(attrTxt){
			var arr_attrText=attrTxt.split('|');
			var arrCore=[];
			for(var i=0;i<arr_attrText.length;i++)
			{				
				var obj={};
				if( "" != arr_attrText[i] && arr_attrText[i].split('~').length > 7 )
				{
					var arr_temp=arr_attrText[i].split('~');
					obj.attrName=arr_temp[0];
					obj.attrTipsShow=arr_temp[1];
					obj.attrPicUrl=arr_temp[2];					
					obj.attrSummary='';
					obj.optionName='';
					obj.optionGroupName='';
					if( arr_temp[3].split(':') && arr_temp[3].split(':')[0] )					
						obj.attrSummary=arr_temp[3].split(':')[0];
					if( arr_temp[3].split(':') && arr_temp[3].split(':')[1] )		
					{
						if( arr_temp[3].split(':')[1].split('^G') && arr_temp[3].split(':')[1].split('^G')[0] )
							obj.optionName=arr_temp[3].split(':')[1].split('^G')[0]
						if( arr_temp[3].split(':')[1].split('^G') && arr_temp[3].split(':')[1].split('^G')[1] )
							obj.optionGroupName=arr_temp[3].split(':')[1].split('^G')[1];
					}//if					
					obj.optionTipsShow=arr_temp[4];
					obj.optionLoverate=arr_temp[5];
					obj.optionPicUrl=arr_temp[6];
					obj.optionSummary=arr_temp[7];		

					arrCore[i]=obj;						
				}		
			}//for
			
			return  arrCore;
		},
		/*回调 查询核心参数相同的*/
		cbQuerySearchListByCoreAttr:function(data){
			if( !data || data.errCode || !data.Same )
				return ;
			if( !data.Same || !data.Same[0]  )  /*|| ( daogou.coreattr != data.Same[0].attrs)*/
				return ;
			if( !data.Same[0].list || data.Same[0].list.length < 3 )
				return 
			//data.Same[0].list=data.Same[0].list.splice(0,3);
			
			//解析文本
			var urlsearch="http://daogou.yixun.com/landing.html?categoryid="+daogou.categoryid+"&coreattr="+daogou.coreattr+"&itemid="+daogou.currentitem+"&type=1"+'&brand_name='+escape(daogou.brand_name+' ' + daogou.item_type)+ '&price='+daogou.price+'&chid='+ daogou.chid;//更多的链接
			
			var arrCore=daogou.parseAttrTex(data.Same[0].attrsTxt);
						
			var html=' <div class="x_mod_box xsame1"> \
							<div class="x_mod_box_hd"> \
								<h3 class="x_mod_box_tit">核心参数相同的'+daogou.c3name+'有</h3> \
								<a target="_blank" ytag="'+daogou.ytag[2]+'" class="x_mod_box_more" href="'+urlsearch+'">更多相似'+daogou.c3name+'</a> \
							</div> \
							<div class="x_mod_box_bd clearfix"> \
								<div class="xsame1_col1"> \
									<div class="xsame1_param"> \
										<h4 class="xsame1_param_hd">本'+daogou.c3name+'核心参数</h4> \
										<ul class="xsame1_param_list">';
										
			//处理核心参数							
			var html_ul_attr='<ul class="xsame1_param_list">';
			
			for(var i=0;i<arrCore.length;i++)
			{
				html_ul_attr +='<li>';
				html_ul_attr +='		<p class="xsame1_param_tit">'+arrCore[i].attrName+'：<em>'+arrCore[i].optionName+'</em></p>';
				if( '' !=  arrCore[i].optionSummary )
					html_ul_attr +='		<p class="xsame1_param_desc">'+arrCore[i].optionSummary+'</p>';
					
				var loverate = parseInt(arrCore[i].optionLoverate);
				if(loverate > 0)
					html_ul_attr +='		<p clas="xsame1_param_favor"><span class="xsame1_param_favor_bar"><span 	style="width:'+arrCore[i].optionLoverate+'%;"></span></span><span class="xsame1_param_favor_percent">'+arrCore[i].optionLoverate+'%</span>用户喜欢</p>';
				html_ul_attr +='</li>';			
			}
			html += html_ul_attr;
			html += '		</ul>	\
						<a target="_blank"  ytag="'+daogou.ytag[1]+'"  class="mod_btn mod_btn_large mod_btn_bg2" href="'+urlsearch+'">更多相似商品&gt;</a> \
					</div> \
				</div> \
				<div class="xsame1_col2"> \
					<div class="xsame1_goods"> \
						<div class="xsame1_goods_inner"> \
							<div class="xsame1_goods_wrapper clearfix">  ';
			
			
			/**
			这里预处理处理商品 data.Same[0].list
			*/
			var logo=['评分较高','销量较高','性价比较高','限时特惠'];
			
			var SelectData=[];//选中的数据放这里
			var pingfenIndex=-1,sellNumberIndex=-1,priceIndex=-1;
			var pingfen=0,sellNumber=0,price=0;
			for( var i=0;i<data.Same[0].list.length;i++)
			{
				if( data.Same[0].list[i].pingfen > pingfen )
				{
					pingfen=data.Same[0].list[i].pingfen;
					pingfenIndex=i;
				}
			}
			SelectData.push(data.Same[0].list.splice(pingfenIndex,1)[0]);
			for( var i=0;i<data.Same[0].list.length;i++)
			{
				if( data.Same[0].list[i].sellNumber > sellNumber )
				{
					sellNumber=data.Same[0].list[i].sellNumber;
					sellNumberIndex=i;
				}
			}
			SelectData.push(data.Same[0].list.splice(sellNumberIndex,1)[0]);
			price=data.Same[0].list[0].price;//给默认
			priceIndex=0;
			for( var i=0;i<data.Same[0].list.length;i++)
			{
				if( data.Same[0].list[i].price < price )
				{
					price=data.Same[0].list[i].sellNumber;
					priceIndex=i;
				}
			}
			SelectData.push(data.Same[0].list.splice(priceIndex,1)[0]);
			for( var i=0;i<data.Same[0].list.length;i++)
			{//选一个price和yixunprice不一样的 
				if( data.Same[0].list[i].price < data.Same[0].list[i].yixunprice )
				{
					SelectData.push(data.Same[0].list[i]);
					break;
				}
			}
			if( SelectData.length < 4 )//上面没选中
			{
				if( data.Same[0].list.length > 0 ) //如果里面还有数据
				{
					SelectData.push(data.Same[0].list[0]);
					logo[3]='推荐商品';
				}				
			}
				
			var arr_html_good=[];
			var logoclass=['xico_score','xico_sale','xico_ratio','xico_time'];
			for( var i=0;i<SelectData.length;i++)
			{
				var itemlink='http://item.yixun.com/item-'+SelectData[i].itemID+'.html';
				var title=SelectData[i].title;				
				var picurl =SelectData[i].picUrl;
				if( !SelectData[i].picUrl.match(/http/) )
					picurl=daogou.getpic(SelectData[i].picUrl,'200');
				var price=	(parseInt(SelectData[i].price)/100).toFixed(2);
				
				arr_html_good[i]='';
				arr_html_good[i] +='<li>';
				arr_html_good[i] +='	<div class="mod_goods x_mod_goods">';
				arr_html_good[i] +='		<div class="mod_goods_img">';
				arr_html_good[i] +='			<a target="_blank"  ytag="'+daogou.ytag[3]+'" href="'+itemlink+'" title="'+title+'"><img alt="" src="'+picurl+'" title="'+title+'"></a>';
				arr_html_good[i] +='		</div>';
				arr_html_good[i] +='		<div class="mod_goods_info">';
				arr_html_good[i] +='			<p class="xsame1_goods_tag xsame1_goods_tag_score"><i class="xico '+logoclass[i]+'"></i>'+logo[i]+'</p>';
				arr_html_good[i] +='			<p class="mod_goods_tit"><a ytag="'+daogou.ytag[4]+'" target="_blank" title="'+title+'" href="'+itemlink+'">'+title+'</a></p>';
				arr_html_good[i] +='			<p class="mod_goods_price"><span class="mod_price c_tx1"><i>¥</i><span>'+price+'</span></span></p>';
				arr_html_good[i] +='		</div>';
				arr_html_good[i] +='	</div>';
				arr_html_good[i] +='</li>';
			}
			
			html +='<ul class="xsame1_goods_list">';
			html += arr_html_good[0];
			html += arr_html_good[1];
			html +='</ul>';
			html +='<ul class="xsame1_goods_list">';
			html += arr_html_good[2];
			if( SelectData.length ==3  )	//如果是只有3个就补一个空的
			{
				arr_html_good[3]='	<li> \
										<!-- 注：无货时多加了class xsame1_goods_none 控制样式--> \
										<div class="mod_goods x_mod_goods xsame1_goods_none"> \
											<div class="mod_goods_img"> \
												<!-- 注：对应的图片为：xclue_1.png 抽油烟机, 2 洗衣机, 3 电视机, 4 空调， 5 冰箱--> \
												<img alt="暂时没有商品哦" src="http://static.gtimg.com/icson/img/detail/v2/xclue_'+daogou.categoryid+'.png"> \
											</div> \
											<div class="mod_goods_info"> \
												暂时没有商品哦 \
											</div> \
										</div> \
									</li>';
			}
			
			html += arr_html_good[3];
			html +='</ul>';
				
			html += '		</div>	\
							</div> \
						</div> \
					</div>\
				</div> \
			</div> ';
			//<a href="#" class="xsame1_goods_prev xsame1_goods_prev_disabled"></a> \ <a href="#" class="xsame1_goods_next"></a> \ //翻页按钮先隐藏
			
			$('#sea_daogou_bottom').html(html+$('#sea_daogou_bottom').html());//搜索结果模块在上面			
		},
		/*回调 品类促销的的*/
		cbQueryPromotionByCategory:function(data){
			if( !data || data.errCode || data.length < 3 )
				return ;
			var urlpromotion="http://daogou.yixun.com/promotion.html?categoryid="+daogou.categoryid;//更多的链接
			
			var html='<div class="x_mod_box xpromogoods"> \
						<div class="x_mod_box_hd"> \
							<h3 class="x_mod_box_tit">促销进行中的'+daogou.c3name+'</h3>	\
							<a class="x_mod_box_more"  ytag="'+daogou.ytag[5]+'"  target="_blank" href="'+urlpromotion+'">更多促销'+daogou.c3name+'</a> \
						</div>	\
						<div class="x_mod_box_bd">	\
							<div class="x_mod_goods_list1">	\
								<ul class="clearfix">';
			var count=0;
			for( var i=0;i<data.length && i< 5 ;i++)
			{
				count++;
				data[i].picurl=daogou.getpic(data[i].productid,'200');
				data[i].downprice=((data[i].yixunprice*100-data[i].price*100)/100);
				data[i].itemlink='http://item.yixun.com/item-'+data[i].itemid+'.html';
				data[i].price=(parseInt(data[i].price)).toFixed(2);
				
				 html +='<li>';
				 html +='	<div class="mod_goods x_mod_goods">';
				 html +='		<div class="mod_goods_img">';
				 html +='			<a title="'+data[i].title+'" ytag="'+daogou.ytag[6]+'"  target="_blank" href="'+data[i].itemlink+'"><img alt="'+data[i].title+'" src="'+data[i].picurl+'"></a>';
				 html +='		</div>';
				 html +='		<div class="mod_goods_info">';
				 html +='			<p class="mod_goods_tit"><a ytag="'+daogou.ytag[7]+'" target="_blank" title="'+data[i].title+'" href="'+data[i].itemlink+'">'+data[i].title+'</a></p>';
				 html +='			<p class="mod_goods_price xpromogoods_price">';
				 html +='				<span class="xpromogoods_price_cur"><span class="mod_price c_tx1"><i>¥</i><span>'+data[i].price+'</span></span></span>';
				 html +='				<span class="xpromogoods_price_save">已降<span class="mod_price c_tx1"><i>¥</i><span>'+data[i].downprice+'</span></span></span>';
				 html +='			</p>';
				 html +='		</div>';
				 html +='	</div>';
				 html +='</li>';
			}//for
			for( var i=0;i< 5-count;i++)
			{
				html +=' <li>	\
							<!-- 注：无货时多加了class xpromogoods_none 控制样式-->\
							<div class="mod_goods x_mod_goods xpromogoods_none">  \
								<div class="mod_goods_img"> \
									<!-- 注：对应的图片为：xclue_1.png 抽油烟机, 2 洗衣机, 3 电视机, 4 空调， 5 冰箱--> \
									<img alt="暂时没有商品哦" src="http://static.gtimg.com/icson/img/detail/v2/xclue_'+daogou.categoryid+'.png"> \
								</div> \
								<div class="mod_goods_info"> \
									暂时没有商品哦 \
								</div> \
							</div> \
							</li> ';
							
			}//for
			
			 html +='</ul> \
					</div>	\
				</div> \
			</div>';
			
			$('#sea_daogou_bottom').append(html);
		},
		getpic:function(productID,size){	
			productID=productID.replace(/R\d*/,'');//二手商品  
			
			var arr_id=productID.split('-');
			var picurl='http://static.gtimg.com/icson/images/detail/v2/'+size+'.jpg';
			if(arr_id.length >2 )
				picurl='http://img2.icson.com/product/pic'+size+'/'+arr_id[0]+'/'+arr_id[1]+'/'+productID+'.jpg';			
			return picurl;
		},
		
	};	
    $(document).bind('init', daogou.initTop);
	
});/*  |xGv00|bfc5669ccab262313e9c6f9cac7a27de */