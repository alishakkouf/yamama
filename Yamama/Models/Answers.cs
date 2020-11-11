using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Answers
    {
        public Answers()
        {
            LinkRQA = new HashSet<LinkRQA>();
        }

        public int Idanswers { get; set; }
        public string AnswerText { get; set; }
        public int AnswerWeight { get; set; }
        public int? QuestionId { get; set; }

        public virtual Questions Question { get; set; }
        public virtual ICollection<LinkRQA> LinkRQA { get; set; }
    }
}
