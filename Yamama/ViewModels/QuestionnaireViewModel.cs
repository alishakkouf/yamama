using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class QuestionnaireViewModel
    {
        public string FactoryId { get; set; }
        public string ProjectId { get; set; }
        public string Notes { get; set; }
        public List<QA> QA { get; set; }
    }
}
