using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class QuestionnaireViewModel
    {
        public int FactoryId { get; set; }
        public int ProjectId { get; set; }
        public string Notes { get; set; }
        public List<QA> QA { get; set; }
    }
}
