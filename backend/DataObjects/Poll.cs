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
        public Poll(List<Answer> answers, List<Tag> tags, string question)
        {
            this.answers = answers;
            this.tags = tags;
            this.question = question;
        }

        public Poll()
        {
            answers = new List<Answer>();
            tags = new List<Tag>();
        }

        public bool ContainsTag(Tag tag)
        {
            return tags.Contains(tag);
        }

        
        public List<Answer> answers { get; set; }
        public List<Tag> tags { get; set; }
        public string question { get; set; }
    }
}
