using System;
using System.Collections.Generic;
using System.Text;

namespace Model.WebApp
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class AssessmentQuestionObj
    {
        public virtual AQuestion question { get; set; }
        public virtual List<AAnswer> answerList { get; set; }
    }

    /// <summary>
    /// 题目
    /// </summary>
    [Serializable]
    public class AQuestion
    {
        public virtual  string Question { get; set; }
        public virtual int Type { get; set; }
        public virtual string Remark { get; set; }
        public virtual string Des { get; set; }
        public virtual int Options { get; set; }
        public virtual int Sort { get; set; }
    }

    /// <summary>
    /// 答案
    /// </summary>
    [Serializable]
    public class AAnswer
    {
        public virtual string Content { get; set; }
        public virtual string Des { get; set; }
        public virtual int Type { get; set; }
        public virtual string Score { get; set; }
    }
}
