using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class QuestionnairesReports
    {
        public List<QuestionAnswersTextsViewModel> questionAnswers { get; set; }
        public int reportID { get; set; }
        public Double Evaluation { get; set; }
        public string Notes { get; set; }
        public string client { get; set; }
    }
}
