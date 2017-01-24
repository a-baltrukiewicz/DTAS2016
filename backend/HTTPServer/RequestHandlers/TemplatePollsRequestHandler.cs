using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using backend.UtilityClasses;
using backend.ObjectsFactories;
using Newtonsoft.Json;
using backend.DataObjects;

namespace backend.HTTPServer.RequestHandlers
{
    class TemplatePollsRequestHandler : AbstractRequestHandler
    {
        public TemplatePollsRequestHandler() : base("templatePolls")
        {
        }

        public override object HandleDELETE(HttpListenerRequest request, ref HTTPResponse response)
        {
            throw new NotImplementedException();
        }

        public override object HandleGET(HttpListenerRequest request, ref HTTPResponse response)
        {
            throw new NotImplementedException();
        }

        public override object HandlePOST(HttpListenerRequest request, ref HTTPResponse response)
        {
            try
            {

                string json = GetRequestData(request);
                Poll poll = JsonConvert.DeserializeObject<Poll>(json);

                response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeCreated();
                return TemplatePollSaver.GetObject().SaveTemplatePoll(poll);
            }
            catch (Exception e)
            {
                response = HTTPResponseFactory.GetObject().CreateCodeInternalServerError();
                return response;
            }
        }

        public override object HandlePUT(HttpListenerRequest request, ref HTTPResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
