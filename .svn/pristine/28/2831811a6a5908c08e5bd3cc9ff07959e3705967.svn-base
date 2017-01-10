/*
 * name: page.detail.customer_service.js
 * author: xeonluo
 * usage:
**/
define("page.detail.customer_service.23", function(require, exports, module) {
    var handle,     // 需要暴露的句柄，可以是 单例、方法、类构造函数等
		CFG,		// 默认配置文件, 大写表示为静态变量，不可变
		_fn;		// 下划线代表私有方法
		

	// 全局配置文件，将一些钩子抽取配置出来
	CFG = {
		TRIGGER_ID : 'c_warranty' //售后服务的DOM容器
	};

	// 需要暴露的句柄，写在最前面，便于阅读维护
	handle = {
		
	};

	var _commSplits = [
		'<div class="mod_aider"><div class="i_hd"><h3>售后条款</h3></div><div class="i_bd">', // 售后条款模块开始
		{
			0:'<div class="mod_warranty id_deadline"><div class="mod_warranty_hd"><h3>保障时效</h3></div><div class="mod_warranty_bd"><p>所购产品如出现国家三包所规定的性能故障，经由厂商指定或特约维修点确认故障确实。售后保障时效如下：</p><div class="deadline"><div class="deadline_item"><div class="img img1"></div><p>7日内,您可以选择退货、换货或者免费保修。</p></div><div class="deadline_item"><div class="img img2"></div><p>第8日至第15日内,您可以选择换货或者免费保修。</p></div><div class="deadline_item noborder"><div class="img img3"></div><p>超过15日并在保修期内,您可以享受免费保修。</p></div></div></div></div>', // 保障时效
			2:'<div class="mod_warranty id_es"><div class="mod_warranty_hd"><h3>保障时效</h3></div><div class="mod_warranty_bd"><p>自商品售出之日起（以收货日期为准，具体保修日期以产品页面备注时间为准）。出现国家三包所规定的性能故障，经由厂商指定或特约维修点确认故障事实。</p><div class="deadline"><div class="deadline_item"><div class="img img1"></div><p>15日内，您可选择退货或免费保修（二手商品不支持换货政策）。</p></div><div class="deadline_item noborder">	<div class="img img3"></div><p>第15日后至保修期内，您可以选择免费保修。</p></div></div><p class="id_es_p"><strong>注意：</strong></p><p class="id_es_p">属于下列情况之一的，则不在易迅以及厂家维修站报修范围内：</p><ol class="id_es_tlist1 clearfix"><li>1.超过二手信息界面的备注保修日期的；</li><li>2.未按产品使用的要求使用、维护、保管等人为原因而造成损坏的；</li><li>3.私自拆动造成损坏的；</li><li>4.没有有效三包凭证或有效发票的；</li><li>5.擅自涂改三包凭证的；</li><li>6.三包凭证上的产品型号或编号与商品实物不相符合的；</li><li>7.非产品本身质量问题，如：兼容性问题，对于颜色，外观，形状不满意等。</li></ol></div></div>' // 保障时效
		},
		{
			0:'<div class="mod_warranty id_promise"><div class="mod_warranty_hd"><h3>易迅承诺</h3></div><div class="mod_warranty_bd"><dl class="promise"><dd class="item"><dl><dt class="promise_i1">正品行货</dt><dd>易迅网销售商品均由供应商或供销商提供，行货正品。</dd></dl></dd><dd class="item"><dl><dt class="promise_i2">修养保障</dt><dd>易迅网销售商品均可享受原厂保修或供应商提供的更换、维修和保养服务；厂家和供应商有责任履行相应责任及义务，为用户提供相应的保修、更换、维修和保养服务。</dd></dl></dd><dd class="item"><dl><dt class="promise_i3">权益维护</dt><dd>当用户向厂家或供应商争取相关权益及应有服务时，易迅网会在用户需要的第一时间提供有关的联系及协调服务，协助用户维护自己应有的权益。</dd></dl></dd><dd class="item"><dl><dt class="promise_i4">正规发票</dt><dd>易迅网会为所有客户开具发票作为客户的质保凭证，请顾客自行保留原件作为后续质保之需。</dd></dl></dd></dl></div></div>', // 易迅承诺
			1:'<div class="mod_warranty id_promise mod_warranty_wg_promise"><div class="mod_warranty_hd"><h3>易迅承诺</h3></div><div class="mod_warranty_bd"><dl class="promise"><dd class="item"><dl><dt class="promise_i1">行货正品</dt><dd>易迅网销售商品均由供应商提供，行货正品。</dd></dl></dd><dd class="item"><dl><dt class="promise_i2">退换货保障</dt><dd>严格按照国家三包政策以及本《退换货政策》，对所售商品履行换货和退货的义务。由于各品类商品的特性不同，退换货政策的实施存在差异，另请参照具体品类的退换货细则。细则部分与本退换货总则不一致的，以退换货细则为准。</dd></dl></dd><dd class="item"><dl><dt class="promise_i3">权益维护</dt><dd>当用户向厂家或商户争取相关权益及应有服务有纠纷肯争议的时候，易迅网会介入提供有关的联系及协调服务，协助用户维护自己应有的权益。</dd></dl></dd><dd class="item"><dl><dt class="promise_i4">运费政策</dt><dd>对购物15天内商品质量问题或是商品描述运费免费，但非易迅上门取件的，需由客户先行支付运费（易迅网暂不支持到付），运费（不包含包装费,保价费等）将以积分的形式返还，额度以实际运费为准，最高不超过15元。购物15天以外且在保修期内，易迅与客户各自承担单向运费。</dd></dl></dd></dl></div></div>',
			2:'<div class="mod_warranty id_es"><div class="mod_warranty_hd"><h3>商品来源</h3></div><div class="mod_warranty_bd"><ul class="id_es_tlist2 clearfix"><li><strong class="id_es_tlist2_tit"><span>客户误购</span></strong><span class="id_es_tlist2_des">客户误购，未拆封，但外包装可能有所损坏；或仅拆封，未实际使用，产品完好；</span></li><li><strong class="id_es_tlist2_tit"><span>仓储或物流破损</span></strong><span class="id_es_tlist2_des">仓储或物流等原因导致产品外包装有损坏，商品功能完好；</span></li><li><strong class="id_es_tlist2_tit"><span>主件维修或换新</span></strong><span class="id_es_tlist2_des">主件被维修过，故障已解决，可正常使用；或主件换新（如手机机头、笔记本电脑硬件换新等）；</span></li><li><strong class="id_es_tlist2_tit"><span>附件换新</span></strong><span class="id_es_tlist2_des">附件已换新，主产品未做换新，（如耳机、充电器换新，而手机机头未换新）；</span></li><li><strong class="id_es_tlist2_tit"><span>厂家检测无故障</span> </strong><span class="id_es_tlist2_des">经厂家或维修站鉴定产品无质量问题，被使用过，但各项功能完好；</span></li><li><strong class="id_es_tlist2_tit"><span>试用机</span></strong><span class="id_es_tlist2_des">用于前台照片展示拍照使用，仅拆封，未实际使用。</span></li></ul><p class="c_tx1">注：二手商品均为“非全新商品”，请您仔细阅读二手商品详情页面中“产品介绍”模块下面的具体说明，对商品要求较高者请您慎重购买！</p><p><strong>采购商购买（如果您有意向大批购买，请联系）</strong></p><ul class="id_es_tlist3 clearfix"><li><i class="id_es_tlist3_icon1"></i><a href="mailto:dongzhao@yixun.com">dongzhao@yixun.com</a></li><li><i class="id_es_tlist3_icon2"></i>021-61831108-60096</li><li><i class="id_es_tlist3_icon3"></i>赵经理</li></ul></div></div>' // 商品来源
		},
		{
			0:'<div class="mod_warranty id_flow"><div class="mod_warranty_hd"><h3>处理流程</h3></div><div class="mod_warranty_bd"><img class="img2" src="http://st.icson.com/static_v1/img/icson/process_flow.png" width="873" height="285"><img class="img1" src="http://st.icson.com/static_v1/img/icson/process_flow_985.png" width="643" height="285"></div></div>', 
			1:'<div class="mod_warranty id_flow"><div class="mod_warranty_hd"><h3>处理流程</h3></div><div class="mod_warranty_bd"><img class="img2" src="http://static.gtimg.com/icson/img/detail/v2/warranty_wg1.jpg" width="873" height="355"><img class="img1" src="http://static.gtimg.com/icson/img/detail/v2/warranty_wg2.jpg" width="680" height="350"></div></div>',
			2:'<div class="mod_warranty id_es"><div class="mod_warranty_hd"><h3>买前必读</h3></div><div class="mod_warranty_bd"><h4 class="id_es_tit">二手品解析</h4><ol><li>1. 易迅网的二手均为正品行货，绝不销售假货、水货、请放心选购；</li><li>2. 易迅网售卖的二手商品可能配件不齐全，或与易迅网正常销售的商品附件有差异，具体情况请参照二手商品信息页面说明；</li><li>3. 易迅网二手商品页面图片所引用为易迅原新商品图片，非拍摄的实物图片，请您仔细阅读二手商品信息页面中的具体说明，并以您收到的实物为准。</li></ol><h4 class="id_es_tit">二手活动</h4><ol><li>1.易迅网所售二手商品均不参与“能效补贴”、“家电下乡”、“手机运营商合约活动”及“评价获取积分”“贵就赔”“价格保护”等其他易迅活动；</li><li>2.所售二手商品易迅网会为所有客户开具正常发票作为客户的质保凭证，请您妥善保留原件作为后续质保之需，选择退货的客户必须提供对应产品的发票，并保证产品无人为损坏，需要收回原包装及所有附件，如包装或附件丢失或损坏，则不符合易迅网的退货条款，易迅网将无法提供退货服务；</li><li>3.由于产品的不同，各厂商服务政策的差异，在实施细则上，如保修操作、售后服务、技术支持等方面为您提供服务可能会有所差异，请以本说明为准。</li></ol></div></div><div class="mod_warranty id_es"><div class="mod_warranty_hd"><h3>二手商品常见问题</h3></div><div class="mod_warranty_bd"><ol><li><p><strong>1.我购买的二手物品（手机、平板电脑和笔记本电脑等）质量有保障吗？</strong></p><p>答：在易迅，只有通过层层筛选和检测的物品才上架销售。我们出售的每一件二手物品都经过我们质检团队专业的检测，确保用户购买的物品所有功能都能正常使用。</p></li><li><p><strong>2.购买后物品发生质量问题怎么办？</strong></p><p>答：购买后，商品发现质量问题，我们提供15天退货、保修期内的保修服务。用户可致电我们的客服热线400-828-1878或直接通过服务中心售后页面申请售后人员处理。</p></li><li><p><strong>3.易迅15天退货服务是无理由退货吗？由此产生的运费由谁来承担？</strong></p><p>答：二手商品只支持购买物品后15天内因产品质量问题方可申请退货服务，由此产生的运费由我们来承担。</p></li><li><p><strong>4.如何申请保修期内维修服务？ 由此产生的运费由谁来承担？</strong></p><p>答：对于物品本身的质量问题我们提供购保修期内的质量保障。由于使用不当、意外等原因导致的故障不在质保范围内。用户可致电我们的客服热线400-828-1878或直接通过售后页面申请售后人员处理。申请确认后请按提示将物品寄给我们，我们收到物品后会根据申请内容提供相应的售后服务，由此产生的运费由我们承担。</p></li></ol></div></div>' // 买前必读、二手商品常见问题
		}, // 处理流程，不一样
		{
			0:'<div class="mod_warranty id_way"><div class="mod_warranty_hd"><h3>办理方式</h3></div><div class="mod_warranty_bd"><div class="item way1"><div class="way_hd"><h4>易迅网全国联保，网上报修</h4></div><div class="way_bd"><p>您只需进入到<span>“<a target="_blank" href="http://base.yixun.com/index.html">我的易迅</a>”-“<a target="_blank" href="http://base.yixun.com/myrepair.html">报修/退换货</a>”</span>中直接提交报修/退换货申请即可，我们的工作人员会在24小时内审核确认（节假日审核时间可能会有延迟）做后续处理。</p></div></div><div class="item way2"><div class="way_hd"><h4>易迅网售后服务电话</h4></div><div class="way_bd"><p>在产品保修期内，如果您有售后问题需要咨询或者办理，欢迎您拨打我们的客服热线:</p><p><span>400-828-1878</span>（周一至周日9：00-18：00）</p></div></div></div></div>',
			1:'<div class="mod_warranty id_way mod_warranty_wg"><div class="mod_warranty_hd"><h3>办理方式</h3></div><div class="mod_warranty_bd"><div class="item way2"><div class="way_hd"><h4>易迅网售后服务电话</h4></div><div class="way_bd"><p>在产品保修期内，如果您有售后问题需要咨询或者办理，欢迎您拨打我们的客服热线: </p><p><span>400-828-1878</span>（周一至周日9：00-18：00）</p></div></div></div></div>',
			2:'<div class="mod_warranty id_way"><div class="mod_warranty_hd"><h3>办理方式</h3></div><div class="mod_warranty_bd"><div class="item way1"><div class="way_hd"><h4>易迅网全国联保，网上报修</h4></div><div class="way_bd"><p>您只需进入到<span>“<a target="_blank" href="http://base.yixun.com/index.html">服务中心</a>”-“<a target="_blank" href="http://base.yixun.com/myrepair.html">售后服务</a>”</span>中直接提交报修/退换货申请即可，我们的工作人员会在24小时内审核确认（节假日审核时间可能会有延迟）做后续处理。</p></div></div><div class="item way2"><div class="way_hd"><h4>易迅网售后服务电话</h4></div><div class="way_bd"><p>在产品保修期内，如果您有售后问题需要咨询或者办理，欢迎您拨打我们的客服热线: </p><p><strong>400-828-1878</strong>（周一至周日9：00-18：00）</p></div></div></div></div>'
		}, // 办理方式，不一样
		"</div></div>", // 售后条款模块结束
	];

	var _commHtmls = {},
		_commHtml = function(_pid, _type){
			if(_commHtmls[_pid]) return _commHtmls[_pid];
			_type = _type ? (_type - 0) : 0;

			var html = [];
			$.each(_commSplits, function(i, splt){
				if(typeof splt != 'string'){
					html.push(splt[_type] ? splt[_type] : splt[0]);
				} else {
					html.push(splt);
				}
			});

			return _commHtmls[_pid] = html.join('');
		};
	
	var _obj = $("#" + CFG.TRIGGER_ID);

	var cbAfterSaleContent = function(o, _pid, _type){
		var data = o.data;
		if(!data || !data.manufacturer || !data.product || !data.manufacturer.data || !data.manufacturer.data.AccessoryItems){
			return;
		}

		var manufacturerNode = data.manufacturer.data;
		var productNode = typeof data.product == 'string' ? null : data.product.data;
	
		var link = function(url){
			if(!url){
				return "";
			}
	
			return "<a target='_blank' href='"+url+"'>"+url+"</a>";
		};
	
		var items = {};
		if(manufacturerNode.AccessoryItems.length > 0){
			for(var i = 0; i < manufacturerNode.AccessoryItems.length; i ++){
				var row = manufacturerNode.AccessoryItems[i];
				if(typeof items[row.ProblemType] === "undefined"){
					items[row.ProblemType] = {
						title	: row.ProblemTypeDesc,
						items	: [row.AccessorySysNoDesc]
					};
	
				}else{
					items[row.ProblemType].items.push(row.AccessorySysNoDesc);
				}
			}
		}
	
		var warranty = "<div class='mod_aider'><div class='i_hd'><h3>保修条款</h3></div><div class='i_bd'><div class='xwarranty'><div class='xwarranty_row'>", postsale = "";

		if(!productNode){
			warranty += '<p>'+data.product+'</p>';
		} else {
			if(productNode.WarrantyDesc){
				warranty += "<p>"+productNode.WarrantyDesc+"</p>";
			}
		
			if(productNode.WarrantyNote){
				warranty += "<p>保修期备注：" + productNode.WarrantyNote + "</p>";
			}
		}

		if(manufacturerNode.AccessoryItems.length > 0){
			warranty += "<p>保修说明：申请退换货及保修时，请根据您申请类型，准备以下附件材料一并寄回</p></div>";
			warranty += "<div class='xwarranty_row'><table class='xwarranty_table'><tbody>";

			for(var j in items){
				warranty += "<tr><td width='120'>"+items[j].title+"</td><td>"+items[j].items.join("，")+"</td></tr>";
			}

			warranty += "</tbody></table></div>";
		} else {
			warranty += "</div>";
		}
	
		var Manufacturer = manufacturerNode.Manufacturer;
		Manufacturer = Manufacturer[0] || {};
		var warrantyManu = [];
		if(Manufacturer.ContactPhone){
			warrantyManu.push('<tr><td width="120">联系方式</td><td>'+Manufacturer.ContactPhone+'</td></tr>');
		}

		if(Manufacturer.WebSiteURL){
			warrantyManu.push('<tr><td width="120">官方网站</td><td>'+link(Manufacturer.WebSiteURL)+'</td></tr>');
		}

		if(Manufacturer.StoreURL){
			warrantyManu.push('<tr><td width="120">门店分布</td><td>'+link(Manufacturer.StoreURL)+'</td></tr>');
		}

		if(Manufacturer.PolicyTypeDesc){
			warrantyManu.push('<tr><td width="120">售后维修方式</td><td>'+Manufacturer.PolicyTypeDesc+'</td></tr>');
		}

		if(warrantyManu.length > 0){
			warranty += "<div class='xwarranty_row'><table class='xwarranty_table'><tbody>";
			warranty += warrantyManu.join("");
			warranty += "</tbody></table></div>";
		}

		warranty += "</div></div></div>";
	
		var RMADescription = "";
		if(manufacturerNode.RMADescription1 || manufacturerNode.RMADescription2){
			RMADescription = "<div class='mod_aider'><div class='i_hd'><h3>售后说明</h3></div><div class='i_bd'><div class='xaftersale_desc'><p>" + manufacturerNode.RMADescription1 + "</p><p>" + manufacturerNode.RMADescription2 + '</p></div></div></div>';
		}

		_obj.html(warranty + RMADescription + _commHtml(_pid, _type));
	};

	// private collection 
	// 私有方法集，可以任意命名
	_fn = {
		init: function(event, item){
			if (config.lv & level.SHOUHOU) {
				var _type = /[a-z]/i.test(item.p_char_id) ? 2 : (item.product_sale_model == 5 ? 1 : 0);
				if(_obj.data("js_loaded")){
					return;
				}
				_obj.html(_commHtml(pid, _type));
				if(_type == 2){ // 二手商品没下面那么多事情
					_obj.data("js_loaded", true);
					return;
				}

				if(item.c3ids && item.brand_no){
					var dir = Math.floor(item.c3ids / 100);
					$.ajax({
						url	: "http://service.yixun.com/json.php?mod=public&act=getwarranty&pid=" + pid + "&c3id=" + item.c3ids +"&mfid=" +item.brand_no,
						//url	: "http://st.icson.com/help/policy/0/46_34.js",
						dataType	: "jsonp",
						jsonp: "callback",
						success	: function(data){
							_obj.data("js_loaded", true);
							cbAfterSaleContent(data, pid, _type);
						},

						error	: function(data){
							//404其实无法处理
							_obj.data("js_loaded", false);
						}
					});
				}
			}
		}
	};
	
	$(document).bind('tab_customer_service', _fn.init);

});/*  |xGv00|0f01eaa8bafd035b20c52bbbf94beb30 */