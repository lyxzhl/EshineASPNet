/*
 * name: page.detail.load_chong.js
 * author: xeonluo
 * usage:
**/
define("page.detail.load_chong.2", function(require, exports, module) {
    var LoadChong = {    
    tpl: ['<div class="x_mod_box xcharge">',
          '<iframe frameborder="0" border="0" frameborder="no" id="preview_frame" width="188" height="225" scrolling="no" allowtransparency="true" src="http://chong.qq.com/tws/entra/getpanel?id=306&vb2ctag=3_1007_1_1346&width=188&height=225"></iframe>',
          '</div>'].join(''),    
    init: function(event, item){
      if(config.lv & level.CHONG){
        if(item.c2ids == 801){
          $('#sea_chong').html(LoadChong.tpl).show();   
        }
      }      
    }
  };
  $(document).bind('sea_chong', LoadChong.init);
});/*  |xGv00|6c7ab32d4c81212e6c33bfe5ba6e66ec */