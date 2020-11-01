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
    }
}
