using backend.DataObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DAOs
{
    class QuestionsDAO : AbstractDAO<Question>
    {
        protected override List<Question> Tokenize(string json)
        {
            JArray token = JArray.Parse(json);
            List<Question> questions = new List<Question>();

            AnswersDAO answersDAO = new AnswersDAO();

            for (int i = 0; i < token.Count(); i++)
            {
                Question question = new Question();
                question.question = token[i]["question"].ToString();
                question.id = (uint)token[i]["ID"];
                question.answers = answersDAO.GetAllFilledAnswersToQuestion(question.id);
                questions.Add(question);
            }
            return questions;
        }

        public Question GetQuestion(uint questionID)
        {//@TODO POPRAWI
            return base.ReceiveFromDatabase("select * from Questions where id = " + questionID)[0];
        }
    }
}
