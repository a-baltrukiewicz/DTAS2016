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
            System.Console.Write(GetRequestData(request));
            System.Console.WriteLine();
            return null;
        }

        public override object HandlePUT(System.Net.HttpListenerRequest request)
        {
            throw new NotImplementedException();
        }

        public override object HandleDELETE(System.Net.HttpListenerRequest request)
        {
            throw new NotImplementedException();
        }

        public static string GetRequestData(HttpListenerRequest request)
        {
            if (!request.HasEntityBody)
            {
                Console.WriteLine("No client data was sent with the request.");
                return ("No data");
            }
            System.IO.Stream body = request.InputStream;
            System.Text.Encoding encoding = request.ContentEncoding;
            System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            string read = reader.ReadToEnd();
            body.Close();
            reader.Close();
            return read;
            // If you are finished with the request, it should be closed also.
        }
    }
}
