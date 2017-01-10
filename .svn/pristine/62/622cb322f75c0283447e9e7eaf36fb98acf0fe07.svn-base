
    //创建和初始化地图函数：
function initMap() {
    createMap();
        setMapEvent(); //设置地图事件
        addMapControl(); //向地图添加控件
    }

//创建地图函数：
function createMap() {
    var map = new BMap.Map("dituContent"); //在百度地图容器中创建一个地图
    window.map = map; //将map变量存储在全局
}

function setMapcenter(lng, lat) {
    var point = new BMap.Point(lng, lat); //定义一个中心点坐标
    map.centerAndZoom(point, 12); //设定地图的中心点和坐标并将地图显示在地图容器中

}

//地图事件设置函数：
function setMapEvent() {
    map.enableDragging(); //启用地图拖拽事件，默认启用(可不写)
    map.enableScrollWheelZoom(); //启用地图滚轮放大缩小
    map.enableDoubleClickZoom(); //启用鼠标双击放大，默认启用(可不写)
    map.enableKeyboard(); //启用键盘上下左右键移动地图
}

//地图控件添加函数：
function addMapControl() {
    //向地图中添加缩放控件
    var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
    map.addControl(ctrl_nav);
    //向地图中添加缩略图控件
    var ctrl_ove = new BMap.OverviewMapControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, isOpen: 1 });
    map.addControl(ctrl_ove);
    //向地图中添加比例尺控件
    var ctrl_sca = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT });
    map.addControl(ctrl_sca);
}

// 编写自定义函数，创建标注   
function addMarker(lng,lat, index, ptitle, pword, plink) {

    var point = new BMap.Point(lng, lat);
    // 创建图标对象   
    var letter = String.fromCharCode(0x41 + index);
    iconimage = "/Images/marker/marker" + letter + ".png";

    var myIcon = new BMap.Icon(iconimage, new BMap.Size(20, 34), {
        // 指定定位位置。   
        // 当标注显示在地图上时，其所指向的地理位置距离图标左上   
        // 角各偏移10像素和25像素。您可以看到在本例中该位置即是   
        // 图标中央下端的尖角位置。   
        offset: new BMap.Size(0, 0),
        // 设置图片偏移。   
        // 当您需要从一幅较大的图片中截取某部分作为标注图标时，您   
        // 需要指定大图的偏移位置，此做法与css sprites技术类似。   
        imageOffset: new BMap.Size(0, 0)   // 设置图片偏移   
    });

    // 创建标注对象并添加到地图   
    var marker = new BMap.Marker(point, { icon: myIcon });
    map.addOverlay(marker);


    //移除标注
    marker.addEventListener("click", function () {
        //            map.removeOverlay(marker);
        //            marker.dispose();

        var opts = {
            width: 250,     // 信息窗口宽度   
            height: 100,     // 信息窗口高度   
            title: ptitle  // 信息窗口标题
        }

        var infoWindow = new BMap.InfoWindow("<a href='" + plink + "' target='_blank'>" + pword + "</a>", opts);  // 创建信息窗口对象
        marker.openInfoWindow(infoWindow, this.point);      // 打开信息窗口


    });
}
