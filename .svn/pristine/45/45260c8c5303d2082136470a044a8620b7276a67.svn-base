/*
 * name: page.detail.order_input.js
 * author: xeonluo
 * usage:
**/
define("page.detail.order_input.2", function(require, exports, module) {
    var OrderInput = {
    init: function() {      
      var ipt = $('#order_num'),
          minus = $('.sea_order_minus'),
          add = $('.sea_order_add');
      ipt.blur(function() {
        OrderInput.inputChange();
        ipt.change();
      });
      minus.click(function() {
        ipt.val(~~ipt.val()-1);
        OrderInput.inputChange();
        ipt.change();
      });
      add.click(function() {
        ipt.val(~~ipt.val()+1);
        OrderInput.inputChange();
        ipt.change();
      });
      // 绑定事件 数值变化时改变加入购物车的链接
      ipt.change(function(){
          var cartBtn = $(".xbase_row4 a.xbtn_cart, .xbase_row4 a.xbtn_buy");
          var v = ~~ipt.val();
          if(cartBtn.length && v){
              var href = cartBtn.attr("href").replace(/pnum=\d+/gi,"pnum="+v);
              cartBtn.attr("href", href);
          }
      });
      OrderInput.inputChange();
    },
    inputChange: function(){
      var ipt = $('#order_num'),
          minus = $('.sea_order_minus'),
          add = $('.sea_order_add'),
          min = ~~ipt.attr('minnumlimit'),
          max = ~~ipt.attr('maxnumlimit'),
          v = ipt.val();
          max > 99 ? 99 : max;        
        ipt.val(v > min ? v : min);
        v = ~~ipt.val();
        ipt.val(v < max ? v : max);
        v = ~~ipt.val();
        v > min ? minus.removeClass('x_mod_number_minus_disabled') : minus.addClass('x_mod_number_minus_disabled');
        v < max ? add.removeClass('x_mod_number_plus_disabled') : add.addClass('x_mod_number_plus_disabled');        
    }
  };
  $(document).bind('init', OrderInput.init);
});/*  |xGv00|3976088cc983fa29bf6a8502b9fd9a83 */