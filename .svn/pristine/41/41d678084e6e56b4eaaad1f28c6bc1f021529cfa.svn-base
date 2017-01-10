/*
 * name: page.detail.pop_control.js
 * author: xeonluo
 * usage:
**/
define("page.detail.pop_control.1", function(require, exports, module) {
    var init = function(){
    $(document).delegate('.sea_pop_a', 'mouseenter', function(){
      
      var _this = $(this),
      _parent = _this.parents('.sea_pop_parent'),
      _other = _parent.siblings(),
      _pop = _parent.find('.sea_pop_box');
      clearTimeout(_parent[0].timer);
      _parent[0].timer = null;
      clearTimeout(_this[0].atimer);
      _this[0].atimer = null;
      _this[0].atimer = setTimeout(function(){
        _other.removeClass('on');
        _parent.addClass('on');
        _pop.show();
      }, 200);      
    });
    $(document).delegate('.sea_pop_box', 'mouseenter', function(){
      var _pop = $(this),
      _parent = _pop.parents('.sea_pop_parent'),
      _other = _parent.siblings();
      clearTimeout(_parent[0].timer);
      _parent[0].timer = null;
      _other.removeClass('on');
      _parent.addClass('on');
      _pop.show();
    });
    $(document).delegate('.sea_pop_box', 'mousemove', function(){
      var _pop = $(this),
      _parent = _pop.parents('.sea_pop_parent'),
      _other = _parent.siblings();
      clearTimeout(_parent[0].timer);
      _parent[0].timer = null;
      _other.removeClass('on');
      _parent.addClass('on');
      _pop.show();
    });
    $(document).delegate('.sea_pop_a', 'mouseleave', function(){   

      var _this = $(this),      
      _parent = _this.parents('.sea_pop_parent'),      
      _pop = _parent.find('.sea_pop_box');
      clearTimeout(_this[0].atimer);
      _this[0].atimer = null;
      clearTimeout(_parent[0].timer);
      _parent[0].timer = null;
      _parent[0].timer = setTimeout(function(){
        _pop.hide();        
        _parent.removeClass('on');
      }, 100);      
    });
    $(document).delegate('.sea_pop_box', 'mouseleave', function(){
      var _pop = $(this),
      _parent = _pop.parents('.sea_pop_parent');
      
      clearTimeout(_parent[0].timer);
      _parent[0].timer = null;
      _parent[0].timer = setTimeout(function(){
        _pop.hide();
        _parent.removeClass('on');
      }, 100);      
    });
  };
  $(document).bind('init', init);
});/*  |xGv00|b0ae1f49edbe276e1edc07c854e8b7a3 */