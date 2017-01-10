/*
 * name: page.detail.lazyload.js
 * author: xeonluo
 * usage:
 **/
define("page.detail.lazyload.8", function(require, exports, module) {
  $(document).bind('init', function() {
    var OxLazyloader = require('common.lazyloader.5');
    var oxLazyloader = new OxLazyloader({
      container: 'document',
      // 容器 默认为document
      imgLazyAttr: 'data-oxlazy-img',
      //img lazyload属性名，值为图片真实地址 默认为 data-oxlazy-img
      moduleLazyAttr: 'data-oxlazy-module',
      //module lazyload属性名，值为module ID, ID作为回调事件的参数 默认为 data-oxlazy-module
      autoDestroy: true,
      // lazyload内容都加载完成时，是否自动停止监听 默认true
      dynamic: true,
      //是否有动态的内容插入 默认 false
      threshold: 100,
      //预加载的距离 默认 100 也可以为每个模块单独设置 例子参看模块1结构
      moduleLoadCallback: function(id, moduleContainer) {
        $(document).trigger(id, [itemInfo]);
      } // 带 moduleLazyAttr值 和 module容器为参数
    });
  });

});/*  |xGv00|462a2fbf558f142f58e6b0e8b3b391ba */