using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DataObjects
{
    class Answer
    {
        //nazwa odpowiedzi
        public string name { get; set; }
        //ilość głosów na odpowiedź
        public uint voteQuantity { get; set; }

        public Answer(/*uint id,*/ string name, uint voteQuantity)
        {
            //this.id = id;
            this.name = name;
            this.voteQuantity = voteQuantity;
        }

        public Answer()
        {
        }

        /*public static bool operator ==(Answer lhs, Answer rhs)
        {
            return lhs.id == rhs.id;
        }

        public static bool operator !=(Answer lhs, Answer rhs)
        {
            return !(lhs == rhs);
        }*/

        public static bool operator >(Answer lhs, Answer rhs)
        {
            return lhs.voteQuantity > rhs.voteQuantity;
        }

        public static bool operator <(Answer lhs, Answer rhs)
        {
            return lhs.voteQuantity < rhs.voteQuantity;
        }
        public static bool operator >=(Answer lhs, Answer rhs)
        {
            return !(lhs < rhs);
        }

        public static bool operator <=(Answer lhs, Answer rhs)
        {
            return !(lhs > rhs);
        }
    }
}