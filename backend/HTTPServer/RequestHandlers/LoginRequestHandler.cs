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

    class LoginRequestHandler : AbstractRequestHandler
    {



        public LoginRequestHandler() : base("login")
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
        public override object HandleGET(System.Net.HttpListenerRequest request, ref UtilityClasses.HTTPResponse response)
        {
            response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeNotImplemented();
            return response;
        }

        public override object HandlePOST(System.Net.HttpListenerRequest request, ref UtilityClasses.HTTPResponse response)
        {
            try
            {
                string json = GetRequestData(request);
                response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeOK();
                return usersDAO.LoginUser(json);
            }
            catch (Exception e)
            {
                response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeInternalServerError();
                return response;
            }

        }

        public override object HandlePUT(System.Net.HttpListenerRequest request, ref UtilityClasses.HTTPResponse response)
        {
            response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeNotImplemented();
            return response;
        }

        public override object HandleDELETE(System.Net.HttpListenerRequest request, ref UtilityClasses.HTTPResponse response)
        {
            response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeNotImplemented();
            return response;
        }
    }
}
