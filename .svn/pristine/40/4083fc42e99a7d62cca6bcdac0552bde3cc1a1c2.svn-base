
  
  var initDetailTab = function() {
      $.each(['introduce', 'comment', 'parameters', 'warranty', 'information'], function(k, v) {
        $('#t_' + v).attr('n', v);
        $('#t_' + v).click(function() {
          $('#introduction .x_mod_tab_hd li').filter('.current').removeClass('current');
          $("#introduction .x_mod_tab_hd li").filter('#t_' + $(this).attr('n')).addClass('current');

          $('#introduction .x_mod_tab_bd').children().filter(':visible').hide();
          var jc = $('#c_' + $(this).attr('n'));          

          if ($(this).attr('n') == 'warranty') {
            $(document).trigger('tab_customer_service', [itemInfo]);
          }
          if ($(this).attr('n') == 'information') {
            $(document).trigger('tab_information', config.information_url);
          }          

          jc.show();
          /**
           * 如果用户处于“产品介绍”“规格参数”“包装清单”“售后服务”这几个tab时，当他的鼠标滚动至tab底部，页面显示出评论模块
           * 用户点击tab，必须切换到顶部给用户看
           * by addisonxue
           * start
           */
          if ($(this).attr('n') != 'comment') {
            
          } else {
            $('#intro-main_tab').append($('#c_comment'));
            $('#J_reviews').hide();
          }
          if ($('#introduction').hasClass('xoverview_fixed')) {
            $('#introduction')[0].scrollIntoView(true);
            $('#introduction').removeClass('xoverview_fixed');
          }
          /**
           * end
           */
         
        });
      });
    };
  var pagedetailinit = function() {
      var review_wrap = $('#sea_review_wrap');
      if (review_wrap.size() > 0) {
        var content_wrap = review_wrap.find('p'),
          content = content_wrap.text();
        if (content.length > 88) {
          content_wrap.attr('title', content);
          content = content.substr(0, 85) + '...';
          content_wrap.text(content);
        }
        review_wrap.show();
      }

      G.app.itemDetail = G.app.itemDetail || {};

      initDetailTab();
      var self = G.app.itemDetail;

      $('#introduction .x_mod_tab_nav li a:first').click(); //显示第一个tab
      var reviewInit = false;
     
      if (config.lv & level.REVIEW) {
        self.review.getReviewProperty(function() {
          if (location.hash.indexOf('#review_box') == 0 || location.hash.indexOf('#introduction') == 0) {
            $('#t_comment').click();
          }
        });
      }
      $('#sea_review_box').click(function() {
        $('#t_comment').click();
      });


      /**
       * 添加tab标签随屏幕滚动
       * by addisonxue
       * start
       */
      var isIE6 = false;
      //isIE6以后优化的时候可以单独弄个全局变量
      if ($.browser.msie && ($.browser.version == "6.0") && !$.support.style) {
        isIE6 = true;
      }
      var introduction = $('.grid_m_inner');
      var tablist = $('#introduction');

      $(window).bind("scroll resize", function() {
        //计算top，left，bottom时候，因为一些页面内容填充是动态的，会导致reflow，所以domReady计算这个取不到准确值，得从新计算
        var introductionTop = introduction.offset().top;
        var introductionBottom = introductionTop + introduction[0].offsetHeight;
        var winHeight = $(window).height();
        var scrollTop = $(window).scrollTop();
        if (scrollTop > introductionTop && scrollTop <= introductionBottom) {
          tablist.addClass('xoverview_fixed');
        } else if (scrollTop > introductionBottom) {
          tablist.removeClass('xoverview_fixed');
        } else if (scrollTop < introductionTop) {
          tablist.removeClass('xoverview_fixed');
        }
        /**
         * 延时评论的加载，当滚动条滚动到适当位置的时候才加载
         */
        var _jc = $('#c_comment');
        _jc.show();

        if (scrollTop + winHeight >= $('#J_reviews').offset().top) {
          if (_jc.data('contentLoaded') != 1) {
            if (config.lv & level.REVIEW) {
              G.app.itemDetail.review.init();
            }
            _jc.data('contentLoaded', 1);
          }
        }

      });
    };

/*  |xGv00|60c016d497ddd4552fed7c187e602791 */