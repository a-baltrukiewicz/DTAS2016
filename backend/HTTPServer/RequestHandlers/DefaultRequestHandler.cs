using backend.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace backend.HTTPServer.RequestHandlers
{
    class DefaultRequestHandler : AbstractRequestHandler
    {
        public DefaultRequestHandler()
            : base(".*", true) //przyjmuje każde możliwe URL 
        {
        }

        public override object HandleDELETE(System.Net.HttpListenerRequest request, ref HTTPResponse response)
        {
            response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeNotFound();
            return HTMLResponse(request, ref response);
        }

        public override object HandleGET(System.Net.HttpListenerRequest request, ref HTTPResponse response)
        {
            response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeNotFound();
            return HTMLResponse(request, ref response);
        }

        public override object HandlePOST(System.Net.HttpListenerRequest request, ref HTTPResponse response)
        {
            response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeNotFound();
            return HTMLResponse(request, ref response);
        }

        public override object HandlePUT(System.Net.HttpListenerRequest request, ref HTTPResponse response)
        {
            response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeNotFound();
            return HTMLResponse(request, ref response);
        }

        private object HTMLResponse(System.Net.HttpListenerRequest request, ref HTTPResponse response)
        {
            return ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeNotFound();
        }
    }
}
