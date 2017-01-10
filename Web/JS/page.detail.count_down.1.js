/*
 * name: page.detail.count_down.js
 * author: xeonluo
 * usage:
**/
define("page.detail.count_down.1", function(require, exports, module) {
    var CountDown = {
    clock: function(dom, finish) {
      var self = CountDown,
        now = new Date(parseInt(dom.attr('now'), 10) * 1000),
        offset = new Date().getTime() - now,
        end = new Date(parseInt(dom.attr('end'), 10) * 1000),
        clockContainer = dom;

      function _timer() {
        var ret = {},
          now = new Date().getTime() - offset,
          distance = parseInt(end - now, 10);

        if (distance <= 0) {
          clearInterval(self.qianggouTimer);
          $.isFunction(finish) && finish.call(self);
          return;
        }
        var _time_config = ['mill', 'second', 'minute', 'hour'];
        for (var i in _time_config) {
          var unit = (i == 0 ? 1000 : (i == 3 ? 24 : 60));
          ret[_time_config[i]] = distance % unit;
          distance = parseInt(distance / unit, 10)
        }

        _time_config[4] = 'day';
        ret[_time_config[4]] = distance;

        var str = '',
          _time_label_config = ['毫秒', '秒', '分', '时', '天'];

        for (var len = _time_config.length, i = len - 1; i > 0; i--) {
          var key = _time_config[i];

          if (i === (len - 1) && !ret[key]) {
            continue;
          }

          if (i !== (len - 1)) {
            ret[key] = ret[key] < 10 ? ('0' + ret[key].toString()) : ret[key];

            if (i === 1) {
              ret[key] += '.' + (parseInt(ret['mill'] / 100, 10));
            }
          }

          str += '<em>' + ret[key] + '</em>' + 　_time_label_config[i];
        }
        str = '剩余' + str;
        clockContainer.html(str);
      }

      self.qianggouTimer = setInterval(_timer, 50);
    },
    init: function() {
      var
      self = CountDown,
        groupClock = $('#mod_time');
      if (groupClock.length > 0) {
        function _finish() {
          groupClock.html('已结束');
          location.reload();
        }
        self.clock(groupClock, _finish);
      }
    }
  };
  $(document).bind('init', CountDown.init);
});/*  |xGv00|1613f76a4d81cfd0f98887fcabb77cf1 */