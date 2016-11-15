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
        public Poll(List<Question> question, List<Tag> tags)
        {
            this.question = question;
            this.tags = tags;
        }

        public Poll()
        {
            question = new List<Question>();
            tags = new List<Tag>();
        }

        public bool ContainsTag(Tag tag)
        {
            return tags.Contains(tag);
        }

        
        public List<Question> question { get; set; }
        public List<Tag> tags { get; set; }
    }
}
