G.app.itemDetail.review = {
	DOMAIN:'pinglun.yixun.com',
	_tpropertyload:false,
	_tscorepropertyload:false,
	_cacheBuster:0,
	_tagid:0,
	_tload:{
		scoreSort:false,
		tag:false
	},
	_ttype:{
		scoreSort:false
	},
	_num: {
		reviews: {},
		sort_reviews:{},
		askings: {}
	},
	_c: {
		reviews: 0,
		askings: 0
	},
	_t: {
		reviews: {
			0: ['allreview', '全部', ['暂无用户发表评论。']],
			1: ['satisfiedexperience', '满意', ['暂无用户发表该类体验评论。', '只有购买过该商品的用户才能发表体验评论。<a href="http://pinglun.yixun.com/review-toaddexperience-{pid}.html" onclick="G.app.itemDetail.review.checkCanAddExperience();return false">我要发表体验评论>></a>']],
			2: ['generalexperience', '一般', ['暂无用户发表该类体验评论。', '只有购买过该商品的用户才能发表体验评论。<a href="http://pinglun.yixun.com/review-toaddexperience-{pid}.html" onclick="G.app.itemDetail.review.checkCanAddExperience();return false">我要发表体验评论>></a>']],
			3: ['unsatisfiedexperience', '不满意', ['暂无用户发表该类体验评论。', '只有购买过该商品的用户才能发表体验评论。<a href="http://pinglun.yixun.com/review-toaddexperience-{pid}.html" onclick="G.app.itemDetail.review.checkCanAddExperience();return false">我要发表体验评论>></a>']]
		},
		askings: {
			0: ['allasking', '全部咨询', ['暂无相关咨询。']],
			1: ['asking', '商品咨询', ['暂无相关咨询。']],
			2: ['tranandpayasking', '配送/支付', ['暂无相关咨询。']],
			3: ['invoiceandmaintasking', '发票/保修', ['暂无相关咨询。']]
		}
	},
	_tp: {
		1: '满意',
		2: '一般',
		3: '不满意',
		4: '讨论',
		5: '商品咨询',
		6: '配送/支付',
		7: '发票/保修'
	},
	_template:{
		brief:"																																\
  <div class='xrating'>       																												\
    <div class='xrating_row1 clearfix'>       																								\
      <div class='xrating_col'>       																										\
        <div class='xrating_score'>       																									\
          <div class='xrating_score_val'>{pingfen}</div>        																			\
          <div class='xrating_score_unit'>分</div>       																					\
        </div>        																														\
      </div>        																														\
      <div class='xrating_col'>       																										\
          <div class='xrating_bar'>       																									\
            <div class='xrating_bar_bg clearfix' style='width:{pingfen_rate}%;'>        													\
              <div class='xrating_bar_bg_inner'>        																					\
                <div class='xrating_bar_col xrating_bar_col1'></div>        																\
                  <div class='xrating_bar_col xrating_bar_col2'></div>        																\
                  <div class='xrating_bar_col xrating_bar_col3'></div>        																\
                  <div class='xrating_bar_col xrating_bar_col4'></div>        																\
                  <div class='xrating_bar_col xrating_bar_col5'></div>        																\
              </div>        																												\
                </div>        																												\
                <div class='xrating_bar_bd clearfix'>       																				\
                  <div class='xrating_bar_col'>非常不满意</div>        																		\
                  <div class='xrating_bar_col'>不满意</div>        																			\
                  <div class='xrating_bar_col'>一般</div>       																			\
                  <div class='xrating_bar_col'>满意</div>       																			\
                  <div class='xrating_bar_col'>非常满意</div>       																		\
                </div>        																												\
                <div class='xrating_bar_tips' style='left:{pingfen_rate_width}px;'>       													\
                  <div class='xrating_bar_tips_bd'>{pingfen}</div>        																	\
                  <div class='xrating_bar_tips_arr'>◆</div>       																			\
                </div>        																												\
          </div>        																													\
          <div class='xrating_count'>共<strong class='xreview_num xrating_count_num'>{experience_number}</strong>位迅友参与评分</div>       \
        </div>        																														\
    </div>              																													\
    <div class='xrating_row2 xrating_summary clearfix' id='performance_box' style='display:none'>       									\
      <div class='xrating_summary_col1'>        																							\
          <strong>性能调查：</strong>       																								\
      </div>        																														\
      <div class='xrating_summary_col2' id='performance_list'>        																		\
      </div>        																														\
    </div>        																															\
  </div>        																															\
  <div class='xreview_action'>        																										\
    <div class='xreview_action_item clearfix'>        																						\
      <a ytag='17771' href='http://pinglun.yixun.com/review-toaddexperience-{pid}.html' onclick='G.app.itemDetail.review.checkCanAddExperience();return false' class='xreview_btn btn_common'><span>发表评论得积分</span></a>        \
      <span class='xreview_action_con'><span>前5名评价用户将获得双倍积分（10积分=1元）。</span><a class='xreview_lk' href='http://st.yixun.com/help/1-3-points.htm' target='_blank'>积分规则&gt;&gt;</a></span>        \
    </div>        																															\
    <div class='xreview_action_item clearfix'>        																						\
      <a ytag='17772' class='xreview_btn btn_common post_asking'  target='_blank'><span>有问题？去咨询</span></a>        					\
          <span class='xreview_action_con'><span>为您提供商品疑问解答。</span></span>        												\
    </div>        																															\
  </div>        ",

  review_list:"<@list@><li {same_cm_item}>               																					\
    <div class='user'>                																										\
      <img width='60' height='60' src='http://st.icson.com/static_v1/img/guest/guest{pic_order}_60.gif'>                					\
      <span class='name'>{user_name}</span> <span class='level'>{user_level_name}</span>                									\
    </div>                																													\
    <div class='cont'>                																										\
      <div class='title'>{type_chn}{stars}{same_cm_link}<span class='date'>{create_time_chn}</span></div>               					\
      <div class='text'>{content}</div>               																						\
      <div class='wrap_btn'>                																								\
        <a href='#' rdown='{id}' onclick='return false'>踩({objector})</a>               													\
        <a href='#' rup='{id}' onclick='return false'>顶({supporter})</a>                													\
      </div>                																												\
      <div class='reply' id='replylist_{type}_{id}' total='{replies_number}' open='0'{attr_addition}>               						\
        <div class='arrow_top'><i>◆</i></div>               																				\
        <p class='reply_more'{ifkillReplyMore}><a href='#' replylist='{id}' rtype='{type}' onclick='return false'>查看全部{replies_number}条回复&gt;&gt;</a></p>               \
        <ul class='list_reply'>               																								\
          <@replies_all@><li>               																								\
            <div class='reply'>               																								\
              <div class='reply_user'><img width='40' height='40' src='http://st.icson.com/static_v1/img/guest/guest{pic_order}_40.gif' /></div>                \
              <div class='reply_cont'><p class='reply_text'><strong class='reply_name'>{user_name}回复：</strong>{content}</p>              \
              <p class='reply_date'>{reply_date_chn}</p>                																	\
            </div>                																											\
          </li><@_replies_all@>               																								\
        </ul>               																												\
      </div>                																												\
    </div>                																													\
        {same_cm_line}                																										\
  </li>{same_cm_content}<@_list@>",

  review_reply_list:"<@list@><li>																											\
		<div class='reply'>																													\
		  <div class='reply_user'><img width='40' height='40' src='http://st.icson.com/static_v1/img/guest/guest{pic_order}_40.gif' /></div>\
		  <div class='reply_cont'><p class='reply_text'><strong class='reply_name'>{user_name}回复：</strong>{content}</p>					\
		  <p class='reply_date'>{reply_date_chn}</p>																						\
		</div>																																\
		</li><@_list@>",

  asking_list:"<@list@><li>        																											\
		  <div class='user'>        																										\
		    <img width='35' height='35' src='http://st.icson.com/static_v1/img/guest/guest{pic_order}_35.gif'>        						\
		    <span class='name'>{user_name}</span> <span class='level'>{user_level_name}</span>        										\
		  </div>        																													\
		  <div class='cont'>        																										\
		    <div class='title'>{type_chn}{stars}<span class='date'>{create_time_chn}</span></div>       									\
		    <div class='text'>{content}</div>       																						\
		    <div class='reply' id='replylist_{type}_{id}' total='{replies_number}' open='0'{attr_addition}>       							\
		      <p class='reply_more'{ifkillReplyMore}><a href='#' replylist='{id}' rtype='{type}' onclick='return false'>查看全部{replies_number}条回复&gt;&gt;</a></p>       \
		      <div class='arrow_top'><i>◆</i></div>       																					\
		      <ul class='list_reply'>       																								\
		        <@replies_all@><li>       																									\
		          <div class='reply'>       																								\
		            <div class='reply_cont'><p class='reply_text'><strong class='reply_name'>{user_name}回复：</strong>{content}</p>       	\
		            <p class='reply_date'>{reply_date_chn}</p>        																		\
		          </div>        																											\
		        </li><@_replies_all@>       																								\
		      </ul>       																													\
		    </div>        																													\
		  </div>        																													\
		</li><@_list@>"
	},
	_jhistory: {},

	_getEmptyReviewDesc: function(desc) {
		var out = '',
			replacePid = function(str) {
				return str.replace(/\{pid\}/g, itemInfo.pid);
			};
		if ($.type(desc) == 'array') {
			var first = desc.shift();
			out = '<div class="tips_cont"><p><strong class="strong">' + replacePid(first) + '</strong></p>';
			$.each(desc, function(k, de) {
				out += '<p>' + replacePid(de) + '</p>';
			});
			out += '</div>';
			desc.unshift(first);
		} else {
			out = '<div class="tips_cont"><p><strong class="strong">' + replacePid(desc) + '</strong></p>';
		}
		return out;
	},

	_getExpDesc: function(star) {
		if (star == 3) return '一般';
		return star > 3 ? '满意' : '不满意';
	},

	_parseUser: function(v) {
		v.user_level = v.user_level > 6 ? 6 : v.user_level;
		v.user_level_name = G.logic.constants.userLevelName[v.user_level];
		v.pic_order = (v.is_icson_reply == 1) ? "Icson" : (v.user_level - 0 + 1);
		v.user_name = v.is_icson_reply == 1 ? "易迅网" : v.user_name;
	},

	_printReviews: function(list) {
		var self = G.app.itemDetail.review,
			len = 0;

		$.each(list, function(k, v) {
			var tp_chn = v.type >= 1 && v.type <= 3 ? '体验' : '讨论',
				is_best_html = (v.is_best == 1) ? '<a class="best" href="javascript:void(0);" title="精华"></a>' : '',
				is_top_html = (v.is_top == 1) ? '<a class="d_mod_btnstick" href="javascript:void(0);" title="置顶"><i class="d_ico d_ico_stick"></i></a>' : '',
				moreDesc = '';

			//v.user_name = v.user_nick || v.user_name;
			v = self._encode(v);
			v.type_chn = (v.type >= 1 && v.type <= 3) ? '' : '<span class="comment_sort">' + is_best_html + is_top_html + '</span>';
			v.content = v.content.replace(/\n/g, "    ").replace(/\s{4,}/g, '    ').replace(/ /g, '&nbsp;');
			v.create_time_chn = G.util.parse.timeFormat(v.create_time, 'y-m-d h:i:s');
			v.stars = (v.type >= 1 && v.type <= 3) ? ('<span class="comment-txt"><span class="icon_star"><b style="width: ' + (20 * v.star) + '%;"></b></span></span><span class="coment_tit"><strong>' + v.star + '分 ' + self._getExpDesc(v.star) + '</strong>' + is_best_html + is_top_html + '</span>') : '';
			self._parseUser(v);

			v.replies_all = [];
			$.each(v.replies, function(kk, reply) {
				reply = self._encode(reply);
				self._parseUser(reply);
				reply.content = reply.content.replace(/\n/g, "    ").replace(/\s{4,}/g, '    ').replace(/ /g, '&nbsp;');
				reply.reply_date_chn = G.util.parse.timeFormat(reply.create_time, 'y-m-d h:i:s');
				v.replies_all.push(reply);
			});

			if (v.replies_all.length > 3) v.replies_all.length = 3;

			if (v.replies_number <= 3) {
				v.ifkillReplyMore = ' style="display:none"';
			}

			if (v.replies_number <= 0) {
				v.attr_addition = ' style="display:none"';
			}

			list[k] = v;
			len++;
		});

			//@2013-02-27 添加合并相同用户相同评论逻辑 pascalli
			$.each(list, function(k, v) {
				var list_len = list.length;
				
				list[k].same_cm = [];		//添加同一用户相同评论字段
				list[k].is_same = list[k].is_same || 0;		//被合并标志位,值为“1”则当前评论已被合并
				
				for(var i = k ,l = list_len; i + 1 < l; i++){
					
					list[i+1].is_same = list[i+1].is_same || 0;
					//检查用户ID和对应的评论内容
					//2013.03.20修改为当页 //&& v.content == list[i+1].content
					if(v.user_id == list[i+1].user_id && list[i+1].is_same == 0){
						v.same_cm.push(list[i+1]);
						list[i+1].is_same = 1;
						list[i+1].same_cm = [];
						list[i+1].same_cm_item = 'class="same_cm_'+v.id+'" style="display:none"';
						list[i+1].same_cm_line = "";
					}	
				}
				
				list[k].same_cm_line = v.same_cm.length > 0 ?'<i class="same_cm_line same_cm_line_'+v.id+'"></i>':"";
				list[k].same_cm_link = v.same_cm.length > 0 ?'<span class="same_cm_link" style="cursor:pointer" uid="'+v.id +'" ytag="20001" title="该用户的其他类似评论">该用户的其他类似评论</span>' : "";
				
				//将相同评论填充模板
				if(!v.is_same && v.same_cm.length > 0){
					//v.same_cm_content =G.ui.template.fillWithTPL(false, {list:v.same_cm}, "review_list_tpl",false,true);
					/*G.ui.template.fillWithTPL('review_brief', {pid: itemInfo.pid},false,self._template.brief);*/
					v.same_cm_content =G.ui.template.fillWithTPL(false, {list:v.same_cm},false,self._template.review_list,true);
				}else{
					v.same_cm_content = "";
				}				
			});
			
			//去除list中被合并的项目
			for(var j = list.length; j > 0; j--){
				if(list[j - 1].is_same == 1){
					list.splice(j - 1,1);	
				}
			}
			
			if (len == 0) {
				$('#review_content .list_comment').empty().html(self._getEmptyReviewDesc(self._t.reviews[self._c.reviews][2]));
			} else {
				//var wrap = $('#review_content .list_comment').empty().html(G.ui.template.fillWithTPL(false, {
				//	list: list
				//}, 'review_list_tpl'));
				var wrap = $('#review_content .list_comment').empty().html(G.ui.template.fillWithTPL(false, {list:list},false,self._template.review_list,true));

				$('.reply a[replylist]', wrap).click(self.loadReplyList);
				$('.wrap_btn a[rup]', wrap).click(self.setLike);
				$('.wrap_btn a[rdown]', wrap).click(self.setUnlike);
				$('.same_cm_link').click(function(){
					var uid = $(this).attr("uid");
					$(".same_cm_"+uid).slideToggle("fast");
					$(".same_cm_line_"+uid).slideToggle("fast");
					$(this).toggleClass("same_cm_link_unfold");
				})
			}
	},

	_printTagsReviewPage: function(page,total) {
		var self = G.app.itemDetail.review;
		totalPage = Math.ceil(total / 10);
		window.showReviewPage = self.getTagReviewsPage;

		if (totalPage <= 1) {
			$('#review_page').empty().parent().hide();
		} else {
			$('#review_page').empty().html(G.ui.page("javascript:showReviewPage('{page}')", page, totalPage, 4)).parent().show();
		}
	},

	_printReviewPage: function(page) {
		var self = G.app.itemDetail.review;
		var totalPage = 0;
		if(self._ttype.scoreSort){
			if(typeof(self._num.sort_reviews[self._c.reviews])=="undefined"){
				totalPage = Math.ceil(self._num.reviews[self._c.reviews] / 10);
			}else{
				totalPage = Math.ceil(self._num.sort_reviews[self._c.reviews] / 10);	
			}
			
		}else{
			totalPage = Math.ceil(self._num.reviews[self._c.reviews] / 10);
		}
		window.showReviewPage = self.getReviewsPage;

		if (totalPage <= 1) {
			$('#review_page').empty().parent().hide();
		} else {
			$('#review_page').empty().html(G.ui.page("javascript:showReviewPage('{page}')", page, totalPage, 4)).parent().show();
		}
	},

	setLike: function() {
		var rid = $(this).attr('rup'),
			ruid = $(this).attr('uid'),
			rtype = $(this).attr('rtype'),
			self = G.app.itemDetail.review;

		if (self._jhistory[rid] == 1) {
			G.ui.popup.showMsg('您已经投过票了。');
			return false;
		}
		self._judgeReview(rid, rtype, 1, $(this));
	},

	setUnlike: function() {
		var rid = $(this).attr('rdown'),
			ruid = $(this).attr('uid'),
			rtype = $(this).attr('rtype'),
			self = G.app.itemDetail.review;

		if (self._jhistory[rid] == 1) {
			G.ui.popup.showMsg('您已经投过票了。');
			return false;
		}

		self._judgeReview(rid, rtype, 2, $(this));
	},

	checkCanAddExperience: function() {
		var timeStat=[];timeStat[0]=new Date();
		if (G.logic.login.ifLogin(this, arguments) === false) return;

		var uid = G.logic.login.getLoginUid(),
			pid = itemInfo.pid;
	
		$.ajax( {
			url : G.util.token.addToken('http://' + G.app.itemDetail.review.DOMAIN + '/json.php?mod=review&act=canaddexperience&fmt=0&uid=' + uid,'jq'),
			data : { pid: pid },
			dataType : 'jsonp',
			success : function( o ) {
				if (o && o.errno != 0) {
					//用户去评论已作废或取消的订单，提示为尚未出库而不是没有购买
					//2013-01-31 pascalli 修改点：增加状态28,修改状态23
					//2013-02-17 pascalli 修改点：增加错误处理中遗漏的else分支及对应的默认文案。
					var messageMap = {
						18	: '您没有购买过该商品，无法发表体验评论，请选择发表商品讨论',
						21	: '您已经对该商品发表过体验评论了！',
						23	: '您尚未购买该商品，无法发表体验评论，欢迎您发表商品讨论或购买后评价。',    //'订单尚未出库，无法发表体验评论！',
						24	: '订单出库48小时之后方可发表体验评论！',
						25	: '您暂时无法对该商品发表体验评论！',
						26	: '您购买的商品已经超过了可评论的期限，您可以对三个月之内的订单发表体验评论并获取积分。感谢您对易迅网的一如既往的支持！',
						28	: '您的订单尚未完成，暂时无法发表体验评论。'
					};

					if ((o.errno-0) in messageMap) {
						return G.ui.popup.showMsg(messageMap[o.errno]);
					}else{
						return G.ui.popup.showMsg("对不起，系统繁忙中，请您稍候重试。");
					}
					
				}
			
				timeStat[1]=new Date() - timeStat[0];
				G.util.ping.timeStat(timeStat,81,8);
				location.href = 'http://pinglun.yixun.com/review-toaddexperience-' + pid + '.html';	
			}
		} );
	},


	_judgeReview: function(rid, rtype, option, btnTarget) {
		var timeStat=[];timeStat[0]=new Date();
		
		if (G.logic.login.ifLogin(this, arguments) === false) return;

		var uid = G.logic.login.getLoginUid();
		$.ajax( {//&callback=G.app.itemDetail.review.checkJudgeReviewCallback
			url : G.util.token.addToken('http://' + G.app.itemDetail.review.DOMAIN + '/json1.php?mod=reviews&act=judge&fmt=0&uid=' + uid,'jq'),
			data :  {
			review_id: rid,
			type: rtype,
			option: option,
			pid: itemInfo.pid
		    },
			dataType : 'jsonp',
			success : function( o ) {
				if (o && o.errno == 0) {
					G.app.itemDetail.review._jhistory[rid] = 1;
					var regex = /.*?\((\d+)\)\s*$/,
						text = btnTarget.html();
					if (regex.test(text)) {
						btnTarget.html('已投票' + text.replace(regex, function(all, c) {
							return '(' + (c - 0 + 1) + ')';
						}));
					}
				} else {
					return G.ui.popup.showMsg('对不起，操作失败');
				}

				timeStat[1]=new Date() - timeStat[0];
				G.util.ping.timeStat(timeStat,81,7);
			}
		} );
	},
	
	


	loadReplyList: function() {
		var self = G.app.itemDetail.review,
			rid = $(this).attr('replylist'),
			rtype = $(this).attr('rtype');

		self._loadReplyList(rid, rtype);
	},

	_loadReplyList: function(rid, rtype, checkToggle) {
		var timeStat=[];timeStat[0]=new Date();
		var self = G.app.itemDetail.review,
			replybox = $('#replylist_' + rtype + '_' + rid),
			urlAddition = checkToggle && replybox.attr('open') != 1 ? '&begin=-4&quatity=4' : '';

		$.get(G.util.token.addToken('http://' + G.app.itemDetail.review.DOMAIN + '/json1.php?mod=reviews&act=getreplylist&jsontype=str' + urlAddition,'jq'), {
			review_id: rid,
			type: rtype
		}, function(o) {
			$('.list_reply li', replybox).each(function() {
				if (!$(this).hasClass('reply_fabiao')) $(this).remove();
			});
			if (o && !o.errno) {
				var reply_list = [],
					total = replybox.attr('total');

				$.each(o, function(k, reply) {
					reply = self._encode(reply);
					self._parseUser(reply);
					reply.content = reply.content.replace(/\n/g, "    ").replace(/\s{4,}/g, '    ').replace(/ /g, '&nbsp;');
					reply.reply_date_chn = G.util.parse.timeFormat(reply.create_time, 'y-m-d h:i:s');
					reply_list.push(reply);
				});

				if (checkToggle && replybox.attr('open') != 1) {
					if (reply_list.length > 3) {
						reply_list = reply_list.slice(-3);
					};
					if (total > 3) $('.reply_more', replybox).show();
				} else {
					replybox.attr('open', 1);
					$('.reply_more', replybox).hide();
				}

				//$('.list_reply', replybox).prepend($(G.ui.template.fillWithTPL(false, {
				//	list: reply_list
				//}, 'review_reply_list_tpl')));
				//
				$('.list_reply', replybox).prepend($(G.ui.template.fillWithTPL(false, {
					list: reply_list
				}, false,self._template.review_reply_list,true)));

			} else {
				G.ui.popup.showMsg('加载回复失败');
			}
			timeStat[1]=new Date() - timeStat[0];
			G.util.ping.timeStat(timeStat,81,4);
		}, 'jsonp');
	},

	getSortReviewProperty: function(callback) {
		var timeStat=[];timeStat[0]=new Date();
		var self = G.app.itemDetail.review;
		if(self._tscorepropertyload){//第二次进入
			if ($.isFunction(callback)) {
				callback();
			}
		}else{
			var url =G.util.token.addToken('http://' + G.app.itemDetail.review.DOMAIN + '/json1.php?mod=reviews&act=sortgetproperty&jsontype=str&pid=' + itemInfo.pid,'jq');
			$.ajax({
				url:self._timeUrl(url),
				type:'get',
				dataType:'jsonp',
				jsonpCallback:"suc_jsonp_getSortReviewProperty_callback",
				cache:false,
				timeout:10000,
				success: function(o){
					self._updateSortReviewStatus(o);
					self._tload.scoreSort = true;
					self._tscorepropertyload = true;
					if ($.isFunction(callback)) {
						callback();
					}
					timeStat[1]=new Date() - timeStat[0];
					G.util.ping.timeStat(timeStat,81,14);
				},
				error:function(o){
					$('#review_content .list_comment').empty().html(self._getEmptyReviewDesc('加载评论内容失败啦~ 请稍候重试 555~'));
				}
			});
		}
	},

	getReviewsPage2: function(page) {
		var self = G.app.itemDetail.review;
		self.getReviews(self._c.reviews, page);
	},

	getReviewsPage: function(page) {
		var self = G.app.itemDetail.review;
		try {
			$('#review_box')[0].scrollIntoView(true);
		} catch (e) {}

		self.getReviews(self._c.reviews, page);
	},

	getReviews: function(type, page) {
		var timeStat=[];timeStat[0]=new Date();
		var self = G.app.itemDetail.review;
		self.clearTagStatus();
		if (!(type in self._t.reviews)) type = 0;

		if (!page || page < 1) page = 1;
		$('#review_content .list_comment').empty().html('<span class="loading_58_58">正在加载中</span>');
		$('#review_page').empty().parent().hide();
		
		var url = '';
		if(G.app.itemDetail.review._ttype.scoreSort){
			url = self._timeUrl('http://' + self.DOMAIN + '/json1.php?mod=reviews&act=sortlist&jsontype=str&pid=' + itemInfo.pid + '&type=' + self._t.reviews[type][0] + '&page=' + page);
		}else{
			url = self._timeUrl('http://' + self.DOMAIN + '/json1.php?mod=reviews&act=getreviews&jsontype=str&pid=' + itemInfo.pid + '&type=' + self._t.reviews[type][0] + '&page=' + page);
		}

		$.ajax({
			url:G.util.token.addToken(url,'jq'),
			type:'get',
			dataType:'jsonp',
	        jsonpCallback:"suc_jsonp_getReviews_callback",
			cache:false,
			timeout:2000,
			scriptCharset:'gbk',
			success: function(o){				
				if (o && !o.errno && !o.errCode) {
					self._c.reviews = type;
					self._printReviews(o);
					self._printReviewPage(page);
				} else {
					$('#review_content .list_comment').empty().html(self._getEmptyReviewDesc('加载评论内容失败 请稍候重试 555~'));
				}

				timeStat[1]=new Date() - timeStat[0];
				if(G.app.itemDetail.review._ttype.scoreSort){
					G.util.ping.timeStat(timeStat,81,6);
				}else{
					G.util.ping.timeStat(timeStat,81,13);
				}
			},
			error:function(xhr, status, errorThrown){
				$('#review_content .list_comment').empty().html(self._getEmptyReviewDesc('加载评论内容失败 请稍候重试 555~'));
			}
		});
	},


	clearTagStatus : function(){
		$('#xclound_list').children().each(function(){
			var jTarget = $(this);
			if(jTarget.hasClass('xclound_item_selected')){
				jTarget.removeClass('xclound_item_selected');
			}
		});
	},

	getTagReviews: function(page) {
		var timeStat=[];timeStat[0]=new Date();
		var self = G.app.itemDetail.review;

		if (!page || page < 1) page = 1;

		$('#review_header li').each(function(i) { 
			var item = $(this);

			if(i == 0){
				if(!item.hasClass('status_on')){
					item.addClass('status_on');
				}
			}else{
				item.removeClass('status_on');
			}
		});
		
		$('#review_content .list_comment').empty().html('<span class="loading_58_58">正在加载中</span>');
		$('#review_page').empty().parent().hide();
		
		var url = self._timeUrl('http://' + self.DOMAIN + "/json1.php?mod=reviews&act=gettagreviews&jsontype=str&pid=" + itemInfo.pid + "&tid=" + self._tagid + "&page=" + page);

		$.ajax({
			url:G.util.token.addToken(url,'jq'),
			type:'get',
			dataType:'jsonp',
	        //jsonpCallback:"suc_jsonp_getTagsReviews_callback",
			cache:false,
			scriptCharset:'gbk',
			timeout:10000,
			success: function(o){
				if (o && !o.errno) {
					self._printReviews(o.data);
					self._printTagsReviewPage(page,o.total);
				} else {
					$('#review_content .list_comment').empty().html(self._getEmptyReviewDesc('拉取标签列表失败啦~ ,当前标签可能已下线，可尝试F5刷新页面 555~'));
				}

				timeStat[1]=new Date() - timeStat[0];
				G.util.ping.timeStat(timeStat,81,16);
				
			},
			error:function(xhr, status, errorThrown){
				$('#review_content .list_comment').empty().html(self._getEmptyReviewDesc('拉取标签列表失败啦~ ,当前标签可能已下线，可尝试F5刷新页面 555~'));
			}
		});
	},

	getTagReviewsPage: function(page) {
		var self = G.app.itemDetail.review;
		try {
			$('#review_box')[0].scrollIntoView(true);
		} catch (e) {}

		self.getTagReviews(page);
	},

	_timeUrl:function(o){
		return o + "&_ut=" + G.app.itemDetail.review._cacheBuster;
	},

	_updateReviewStatus: function(o) {
		var self = G.app.itemDetail.review;
		o = o || {};
		$.extend(self._num.reviews, {
			0: o.total || 0,
			1: o.satisfied || 0,
			2: o.general || 0,
			3: o.unsatisfied || 0
		});

		self._localUpdateReviewStatus();
	},

	_localUpdateReviewStatus:function(){
		var self = G.app.itemDetail.review;
		$.each(self._num.reviews, function(k, v) {
			if(k == 0){
				$('#review_header li[t=' + k + '] a').html(self._t.reviews[k][1]);
			}else{
				$('#review_header li[t=' + k + '] a').html(self._t.reviews[k][1] + '(' + v + ')');
			}
		});
	},

	_updateSortReviewStatus: function(o) {
		var self = G.app.itemDetail.review;
		o = o || {};
		$.extend(self._num.sort_reviews, {
			0: o.total || 0,
			1: o.satisfied || 0,
			2: o.general || 0,
			3: o.unsatisfied || 0
		});
		self._localUpdateSortReviewStatus();
	},

	_localUpdateSortReviewStatus:function(){
		var self = G.app.itemDetail.review;
		$.each(self._num.sort_reviews, function(k, v) {
			if( k == 0){
				$('#review_header li[t=' + k + '] a').html(self._t.reviews[k][1]);
			}else{
				$('#review_header li[t=' + k + '] a').html(self._t.reviews[k][1] + '(' + v + ')');
			}
		});
	},

	getReviewProperty: function(callback) {
		var timeStat=[];timeStat[0]=new Date();
		var self = G.app.itemDetail.review;

		if(self._tpropertyload){//第二次进入
			if(self._ttype.scoreSort && !self._tload.scoreSort){
				self.getSortReviewProperty(function() {
					if ($.isFunction(callback)) {
						callback();
					}
				});
			}else{
				if ($.isFunction(callback)) {
						callback();
				}			
			}
		}else{
			$.ajax({
				url:G.util.token.addToken(self._timeUrl('http://' + self.DOMAIN + '/json1.php?mod=reviews&act=getproperty&jsontype=str&pid=' + itemInfo.pid),'jq'),
				type:'get',
				cache : false,
				dataType:'jsonp',
	            //jsonpCallback:"suc_jsonp_getReviewProperty_callback",
	            scriptCharset:'gbk',
				timeout:10000,
				success: function(o){
					var timeStat=[];timeStat[0]=new Date();
					self._getReviewPropertySuc(o,callback);
					timeStat[1]=new Date() - timeStat[0];
					G.util.ping.timeStat(timeStat,81,5);
				}
			});
		}
	},

	_getReviewPropertySuc:function(o,callback){
		var self = G.app.itemDetail.review;
		self._updateReviewStatus(o);
		var pingfen = o.experience_number > 0 ? ((o.satisfaction || 0) / o.experience_number).toFixed(1) : '';
		if (o.experience_number <= 0 || o.errno || o.errCode) {
			$('#review_brief').empty().html(self._getEmptyReviewDesc(['暂无用户评分,只有购买过该商品的用户才可以进行评分。', '<a class="btn_strong" href="http://'+G.app.itemDetail.review.DOMAIN+'/review-toaddexperience-{pid}.html" onclick="G.app.itemDetail.review.checkCanAddExperience();return false">发表体验评论</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="hot">发表体验评论赠送积分(10积分=1元)，加为精华评论更有额外积分奖励！</span>']));
		} else {
			var top_users = [];
			var comma = '';
			$.each(o.top_users, function(k, tuser) {
				//tuser.name = comma + (tuser.nick || tuser.name);
				tuser.name = comma + (tuser.name);
				top_users.push(self._encode(tuser));
				comma = ', ';
			});

			/*G.ui.template.fillWithTPL('review_brief', {
				experience_number: o.experience_number,
				pingfen: pingfen,
				pingfen_rate: (pingfen * 20),
				pingfen_rate_width: ((pingfen * 20) * 450/100.0 - 12),
				rate: Math.round((o.satisfied || 0) * 100 / o.experience_number),
				top_users: top_users,
				pid: itemInfo.pid
			});*/
			//start
			G.ui.template.fillWithTPL('review_brief', {
				experience_number: o.experience_number,
				pingfen: pingfen,
				pingfen_rate: (pingfen * 20),
				pingfen_rate_width: ((pingfen * 20) * 450/100.0 - 12),
				rate: Math.round((o.satisfied || 0) * 100 / o.experience_number),
				top_users: top_users,
				pid: itemInfo.pid
			},false,self._template.brief);
			//end

			$('#product_pingfen').html('迅友评级：<span class="icon_star"><b style="width: ' + (pingfen * 20 - 1) + '%;"></b></span>(<a href="#introduction" ytag="67001" hotname="I.ITEM.REVIEWCOUNT">共' + o.total + '条评论</a>)').show();
			var lw = $('#review_brief .satisfaction').width() * pingfen * 20 / 100 - 35 - ($('#review_brief .satisfaction .point').width() / 2);
			$('#review_brief .satisfaction .point').css('left', lw + 'px');
		}

		$("#product_pingfen a").click(function() {
			$('#t_comment').click();
		});
		if ($.isFunction(callback)) {
			callback();
		}
		/**
		 * 直接在tab上显示评论数
		 * addisonxue
		 * start
		 */
		if (o && o.total != null) {
			if ($('#t_comment a').html().indexOf('(') < 0) {
				$('#t_comment a').html($('#t_comment a').html() + '(' + o.total + ')');
			}
		}

		if(o && o.total != null && o.list_type == 2){
			$('#sort_score').addClass("d_mod_btn6_on");
			self._ttype.scoreSort = true;
		}else{
			$('#sort_date').addClass("d_mod_btn6_on");
			self._ttype.scoreSort = false;
		}
		if(o && o.total != null && o.tag_min_quantity != null){
			if(o.tag_min_quantity == 65535){
				self._tload.tag = false;	
			}else{
				self._tload.tag = (o.total >= o.tag_min_quantity);
			}
		}

		self._tpropertyload = true;
		/**
		 * end
		 */
	},

	_printAskings: function(list) {
		var self = G.app.itemDetail.review,
			len = 0;
		$.each(list, function(k, v) {
			//v.user_name = v.user_nick || v.user_name;
			v = self._encode(v);
			v.type_chn = self._tp[v.type] ? ('<span class="comment_sort"><strong>[' + self._tp[v.type] + ']</strong></span>') : '';
			v.content = v.content.replace(/\n/g, "    ").replace(/\s{4,}/g, '    ').replace(/ /g, '&nbsp;');
			v.create_time_chn = G.util.parse.timeFormat(v.create_time, 'y-m-d h:i:s');
			v.user_level = v.user_level > 6 ? 6 : v.user_level;
			v.user_level_name = G.logic.constants.userLevelName[v.user_level];
			v.pic_order = v.user_level - 0 + 1;

			v.replies_all = [];
			$.each(v.replies, function(kk, reply) {
				reply = self._encode(reply);
				self._parseUser(reply);
				reply.content = reply.content.replace(/\n/g, "    ").replace(/\s{4,}/g, '    ').replace(/ /g, '&nbsp;');
				reply.reply_date_chn = G.util.parse.timeFormat(reply.create_time, 'y-m-d h:i:s');
				v.replies_all.push(reply);
			});

			if (v.replies_all.length > 3) v.replies_all.length = 3;
			var moreDesc = '';
			if (v.replies_number <= 3) {
				v.ifkillReplyMore = ' style="display:none"';
			}

			if (v.replies_number <= 0) {
				v.attr_addition = ' style="display:none"';
			}
			list[k] = v;
			len++;
		});

		if (len == 0) {
			$('#asking_content .list_comment').empty().html(self._getEmptyReviewDesc(self._t.askings[self._c.askings][2]));
		} else {
			//var wrap = $('#asking_content .list_comment').empty().html(G.ui.template.fillWithTPL(false, {
			//	list: list
			//}, 'asking_list_tpl'));
			var wrap = $('#asking_content .list_comment').empty().html(G.ui.template.fillWithTPL(false, {
				list: list
			}, false,self._template.asking_list,true));
			$('.reply a[replylist]', wrap).click(self.loadReplyList);
		}
	},

	_printAskingPage: function(page) {
		var self = G.app.itemDetail.review,
			totalPage = Math.ceil(self._num.askings[self._c.askings] / 10);
		window.showAskingPage = self.getAskingsPage;
		if (totalPage <= 1) {
			$('#asking_page').empty().parent().hide();
		} else {
			$('#asking_page').empty().html(G.ui.page("javascript:showAskingPage('{page}')", page, totalPage, 4)).parent().show();
		}
	},

	getAskingsPage: function(page) {
		var self = G.app.itemDetail.review;
		self.getAskings(self._c.askings, page);
	},

	getAskings: function(type, page) {
		var timeStat=[];
		timeStat[0]=new Date();
		var self = G.app.itemDetail.review;
		if (!(type in self._t.askings)) type = 0;

		if (!page || page < 1) page = 1;

		$('#asking_content .list_comment').empty().html('<span class="loading_58_58">正在加载中</span>');
		$('#asking_page').empty().parent().hide();


		$.ajax({
			url:G.util.token.addToken(self._timeUrl('http://' + G.app.itemDetail.review.DOMAIN + '/json1.php?mod=reviews&act=getaskings&jsontype=str&pid=' + itemInfo.pid + '&type=' + self._t.askings[type][0] + '&page=' + page),'jq'),
			type:'get',
			dataType:'jsonp',
	        jsonpCallback:"suc_jsonp_getAskings_callback",
			cache:false,
			timeout:10000,
			scriptCharset:'gbk',
			success: function(o){
				if (o && !o.errno && !o.errCode) {
					self._c.askings = type;
					self._printAskings(o);
					self._printAskingPage(page);

					if (location.hash.indexOf('#asking_box') == 0 && !self.__located) {
						setTimeout(function() {
							$('#asking_box')[0].scrollIntoView(true);
						}, 1);
						self.__located = true;
					}
				} else {
					$('#asking_content .list_comment').empty().html(self._getEmptyReviewDesc('加载咨询内容失败'));
				}
				timeStat[1]=new Date() - timeStat[0];
				G.util.ping.timeStat(timeStat,81,11);
			},
			error:function(xhr, status, errorThrown){
				$('#asking_content .list_comment').empty().html(self._getEmptyReviewDesc('加载咨询内容失败'));
			}
		});
	},
	getAskingCount: function(callback) {
		var timeStat=[];
		timeStat[0]=new Date();
		var self = G.app.itemDetail.review;
		$.get(G.util.token.addToken('http://' + G.app.itemDetail.review.DOMAIN + '/json1.php?mod=reviews&act=getaskingcount&jsontype=str&pid=' + itemInfo.pid,'jq'), function(o) {
			var oo = o || {};
			$.extend(self._num.askings, {
				0: oo.total || 0,
				1: oo.asking || 0,
				2: oo.transport || 0,
				3: oo.invoice || 0
			});

			$.each(self._num.askings, function(k, v) {
				$('#asking_header li[t=' + k + '] a').html(self._t.askings[k][1] + '(' + v + ')');
			});

			callback();
			timeStat[1]=new Date() - timeStat[0];
			G.util.ping.timeStat(timeStat,81,10);
		}, 'jsonp');
	},


	handleToggle: function(){
		var toggle = $('#xclound_box .xclound_toggle');
		if ($('#xclound_box .xclound_list_inner').height() <= 38) {
			toggle.hide();
		} else {
			toggle.show();
		}
	},


	loadTagsInfo:function(){
		var self = G.app.itemDetail.review;

		if(!self._tload.tag){
			return;
		}

		var timeStat=[];
		timeStat[0]=new Date();
		$.ajax({
				url:G.util.token.addToken(self._timeUrl('http://' + self.DOMAIN + '/json1.php?mod=reviews&act=gettags&jsontype=str&pid='+ itemInfo.pid),'jq'),
				type:'get',
				cache : false,
				dataType:'jsonp',
	            //jsonpCallback:"suc_jsonp_getTags_callback",
	            //scriptCharset:'gbk',
				timeout:10000,
				success: function(o){
					if (o && o.errno == 0) {
						var grps = [];
						//for (var i = 0; i < 3; i++) 
						{
							$.each(o.data, function( k , item) {
								grps.push(
									{
										tid: item.tagId,
										name: item.tagName,
										type: item.tagType,
										total: item.reviewNums
									}
								)
							});
						}
						grps.sort(function(a, b) {
							return (a.type*1000000 - a.total) - (b.type*1000000 - b.total);
						});

						var htm = [];
						$.each(grps, function(n,grp) {
							var cls = "";
							if (grp.type != 1){
								cls = " xclound_item_negative";
							}

							htm.push("<span class='xclound_item"+ cls +"'><a onclick='return false' href='#' tag_id="+grp.tid+">"+ grp.name +"(" + grp.total + ")<i></i></a></span>");							
						});
						if (htm.length > 0){
							$('#xclound_list').empty().html(htm.join(''));
							$('#xclound_box').show();
							self.handleToggle();
							timeStat[1]=new Date() - timeStat[0];
							G.util.ping.timeStat(timeStat,81,17);
						}else{
							timeStat[1]=new Date() - timeStat[0];
							G.util.ping.timeStat(timeStat,81,18);
						}
					}
					timeStat[1]=new Date() - timeStat[0];
					G.util.ping.timeStat(timeStat,81,15);
				}
			});
	},
	loadVoteInfo: function() {
		var self = G.app.itemDetail.review;
		self.loadTagsInfo();

		var timeStat=[];
		timeStat[0]=new Date();
		$.ajax({
				url:G.util.token.addToken(self._timeUrl('http://' + G.app.itemDetail.review.DOMAIN + '/json1.php?mod=reviews&act=getvotes&pid=' + itemInfo.pid),'jq'),
				type:'get',
				cache : false,
				dataType:'jsonp',
				scriptCharset:'gbk',
				success: function(o) {
					if (o && o.errno == 0 && !o.errCode) {
						// 分组
						var grps = {};
						$.each(o.data, function(k, item) {
							if (!grps[item.group_id]) {
								grps[item.group_id] = {
									gid: item.group_id,
									name: item.option_name1,
									order: item.order,
									list: {}
								};
							}
							grps[item.group_id].list[item.option_id] = {
								name: item.option_name2,
								score: item.score
							};
						});

						var gps = [];
						$.each(grps, function(k, grp) {
							gps.push(grp);
						});
						gps.sort(function(a, b) {
							return b.order - a.order;
						});

						var htm = [],
							ept = true;
						$.each(gps, function(k, grp) {
							var desc = [],
								sum = 0;
							$.each(grp.list, function(lk, ll) {
								if (ll.name == '一般') return;
								sum += ll.score - 0 ;
							});
							if (ept && sum > 0) ept = false;
							$.each(grp.list, function(lk, ll) {
								var rate = 0;
								if (sum != 0) {
									rate = Math.round(ll.score * 100 / sum);
								}
								if (ll.name == '满意') {
									htm.push("<span class='xrating_summary_param'>"+ grp.name +"：<strong class='xreview_num'>"+ (rate || 1) +"%</strong></span>");
								}
							});
							
						});
						if (!ept) {
							$('#performance_list').empty().html(htm.join(''));
							$('#performance_box').show();
							timeStat[1]=new Date() - timeStat[0];
							G.util.ping.timeStat(timeStat,81,19);
						}
					}
					timeStat[1]=new Date() - timeStat[0];
					G.util.ping.timeStat(timeStat,81,9);
				}
		});
	},
	loadAsking: function() { // 咨询模块加载函数
		var self = G.app.itemDetail.review;
		if (lossServiceLevel !== 2) { // lossService ：critical
			$('#asking_header li').each(function(i, item) { // 客户咨询
				$(item).click(function() {
					$('#asking_header li').removeClass('status_on');
					self.getAskings($(this).addClass('status_on').attr('t'), 1);
				});
			});
		}

		self.getAskingCount(function() {
			$('#asking_box').show();
			$('#asking_header li:first').click();
		});
	},
	init: function() {
		var self = G.app.itemDetail.review,
			$review_li = $('#review_header li').each(function(i, item) { //注册事件（全部评论、满意、一般、不满意、讨论）
				$(item).click(function() {
					$('#review_header li').removeClass('status_on');
					var target = $(this);

					if(self._ttype.scoreSort){
						self.getSortReviewProperty(function() {
							self.getReviews(target.addClass('status_on').attr('t'), 1); //获取评论第一页
						});
					}else{
						self.getReviews(target.addClass('status_on').attr('t'), 1); //获取评论第一页
					}
				});
			});

		if (lossServiceLevel !== 2) { // lossService ：critical
			self.getReviewProperty(function() { // 客户满意度
				/*
					$('#review_box').show();
					if (location.hash.indexOf('#review_box') == 0) {
						$('#review_box')[0].scrollIntoView(true);
					}
*/
				$review_li.first().click();
				self.loadVoteInfo(); // 性能调查
			});

			//$('#review_brief_box').show();

			//				$('#asking_header li').each(function(i, item) {// 客户咨询
			//					$(item).click(function() {
			//						$('#asking_header li').removeClass('status_on');
			//						self.getAskings($(this).addClass('status_on').attr('t'), 1);
			//					});
			//				});
			//
			//				self.getAskingCount(function() {
			//					$('#asking_box').show();
			//					$('#asking_header li:first').click();
			//				});
		} else {
			$review_li.first().click();
		}
		//发表咨询
		$('.post_asking').attr('href', 'http://'+G.app.itemDetail.review.DOMAIN+'/review-toaddasking-' + itemInfo.pid + '.html');
		$('.post_asking').click(function() {
			var callee = arguments.callee;
			var _msg = '</h4><h4 class="layer_global_tit">您必须手机验证才可以发表咨询！</h4>' +
				'<p class="todo_link">' +
				'<a class="tit" href="http://base.yixun.com/myprofile.html" target="_blank">现在进入验证页面&gt;&gt;</a>' +
				'</p><br/>';

			if (G.logic.login.ifLogin(this, arguments) === false) return false;

			G.logic.login.getLoginUser(function(o) {
				if (o && o.data && (o.data.bindMobile == 0)) {
					var dialog = G.ui.popup.showMsg(_msg, 1, function() {
						G.logic.login.getLoginUser(function(a) {
							if (a && a.data && (a.data.bindMobile == 1)) {
								location.href = 'http://'+G.app.itemDetail.review.DOMAIN+'/review-toaddasking-' + itemInfo.pid + '.html';
							} else {
								dialog.close();
								setTimeout(callee, 200);
							}
						}, false, true);
						return false;

					}, null, null, '已完成验证', '关闭');

					return false;
				} else {
					var url = G.util.token.addToken('http://' + G.app.itemDetail.review.DOMAIN + '/json.php?mod=review&act=canaddasking&pid='+ itemInfo.pid,'jq');
					$.get(url, function(o) {
						if (o && o.errno == 600) {
							return G.ui.popup.showMsg('您的发言频率过快，请稍候再发！');
						}
						if (o && o.errno == 601) {
							return G.ui.popup.showMsg('系统繁忙，请稍候再试！');
						}
						if (o && o.errno == 15) {
							var dialog = G.ui.popup.showMsg(_msg, 1, function() {
								G.logic.login.getLoginUser(function(a) {
									if (a && a.data && (a.data.bindMobile == 1)) {
										location.href = 'http://'+G.app.itemDetail.review.DOMAIN+'/review-toaddasking-' + itemInfo.pid + '.html';
									} else {
										dialog.close();
										setTimeout(callee, 200);
									}
								}, false, true);
								return false;

							}, null, null, '已完成验证', '关闭');
							return false;
						}
						location.href = 'http://'+G.app.itemDetail.review.DOMAIN+'/review-toaddasking-' + itemInfo.pid + '.html';
					}, 'jsonp');
				}
			}, false, false);
			return false;
		});

		$('.btn_rvsort1').each(function(){
			$(this).bind(
				"click",
				function() {
					if (!$(this).hasClass('d_mod_btn6_on')){
						$('.btn_rvsort1').each(function(){
							$(this).toggleClass("d_mod_btn6_on");
						});
					}

					var isScoreSort = ($(this).attr("id") == 'sort_score');
					G.app.itemDetail.review._ttype.scoreSort = isScoreSort;
					if(!G.app.itemDetail.review._tload.scoreSort){
						self.getSortReviewProperty(function() {
							self.getReviewsPage2(1);
						});
					}else{
						if(isScoreSort){
							self._localUpdateSortReviewStatus();
						}else{
							self._localUpdateReviewStatus();
						}
						self.getReviewsPage2(1);
					}
				});
		});

		G.logic.header.initTopAdvertise();

		//			G.app.itemDetail.group.init();
	},

	_encode: function(arr) {
		var newArr = {};
		$.each(arr, function(_k, _v) {
			if(typeof _v == 'string' && _k == "content"){
					newArr[_k] = _v;
					
			}else{
				newArr[_k] = typeof _v == 'string' ? G.util.parse.encodeHtml(_v) : _v;
			}
		});
		return newArr;
	}
};

