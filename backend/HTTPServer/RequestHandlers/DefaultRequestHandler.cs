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
        { }

        public override string HandleRequest(HttpListenerRequest request)
        {
            //@todo: implement
            return "<HTML>404 " + request.Url.ToString() + "</HTML>";
        }
    }
}
