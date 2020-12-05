using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
            LinkRQA = new HashSet<LinkRQA>();
        }

        public int IdQuestions { get; set; }
        public string QuestionText { get; set; }
        public int? ModelName { get; set; }

        public virtual QModelNames ModelNameNavigation { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<LinkRQA> LinkRQA { get; set; }
    }
}
