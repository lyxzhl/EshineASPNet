/*
 * name: page.detail.show_error.js
 * author: xeonluo
 * usage:
 **/
define("page.detail.show_error.8", function(require, exports, module) {
  var showError = {
    showerr: function(item) {
      var btlist = {
        "1": "商品下架",
        "2": "商品库存下架",
        "3": "商品限运",
        "4": "延保商品",
        "5": "商品库存不足",
        "6": "商品易迅价999999"
      },
      errolist = {
        "1000000": "TWS调用AO网络层失败",
        "1000001": "TWS调用AO入参不合法",
        "1000002": "商品系统AO调用失败",
        "1000003": "商品系统AO返回无数据",
        "1000004": "商品系统返回数据非请求商品",
        "1100006": "商品没有仓库信息及最大最小购买数",
        "1100007": "调用库存服务失败",
        "1100008": "库存服务返回无数据",
        "1100009": "库存服务返回非请求商品",
        "1100010": "调用商品TTC服务失败",
        "1100011": "调用商品TTC服务返回无数据",
        "1100012": "调用商品TTC服务返回非请求商品",
        "1100013": "调用配送服务失败",
        "1100014": "调用配送服务返回无数据",
        "1100015": "调用配送服务返回非请求商品",
        "1100016": "调用多价服务失败",
        "1100017": "调用多价服务返回无数据",
        "1100018": "调用多价服务返回非请求商品",
        "1100019": "易迅价异常",
        "1100020": "起购数大于限购数"
      };
      if ((item.bt_state && item.bt_state > 0) || (item.button_result && item.button_result.length > 0)) {
        var msg = '';
        if(item.bt_state && item.bt_state > 0 && btlist[item.bt_state]){
            msg += '暂不销售原因：' + btlist[item.bt_state] + '<br />';
        }
        for (var i = 0, j = item.button_result.length; i < j; i++) {
          
          if (item.button_result[i] && item.button_result[i].base_error_code > 0 && errolist[item.button_result[i].base_error_code]) {
            msg += '错误码'+item.button_result[i].base_error_code + '：' + errolist[item.button_result[i].base_error_code];
            if (item.button_result[i].extend_error_code > 0) {
              msg += '，系统返回码' + item.button_result[i].extend_error_code;
            }
            msg += '<br />';
          }
        }
        var x = G.ui.popup.showMsg(msg);
        x.resize({height:$('.layer_global_mod').height()+80});
      }
    },
    init: function(event, item) {
      $(document).bind('keydown', function(e) {
        if (e.metaKey || e.ctrlKey) {
          var err = 'Y';
          if (e.keyCode === err.charCodeAt(0)) {
            showError.showerr(item);
          }
        }
      });
    }
  };
  $(document).bind('init', showError.init);
});/*  |xGv00|799df284f8db42062e7d304002335c45 */