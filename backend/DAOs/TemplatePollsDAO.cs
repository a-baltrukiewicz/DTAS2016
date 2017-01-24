using backend.DataObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DAOs
{
    class TemplatePollsDAO : AbstractDAO<uint>
    {
        public TemplatePollsDAO() { }
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

        public uint SaveTemplatePoll(Poll poll)
        {
            string comm = "insert into Polls (name, description) values ";
            comm += "('" + poll.name + "', '" + poll.description + "') SELECT CAST(scope_identity() AS int) as 'ID'";
            string returnStr = SendToDatabase(comm);
            return Tokenize(returnStr)[0];
        }
    }
}
