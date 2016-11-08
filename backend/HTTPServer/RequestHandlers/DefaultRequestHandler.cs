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

        public override object HandleRequest(HttpListenerRequest request)
        {
            return HTMLResponse(request);
        }

        private string HTMLResponse(HttpListenerRequest request)
        {
            return @"<HTML>404 Page " + request.Url.ToString() + @" not found.</HTML>";
        }
    }
}
