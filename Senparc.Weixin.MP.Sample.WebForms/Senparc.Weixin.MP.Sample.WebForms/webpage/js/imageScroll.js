var SellerScroll = function (options) {
        this.SetOptions(options);
        this.lButton = this.options.lButton;
        this.rButton = this.options.rButton;
        this.oList = this.options.oList;
        this.showSum = this.options.showSum;

        this.iList = $("#" + this.options.oList + " > li");
        this.iListSum = this.iList.length;
        this.iListWidth = this.iList.outerWidth(true);
        this.moveWidth = this.iListWidth * this.showSum;

        this.dividers = Math.ceil(this.iListSum / this.showSum);    //共分为多少块  
        this.moveMaxOffset = (this.dividers - 1) * this.moveWidth;
        this.LeftScroll();
        this.RightScroll();
    };
    SellerScroll.prototype = {
        SetOptions: function (options) {
            this.options = {
                lButton: "left_scroll",
                rButton: "right_scroll",
                oList: "carousel_ul",
                showSum: 4  //一次滚动多少个items  
            };
            $.extend(this.options, options || {});
        },
        ReturnLeft: function () {
            return isNaN(parseInt($("#" + this.oList).css("left"))) ? 0 : parseInt($("#" + this.oList).css("left"));
        },
        LeftScroll: function () {
            if (this.dividers == 1) return;
            var _this = this, currentOffset;
            $("#" + this.lButton).click(function () {
                currentOffset = _this.ReturnLeft();
                if (currentOffset == 0) {
                    for (var i = 1; i <= _this.showSum; i++) {
                        $(_this.iList[_this.iListSum - i]).prependTo($("#" + _this.oList));
                    }
                    $("#" + _this.oList).css({ left: -_this.moveWidth });
                    $("#" + _this.oList + ":not(:animated)").animate({ left: "+=" + _this.moveWidth }, {
                        duration: "slow", complete: function () {
                            for (var j = _this.showSum + 1; j <= _this.iListSum; j++) {
                                $(_this.iList[_this.iListSum - j]).prependTo($("#" + _this.oList));
                            }
                            $("#" + _this.oList).css({ left: -_this.moveWidth * (_this.dividers - 1) });
                        }
                    });
                } else {
                    $("#" + _this.oList + ":not(:animated)").animate({ left: "+=" + _this.moveWidth }, "slow");
                }
            });
        },
        RightScroll: function () {
            if (this.dividers == 1) return;
            var _this = this, currentOffset;
            $("#" + this.rButton).click(function () {
                currentOffset = _this.ReturnLeft();
                if (Math.abs(currentOffset) >= _this.moveMaxOffset) {
                    for (var i = 0; i < _this.showSum; i++) {
                        $(_this.iList[i]).appendTo($("#" + _this.oList));
                    }
                    $("#" + _this.oList).css({ left: -_this.moveWidth * (_this.dividers - 2) });

                    $("#" + _this.oList + ":not(:animated)").animate({ left: "-=" + _this.moveWidth }, {
                        duration: "slow", complete: function () {
                            for (var j = _this.showSum; j < _this.iListSum; j++) {
                                $(_this.iList[j]).appendTo($("#" + _this.oList));
                            }
                            $("#" + _this.oList).css({ left: 0 });
                        }
                    });
                } else {
                    $("#" + _this.oList + ":not(:animated)").animate({ left: "-=" + _this.moveWidth }, "slow");
                }
            });
        }
    };