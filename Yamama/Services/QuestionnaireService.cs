using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;
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

        public async Task<fullQuestionModel> AddQuestionModel(fullQuestionModel questionModel)
        {
            int modelId = _yamamadbcontext.QModelNames.Where(x => x.Name == questionModel.ModelName).Select(x => x.IdqModelNames).SingleOrDefault();

            List<Answers> result = new List<Answers>();
                Questions q = new Questions()
                {
                    QuestionText = questionModel.Question,
                    ModelName = modelId
                };
                await _yamamadbcontext.Questions.AddAsync(q);
                await _yamamadbcontext.SaveChangesAsync();


                //get id for this questionnaire
                var RecentQuestionnaire = _yamamadbcontext.Questions.OrderByDescending(p => p.IdQuestions).FirstOrDefault();
                int RecentQuestionID = RecentQuestionnaire.IdQuestions;

                for (int j = 0; j < questionModel.Answers.Count; j++)
                {
                    Answers answers = new Answers()
                    {
                        AnswerText = questionModel.Answers[j],
                        AnswerWeight = questionModel.Weights[j],
                        QuestionId=RecentQuestionID
                    
                    };
                result.Add(answers);
                  
                }
          await  insertToAnswers(result);


            return questionModel; ;
        }

        public async Task<Double> insertToAnswers(List<Answers> result )
        {
            for (int i = 0; i < result.Count; i++)
            {
               
               await _yamamadbcontext.Answers.AddAsync(result[i]);
               await _yamamadbcontext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Double> AddQuestionnaire(QuestionnaireViewModel questionnaireViewModel)
        {
            List<QA> qa = questionnaireViewModel.QA;
            //store sum of answers_weights
            Double sum = 0;
            for (int i = 0; i < qa.Count; i++)
            {
                int question = qa[i].QID;
                int answer = qa[i].AID;
                int weight =  _yamamadbcontext.Answers.Where(x => x.Idanswers == answer).Select(x => x.AnswerWeight).SingleOrDefault();
                sum += weight;
            }
            double avg = sum / (qa.Count);

            int p_id = _yamamadbcontext.Project.Where(x => x.Name == questionnaireViewModel.ProjectId).Select(x => x.Idproject).SingleOrDefault();
            int f_id = _yamamadbcontext.Factory.Where(x => x.Name == questionnaireViewModel.FactoryId).Select(x => x.Idfactory).SingleOrDefault();


            CustomerSatisfactionReports reports = new CustomerSatisfactionReports
            {

                ProjectId = (p_id != 0) ? p_id : (int?)null,

                FactoryId = (f_id != 0) ? f_id : (int?) null,


                Notes = questionnaireViewModel.Notes,
                SatisfactionEvaluation = avg

            };
           await _yamamadbcontext.CustomerSatisfactionReports.AddAsync(reports);
           await _yamamadbcontext.SaveChangesAsync();

            //get id for this report

            var RecentReport = _yamamadbcontext.CustomerSatisfactionReports.OrderByDescending(p => p.IdcustomerSatisfactionReports).FirstOrDefault();
            int RecentReportID = RecentReport.IdcustomerSatisfactionReports;

            //assign every report with its questions and answers
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

        public List<CustomerSatisfactionReports> GetQuestionnaire(string factory, string project)
        {
            int f_id = _yamamadbcontext.Factory.Where(x => x.Name == factory).Select(x => x.Idfactory).SingleOrDefault();
            int p_id = _yamamadbcontext.Project.Where(x => x.Name == project).Select(x => x.Idproject).SingleOrDefault();

            List<CustomerSatisfactionReports> satisfactionReports = new List<CustomerSatisfactionReports>();
            if (f_id != 0)
            {
                satisfactionReports = _yamamadbcontext.CustomerSatisfactionReports.Where(x => x.FactoryId == f_id).ToList();
                //int recentReport = _yamamadbcontext.CustomerSatisfactionReports.OrderByDescending(p => p.IdcustomerSatisfactionReports).Select
                //                   (x =>x.IdcustomerSatisfactionReports).FirstOrDefault();
            }
            else
            {
                satisfactionReports = _yamamadbcontext.CustomerSatisfactionReports.Where(x => x.ProjectId == p_id).ToList();
                // int report = _yamamadbcontext.CustomerSatisfactionReports.Where(x => x.FactoryId == factory).Select
                //(x => x.IdcustomerSatisfactionReports).SingleOrDefault();
            }
            return satisfactionReports;
        }

        public async Task<List<QuestionnairesReports>> GetQuestionnaireTexts(string factory, string project)
        {
            List<CustomerSatisfactionReports> satisfactionReports = GetQuestionnaire(factory , project);
            //string client;
            List<QuestionnairesReports> result = new List<QuestionnairesReports>();
            for (int i = 0; i < satisfactionReports.Count; i++)
            {
                QuestionnairesReports SubResult = new QuestionnairesReports();
                string ProjectName = _yamamadbcontext.Project.Where(x => x.Idproject == satisfactionReports[i].ProjectId).Select
                     (x => x.Name).SingleOrDefault();

                string FactoryName = _yamamadbcontext.Factory.Where(x => x.Idfactory == satisfactionReports[i].FactoryId).Select
                     ( x => x.Name).SingleOrDefault();
                SubResult.client = (satisfactionReports[i].ProjectId != null) ? ProjectName : FactoryName;
                               
                SubResult.Evaluation = satisfactionReports[i].SatisfactionEvaluation;
                SubResult.Notes = satisfactionReports[i].Notes;
                SubResult.reportID = satisfactionReports[i].IdcustomerSatisfactionReports;
                SubResult.questionAnswers = GetTexts(SubResult.reportID);

                result.Add(SubResult);
            }
            return result;
        }

        //return questions and answers as texts
        public List<QuestionAnswersTextsViewModel> GetTexts(int reportID)
        {
            List<LinkRQA> link = _yamamadbcontext.LinkRQA.Where(x =>x.ReportId == reportID).ToList();
            List<QuestionAnswersTextsViewModel> ListText = new List<QuestionAnswersTextsViewModel>();
            for (int i = 0; i <link.Count ; i++)
            {
                QuestionAnswersTextsViewModel one = new QuestionAnswersTextsViewModel
                {
                    Question = _yamamadbcontext.Questions.Where(x => x.IdQuestions == link[i].QId).Select(x => x.QuestionText).SingleOrDefault(),
                    Answer = _yamamadbcontext.Answers.Where(x => x.Idanswers == link[i].AnswerId).Select(x => x.AnswerText).SingleOrDefault()
                };

                ListText.Add(one);
            }
            return ListText;
        }

        public async Task<string> AddModelName(string name)
        {
            try
            {
                QModelNames qModelNames = new QModelNames();
                qModelNames.Name = name;
              await  _yamamadbcontext.QModelNames.AddAsync(qModelNames);
               await _yamamadbcontext.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {

                return "failed";
            }
       
        }



    }
}
