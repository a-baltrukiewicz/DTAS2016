using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DataObjects
{
    class Question
    {
        public uint id { get; set; }
        public string question { get; set; }
        public List<Answer> answers { get; set; }

        public Question()
        {
            answers = new List<Answer>();
        }

        Question(uint id, List<Answer> answers, string question)
        {
            this.id = id;
            this.answers = answers;
            this.question = question;
        }

    }
}
