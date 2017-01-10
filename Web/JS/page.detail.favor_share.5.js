/*
 * name: page.detail.favor_share.js
 * author: xeonluo
 * usage:
**/
define("page.detail.favor_share.5", function(require, exports, module) {
    var FavorShere = {
    add_favor: function(pid) {
      if (G.logic.login.ifLogin(FavorShere.add_favor, arguments) === false) return;
      var uid = G.logic.login.getLoginUid();
      G.util.post('http://' + G.DOMAIN.BASE_ICSON_COM + '/json.php?mod=favor&act=add&uid=' + uid, {
        pid: pid
      }, function(o) {
        if (o && o.errno == 0) {
          G.ui.popup.showMsg('收藏成功！', 3);
        } else if (o && o.errno == 404) {
          G.ui.popup.showMsg('您之前已经收藏过该商品！', 3);
        } else {
          G.ui.popup.showMsg('收藏失败！', 1);
        }
      });
    },
    notify: function(pid) {
      if (G.logic.login.ifLogin(this, arguments) === false) return;

      G.logic.login.getLoginUser(function(o) {
        if (o === false) {
          G.ui.popup.showMsg('您还没有登录');
          return;
        }
        
        // 分站id对应名称
        var oSite = {
            "1": "上海站",
            "1001": "深圳站",
            "2001": "北京站",
            "3001": "武汉站",
            "4001": "重庆站",
            "5001": "西安站"
        };
        var siteName  = oSite[G.util.cookie.get("wsid")];
        siteName  = siteName ?siteName:"";//防止 undefined
        if (o && o.data && !$.trim(o.data.email)) {
          var _msgOK = '</h4><h4 class="layer_global_tit"></h4>' + '<p>请填写您的邮箱，我们会将到货通知发到此邮箱</p>' + '<p><input type="text" class="input_long" id="enter_email"/>' + '<b class="icon icon_msg0 icon_msg0_right" id="enter_emailOK"></b>' + '<span class="strong" id="enter_emailNO"><b class="icon icon_msg0 icon_msg0_warn"></b>请输入正确的邮箱</span></p>';

          G.ui.popup.showMsg(_msgOK, 1, function() {
            var enter_email = $('#enter_email').val();
            if (!enter_email || !G.logic.validate.checkEmail(enter_email)) {
              $('#enter_emailNO').css('display', '');
              $('#enter_emailOK').css('display', 'none');
              return false;

            } else {
              G.util.post('http://' + G.DOMAIN.BASE_ICSON_COM + '/json.php?mod=mynotify&act=enterEmail', {
                email: enter_email
              }, function(o) {
                var _notifyOK = '</h4><h4 class="layer_global_tit">此商品'+siteName+'“到货通知”设置成功!</h4>' + '<p>我们会将到货信息及时发送至您的邮箱：</p>' + '<p>' + enter_email + '<a class="nor btn" href="http://base.yixun.com/myprofile.html?notify" target="_blank">修改邮箱</a></p>';

                if (o && o.errno == 0) {
                  G.util.post('http://' + G.DOMAIN.BASE_ICSON_COM + '/json.php?mod=mynotify&act=addMynotify', {
                    pid: pid,
                    email: enter_email
                  }, function(a) {
                    if (a && a.errno == 0) {
                      G.ui.popup.showMsg(_notifyOK, 3, function() {
                        location.href = 'http://base.yixun.com/mynotify.html?pid=' + pid;
                      }, null, null).paint(function() {
                        $(this).addClass('id_goods_arrive');
                      });
                    } else {
                      G.ui.popup.showMsg('抱歉,此商品“到货通知”设置失败!', 1);
                    }
                  });
                }
              });
            }
          }, null, null).paint(function() {
            $(this).addClass('id_goods_arrive');
            $('#enter_emailOK').css('display', 'none');
            $('#enter_emailNO').css('display', 'none');
            $('#enter_email').bind('blur', function() {
              var enter_email = $('#enter_email').val();
              if (!enter_email || !G.logic.validate.checkEmail(enter_email)) {
                $('#enter_emailNO').css('display', '');
                $('#enter_emailOK').css('display', 'none');
                return false;
              } else {
                $('#enter_emailNO').css('display', 'none');
                $('#enter_emailOK').css('display', '');
              }
            });
          });
        } else {
          var _notifyOK = '</h4><h4 class="layer_global_tit">此商品'+siteName+'“到货通知”设置成功!</h4>' + '<p>我们会将到货信息及时发送至您的邮箱：</p>' + '<p>' + o.data.email + '<a class="nor btn" href="http://base.yixun.com/myprofile.html?notify" target="_blank">修改邮箱</a></p>';

          var _notify_isOK = '</h4><h4 class="layer_global_tit">您之前已经设置过该商品为到货通知！</h4>' + '<p>我们会将到货信息及时发送至您的邮箱：</p>' + '<p>' + o.data.email + '<a class="nor btn" href="http://base.yixun.com/myprofile.html?notify" target="_blank">修改邮箱</a></p>';

          G.util.post('http://' + G.DOMAIN.BASE_ICSON_COM + '/json.php?mod=mynotify&act=addMynotify', {
            pid: pid,
            email: o.data.email
          }, function(a) {
            if (a && a.errno == 0) {
              G.ui.popup.showMsg(_notifyOK, 3).paint(function() {
                $(this).addClass('id_goods_arrive');
              });
            } else if (a && a.errno == 33) {
              G.ui.popup.showMsg(_notify_isOK, 3).paint(function() {
                $(this).addClass('id_goods_arrive');
              });
            } else {
              G.ui.popup.showMsg('抱歉,此商品“到货通知”设置失败!', 1);
            }
          });
        }
      }, false, true);
    },
    init: function(event, item) {
      var msg = '我在易迅网看到' + itemInfo.name + '易迅只要' + (item.price / 100).toFixed(2) + '元，还等什么，大家快来抢吧！ @易迅网 ',
        msg_sina = '我在易迅网看到' + itemInfo.name + '易迅只要' + (item.price / 100).toFixed(2) + '元，还等什么，大家快来抢吧！ @易迅网官网 ',
        url = 'http://item.' + host + '/item-' + itemInfo.pid + '.html?LS=tqq';
      msg = encodeURIComponent(msg);
      msg_sina = encodeURIComponent(msg_sina);
      url = encodeURIComponent(url);

      $('#share_tx_weibo').attr({
        href: 'http://v.t.qq.com/share/share.php?title=' + msg + '&url=' + url + '&appkey=0cb44fae2de1437a81b846a9d45180f4&site=http://www.yixun.com&pic=' + G.logic.constants.getMMUrl(itemInfo.p_char_id, 0),
        target: '_blank'
      });

      //旧key:0cb44fae2de1437a81b846a9d45180f4,貌似不可用了,所以换了个新的key:2992571369
      $('#share_sina_weibo').attr({
        href: 'http://v.t.sina.com.cn/share/share.php?content=' + msg_sina + '&title=' + msg_sina + '&url=' + url + '&appkey=2992571369&site=http://www.yixun.com&pic=' + G.logic.constants.getMMUrl(itemInfo.p_char_id, 0),
        target: '_blank'
      });
      $(".xcontent_row2").delegate('#sea_add_favor', 'click', function() {
        FavorShere.add_favor(item.pid);
      });
      $('#sea_notify').click(function() {
        FavorShere.notify(item.pid);
      });
    }
  };
  $(document).bind('init', FavorShere.init);
});/*  |xGv00|aea3edd767b1933f3b965c1573ba335a */