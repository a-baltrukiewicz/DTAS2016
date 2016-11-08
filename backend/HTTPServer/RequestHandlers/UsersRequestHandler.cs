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
        public UsersRequestHandler() : base("users")
        {
            usersDAO = new DAOs.UsersDAO();
        }

        public override object HandleRequest(HttpListenerRequest request)
        {
            List<User> users = usersDAO.GetAllUsers();
            return new UsersContainer(users);
        }

        private DAOs.UsersDAO usersDAO;

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
