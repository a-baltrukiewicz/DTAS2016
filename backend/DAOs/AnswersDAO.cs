using backend.DataObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DAOs
{
    class AnswersDAO : AbstractDAO<Answer>
    {
        protected override List<Answer> Tokenize(string json)
        {
            JArray token = JArray.Parse(json);
            List<Answer> answers = new List<Answer>();

            for (int i = 0; i < token.Count(); i++)
            {
                Answer answer = new Answer();
                answer.name = token[i]["answer"].ToString();
                answer.voteQuantity = (uint)token[i]["quantity"];
                answers.Add(answer);
            }
            return answers;
        }

        public List<Answer> GetAllFilledAnswersToQuestion(uint questionID)
        {
            return ReceiveFromDatabase("select f.answer, COUNT(f.answer) as quantity from FilledFields f where questionID = " + questionID+ " group by answer");
        }
    }
}
