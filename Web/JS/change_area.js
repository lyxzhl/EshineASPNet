/**
 * "选择地区控件
 */
G.app.change_area = {
	location	: {
		_loc	: false,
		_p_data : false,
		_isSetCookie : true,
		_hasSubProvinceName : false,
		_mapDistrict2Division: {
			"420":"7",
			"556":"6","789":"6","201":"6","403":"6",
			"2490":"5","299":"5","2130":"5","2160":"5","2878":"5",
			"158":"4","2652":"4","3077":"4","693":"4","2996":"4",
			"1144":"3","1454":"3","1718":"3","1323":"3",
			"2621":"2",
			"3225":"1","1591":"1","1":"1","131":"1","2858":"1","814":"1",
			"2329":"1","2490":"1","1900":"1","1830":"1","999":"1","2016":"1"
		},
		getLocInfo	: function(district){
			if(!G.util.area) return false;

			var self = G.app.change_area.location;
			if(self._loc === false){
				self._loc = {};
				if(self._hasSubProvinceName == false){ // 省份name截取处理
					$.each(G.util.area, function(pid, pinfo){
						pinfo.n = pinfo.n.replace(/市|省|自治区/, "");
						if(pinfo.n.length >= 4){
							pinfo.n = pinfo.n.substr(0,2);
						}
					});
					self._hasSubProvinceName = true
				}
				
				$.each(G.util.area, function(pid, pinfo){
					$.each(pinfo.l, function(cid, cinfo){
						$.each(cinfo.l, function(did, dname){
							// [名称,省份ID,省份名称,城市ID,城市名称]
							self._loc[did] = [
								dname,
								pid,
								pinfo.n,
								cid,
								cinfo.n,
								did
							];
						});
					});
				});
			}
            
			var final_id=district;
			var pid =  G.header.common.getCookie("prid").split("_")[1];
			
			var loc = self._loc[final_id];
			
			if(!loc){
				final_id = pid;	
			}
			
			$.each(G.logic.constants.serviceAreas,function(index, item){
			     if(index==final_id){
			       final_id=item[2];
			     }
			 });
			
			loc = self._loc[final_id];
			//确实没有找到，默认至上海市徐汇区
			if(!loc) {
			  loc=self._loc[2626];
			}
			
			return {
				name	: loc[0],
				provinceId	: loc[1],
				provinceName	: loc[2],
				cityId	: loc[3],
				cityName	: loc[4],
				did : loc[5],
				sid : self.getSid(loc[1])
			};
		},

		getSid : function(pid){
			var sid = 1;
			$.each(G.logic.constants.serviceAreas, function(idx, mapInfo){
				if(idx == pid){
					sid = mapInfo[1];
					return false;
				}
			});
			return sid;
		},
		
		getPidBySid : function(sid){ //根据站点id找到对应的省id数组
			var arr = [];
			$.each(G.logic.constants.serviceAreas, function(idx, mapInfo){
				if(mapInfo[1] == sid){
					arr.push(idx);
				}
			});
			return arr;
		},
		
		getDefaultDidByPid : function(pid){ //根据省id找到默认显示的区id
			var ret;
			$.each(G.logic.constants.serviceAreas, function(idx, mapInfo){
				if(idx == pid){
					ret = mapInfo[2];
					return false;
				}
			});
			return ret;
		},
		
		getDivisionId: function(did) {
			var self = G.app.change_area.location,
				locInfo = self.getLocInfo(did),
				map = self._mapDistrict2Division;
			
			if (!locInfo) return 2;//成熟区A
			return map[locInfo.cityId] || map[locInfo.provinceId] || 2;
		},

		//同步cookie到yixun或51buy
		synLoc : function(loc,prid,wsid,areasInfo,callback) {
			var loc =loc || G.header.common.getCookie("loc");
			var prid =prid ||  G.header.common.getCookie("prid");
			var wsid =wsid || G.header.common.getCookie("wsid");
			var areasInfo =areasInfo || G.header.common.getCookie("areasInfo");
			
			if(!loc || !prid || !wsid || !areasInfo){
				// 三个变量任一是空
				return;	
			}
			
			var domain = /51buy\.com/.test(location.host) ? '.yixun.com' : '.51buy.com';
			
			var src = "http://st"+domain+"/static_v1/htm/locproxy.html?loc="+loc+"&prid="+prid+"&wsid="+wsid +"&areasInfo="+areasInfo;
			
			var iframe = document.createElement("iframe");
				iframe.src = src;
				if (iframe.attachEvent){    
					iframe.attachEvent("onload", function(){        
						  $.isFunction(callback) && callback(); 
					});
				} else {    
					iframe.onload = function(){        
						 $.isFunction(callback) && callback();
					};
				}
				iframe.style.display= "none";
				
				document.body.appendChild(iframe);
		},
		
		locSelection : function(district,func){
			var p_obj=$("#p_box"),
				self = G.app.change_area.location;
			if(self._p_data === false){
				self._p_data = '';
				$.each(G.logic.constants.allowedWhInfo, function(sid, sitename) {
					var p_temp_data = '';
					$.each(G.logic.constants.serviceAreasSeq, function(){
						var prInfo = G.logic.constants.serviceAreas[this];
						if(prInfo[1] == sid){
							p_temp_data = p_temp_data+'<li><a v="'+this+'" title="'+prInfo[0]+'" href="javascript:void(0);">'+prInfo[0]+'</a></li>';
						}
					});
					
					var p_html=[
					  '<div class="storage_item">',
					  '<p>' + sitename + '仓服务' + '：</p>',
					  '<ul>',
				      ''+p_temp_data+'',
					  '</ul>',
					  '</div>'
					].join("");  
					
					self._p_data =self._p_data + p_html;
				});
				self._p_data += '<p class="tip">易迅商品暂时只支持配送至中国大陆地区</p>';
			}
			p_obj.html(self._p_data);
			
			
			p_obj.find("a").unbind("click").bind('click', function() {
				 var pid = $(this).attr('v');
				 $('#p_wrap .area').html($(this).html());
				 $("#area_result_box .area_item").removeClass("area_item_current");
				 $('#c_wrap').addClass("area_item_current");
				 $('#p_box').hide();
				 $('#c_box').show();
				 
				 $('#c_wrap .area').html('请选择市');
				 $('#d_wrap .area').html('请选择区县');
				 $("#d_box").html('');
				 
			     getcity_data(pid);
				 return false;
			});
			
			function getcity_data(pid){
				var c_obj=$("#c_box");
				var c_temp_data = '';
				if(G.util.area[pid]){
					var arr = [];
					$.each(G.util.area[pid].l, function(cid, cinfo){
						cinfo.cid = cid
						arr.push({cid:cid, cinfo:cinfo});
					});
					arr.sort(function(a, b){
						if (a.cinfo.n.length == b.cinfo.n.length) {
							if(a.cid == b.cid) {
								return 0; //noway
							} else {
								return a.cid > b.cid ? 1 : -1
							}
						} else {
							return a.cinfo.n.length >b.cinfo.n.length ? 1 : -1;
						}
					});
					$.each(arr, function(idx, item){
						var icSupported = false; // 支持货到付款
						$.each(item.cinfo.l, function(did, dinfo) {
							if (G.util.areaIcsonDelivery && G.util.areaIcsonDelivery[did]) {
								icSupported = true;
								return false;
							}
						});
						var item_name = item.cinfo.n+(icSupported ? '<span class="special">*</span>' : ''),
							is_icson_delivery = icSupported ? 1 : 0,
							class_name = (item.cinfo.n.length + is_icson_delivery) > 4 ? ' class="staus01"' : '';
						c_temp_data=c_temp_data+'<a v="'+item.cinfo.cid+'" title="'+item.cinfo.n+'" href="javascript:void(0);"' + class_name + '>'+ item_name +'</a>';
					});
				}
				
				var c_html=[
				  '<p class="tip_special">带<span class="special">&nbsp;*&nbsp;</span>地区支持货到付款</p>',
				  '<p class="city_all">',
			      ''+c_temp_data+'',
			      '</p>'
				].join("");  
				
				c_obj.html(c_html);
				
				//是直辖市则直接跳转到区级地区（除北京市）
				if(pid == 2621 || pid == 158 || pid == 2858){
					var self = c_obj.find("a").eq(0);
					var cid = self.attr('v');
					$('#c_box').hide();
				 	$('#d_box').show();
					$('#c_wrap .area').html(self.html());
					$("#area_box .area_item").removeClass("area_item_current");
					$('#d_wrap').addClass("area_item_current");
					getdistrict_data(pid,cid);
				}
				c_obj.find("a").unbind("click").bind('click', function() {
				  var cid = $(this).attr('v');
				  $('#c_wrap .area').html($(this).html());
				  $("#area_result_box .area_item").removeClass("area_item_current");
				  $('#d_wrap').addClass("area_item_current");
				  $('#c_box').hide();
				  $('#d_box').show();
				 
				  getdistrict_data(pid,cid);
				  return false;
				});
			}
			
			function getdistrict_data(pid,cid){
				var d_obj=$("#d_box");
				var d_temp_data = '';
				if(G.util.area[pid] && G.util.area[pid].l[cid]){
					var r = $.extend({}, G.util.area[pid].l[cid].l);
					var l = [];
					$.each(r, function(k, v){
						l.push({
							id	: k,
							name	: v
						});
					});
					var long_name = [],
						short_name = [];
					$.each(l, function(idx, info){
						if(info.name.length > 4){
							long_name.push(info);
						}else{
							short_name.push(info);	
						}
					});
					long_name.sort(function(a,b){
						return a.name.toString().localeCompare(b.name.toString());
					});
					
					
					short_name.sort(function(a, b){
						if (a.name.length == b.name.length) {
							return 0;
						} else {
							return a.name.length >b.name.length ? 1 : -1;
						}
					});

					l = $.merge(short_name, long_name);
					$.each(l, function(kk, dInfo){
						var d_name = dInfo.name+(G.util.areaIcsonDelivery && G.util.areaIcsonDelivery[dInfo.id] ? ' <span class="special">*</span>' : ''),
							is_icson_delivery = G.util.areaIcsonDelivery && G.util.areaIcsonDelivery[dInfo.id] ? 1 : 0,
							class_name = (dInfo.name.length + is_icson_delivery) > 4 ? ' class="staus01"' : '';
						d_temp_data=d_temp_data+'<a v="'+dInfo.id+'" title="'+dInfo.name+'" href="javascript:void(0);"' + class_name + '>'+ d_name +'</a>';
					});
					l = null;
				}
				
				var d_html=[
				  '<p class="tip_special">带<span class="special">&nbsp;*&nbsp;</span>地区支持货到付款</p>',
				  '<p class="city_all">',
			      ''+d_temp_data+'',
			      '</p>'
				].join("");  
				
				d_obj.html(d_html);
				
				d_obj.find("a").unbind("click").bind('click', function() {
					var did=$(this).attr('v'),
						d_name = $(this).html();
					$("#area_result_box .area_item").removeClass("area_item_current");
					$("#area_show_result > div").eq(0).removeClass("area_item_current");
					$("#area_box").hide();
					
					
					$('#d_wrap .area').html(d_name);
					var _areaDate = $('#p_wrap .area').html() + ' ' + $('#c_wrap .area').html() + ' ' + $('#d_wrap .area').html();
					$('#area_name').attr("did", did).html(_areaDate);
				    var locInfo = G.app.change_area.location.getLocInfo(did);
					
					
					if(G.app.change_area.location._isSetCookie){
						//G.header.common.loc.setLocByIcsonCode(0,pid,did);
						var domain = /51buy\.com/.test(location.host) ? '51buy.com' : 'yixun.com';
						
						$.ajax({
							url : 'http://base.'+domain+'/w/loc/getlocbyic?icsonDistrictId='+did+'&icsonProvinceId='+pid+'&noSetCookie=0',
							dataType    : 'jsonp',
							cache   : false,
							success: function(msg){
								if (msg && msg.iRet == 0) {
									// TODO 成功，cookie已经设置上。疑问：此处是否需要重新获取locInfo？
									//G.app.change_area.location.synLoc();

									// 抽查，校验数据准确性
									if (!msg.data || !msg.data.icsonDistrictId) return false;

									var d = msg.data;
									var divisionId = G.app.change_area.location.getDivisionId(did);
									var loc = d.zoneid+'_'+d.wsid+'_'+d.gbProvinceId+'_'+d.gbCityId+'_'+d.gbDistrictId;
									var prid = d.icsonDistrictId+'_'+d.icsonProvinceId;
									var wsid = d.wsid;
									var areasInfo = "S000" + divisionId+ '_' +d.wsid;
									
									G.app.change_area.location.synLoc(loc,prid,wsid,areasInfo,function() {
										$.isFunction(func) && func(d.icsonDistrictId, d.icsonProvinceId, d.wsid);
									});
								} else {
									// TODO 错误处理，需要再考虑
									//alert('convert failure');
									G.header.common.addCookie('prid', did+'_'+pid, '/', 12 * 30 * 24 * 3600, '.'+domain);
									G.header.common.addCookie('wsid', locInfo.sid, '/', 12 * 30 * 24 * 3600, '.'+domain);
									// areasInfo 在刷新后自动维护，loc因数据不足，处理成容错值

									var divisionId = G.app.change_area.location.getDivisionId(did);
									var loc = divisionId+'_'+locInfo.sid+'_0_0_0';
									var areasInfo = "S000" + divisionId+ '_' +locInfo.sid;
									
									G.header.common.addCookie('loc', loc, '/', 12 * 30 * 24 * 3600, '.'+domain);
									G.app.change_area.location.synLoc(loc,did+'_'+pid,locInfo.sid,areasInfo,function() {
										$.isFunction(func) && func(did, pid, locInfo.sid);
									});
								}
							},
							error: function() {
								// 接口网络错误，或HTTP错误
								location.reload();
							}
						}); 

					} else{
						// 不setcookie，那就没有同步的必要
						//G.app.change_area.location.synLoc();
						$.isFunction(func) && func(did, pid, locInfo.sid);	
					}
				});
			}	
		},

		getLocName	: function(district,callback){
			var self = G.app.change_area.location;
			var dInfo = "";
			var domain = /51buy\.com/.test(location.host) ? '51buy.com' : 'yixun.com';
			var loc = G.util.cookie.get("loc");
			var prid = G.util.cookie.get("prid") || "0_0_0";
			var isDefaultLoc = prid.split("_")[2] || 0;
			
			//检查是否有loc，且当前loc为非默认值
			if(!loc || isDefaultLoc){
				
				$.ajax({
					url : 'http://base.'+domain+'/w/loc/getloc',
					dataType    : 'jsonp',
					cache   : false,
					success: function(msg){
						if(!msg.iRet){
							dInfo = self.getLocInfo(msg.data.icsonDistrictId);
						}else{
							dInfo = self.getLocInfo((G.util.cookie.get("prid").split("_"))[0]);
						}
						
						if(dInfo === false) return '';
            			
						$.isFunction(callback)&&callback(dInfo);
					}
				}); 
			}else{
				if(district){
					dInfo = self.getLocInfo(district);	
				}else{
					dInfo = self.getLocInfo((G.util.cookie.get("prid").split("_"))[0]);		
				}
				
				if(dInfo === false) return '';
				
            	$.isFunction(callback)&&callback(dInfo);
			}
		}
	},
	
	//选择切换地址
    start_changeArea:function(loc_id, func, isSetCookie, initFn){
		
		//地域组件灰度逻辑
	//	if(LOCGRAY && G.header.common){
			G.header.common.loc.initChangeArea(loc_id, func, isSetCookie, initFn);
			return;	
	//	}
		
		var self = this,
		    area_box = $("#area_box");
		
		// 未传参、或传参不为false，都认为要设cookie
		isSetCookie = (isSetCookie === false) ? false : true;
		
		G.app.change_area.location._isSetCookie = isSetCookie;
		
		
		this.location.getLocName(loc_id,function(loc_data_name){
			html = 
				'<div class="area_item_list" id="area_result_box">\
					<div class="area_item" id="p_wrap">\
					<p><span class="area">'+ loc_data_name.provinceName + '</span><span class="arrow"></span></p>\
					</div>\
					<div class="area_item" id="c_wrap">\
					<p><span class="area">'+ loc_data_name.cityName + '</span><span class="arrow"></span></p>\
					</div>\
					<div class="area_item" id="d_wrap">\
					<p><span class="area">'+ loc_data_name.name + '</span><span class="arrow"></span></p>\
					</div></div>\
					<div id="p_box" class="area_list storage_list"></div>\
					<div class="area_list" id="c_box"></div>\
				<div class="area_list" id="d_box"></div>\
				';
		area_box.html(html);
		var loc_data=G.app.change_area.location.locSelection(0,func);
		//显示地区全名
		$('#area_name').attr('v', loc_id).html(loc_data_name.provinceName + ' ' + loc_data_name.cityName + ' ' + loc_data_name.name);
		$('#area_result_box').show();
		//开始打开默认地区
		$("#p_box a[v='"+loc_data_name.provinceId+"']").click();
		$("#c_box a[v='"+loc_data_name.cityId+"']").click();
		
        $('#area_show_result').unbind('click').bind('click', function() {
          var result_div = $(this).find('>div').eq(0),
          	  loc_did = $("#area_name").attr("did") || loc_id;
          	  self.location.getLocName(loc_did,function(loc_data_name){
				  if(!result_div.hasClass('area_item_current')) {
					result_div.addClass('area_item_current');
					$('.bd_act').show();
					//开始打开默认地区
					$("#p_box a[v='"+loc_data_name.provinceId+"']").click();
					$("#c_box a[v='"+loc_data_name.cityId+"']").click();
				  } else {
					result_div.removeClass('area_item_current');
					$('.bd_act').hide();
				  }
				  return false;
			  })
        });
        $('#area_result_box').find('div').each(function(i) {
          $(this).unbind("click").bind('click', function() {
            $('#area_result_box').find('div').removeClass('area_item_current');
            $(this).addClass('area_item_current');
            $('#area_box .area_list').hide();
            $('#area_box .area_list').eq(i).show();
			return false;
          });
        });
        $(document).unbind("click").bind('click', function(event) {
          var _target = $(event.target);
          if(!_target.parents('#select_area_act').length){
            $('.hd_act').find('>div').eq(0).removeClass('area_item_current');
            $('#area_box').hide();
          }
        });
	})}
};/*  |xGv00|0c5d8d6b38caf39321216cb305233ed8 */