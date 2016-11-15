using backend.DataObjects;

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

        public override object HandleRequest(HttpListenerRequest request)
        {
            return new DAOs.QuestionsDAO().GetFilledQuestion(4);
        }

        private class PollsContainer
        {
            public PollsContainer(List<Poll> polls)
            {
                this.polls = polls;
            }

            public List<Poll> polls { get; set; }
        }

    }
}
