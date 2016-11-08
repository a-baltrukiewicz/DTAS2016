using backend.DataObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace backend.HTTPServer.RequestHandlers
{

    class UsersRequestHandler : AbstractRequestHandler
    {
        public UsersRequestHandler() : base("users") { }

        public override object HandleRequest(HttpListenerRequest request)
        {

            SQLCommunication SQLconn = new SQLCommunication();
            SQLconn.connectToSQLServer();
            string json = SQLconn.executeSQLCommand("SELECT * FROM USERS");
            SQLconn.disconnectFromSQLServer();
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

            return new UsersContainer(users);
        }

        private class UsersContainer
        {
            public UsersContainer(List<User> users)
            {
                this.users = users;
            }

            public List<User> users { get; set; }
        }

    }
}
