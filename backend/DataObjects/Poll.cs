using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DataObjects
{
    class Poll
    {
        public Poll(uint id, string name, string description, List<Question> questions, List<Tag> tags)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.questions = questions;
            this.tags = tags;
        }

        public Poll()
        {
            questions = new List<Question>();
            tags = new List<Tag>();
        }

        public bool ContainsTag(Tag tag)
        {
            return tags.Contains(tag);
        }


        public uint id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Question> questions { get; set; }
        public List<Tag> tags { get; set; }
    }
}
