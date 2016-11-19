using backend.DataObjects;
using backend.UtilityClasses;
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

        public override object HandleDELETE(System.Net.HttpListenerRequest request)
        {
            throw new NotImplementedException();
        }

        public override object HandleGET(System.Net.HttpListenerRequest request)
        {
            ObjectsFactories.PollsFactory factory = new ObjectsFactories.PollsFactory();
            RESTCollectionElementID collectionElementID = GetCollectionElementID(request);
            if (collectionElementID.IsCollection())
            {
                return factory.CreateFilledPolls().WithTags().GetPolls();
            }
            else
            {
                return factory.CreateFilledPoll(collectionElementID.elementNumber).WithAllFilled().GetPoll();
            }
        }

        public override object HandlePOST(System.Net.HttpListenerRequest request)
        {
            throw new NotImplementedException();
        }

        public override object HandlePUT(System.Net.HttpListenerRequest request)
        {
            throw new NotImplementedException();
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
