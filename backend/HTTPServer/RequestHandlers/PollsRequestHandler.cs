using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace backend.HTTPServer.RequestHandlers
{
    class PollsRequestHandler : AbstractRequestHandler
    {
        public PollsRequestHandler() : base("polls") { }

        public override string HandleRequest(HttpListenerRequest request)
        {
            //@todo: implement
            return "<HTML>200 BITCH</HTML>";
        }
    }
}
