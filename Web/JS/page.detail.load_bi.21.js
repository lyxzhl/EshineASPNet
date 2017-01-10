/*
 * name: page.detail.load_bi.js
 * author: xeonluo
 * usage:
 **/
define("page.detail.load_bi.21", function(require, exports, module) {
  var template = require('common.template.1');
  var image = require('common.image.7');
  var LoadBI = {
    nostock_tpl: ['<div class="xsimilar">', '<p class="xsimilar_tit">晚了一步？看看其他类似商品吧！</p>', '<ul class="xsimilar_list clearfix">', '<%for(var i = 0, j = list.length;i < j; i++){%><li itemscope="" itemtype="http://schema.org/SomeProducts">', '<div class="mod_goods">', '<div class="mod_goods_img">', '<a target="_blank" href="<%= list[i].URL %>" itemprop="url" title="<%= list[i].TITLE %>"><img src="<%= list[i].IMG %>" alt="<%= list[i].TITLE %>" itemprop="image"></a>', '</div>', '<div class="mod_goods_info">', '<p class="mod_goods_tit"><a href="<%= list[i].URL %>" itemprop="name" title="<%= list[i].TITLE %>"><%= list[i].TITLE %></a></p>', '<p class="mod_goods_price" itemprop="offers" itemscope="" itemtype="http://schema.org/Offer"><span class="mod_price" itemprop="price"><i>&yen;</i><span><%= list[i].PRICE %></span></span></p>', '</div>', '</div>', '</li><%}%>', '</ul>', '</div>'].join(''),
    buy_tpl: ['<div class="x_mod_box xrelative">', '<div class="x_mod_box_hd">', '<div class="x_mod_box_tit">买了的人还买了</div>', '</div>', '<div class="x_mod_box_bd">', '<%if(category.length>0){%><div class="xrelative_buy">', '<%for(var i = 0, j = category.length;i < j; i++){%><p><strong><%=category[i].p%>%</strong>的人买了<a href="<%=category[i].url%>" target="_blank" title="<%=category[i].name%>" ytag="<%=category[i].ytag%>"><%=category[i].name%></a></p><%}%>', '</div><%}%>', '<div class="xrelative_goods">', '<ul class="x_mod_goods_list">', '<%for(var i = 0, j = list.length;i < j; i++){%><%if(i == j - 1){%><li class="x_mod_goods_last"><%}else{%><li><%}%>', '<div class="mod_goods x_mod_goods">', '<div class="mod_goods_img">', '<a target="_blank" ytag="30<%=list[i].TYPE%>0<%=(i+1)%>" href="<%= list[i].URL %>" title="<%= list[i].TITLE %>"><img src="<%= list[i].IMG %>" alt="<%= list[i].TITLE %>"></a>', '</div>', '<div class="mod_goods_info">', '<p class="mod_goods_tit"><a target="_blank" ytag="30<%=list[i].TYPE%>0<%=(i+1)%>" href="<%= list[i].URL %>" title="<%= list[i].TITLE %>"><%= list[i].TITLE %></a></p>', '<p class="mod_goods_price"><span class="mod_price c_tx1"><i>&yen;</i><span><%= list[i].PRICE %></span></span></p>', '</div>', '</div>', '</li><%}%>', '</ul>', '</div>', '</div>', '</div>'].join(''),
    see_tpl: ['<div class="x_mod_box xbrowse">', '<div class="x_mod_box_hd">', '<div class="x_mod_box_tit">看了最终买</div>', '</div>', '<div class="x_mod_box_bd">', '<ul class="x_mod_goods_list">', '<%for(var i = 0, j = list.length;i < j; i++){%><%if(i == j - 1){%><li class="x_mod_goods_last"><%}else{%><li><%}%>', '<div class="mod_goods x_mod_goods">', '<div class="mod_goods_img">', '<a target="_blank" ytag="30<%=list[i].TYPE%>0<%=(i+1)%>" href="<%= list[i].URL %>" title="<%= list[i].TITLE %>"><img src="<%= list[i].IMG %>" alt="<%= list[i].TITLE %>"></a>', '</div>', '<div class="mod_goods_info">', '<p class="mod_goods_tit"><a target="_blank" ytag="30<%=list[i].TYPE%>0<%=(i+1)%>" href="<%= list[i].URL %>" title="<%= list[i].TITLE %>"><%= list[i].TITLE %></a></p>', '<p class="mod_goods_price"><span class="mod_price c_tx1"><i>&yen;</i><span><%= list[i].PRICE %></span></span></p>', '</div>', '</div>', '</li><%}%>', '</ul>', '</div>', '</div>'].join(''),
    bt_tpl: ['<div class="x_mod_box xfinalbuy">', '<div class="x_mod_box_hd">', '<div class="x_mod_box_tit"><%=name%></div>', '</div>', '<div class="x_mod_box_bd">', '<div class="x_mod_goods_list1">', '<ul class="clearfix">', '<%for(var i = 0, j = list.length;i < j; i++){%><li>', '<div class="mod_goods x_mod_goods">', '<div class="mod_goods_img">', '<a href="<%=list[i].URL%>" target="_blank" title="<%=list[i].TITLE%>" ytag="<%=list[i].bt_ytag%>"><img src="<%=list[i].IMG%>" alt="<%=list[i].TITLE%>"></a>', '</div>', '<div class="mod_goods_info">', '<p class="mod_goods_tit"><a href="<%=list[i].URL%>" target="_blank" title="<%=list[i].TITLE%>" ytag="<%=list[i].bt_ytag%>"><%=list[i].TITLE%></a></p>', '<p class="mod_goods_price"><span class="mod_price c_tx1"><i>&yen;</i><span><%=list[i].PRICE%></span></span></p>', '</div>', '</div>', '</li><%}%>', '</ul>', '</div>', '</div>', '</div>'].join(''),
    history_tpl: ['<div class="x_mod_box xhistory">', '<div class="x_mod_box_hd">', '<div class="x_mod_box_tit">最近浏览过的产品</div>', '</div>', '<div class="x_mod_box_bd">', '<div class="xhistory_list">', '<ul class="clearfix"> ', '<%for(var i = 0, j = list.length;i < j; i++){%><li>', '<div class="mod_goods">', '<div class="mod_goods_img">', '<a target="_blank" href="<%=list[i].URL%>" ytag="<%=list[i].ytag%>"><img src="<%= list[i].IMG %>" alt="<%=list[i].TITLE%>" width="80" height="80" /></a>', '</div>', '<div class="mod_goods_info">', '<p class="mod_goods_tit"><a target="_blank" href="<%=list[i].URL%>" title="<%=list[i].TITLE%>" ytag="<%=list[i].ytag%>"><%=list[i].TITLE%></a></p>', '<p class="mod_goods_price"><span class="mod_price"><i>&yen;</i><span><%=list[i].PRICE%></span></span></p>', '</div>', '<b class="xhistory_bg"></b>', '</div>', '</li><%}%>', '</ul>', '</div>', '</div>', '</div>'].join(''),
    same_wrap_tpl: ['<div class="x_mod_box xsame">', '<div class="x_mod_box_hd">', '<%if(price_list.length > 0 && brand_list.length == 0){%><div class="x_mod_box_tit">同价位</div><%}%>', '<%if(price_list.length == 0 && brand_list.length > 0){%><div class="x_mod_box_tit">同品牌</div><%}%>', '<%if(price_list.length > 0 && brand_list.length > 0){%><ul class="x_mod_box_nav">', '<li class="current"><a rel="sea_same_price" href="javascript:" ytag="30701">同价位</a></li>', '<li><a rel="sea_same_brand" href="javascript:" ytag="30601">同品牌</a></li>', '</ul><%}%>', '</div>', '<div class="x_mod_box_bd">', '<div class="xsame_item" id="sea_same_price" style="display:none">', '</div>', '<div class="xsame_item" id="sea_same_brand" style="display:none">', '</div>', '</div>', '</div>'].join(''),
    same_item_tpl: ['<ul class="x_mod_goods_list">', '<%for(var i = 0, j = list.length;i < j; i++){%><%if(i == j - 1){%><li class="x_mod_goods_last"><%}else{%><li><%}%>', '<div class="mod_goods x_mod_goods">', '<div class="mod_goods_img">', '<a target="_blank" href="<%=list[i].URL%>" title="<%=list[i].TITLE%>" ytag="<%=list[i].ytag%>"><img src="<%=list[i].IMG%>" alt="<%=list[i].TITLE%>"></a>', '</div>', '<div class="mod_goods_info">', '<p class="mod_goods_tit"><a target="_blank" href="<%=list[i].URL%>" title="<%=list[i].TITLE%>"><%=list[i].TITLE%></a></p>', '<p class="mod_goods_price"><span class="mod_price c_tx1"><i>&yen;</i><span><%=list[i].PRICE%></span></span></p>', '</div>', '</div>', '</li><%}%>', '</ul>'].join(''),
    getUrl: function(item, key) {
      return 'http://s2.smart.yixun.com/w/tf/gettfx?tfid=' + key + '&biReserved=' + item.whid + ':' + item.current_locid + ',' + item.loc_id + ',' + item.whid + '-' + item.pid + ':' + item.c3ids + ',' + item.brand_id + ',' + item.category_id + ',' + item.price + '&type=jsonp&tcdn=1'
    },
    nostock_init: function(item) {
      $.ajax({
        type: "GET",
        url: LoadBI.getUrl(item, 100003),
        dataType: 'jsonp',
        report: {
          key: "iRet",
          formatUrl: false,
          url: 'http://s2.smart.yixun.com/w/tf/gettfx?tfid=100003'
        },
        success: function(o) {

          if (o.iRet == 0) {
            var key = 4,
              length = o.data.POS_RECOM ? o.data.POS_RECOM.length : 0,
              _data = {
                list: []
              },
              render = template.compile(LoadBI.nostock_tpl);
            length = length > key ? key : length;
            for (var i = 0, j = length; i < j; i++) {
              o.data.POS_RECOM[i].IMG = image.getPicBySize(o.data.POS_RECOM[i].IMG, 120);//o.data.POS_RECOM[i].IMG.replace(/\/pic160\//, '/middle/');
              _data.list.push(o.data.POS_RECOM[i]);
            }
            if (length > 0) {
              $('#sea_nostock_same').html(render(_data)).show();
            }
          }
        }
      });
    },
    history_init: function(item) {
      $.ajax({
        type: "GET",
        url: LoadBI.getUrl(item, 100006),
        dataType: 'jsonp',
        report: {
          key: "iRet",
          formatUrl: false,
          url: 'http://s2.smart.yixun.com/w/tf/gettfx?tfid=100006'
        },
        success: function(o) {

          if (o.iRet == 0) {
            var length = o.data.POS_HISTORY ? o.data.POS_HISTORY.length : 0,
              _data = {
                list: []
              },
              render = template.compile(LoadBI.history_tpl);

            for (var i = 0, j = length; i < j; i++) {
              o.data.POS_HISTORY[i].IMG = image.getPicBySize(o.data.POS_HISTORY[i].IMG, 80);//o.data.POS_HISTORY[i].IMG.replace(/\/pic160\//, '/small/');
              o.data.POS_HISTORY[i].ytag = 30001 + i;
              _data.list.push(o.data.POS_HISTORY[i]);
            }
            var wrap = $('#sea_history');
            if (length > 0) {
              wrap.html(render(_data)).css({height: 'auto'}).show();
            }else{
              wrap.hide();
            }
            wrap.delegate('li', 'mouseenter', function() {
              $(this).addClass('on');
            });
            wrap.delegate('li', 'mouseleave', function() {
              $(this).removeClass('on');
            });

          }
        }
      });
    },
    rank_init: function(item) {
      $.ajax({
        type: "GET",
        url: LoadBI.getUrl(item, 100007),
        dataType: 'jsonp',
        report: {
          key: "iRet",
          formatUrl: false,
          url: 'http://s2.smart.yixun.com/w/tf/gettfx?tfid=100007'
        },
        success: function(o) {
          if (o.iRet == 0) {
            if (o.data.POS_RANK && o.data.POS_RANK[0]) {
              o = $.parseJSON(o.data.POS_RANK[0].BI_EXTINFO);
              var num = ~~o.R1;
              if (num > 0 && num < 11) {
                $('#sea_rank_num').text(num);
                $('#sea_rank').show();
              }
            }
          }
        }
      });
    },
    see_buy_init: function(item,tfid) {
      $.ajax({
        type: "GET",
        url: LoadBI.getUrl(item, tfid),
        dataType: 'jsonp',
        report: {
          key: "iRet",
          formatUrl: false,
          url: 'http://s2.smart.yixun.com/w/tf/gettfx?tfid='+tfid
        },
        success: function(o) {
          if (o.iRet == 0) {
            var _see_length = o.data.POS_BROW ? o.data.POS_BROW.length : 0,
              _buy_length = o.data.POS_BUY ? o.data.POS_BUY.length : 0,
              _data_see = {
                list: [],
                name: '浏览过此商品的用户最终购买了'
              },
              _data_buy = {
                list: [],
                category: [],
                name: '购买过此商品的用户还买了'
              },
              _buy_render = template.compile(LoadBI.buy_tpl),
              _see_render = template.compile(LoadBI.see_tpl),
              _bt_render = template.compile(LoadBI.bt_tpl);
            for (var i = 0, j = _see_length; i < j; i++) {
              o.data.POS_BROW[i].IMG = image.getPicBySize(o.data.POS_BROW[i].IMG, 120);//o.data.POS_BROW[i].IMG.replace(/\/pic160\//, '/middle/');
              o.data.POS_BROW[i].TYPE = 2;
              o.data.POS_BROW[i].bt_ytag = 30401 + i;
              _data_see.list.push(o.data.POS_BROW[i]);
            }
            for (var i = 0, j = _buy_length; i < j; i++) {
              o.data.POS_BUY[i].IMG = image.getPicBySize(o.data.POS_BUY[i].IMG, 120);//o.data.POS_BUY[i].IMG.replace(/\/pic160\//, '/middle/');
              o.data.POS_BUY[i].TYPE = 1;
              o.data.POS_BUY[i].bt_ytag = 30501 + i;
              _data_buy.list.push(o.data.POS_BUY[i]);
            }
            if (o.data.POS_CATEGORY) {

              for (var i = 0, j = o.data.POS_CATEGORY.length; i < j; i++) {
                var _p = $.parseJSON(o.data.POS_CATEGORY[i].BI_EXTINFO).R1;
                if (_p && _p > 30) {
                  _data_buy.category.push({
                    name: o.data.POS_CATEGORY[i].TITLE,
                    url: o.data.POS_CATEGORY[i].URL,
                    p: _p,
                    ytag: 30106 + i
                  });
                }
              }
            }
            if (_see_length > 0) {

              $('#sea_see_same').html(_see_render(_data_see)).css({height: 'auto'}).show();
            }else if(tfid === 100015){
              $('#sea_see_same').hide();
            }
            if (_buy_length > 0) {
              $('#sea_buy_same').html(_buy_render(_data_buy)).css({height: 'auto'}).show();
            }else if(tfid === 100014){
              $('#sea_buy_same').hide();
            }
/*
            if (_see_length == 5) {
              $('#sea_review_list').html(_bt_render(_data_see)).show();
            }
            if (_buy_length == 5) {
              $('#sea_bought_list').html(_bt_render(_data_buy)).show();
            }*/
          }
        }
      });
    },
    /**
     * 底部BI模块
     * @param {Object} item
     */
    getBottomBiData: function(item, maxNum) {
      $.ajax({
        type: "GET",
        url: LoadBI.getUrl(item, 100013),
        dataType: 'jsonp',
        report: {
          key: "iRet",
          formatUrl: false,
          url: 'http://s2.smart.yixun.com/w/tf/gettfx?tfid=100013'
        },
        success: function(o) {
          if (o && o.iRet == 0) {
            var _see_length = o.data.POS_BROW ? o.data.POS_BROW.length : 0,                         
              _data_see = {
                list: [],
                category: [],
                name: '你可能还会喜欢这些商品'
              },
              _bt_render = template.compile(LoadBI.bt_tpl);
            for (var i = 0, j = _see_length; i < j && i < maxNum; i++) {
              o.data.POS_BROW[i].IMG = image.getPicBySize(o.data.POS_BROW[i].IMG, 120);//o.data.POS_BROW[i].IMG.replace(/\/pic160\//, '/middle/');
              o.data.POS_BROW[i].TYPE = 2;
              o.data.POS_BROW[i].bt_ytag = 30401 + i;
              _data_see.list.push(o.data.POS_BROW[i]);
            }            
            if (_see_length >= maxNum) {
              $('#sea_bought_list').html(_bt_render(_data_see)).show();
              if(maxNum > 5){
                  $('#sea_bought_list ul').css("width","auto");
              }
            }
          }
        }
      });
    },

    same_price_brand_init: function(item) {
      $.ajax({
        type: "GET",
        url: LoadBI.getUrl(item, 100008),
        dataType: 'jsonp',
        report: {
          key: "iRet",
          formatUrl: false,
          url: 'http://s2.smart.yixun.com/w/tf/gettfx?tfid=100008'
        },
        success: function(o) {
          if (o.iRet == 0) {
            var _price_length = o.data.POS_PRICE ? o.data.POS_PRICE.length : 0,
              _brand_length = o.data.POS_BRAND ? o.data.POS_BRAND.length : 0,
              _data_price = {
                list: []
              },
              _data_brand = {
                list: []
              },
              _wrap_render = template.compile(LoadBI.same_wrap_tpl),
              _item_render = template.compile(LoadBI.same_item_tpl);

            for (var i = 0, j = _price_length; i < j; i++) {
              o.data.POS_PRICE[i].IMG = image.getPicBySize(o.data.POS_PRICE[i].IMG, 120);//o.data.POS_PRICE[i].IMG.replace(/\/pic160\//, '/middle/');
              o.data.POS_PRICE[i].ytag = 30702 + i;
              _data_price.list.push(o.data.POS_PRICE[i]);
            }
            for (var i = 0, j = _brand_length; i < j; i++) {
              o.data.POS_BRAND[i].IMG = image.getPicBySize(o.data.POS_BRAND[i].IMG, 120);//o.data.POS_BRAND[i].IMG.replace(/\/pic160\//, '/middle/');
              o.data.POS_BRAND[i].ytag = 30602 + i;
              _data_brand.list.push(o.data.POS_BRAND[i]);
            }
            if (_price_length > 0 || _brand_length > 0) {
              $('#sea_same_price_brand').html(_wrap_render({
                price_list: _data_price.list,
                brand_list: _data_brand.list
              })).css({height: 'auto'}).show();
              if (_price_length > 0) {
                $('#sea_same_price').html(_item_render(_data_price)).show();
              }
              if (_brand_length > 0) {
                if (_price_length > 0) {
                  $('#sea_same_brand').html(_item_render(_data_brand));
                } else {
                  $('#sea_same_brand').html(_item_render(_data_brand)).show();
                }
              }
            }else{
              $('#sea_same_price_brand').hide();
            }
            $('#sea_same_price_brand').delegate('.x_mod_box_nav li', 'mouseenter', function() {

              var _this = $(this),
                _all = _this.parent().find('li');
              if (_this.hasClass('current')) {
                return false;
              }
              _all.removeClass('current');
              _this.addClass('current');
              $('#sea_same_price_brand .xsame_item').hide();
              $('#' + _this.find('a').attr('rel')).show();
            });
          }
        }
      });
    },
    init: function(event, item) {
      var areaid = G.logic.constants.getLocationId().split('_'),
        current_locid = areaid[0] || 0;
      var locarr = G.util.cookie.get('loc').split('_');
      item.loc_id = locarr[locarr.length - 1];
      item.current_locid = current_locid;

      if (config.lv & level.BI_RANK && item.product_sale_model != 5) { //排行榜
        LoadBI.rank_init(item);
      }

      if (config.lv & level.BI_NO_STOCK) { //无货推荐
        if (item.bt_state > 0) {
          LoadBI.nostock_init(item, current_locid);
        }
      }
      $(document).bind('sea_buy_same', function() { //买了买
        if (config.lv & level.BI_SEE_BUY) {
          LoadBI.see_buy_init(item,100014);
        }else{
          $('#sea_buy_same').hide();
        }
      });
      
      $(document).bind('sea_see_same', function() { //看了看
        if (config.lv & level.BI_SEE_SEE) {
          LoadBI.see_buy_init(item,100015);
        }else{
          $('#sea_see_same').hide();
        }
      });
      
      $(document).bind('sea_history', function() { //历史记录
        if (config.lv & level.BI_HISTORY) {
          LoadBI.history_init(item);
        }else{
          $('#sea_history').hide();
        }
      });
      $(document).bind('sea_same_price_brand', function() { //同价位同品牌
        if (config.lv & level.BI_SAME_PRICE_BRAND && item.product_sale_model != 5) {
          LoadBI.same_price_brand_init(item);
        }else{
          $('#sea_same_price_brand').hide();
        }
      });

      if (config.lv & level.BI_BOTTOM) {
          var maxNum = 5;
          if(itemInfo.bt_state != 0){
            $(".xcontent_row3").append($("#sea_bought_list")).show();
            maxNum = 6;
          }
          $(document).bind('sea_bi_bottom', function() { //底部BI推荐
              LoadBI.getBottomBiData(item, maxNum);
          });
      }else{
          $('#sea_bi_bottom').hide();
      }
    }
  };
  $(document).bind('init', LoadBI.init);
});/*  |xGv00|7b086524d9b172dba29309e8456a9005 */