/*
 * name: common.cookie.js
 * author: xeonluo
 * usage: 
 * cookie.get(name);
 * cookie.set(name, value, path, expire, domain);
 * cookie.del(name, domain);
 **/

define("common.cookie.2", function(require, exports, module) {

  var handle, _fn;

  // private collection 
  _fn = {
    get: function(name) {
      var r = new RegExp("(^|;|\\s+)" + name + "=([^;]*)(;|$)");
      var m = document.cookie.match(r);
      return (!m ? "" : unescape(m[2]));
    },

    set: function(name, value, path, expire, domain) {
      var s = name + "=" + escape(value) + "; path=" + (path || '/') // 默认根目录
      + (domain ? ("; domain=" + domain) : '');
      if (expire > 0) {
        var d = new Date();
        d.setTime(d.getTime() + expire * 1000);
        s += ";expires=" + d.toGMTString();
      }
      document.cookie = s;
    },

    del: function(name, domain) {
      document.cookie = name + "=;path=/;" + (domain ? ("domain=" + domain + ";") : '') + "expires=" + (new Date(0)).toGMTString();
    }
  }

  // public collection
  handle = {
    get: _fn.get,
    set: _fn.set,
    del: _fn.del
  }  

  module.exports = handle;

});/*  |xGv00|1b95e4808231ad9bc573e27cbb373d24 */