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
        

        private DAOs.UsersDAO usersDAO;

        private class UsersContainer
        {
            public UsersContainer(List<User> users)
            {
                this.users = users;
            }

            public List<User> users { get; set; }
        }

        public override object HandleGET(System.Net.HttpListenerRequest request)
        {
            List<User> users = usersDAO.GetAllUsers();
            return users;
        }

        public override object HandlePOST(System.Net.HttpListenerRequest request)
        {
            string json = GetRequestData(request);
            return usersDAO.SaveUsers(json);
        }

        public override object HandlePUT(System.Net.HttpListenerRequest request)
        {
            throw new NotImplementedException();
        }

        public override object HandleDELETE(System.Net.HttpListenerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
