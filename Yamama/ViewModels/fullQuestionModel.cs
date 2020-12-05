using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class fullQuestionModel
    {
        public string ModelName { get; set; }
        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public List<int> Weights { get; set; }

    }
}
