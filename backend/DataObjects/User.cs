using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace backend.DataObjects
{
    class User
    {
        public User(int id, string firstName, string lastName, string email, string password, string sex)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.id = id;
            this.password = password;
            this.sex = sex;
        }

        public User()
        {
        }

        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string sex { get; set; }
    }
}
