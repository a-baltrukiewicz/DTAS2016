using backend.DataObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DAOs
{
    class UsersDAO : AbstractDAO <User>
    {
        public UsersDAO() { }
        

        public List<User> GetAllUsers()
        {
            base.ConnectToSQLServer();
            string json = base.ExecuteSQLCommand("select * from users");
            base.DisconnectFromSQLServer();

            return Tokenize(json);
        }

        protected override List<User> Tokenize(string json)
        {
            JArray token = JArray.Parse(json);
            List<User> users = new List<User>();

            for (int i = 0; i < token.Count(); i++)
            {
                User newUser = new User();
                newUser.id = (int)token[i]["ID"];
                newUser.firstName = token[i]["firstName"].ToString();
                newUser.lastName = token[i]["lastName"].ToString();
                newUser.email = token[i]["email"].ToString();
                newUser.password = token[i]["password"].ToString();
                newUser.sex = token[i]["sex"].ToString();
                users.Add(newUser);
            }
            return users;
        }
    }
}
