using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Services
{
    public class QuestionnaireService : Iquestionnaire
    {
        private readonly yamamadbContext _yamamadbcontext;

        public QuestionnaireService(yamamadbContext yamamadbContext)
        {
            _yamamadbcontext = yamamadbContext;
        }
        public async Task<Double> AddQuestionnaire(QuestionnaireViewModel questionnaireViewModel)
        {
            List<QA> qa = questionnaireViewModel.QA;
            //store sum of weights
            int sum = 0;
            for (int i = 0; i < qa.Count; i++)
            {
                int question =(qa[i].QID);
                int answer = qa[i].AID;
                int weight =  _yamamadbcontext.Answers.Where(x => x.Idanswers == answer).Select(x => x.AnswerWeight).SingleOrDefault();
                sum += weight;
            }
            double avg = sum / (qa.Count);
            int client = 0;
            //if (questionnaireViewModel.Factory != 0) { client = questionnaireViewModel.Factory; } else { client = questionnaireViewModel.Project; }

            CustomerSatisfactionReports reports = new CustomerSatisfactionReports
            {
                ProjectId = (questionnaireViewModel.ProjectId != 0) ? questionnaireViewModel.ProjectId : (int?)null,
                FactoryId = (questionnaireViewModel.FactoryId != 0) ? questionnaireViewModel.FactoryId : (int?)null,
                Notes = questionnaireViewModel.Notes,
                SatisfactionEvaluation = avg

            };
           await _yamamadbcontext.CustomerSatisfactionReports.AddAsync(reports);
           await _yamamadbcontext.SaveChangesAsync();

            //get id for this report

            var RecentReport = _yamamadbcontext.CustomerSatisfactionReports.OrderByDescending(p => p.IdcustomerSatisfactionReports).FirstOrDefault();
            int RecentReportID = RecentReport.IdcustomerSatisfactionReports;

           await AddToLink_R_Q_A(qa, RecentReportID);


            return 0;
        }

    

        public async Task<string> AddToLink_R_Q_A(List<QA> qa, int RecentReportID)
        {
            try
            {
                //Double fullcost = 0;
                for (int i = 0; i < qa.Count; i++)
                {
                    LinkRQA linkRQA = new LinkRQA
                    {
                        QId = Convert.ToInt32(qa[i].QID),
                        AnswerId = qa[i].AID,
                        ReportId = RecentReportID
                    };

                   

                    await _yamamadbcontext.LinkRQA.AddAsync(linkRQA);

                    await _yamamadbcontext.SaveChangesAsync();
                }
                return "success";
            }
            catch (Exception)
            {

                return null;
            }


        }
    }
}
