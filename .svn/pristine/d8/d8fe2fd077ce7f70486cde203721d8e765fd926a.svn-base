/*
 * name: page.detail.tab_list.js
 * author: xeonluo
 * usage:
 **/
define("page.detail.tab_list.53", function(require, exports, module) {
  var getAd = function() {
      var isWide = (window.screen.availWidth >= 1280) ? 1 : 0,
        wsid = G.util.cookie.get("wsid");
      window.renderAd = function(o) {
        if (o && o.ret == 0 && o.data != '') {
          $('#sea_content_promo').empty().html(o.data);
          $('#sea_content_promo').show();
        } else {
          $('#sea_content_promo').hide();
        }
      };
      var _url = 'http://d.item.yixun.com/p/item/getad?param=' + wsid + ',' + itemInfo.pid + ',' + itemInfo.c1ids + ',' + itemInfo.c2ids + ',' + itemInfo.c3ids + ',' + itemInfo.brand_no + '&isWide=' + isWide;
      if(config.lv & level.NODE_AD){
        _url = 'http://d.item.yixun.com/n/ad?param=' + wsid + ',' + itemInfo.pid + ',' + itemInfo.c1ids + ',' + itemInfo.c2ids + ',' + itemInfo.c3ids + ',' + itemInfo.brand_no + '&isWide=' + isWide; 
      }
      $.ajax({
        type: "GET",
        url: _url,
        report: "ret",
        cache: true,
        dataType: 'jsonp',
        jsonpCallback: 'renderAd'
      });

    };
    var getNewParamHtml = function(){
        var escapeHtml = function(text) {
            return text.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/"/g, "&quot;").replace(/'/g, "&#039;");
        };
        var by = function(name, minor) {//对象排序，第一个参数表示对象的key，第二个参数表示第一个参数相等时的处理
            return function(o, p) {
                var a, b;
                if(o && p && typeof o === 'object' && typeof p === 'object') {
                    a = o[name];
                    b = p[name];
                    if(a === b) {
                        return typeof minor === 'function' ? minor(o, p) : 0;
                    }
                    if( typeof a === typeof b) {
                        return a < b ? -1 : 1;
                    }
                    return typeof a < typeof b ? -1 : 1;
                }
            }
        };
        
        var result = itemInfo.nca_detail_list;// 规格参数
        if(result && result.length > 0) {
            var arr = result.sort(by('group_order', by('group_id', by('order')))), html = '<table cellpadding="0" cellspacing="0" class="specification"><tbody>', title_arr = {},temp_gid = null;
            for(var i = 0, j = arr.length; i < j; i++) {
                
                if(temp_gid != arr[i].group_id){
                    var _name = arr[i].group_name ? escapeHtml(arr[i].group_name) : '规格参数';
                    html += '<tr><td colspan="2" class="title">' + escapeHtml(_name) + '</td></tr>';
                    temp_gid = arr[i].group_id;
                }
        
                html += '<tr><td class="name">' + escapeHtml(arr[i].attr_name) + '</td>';
                html += '<td class="desc">' + escapeHtml(arr[i].option) + '</td></tr>'
            }
            html += '</tbody></table>';
            return html;
        }
        return "";
    };
  var initDetailTab = function(pid) {
      $.each(['introduce', 'comment', 'parameters', 'warranty', 'information'], function(k, v) {
        $('#t_' + v).attr('n', v);
        $('#t_' + v).click(function() {
          $('#introduction .x_mod_tab_hd li').filter('.current').removeClass('current');
          $("#introduction .x_mod_tab_hd li").filter('#t_' + $(this).attr('n')).addClass('current');

          $('#introduction .x_mod_tab_bd').children().filter(':visible').hide();
          var jc = $('#c_' + $(this).attr('n'));          

          if ($(this).attr('n') == 'warranty') {
            $(document).trigger('tab_customer_service', [itemInfo]);
          }
          if ($(this).attr('n') == 'information') {
            $(document).trigger('tab_information', config.information_url);
          }          

          jc.show();
          /**
           * 如果用户处于“产品介绍”“规格参数”“包装清单”“售后服务”这几个tab时，当他的鼠标滚动至tab底部，页面显示出评论模块
           * 用户点击tab，必须切换到顶部给用户看
           * by addisonxue
           * start
           */
          if ($(this).attr('n') != 'comment') {
            /**
             * 动态创建J_reviews块作为评论的暂时存放
             */
            if ($('#J_reviews').length == 0) {
              $('#statement').after(['<div id="J_reviews" class="mod_aider">', '<div class="hd"><div class="mod_aider_tit">商品评论</div></div>', '<div class="bd">', '</div>', '</div>'].join(''));
            }
            $('#J_reviews div.bd').append($('#c_comment'));
            $('#J_reviews').show();
          } else {
            $('#intro-main_tab').append($('#c_comment'));
            $('#J_reviews').hide();
          }
          if ($('#introduction').hasClass('xoverview_fixed')) {
            $('#introduction')[0].scrollIntoView(true);
            $('#introduction').removeClass('xoverview_fixed');
          }
          /**
           * end
           */
          if (jc.data('contentLoaded') != 1) {
            jc.data('contentLoaded', 1);
            var pname = $(this).attr('n');
            if (pname == 'comment') {
              if (config.lv & level.REVIEW) {
                G.app.itemDetail.review.init();
              }
              jc.data('contentLoaded', 1);
            } else {

              if(pname !== 'parameters'){
                jc.html('<div id="sea_content_promo" class="intro-main-gg"><span class="loading_58_58">正在加载中</span></div><div id="detail_info"></div>');
              }
              
              function html_decode(str) {
                var s = "";
                if (str.length == 0) return "";
                s = str.replace(/&amp;/g, "&");
                s = s.replace(/&lt;/g, "<");
                s = s.replace(/&gt;/g, ">");
                s = s.replace(/&nbsp;/g, " ");
                s = s.replace(/&quot;/g, "\"");
                return s;
              }
              window['CallBackDetail_' + itemInfo.open_item_id] = window['CallBackDetail_' + itemInfo.skuID] = function(_data) {
                jc.data('contentLoaded', 1);
                if (_data[8] && _data[8].desc && ~~curtime > ~~_data[8].startTime && ~~curtime < ~~_data[8].endTime) {
                  config.information_url = _data[8].desc;
                  $('#introduction').addClass('x_mod_tab1');
                  $('#t_warranty').removeClass('x_mod_tab_nav_last');
                  $('#t_information').addClass('x_mod_tab_nav_last').show();

                }
                function html_decode(str) {
                  var s = "";
                  if (str.length == 0) return "";
                  s = str.replace(/&amp;/g, "&");
                  s = s.replace(/&lt;/g, "<");
                  s = s.replace(/&gt;/g, ">");
                  s = s.replace(/&nbsp;/g, " ");
                  s = s.replace(/&quot;/g, "\"");
                  return s;
                }
                var _html = '';
                if(_data.type && _data.type == 1){
                  _html = _data['0'] || '暂无相关内容';
                }else{
                  var _temp_html = '';
                  if(/^[\d\-]+$/.test(itemInfo.p_char_id)){
                      if(_data['111'] && _data['111'].desc && (_data['111'].endTime == 0 || curtime > _data['111'].startTime && curtime < _data['111'].endTime)){ //经销授权
                        _temp_html += '<div class="mod_detail_info id_accredit"><div class="mod_hd"><div class="mod_hd_tit"><span class="tit">经销授权</span>官方授权，品质保障</div><i class="line"></i></div> <div class="mod_bd"><center>  <img class="img" src="'+_data[111].desc+'" /> </center></div></div>';
                      }
                      if(_data['110'] && _data['110'].desc && (_data['110'].endTime == 0 || curtime > _data['110'].startTime && curtime < _data['110'].endTime)){ //强烈推荐
                        _temp_html += '<div class="mod_detail_info id_recommend"><div class="mod_hd"><div class="mod_hd_tit"><span class="tit">强烈推荐</span>货比三家，还选易迅</div><i class="line"></i></div><div class="mod_bd"><p class="i_bd">'+_data[110].desc+'</p><span class="start_quot"></span><span class="end_quot"></span></div></div>';
                      }
                      if(_data['113'] && _data['113'].desc && (_data['113'].endTime == 0 || curtime > _data['113'].startTime && curtime < _data['113'].endTime)){ //商品介绍
                        _temp_html += '<div class="mod_detail_info id_intro"> <div class="mod_hd"><div class="mod_hd_tit"><span class="tit">商品简介</span>简单明了地从这里开始了解产品</div><i class="line"></i></div> <div class="mod_bd">'+_data[113].desc+'</div></div>';
                      }
                      if(_data['114'] && _data['114'].desc && (_data['114'].endTime == 0 || curtime > _data['114'].startTime && curtime < _data['114'].endTime)){ //商品特性
                        _temp_html += '<div class="mod_detail_info id_features"> <div class="mod_hd"><div class="mod_hd_tit"><span class="tit">商品特性</span>产品描述仅供参考，具体请查看规格参数</div><i class="line"></i></div>  <div class="mod_bd">'+_data[114].desc+'</div></div>';
                      }
                      if(_data['115'] && _data['115'].desc && (_data['115'].endTime == 0 || curtime > _data['115'].startTime && curtime < _data['115'].endTime)){ //精美图片
                        _temp_html += '<div class="mod_detail_info id_pic">  <div class="mod_hd"><div class="mod_hd_tit"><span class="tit">精美图片</span></div><i class="line"></i></div>  <div class="mod_bd">'+_data[115].desc+'</div></div>';
                      }
                      if(_data['116'] && _data['116'].desc && (_data['116'].endTime == 0 || curtime > _data['116'].startTime && curtime < _data['116'].endTime)){ //相关说明
                        _temp_html += '<div id="id_link" class="mod_detail_info id_link"> <div class="mod_hd"><div class="mod_hd_tit"><span class="tit">相关说明</span></div><i class="line"></i></div><div class="mod_bd">'+_data[116].desc+'</div></div>';
                      }
                      if(_data['109'] && _data['109'].desc && (_data['109'].endTime == 0 || curtime > _data['109'].startTime && curtime < _data['109'].endTime)){ //退货原因
                        _temp_html += '<div class="mod_detail_info id_pic">  <div class="mod_hd"><div class="mod_hd_tit"><span class="tit">退货原因</span></div><i class="line"></i></div>  <div class="mod_bd">'+_data[109].desc+'</div></div>';
                      }
                      if(_data['112'] && _data['112'].desc && (_data['112'].endTime == 0 || curtime > _data['112'].startTime && curtime < _data['112'].endTime)){ //视频地址
                        _temp_html += '<div class="mod_detail_info id_video"> <div class="mod_hd"><div class="mod_hd_tit"><span class="tit">视频地址</span></div><i class="line"></i></div> <div class="mod_bd"> <a href="'+_data[112].desc+'" target="_blank">'+_data[112].desc+'</a> </div></div>';
                      }
                  }
                  _html = _temp_html || _data['100'] || _data['0'] || '暂无相关内容';

                }
                _html = _html.replace(new RegExp('document.write', 'g'), '$("#detail_info").prepend');
                if (~_html.indexOf('&lt;table')) {
                  _html = html_decode(_html);
                }
                _html = _html.replace(/易讯/gmi, "易迅");
                _html = _html.replace(/51buy\.com/gmi, "yixun.com");
                _html = _html.replace(/<img([^<]+) src=/gmi, "<img $1 src='http://static.gtimg.com/icson/img/common/blank.png' data-oxlazy-img=");
                $('#detail_info').html(_html);
                
                
                var parameters_html = '';
                if (_data['3']) {
                  parameters_html += '<table cellpadding="0" cellspacing="0" class="specification"><tbody><tr><td colspan="2" class="title">包装清单</td></tr>' + '<tr><td class="name">包装清单</td><td class="desc">' + _data['3'] + '</td></tr></tbody></table>';
                }
                if (_data['1']) { //规格参数
                  parameters_html += (_data['1']);
                }else if( (config.lv & level.USE_NCA_DETAIL) && itemInfo.nca_detail_list && itemInfo.nca_detail_list.length){ // 加个开关 如果没数据也走老流程
                    // _data['3']的放在前面
                   parameters_html += getNewParamHtml();
                } else if (config.lv & level.DETAIL_NCA) {
                    
                  parameters_html += '<div id="nca_param_wrap"></div>';
                  if (itemInfo.category_attr && itemInfo.category_id) {
                    window.renderATT = function(tdata) {
                      if (tdata.ret == 0) {
                        $('#nca_param_wrap').html(tdata.data);
                      } else {
                        if (_data['3']) {
                          //do nothing
                        } else {
                          $('#nca_param_wrap').html('暂无相关内容');
                        }
                      }
                    };
                    var _url = 'http://d.item.yixun.com/p/item/nca?att=' + itemInfo.category_attr + '&cid=' + itemInfo.category_id;
                    if(config.lv & level.NODE_NCA){
                      _url = 'http://d.item.yixun.com/n/nca?att=' + itemInfo.category_attr + '&cid=' + itemInfo.category_id; 
                    }
                    $.ajax({
                      type: "GET",
                      url: _url,
                      report: "ret",
                      dataType: 'jsonp',
                      cache: true,
                      jsonpCallback: 'renderATT'
                    });
                  } else {
                    $('#nca_param_wrap').html('暂无相关内容');
                  }

                }
                parameters_html = parameters_html || '暂无相关内容';
                $('#c_parameters').data('contentLoaded', 1);
                $('#c_parameters').html(parameters_html.replace(/^\s+/, ''));

                var warranty_html = '';
                if (_data['2']) {
                  warranty_html += '<div class="mod_aider"><div class="i_hd"><div class="mod_aider_tit">保修条款</div></div><div class="i_bd"><p>' + _data['2'] + '</p></div></div>';
                }

                warranty_html = warranty_html + '<div class="mod_aider">' + '<div class="i_hd">' + '<div class="mod_aider_tit">售后条款</div>' + '</div>' + '<div class="i_bd">' + '<div class="mod_warranty id_deadline">' + '<div class="mod_warranty_hd"><div class="mod_aider_tit">保障时效</div></div>' + '<div class="mod_warranty_bd">' + '<p>所购产品如出现国家三包所规定的性能故障，经由厂商指定或特约维修点确认故障确实。售后保障时效如下：</p>' + '<div class="deadline">' + '<div class="deadline_item"><div class="img img1"></div><p>7日内,您可以选择退货、换货或者免费保修。</p></div>' + '<div class="deadline_item"><div class="img img2"></div><p>第8日至第15日内,您可以选择换货或者免费保修。</p></div>' + '<div class="deadline_item noborder"><div class="img img3"></div><p>超过15日并在保修期内,您可以享受免费保修。</p></div>' + '</div>' + '</div>' + '</div>' + '<div class="mod_warranty id_promise">' + '<div class="mod_warranty_hd"><div class="mod_aider_tit">易迅承诺</div></div>' + '<div class="mod_warranty_bd">' + '<dl class="promise">' + '<dd class="item"><dl><dt class="promise_i1">正品行货</dt><dd>易迅网销售商品均由供应商或供销商提供，行货正品。</dd></dl>' + '<dd class="item"><dl><dt class="promise_i2">修养保障</dt><dd>易迅网销售商品均可享受原厂保修或供应商提供的更换、维修和保养服务；厂家和供应商有责任履行相应责任及义务，为用户提供相应的保修、更换、维修和保养服务。</dd></dl>' + '<dd class="item"><dl><dt class="promise_i3">权益维护</dt><dd>当用户向厂家或供应商争取相关权益及应有服务时，易迅网会在用户需要的第一时间提供有关的联系及协调服务，协助用户维护自己应有的权益。</dd></dl>' + '<dd class="item"><dl><dt class="promise_i4">正规发票</dt><dd>易迅网会为所有客户开具发票作为客户的质保凭证，请顾客自行保留原件作为后续质保之需。</dd></dl>' + '</dl>' + '</div>' + '</div>' + '<div class="mod_warranty id_flow">' + '<div class="mod_warranty_hd"><div class="mod_aider_tit">处理流程</div></div>' + '<div class="mod_warranty_bd">' + '<img class="img2" src="http://st.icson.com/static_v1/img/icson/process_flow.png" width="873" height="285" />' + '<img class="img1" src="http://st.icson.com/static_v1/img/icson/process_flow_985.png" width="643" height="285" />' + '</div>' + '</div>' + '<div class="mod_warranty id_way">' + '<div class="mod_warranty_hd"><div class="mod_aider_tit">办理方式</div></div>' + '<div class="mod_warranty_bd">' + '<div class="item way1"><div class="way_hd"><h4>易迅网全国联保，网上报修</h4></div><div class="way_bd"><p>您只需进入到<span>“<a target="_blank" href="http://base.yixun.com/index.html">我的易迅</a>”-“<a target="_blank" href="http://base.yixun.com/myrepair.html">报修/退换货</a>”</span>中直接提交报修/退换货申请即可，我们的工作人员会在24小时内审核确认（节假日审核时间可能会有延迟）做后续处理。</p></div></div>' + '<div class="item way2"><div class="way_hd"><h4>易迅网售后服务电话</h4></div><div class="way_bd"><p>在产品保修期内，如果您有售后问题需要咨询或者办理，欢迎您拨打我们的客服热线: </p><p><span>上海站：400-828-1878</span>（周一至周六9：00-18：00）</p><p><span>深圳站：400-828-6699</span>（周一至周六9：00-18：00）</p><p><span>北京站：400-828-0055</span>（周一至周六9：00-18：00）</p></div></div>' + '</div>' + '</div>' + '</div>' + '</div>';

                $('#c_warranty').data('contentLoaded', 1);
                $('#c_warranty').html(warranty_html.replace(/^\s+/, ''));
                
                window['CallBackDetail_' + itemInfo.open_item_id] = window['CallBackDetail_' + itemInfo.skuID] = null;
                if(window.detail){
                    detail = null;
                }

              }
              
              if (config.lv & level.CDN_DETAIL) {
                  var det_url = config.detailUrl;
                  if((config.lv & level.OPEN_PIC_DET) && itemInfo.detail_cdn_name){
                      det_url = "http://item.wgimg.com/"+itemInfo.detail_cdn_name;
                  }
                  $.getScript(det_url);
              }
              
              getAd();
            }
          }
        });
      });
    };
  var init = function(event, item) {
      var review_wrap = $('#sea_review_wrap');
      if (review_wrap.size() > 0) {
        var content_wrap = review_wrap.find('p'),
          content = content_wrap.text();
        if (content.length > 88) {
          content_wrap.attr('title', content);
          content = content.substr(0, 85) + '...';
          content_wrap.text(content);
        }
        review_wrap.show();
      }

      G.app.itemDetail = G.app.itemDetail || {};

      initDetailTab(item.pid);
      var self = G.app.itemDetail;

      $('#introduction .x_mod_tab_nav li a:first').click(); //显示第一个tab
      var reviewInit = false;
      var _onScroll = function(event) { //初始化评论部分延迟
          var reserve = 100,
            bottomPos = $(window).scrollTop() + $(window).height(),
            $review = '';
          $review = $('#statement');

          var reviewTop = $review.offset().top;


          if (!reviewInit && (bottomPos + reserve >= reviewTop)) {
            reviewInit = true;
            self.review.loadAsking();
            $(document).trigger('scrollInit', [item]);
          }


          if (reviewInit) {
            $(window).unbind('scroll', _onScroll);
          }
        };
      $(window).bind('scroll', _onScroll);

      if (config.lv & level.REVIEW) {
        self.review.getReviewProperty(function() {
          if (location.hash.indexOf('#review_box') == 0 || location.hash.indexOf('#introduction') == 0) {
            $('#t_comment').click();
          }
        });
      }
      $('#sea_review_box').click(function() {
        $('#t_comment').click();
      });


      /**
       * 添加tab标签随屏幕滚动
       * by addisonxue
       * start
       */
      var isIE6 = false;
      //isIE6以后优化的时候可以单独弄个全局变量
      if ($.browser.msie && ($.browser.version == "6.0") && !$.support.style) {
        isIE6 = true;
      }
      var introduction = $('.grid_m_inner');
      var tablist = $('#introduction');

      $(window).bind("scroll resize", function() {
        //计算top，left，bottom时候，因为一些页面内容填充是动态的，会导致reflow，所以domReady计算这个取不到准确值，得从新计算
        var introductionTop = introduction.offset().top;
        var introductionBottom = introductionTop + introduction[0].offsetHeight;
        var winHeight = $(window).height();
        var scrollTop = $(window).scrollTop();
        if (scrollTop > introductionTop && scrollTop <= introductionBottom) {
          tablist.addClass('xoverview_fixed');
        } else if (scrollTop > introductionBottom) {
          tablist.removeClass('xoverview_fixed');
        } else if (scrollTop < introductionTop) {
          tablist.removeClass('xoverview_fixed');
        }
        /**
         * 延时评论的加载，当滚动条滚动到适当位置的时候才加载
         */
        var _jc = $('#c_comment');
        _jc.show();

        if (scrollTop + winHeight >= $('#J_reviews').offset().top) {
          if (_jc.data('contentLoaded') != 1) {
            if (config.lv & level.REVIEW) {
              G.app.itemDetail.review.init();
            }
            _jc.data('contentLoaded', 1);
          }
        }

      });
    };
  $(document).bind('init', init);
});
/*  |xGv00|60c016d497ddd4552fed7c187e602791 */