using backend.DataObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DAOs
{
    class FilledQuestionsDAO : AbstractDAO<Question>
    {
        protected override List<Question> Tokenize(string json)
        {
            JArray token = JArray.Parse(json);
            List<Question> questions = new List<Question>();

            for (int i = 0; i < token.Count(); i++)
            {
                Question question = new Question();
                question.question = token[i]["question"].ToString();
                question.id = (uint)token[i]["id"];
                questions.Add(question);
            }
            return questions;
        }

        public Question GetFilledQuestion(uint questionID)
        {//@TODO POPRAWI
            return base.ReceiveFromDatabase("select * from Questions where id = " + questionID)[0];
        }

        public List<Question> GetAllFilledQuestionsToPoll(uint pollID)
        {
            return base.ReceiveFromDatabase("select q.id, q.question from Questions q, QuestionTable qt where pollID = " + pollID + " AND q.ID = qt.questionID;");
        }
    }
}
