using System;
using System.Collections.Generic;
using System.Text;

namespace Model.WebApp
{
    [Serializable]
    public class QuestionTypeApp
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string ShortName { get; set; }
        public virtual string Des { get; set; }
        public virtual string Document { get; set; }
    }
}
