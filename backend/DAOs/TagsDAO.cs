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

        protected override List<Tag> Tokenize(string json)
        {
            JArray token = JArray.Parse(json);
            List<Tag> tags = new List<Tag>();

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
            return ReceiveFromDatabase("select * from tags where  " + pollID); //@todo: poprawienie SQL
        }

        public List<Tag> GetAllTags()
        {
            return ReceiveFromDatabase("select * from tags");
        }
    }
}