(function($) {
	$.fn.autoResize = function(options) {
		// Just some abstracted details,
		// to make plugin users happy:
		var settings = $.extend({
			onResize: function() {},
			animate: true,
			animateDuration: 150,
			animateCallback: function() {},
			extraSpace: 20,
			limit: 1000
		},
		options);

		// Only textarea's auto-resize:
		this.filter('textarea').each(function() {

			// Get rid of scrollbars and disable WebKit resizing:
			var textarea = $(this).css({
				resize: 'none',
				'overflow-y': 'hidden'
			}),

				// Cache original height, for use later:
				origHeight = textarea.height(),

				// Need clone of textarea, hidden off screen:
				clone = (function() {

					// Properties which may effect space taken up by chracters:
					var props = ['height', 'width', 'lineHeight', 'textDecoration', 'letterSpacing'],
						propOb = {};

					// Create object of styles to apply:
					$.each(props,

					function(i, prop) {
						propOb[prop] = textarea.css(prop);
					});

					// Clone the actual textarea removing unique properties
					// and insert before original textarea:
					return textarea.clone().removeAttr('id').removeAttr('name').css({
						position: 'absolute',
						top: 0,
						left: -9999
					}).css(propOb).attr('tabIndex', '-1').insertBefore(textarea);

				})(),
				lastScrollTop = null,
				updateSize = function() {

					// Prepare the clone:
					clone.height(0).val($(this).val()).scrollTop(10000);

					// Find the height of text:
					var scrollTop = Math.max(clone.scrollTop(), origHeight) + settings.extraSpace,
						toChange = $(this).add(clone);

					// Don't do anything if scrollTip hasen't changed:
					if (lastScrollTop === scrollTop) {
						return;
					}
					lastScrollTop = scrollTop;

					// Check for limit:
					if (scrollTop >= settings.limit) {
						$(this).css('overflow-y', '');
						return;
					}
					// Fire off callback:
					settings.onResize.call(this);

					// Either animate or directly apply height:
					settings.animate && textarea.css('display') === 'block' ? toChange.stop().animate({
						height: scrollTop
					},
					settings.animateDuration, settings.animateCallback) : toChange.height(scrollTop);
				};

			// Bind namespaced handlers to appropriate events:
			textarea.unbind('.dynSiz').bind('keyup.dynSiz', updateSize).bind('keydown.dynSiz', updateSize).bind('change.dynSiz', updateSize);
		});
		// Chain:
		return this;
	};


	$('#xclound_box').click(function(e){
		var jTarget = $( e.target );

		var self = G.app.itemDetail.review;
		if (( jTarget[0].tagName.toLowerCase() == 'a' && jTarget.parents( '.xclound_item' ).length > 0 ) ){
			e.preventDefault();

			jTarget.parents( '.xclound_item' ).siblings().removeClass('xclound_item_selected');

			if (jTarget.parents( '.xclound_item' ).hasClass('xclound_item_selected')) {
				jTarget.parents( '.xclound_item' ).removeClass('xclound_item_selected');


				self.getReviews(0, 1);
			} else {
				jTarget.parents( '.xclound_item' ).addClass('xclound_item_selected');
				self._tagid = jTarget.attr('tag_id');
				self.getTagReviews(1);
			}
		}
	});

	$('.xclound_toggle').bind('click', function(e){
		var list = $('.xclound_list');
		if ($(this).hasClass('xclound_toggle_fold')) {
			list.css('height','');
			$(this).removeClass('xclound_toggle_fold');
		} else {
			list.css('height','auto');
			$(this).addClass('xclound_toggle_fold');
		}
	});

	$(window).bind('resize', function(){
		G.app.itemDetail.review.handleToggle();
	});


	setInterval(function() {
		var now = new Date();
		//YYYYmmDDHHMM		
		tick = parseInt(now.getFullYear() + "" + now.getHours() +""+ now.getMinutes() + ""+ (parseInt(now.getSeconds()/15) * 15)) ;
    	G.app.itemDetail.review._cacheBuster = tick;
	}, 1000 * 15);
})(jQuery);/*  |xGv00|a7b26f3c7d0efdaab8b05d8f40d27640 */