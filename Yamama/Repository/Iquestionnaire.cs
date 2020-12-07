using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.ViewModels;

namespace Yamama.Repository
{
   public interface Iquestionnaire
    {
        Task<Double> AddQuestionnaire(QuestionnaireViewModel questionnaireViewModel);
        //Task<List<CustomerSatisfactionReports>> GetQuestionnaireTexts(int factory , int project);
        Task<List<QuestionnairesReports>> GetQuestionnaireTexts(string factory, string project);

        Task<fullQuestionModel> AddQuestionModel(fullQuestionModel questionModel);
        Task<string> AddModelName(string name);
    }
}
