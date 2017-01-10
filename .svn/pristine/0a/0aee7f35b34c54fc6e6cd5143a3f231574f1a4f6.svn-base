/*
 * name: common.image.js
 * author: xeonluo
 * usage: 
 * var image = require('common.image');
 * image.getPicBySize(pCharId, picIdx, size); 易迅CDN
 * image.getPicBySize(picURL, size); 腾讯CDN
 *
 **/
define("common.image.7", function(require, exports, module) {

  var handle, _fn;

  // private collection 
  _fn = {
    getPicUrl: function(pCharId, type, picIdx) {
      var parts = pCharId.split("R", 2);
      pCharId = parts[0];
      parts = pCharId.split("-", 3);
      var part1 = parts[0],
        part2 = parts[1],
        part3 = parts[2];
      return 'http://img' + (parseInt(part3) % 2 ? '1' : '2') + '.icson.com/product/' + type + '/' + part1 + '/' + part2 + '/' + pCharId + (picIdx == 0 ? '' : ('-' + (picIdx < 10 ? ('0' + picIdx) : picIdx))) + '.jpg';
    },
    getPicByPic: function(pic, size){
      if(size == 0){
        var _pic = (pic+'').replace(/(jpg|gif|png|bmp)\/\d+(\?\w+)?$/, '$1/'+size+'$2');
        return _pic.replace(/qqbuy/, '51buypic');
      }else{
        return (pic+'').replace(/(jpg|gif|png|bmp)\/\d+(\?\w+)?$/, '$1/'+size+'$2');
      }      
    },
    getYXPicBySize: function(pic, size){
        var existSize = [0, 30, 60, 80, 120, 160, 200, 300, 400, 600, 800];
    	if(pic.indexOf("icson.com") > -1){
    		existSize = [50, 60, 80, 120, 160, 200, 300, 600, 800];
    	}
    	var flag = false;
    	for(var i = 0; i < existSize.length;i++){
    		if(size == existSize[i]){
    			flag = true;
    			break;
    		}
    	}
    	if(flag){
    		var url = "";
			if(pic.indexOf("wgimg.com") > -1){
				url = this.getPicByPic(pic, size==800?0:size);
			}else if(pic.indexOf("paipaiimg.com") > -1){
				//网购的匹配 .120x120.jpg这样结尾的
				if(size == 0){
    			    url = pic.replace(/\.\d+x\d+(\.jpg|gif|png|bmp)?$/,"$1");
				}else{
				    // 当为0时没有 /\d+x\d+/ 所有这里多替换1次
    			    url = pic.replace(/(\.)\d+x\d+(\.jpg|gif|png|bmp)?$/,"$1"+(size+"x"+size)+"$2").replace(/(\.\d+)(\.jpg|gif|png|bmp)?$/,"$1."+(size+"x"+size)+"$2");
				}
			}else if(pic.indexOf("icson.com") > -1){
				url = pic.replace(/\/product\/\w+\//, "/product/"+this.icsonExistMap[""+size]+"/");
			}
			return url;
    	}else{
    		return existSize.join(",");
    	}
    	
    },
    getIcsonPicBySize: function(pCharId, picIdx, size){
    	var existMap = this.icsonExistMap;
    	if((""+size) in existMap){
    		return this.getPicUrl(pCharId, existMap[""+size], picIdx);
    	}else{
    		// 不存在返回存在的列表
    		var str = [];
    		for(var n in existMap){
    			str.push(n); 
    		}
    		return str.join(",");
    	}
    },
    icsonExistMap: {
		"50": "ss", 
		"60": "pic60",
		"80": "small",
		"120": "middle",
		"160": "pic160",
		"200": "pic200",
		"300": "mm",
		"800": "mpic"
    }
  };

  // public collection
  handle = {
    getPicBySize: function(){
    	if(arguments.length == 2){// 只带链接地址和尺寸
    		return _fn.getYXPicBySize.apply(_fn, arguments);
    	}else if(arguments.length == 3){// pCharId计算需要pCharId, picIdx和尺寸
    		return _fn.getIcsonPicBySize.apply(_fn, arguments);
    	}
    }
  };

  module.exports = handle;

});/*  |xGv00|a0b9182ce986d451bd842350a8898aa9 */