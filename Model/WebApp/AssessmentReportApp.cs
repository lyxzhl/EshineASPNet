using System;
using System.Collections.Generic;
using System.Text;

namespace Model.WebApp
{
    [Serializable]
      public class AssessmentReportApp
    {
        public virtual int ARID { get; set; }
        public virtual int customerID { get; set; }
        public virtual int CType { get; set; }
        public virtual string customerCode { get; set; }
        public virtual int customerGender { get; set; }
        public virtual DateTime customerDOB { get; set; }
        public virtual string ARCode { get; set; }
        public virtual int customerAge { get; set; }
        public virtual int QTID { get; set; }
        public virtual string QTShortName { get; set; }
        public virtual DateTime ARCreate { get; set; }
        public virtual int ARStatus { get; set; }
        public virtual string ARDetail { get; set; }
        public virtual double ARScore { get; set; }
        public virtual string QTTemplate { get; set; }
        public virtual string QTPage { get; set; }
        public virtual string IRequest { get; set; }
        public virtual string IResponse { get; set; }
        public virtual DateTime IRequestTime { get; set; }
        public virtual DateTime IResponseTime { get; set; }
        public virtual string ARContent { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime UpdateTime { get; set; }
        public virtual int CreateUser { get; set; }
        public virtual int UpdateUser { get; set; }
        public virtual int IsShow { get; set; }
        public virtual int IsDel { get; set; }
    }
}
