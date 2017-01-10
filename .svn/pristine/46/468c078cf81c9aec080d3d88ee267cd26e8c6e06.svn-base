using System;
using System.Collections.Generic;

namespace Model.WebApp
{
    [Serializable]
    public class iAssessmentReport
    {
        /// <summary>
        /// 答案集合
        /// </summary>
        public virtual List<iAnswer> alist { get; set; }

        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public virtual string user { get; set; }
    }

    [Serializable]
    public class iAnswer
    {
        /// <summary>
        /// 答案分类
        /// </summary>
        public virtual string qclass { get; set; }
        /// <summary>
        /// 答案列表信息
        /// </summary>
        public virtual List<iAnswerItem> qlist { get; set; }
    }

    [Serializable]
    public class iAnswerItem
    {
        /// <summary>
        /// 问题编号
        /// </summary>
        public virtual string qid { get; set; }
        /// <summary>
        /// 问题答案值
        /// </summary>
        public virtual object qvalue { get; set; }
    }
}
