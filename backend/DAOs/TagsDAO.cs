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
            json = json.Substring(12);
            json = json.Remove(json.Length - 2);
            bool x = Validate(json);
            if (x)
            {
                string comm = "insert into Tags values ('" + json + "')";
                return SendToDatabase(comm);
            }
            else return "error";
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

        public bool Validate(string json)
        {
            int x = 0;
            for(int i=0;i<json.Length;i++)
            {
                if (json.StartsWith("delete") || json.StartsWith("insert") || json.StartsWith("drop") || json.StartsWith("update"))
                {
                    x++;
                }
                if (json.StartsWith("DELETE") || json.StartsWith("INSERT") || json.StartsWith("DROP") || json.StartsWith("UPDATE"))
                {
                    x++;
                }
                json = json.Substring(1);
            }
            
            if (x == 0) return true;
            else return false;
        }
    }
}
