using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DAOs
{
    class NewFilledPollDAO : AbstractDAO<uint>
    {
        protected override List<uint> Tokenize(string json)
        {
            JArray token = JArray.Parse(json);
            List<uint> list = new List<uint>();

            for (int i = 0; i < token.Count(); i++)
            {
                uint id =  (uint)token[i]["ID"];
                list.Add(id);
            }
            return list;
        }
        
        public uint CreateNewFilledPoll(uint userID, uint pollID)
        {
            string comm = "insert into FilledPolls (userID, pollID) values ";
            comm += "(" + userID + ", " + pollID + ")";
            SendToDatabase(comm);
            return ReceiveFromDatabase("select ID from FilledPolls where userID = " + userID + " AND pollID = " +pollID)[0];
        }
    }
}
