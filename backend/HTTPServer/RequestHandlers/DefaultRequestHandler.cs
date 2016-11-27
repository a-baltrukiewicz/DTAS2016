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

        public override object HandleDELETE(System.Net.HttpListenerRequest request)
        {
            return HTMLResponse(request);
        }

        public override object HandleGET(System.Net.HttpListenerRequest request)
        {
            return HTMLResponse(request);
        }

        public override object HandlePOST(System.Net.HttpListenerRequest request)
        {
            return HTMLResponse(request);
        }

        public override object HandlePUT(System.Net.HttpListenerRequest request)
        {
            return HTMLResponse(request);
        }

        private string HTMLResponse(System.Net.HttpListenerRequest request)
        {
            return @"<HTML>404 Page " + request.Url.ToString() + @" not found.</HTML>";
        }
    }
}
