using backend.DataObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DAOs
{
    class TagsDAO : AbstractDAO<Tag>
    {
        public TagsDAO() : base()
        {   }

        public string SaveTags(string json)
        {
            if (CheckForSQLInjection(json))
                throw new Exception();
            json = json.Substring(12);
            json = json.Remove(json.Length - 2);
            string comm = "insert into Tags values ('" + json + "')";
            return SendToDatabase(comm);
        }

        protected override List<Tag> Tokenize(string json)
        {
            List<Tag> tags = new List<Tag>();
            JArray token = JArray.Parse(json);

            for (int i = 0; i < token.Count(); i++)
            {
                Tag tag = new Tag();
                tag.id = (uint)token[i]["ID"];
                tag.name = token[i]["tagText"].ToString();
                tags.Add(tag);
            }
            return tags;
        }
        
        public List<Tag> GetPollTagsList(uint pollID)
        {
            return ReceiveFromDatabase("select t.* from tags t, tagsTable tt where tt.tagID = t.ID and tt.pollID = " + pollID);
        }

        public List<Tag> GetAllTags()
        {
            return ReceiveFromDatabase("select * from tags");
        }

        public int ConnectTagsWithPoll(uint pollID, List<Tag> tags)
        {
            string comm = "insert into TagsTable (PollID, TagID) values ";
            foreach (var tag in tags)
            {
                comm += "\n(" + pollID + ", " + tag.id + "),";
            }
            comm = comm.Remove(comm.Length - 1);
            SendToDatabase(comm);
            return 0;
        }
    }
}
