using backend.DataObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DAOs
{
    class FilledPollsDAO : AbstractDAO<Poll>
    {
        protected override List<Poll> Tokenize(string json)
        {
            JArray token = JArray.Parse(json);
            List<Poll> polls = new List<Poll>();

            for (int i = 0; i < token.Count(); i++)
            {
                Poll poll = new Poll();
                poll.id = (uint)token[i]["ID"];
                poll.name = token[i]["name"].ToString();
                poll.description = token[i]["description"].ToString();
                polls.Add(poll);
            }
            return polls;
        }

        public Poll GetFilledPoll(uint id)
        {
            return ReceiveFromDatabase("select * from Polls where Polls.id = " + id)[0];
        }
        public List<Poll> GetFilledPolls()
        {
            return ReceiveFromDatabase("select * from Polls");
        }
    }
}
