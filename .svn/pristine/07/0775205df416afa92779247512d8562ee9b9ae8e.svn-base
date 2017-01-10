/*
 * name: page.detail.load_promo.js
 * author: xeonluo
 * usage:
 **/
define("page.detail.load_promo.14", function(require, exports, module) {
  var Grade = {
    wrapTpl: ['<dl class="xbase_item xpromo">', '<dt class="xbase_col1">优惠</dt>', '<dd class="xbase_col2">', '<ul class="xpromo_list">', '</ul>', '</dd>', '</dl>'].join(''),
    tpl: ['<li class="sea_pop_parent">', '<div class="x_mod_promo">', '<span class="x_mod_promo_tag"><%= title %><i></i></span>', '<span class="x_mod_promo_con">', '<span class="sea_pop_a"><% if(tag>0) {%><a target="_blank" href="<%= url %>"><%}%><%= name %><% if(tag>0) {%></a><%}%></span>', '</span>', '</div>', '<div class="mod_hint mod_hint_weak x_mod_hint3 sea_pop_box">', '<div class="mod_hint_inner">', '<%== desc %>', '<% if(tag>0) {%><p><a ytag="22151" target="_blank" href="<%= url %>" class="lk_0">查看相关活动&gt;&gt;</a></p><%}%>', '</div>', '<i class="mod_hint_arrow1"></i>', '</div>', '</li>'].join(''),
    addrTpl: ['<% for (var i = 0; i < list.length; i ++) { %><li class="sea_pop_parent">', '<div class="x_mod_promo">', '<span class="x_mod_promo_tag"><%= list[i].title %><i></i></span>', '<span class="x_mod_promo_con">', '<span><a target="_blank" href="<%= list[i].discount_url %>"><%= list[i].desc %></a></span>', '</span>', '</div>', '</li><%}%>'].join(''),
    addPriceTpl: ['<li class="sea_pop_parent">', '<div class="x_mod_promo">', '<span class="x_mod_promo_tag"><%= title %><i></i></span>', '<span class="x_mod_promo_con">', '<span class="sea_pop_a"><% if(tag>0) {%><a target="_blank" href="<%= url %>"><%}%><%= name %><% if(tag>0) {%></a><%}%></span>', '</span>', '</div>', '<div class="mod_hint mod_hint_weak x_mod_hint2 sea_pop_box">', '<div class="mod_hint_inner xhint_gift">', '<div class="xhint_gift_item">', '<p class="xhint_gift_tit"><%== desc %>：</p>', '<ul class="x_hint_gift_list">', '<%for(var i = 0, j = list.length; i < j; i++){%>', '<li>', '<div class="x_mod_gift">', '<a href="<%=list[i].url%>" class="x_mod_gift_img" target="_blank" title="<%=list[i].fullname%>"><img src="<%=list[i].img%>" alt="<%=list[i].name%>" onerror="this.src=\'http://static.gtimg.com/icson/images/detail/v2/30.jpg\'"></a>', '<a href="<%=list[i].url%>" class="x_mod_gift_name" target="_blank" title="<%=list[i].fullname%>"><%=list[i].name%></a>', '<span class="x_mod_gift_price"><%==list[i].info%></span>', '</div>', '</li>', '<%}%>', '</ul>', '</div>', '</div>', '<i class="mod_hint_arrow1"></i>', '</div>'].join(''),
    promo_init: function(item) {
      var _url = 'http://' + G.DOMAIN.ITEM_ICSON_COM + '/p/CGINewPromotion?cids1=' + item.c1ids + '&cids2=' + item.c2ids + '&cids3=' + item.c3ids + '&pid=' + item.pid + '&whid=' + item.whid+'&product_sale_model='+item.product_sale_model;
      $.ajax({
        type: "GET",
        url: _url,
        dataType: 'json',
        report: "errno",
        cache: true,
        success: function(o) {
          var _wrap = $('#sea_promo_wrap');
          if (o.errno == 0) {
            var _templj = [],
              _templs = [],
              _tempby = [],
              _tempaddr = [],
              _tempaddprice = [],
              _html = '',
              template = require('common.template.1'),
              render = template.compile(Grade.tpl),
              renderAddr = template.compile(Grade.addrTpl),
              renderAddPrice = template.compile(Grade.addPriceTpl); //_templj满立减_templs满立送_tempby满包邮
            for (var i = 0, j = o.data.length; i < j; i++) {
              var temp = o.data[i];
              if (temp.itemid == item.pid && temp.is_plus == 0) {
                for (var _i = 0, _j = temp.info_list.length; _i < _j; _i++) {
                  var _temp = temp.info_list[_i];
                  if (_temp.discount_type == '5') {
                    _templj.push(_temp);
                  } else if (_temp.discount_type == '6') {
                    _templs.push(_temp);
                  } else if (_temp.discount_type == '7') {
                    _tempby.push(_temp);
                  }else if (_temp.discount_type == '10' || _temp.discount_type == '11') {
                    _tempaddr.push(_temp);
                  } else if (_temp.discount_type == '8' || _temp.discount_type == '9') {
                    _tempaddprice.push(_temp);
                  }

                }
              }
            }
            if (_wrap.find('.xpromo_list').size() == 0 && (_templj.length > 0 || _templs.length > 0 || _tempby.length > 0 || _tempaddprice.length>0 || _tempaddr.length>0)) {
              _wrap.html(Grade.wrapTpl);
            }
            //满立减
            var _viewlj = {
              title: '满立减'
            };
            if (_templj.length > 1) {
              var _desc = '';
              for (var i = 0, j = _templj.length; i < j; i++) {
                _desc += _templj[i].desc + '<br />';
              }
              _viewlj.desc = _desc;
              var _t = _templj[0];
              _viewlj.name = _t.name;
              if (_t.discount_url) {
                _viewlj.tag = 1;
                _viewlj.url = _t.discount_url;
              } else {
                _viewlj.tag = 0;
                _viewlj.url = 'javascript:';
              }

            } else if (_templj.length == 1) {

              var _t = _templj[0];
              _viewlj.desc = _t.desc;
              _viewlj.name = _t.name;
              if (_t.discount_url) {
                _viewlj.tag = 1;
                _viewlj.url = _t.discount_url;
              } else {
                _viewlj.tag = 0;
                _viewlj.url = 'javascript:';
              }
            }
            if (_templj.length > 0) {
              _wrap.find('.xpromo_list').append(render(_viewlj));
            }            
            //满赠券
            var _viewls = {
              title: '满赠券'
            };
            if (_templs.length > 1) {
              var _desc = '';
              for (var i = 0, j = _templs.length; i < j; i++) {
                _desc += _templs[i].desc + '<br />';
              }
              _viewls.desc = _desc;
              var _t = _templs[0];
              _viewls.name = _t.name;
              if (_t.discount_url) {
                _viewls.tag = 1;
                _viewls.url = _t.discount_url;
              } else {
                _viewls.tag = 0;
                _viewls.url = 'javascript:';
              }

            } else if (_templs.length == 1) {

              var _t = _templs[0];
              _viewls.desc = _t.desc;
              _viewls.name = _t.name;
              if (_t.discount_url) {
                _viewls.tag = 1;
                _viewls.url = _t.discount_url;
              } else {
                _viewls.tag = 0;
                _viewls.url = 'javascript:';
              }
            }
            if (_templs.length > 0) {
              _wrap.find('.xpromo_list').append(render(_viewls));
            }
        
            //满换购和满立送
            if (config.lv & level.ADD_PRICE && _tempaddprice.length > 0) {
              var _html = '',
                _title = '';
              for (var i = 0, j = _tempaddprice.length; i < j; i++) {
                if (_tempaddprice[i].discount_type == 8) {
                  _title = '满换购';
                } else if (_tempaddprice[i].discount_type == 9) {
                  _title = '满立送';
                }
                var _tp = {
                  title: _title,
                  name: _tempaddprice[i].desc,
                  desc: _tempaddprice[i].name,
                  list: []
                };
                if (_tempaddprice[i].discount_url) {
                  _tp.tag = 1;
                  _tp.url = _tempaddprice[i].discount_url;
                } else {
                  _tp.tag = 0;
                  _tp.url = 'javascript:';
                }
                for (var n = 0, m = o.data.length; n < m; n++) {
                  if (o.data[n].item_ruleid == _tempaddprice[i].promotion_ruleid && o.data[n].rule_index == 0) {
                    var _name = o.data[n].title,
                      _info = '';
                    if (_tempaddprice[i].discount_type == 8) {
                      _info = '换购价<span class="mod_price"><i>¥</i>' + (o.data[n].promotion_price / 100).toFixed(2) + '</span>';
                    } else if (_tempaddprice[i].discount_type == 9) {
                      _info = '赠品';
                    }
                    _tp.list.push({
                      fullname: _name,
                      name: _name.length < 19 ? _name : _name.substring(0, 18) + '...',
                      url: 'http://item.yixun.com/item-' + o.data[n].itemid + '.html',
                      img: G.logic.constants.getSSUrl(o.data[n].p_char_id, 0),
                      info: _info
                    });
                  }
                }
                _html += renderAddPrice(_tp);
              }
              _wrap.find('.xpromo_list').append(_html);              
            }
            //推荐活动10和可领券11
              if(_tempaddr.length >0){
                  for (var i = 0, j = _tempaddr.length; i < j; i++) {
                    if(_tempaddr[i].discount_type == 10){
                        _tempaddr[i].title = '推荐活动';
                    }else{
                        _tempaddr[i].title = '可领券';
                    }
                  }
                  _wrap.find('.xpromo_list').append(renderAddr({
                    list:_tempaddr
                  }));
              }
          }
          if (_wrap.text().length == 0) {
            _wrap.remove();
          }
          
        }
      });
    },
    init: function(event, item) {
      if (config.lv & level.PROMOTE) {
        Grade.promo_init(item);
      }
    }
  };
  $(document).bind('init', Grade.init);
});/*  |xGv00|339b259f39ecedde407ee9946f446e95 */