using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //[Serializable]
    //public class AssessmentType
    //{
    //    public virtual string Id { get; set; }
    //    public virtual string Id { get; set; }
    //    public virtual string Id { get; set; }
    //}

    [Serializable]
    public class LoginInfo
    {
        public virtual string code { get; set; }
        public virtual string message { get; set; }
        public virtual List<Dictionary<string, object>> data { get; set; }
        public virtual string key { get; set; }
    }

    [Serializable]
    public class InfoObj1 {
        public virtual string key { get; set; }
        public virtual string value { get; set; }
    }

    [Serializable]
    public class InfoObj2
    {
        public virtual string key { get; set; }
        public virtual string value { get; set; }
    }
}
