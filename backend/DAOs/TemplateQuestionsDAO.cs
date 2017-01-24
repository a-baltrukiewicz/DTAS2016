using backend.DataObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DAOs
{
    class TemplateQuestionsDAO : AbstractDAO<uint>
    {
        protected override List<uint> Tokenize(string json)
        {
            JArray token = JArray.Parse(json);
            List<uint> list = new List<uint>();

            for (int i = 0; i < token.Count(); i++)
            {
                uint id = (uint)token[i]["ID"];
                list.Add(id);
            }
            return list;
        }

        public void SaveQuestions(uint pollID, List<Question> questions)
        {
            string comm = "insert into Questions (openQstn, question) values ";
            List<uint> idsList = new List<uint>();
            foreach (var question in questions)
            {
                string localComm = comm;
                localComm += "(1, '" + question.question + "')";
                localComm += " SELECT CAST(scope_identity() AS int) as 'ID';";
                string sendedIDString = SendToDatabase(localComm);
                idsList.Add(Tokenize(sendedIDString)[0]);
            }

            comm = "insert into QuestionTable (pollID, questionID) values ";
            foreach (var id in idsList)
            {
                comm += String.Format("\n({0}, {1}),", pollID, id);
            }
            comm = comm.Remove(comm.Length - 1);
            SendToDatabase(comm);

        }
    }
}
