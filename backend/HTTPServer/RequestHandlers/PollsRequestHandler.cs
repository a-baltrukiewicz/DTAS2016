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

        public override object HandleDELETE(System.Net.HttpListenerRequest request, ref UtilityClasses.HTTPResponse response)
        {
            response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeNotImplemented();
            return response;
        }

        public override object HandleGET(System.Net.HttpListenerRequest request, ref UtilityClasses.HTTPResponse response)
        {
            ObjectsFactories.PollsFactory factory = new ObjectsFactories.PollsFactory();
            RESTCollectionElementID collectionElementID = GetCollectionElementID(request);
            try
            {
                if (collectionElementID.IsCollection())
                {
                    response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeOK();
                    return factory.CreateFilledPolls().WithTags().GetPolls();
                }
                else
                {
                    response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeOK();
                    return factory.CreateFilledPoll(collectionElementID.elementNumber).WithAllFilled().GetPoll();
                }
            }
            catch (Exception e)
            {
                response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeInternalServerError();
                return response;
            }
        }

        public override object HandlePOST(System.Net.HttpListenerRequest request, ref UtilityClasses.HTTPResponse response)
        {
            response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeNotImplemented();
            return response;
        }

        public override object HandlePUT(System.Net.HttpListenerRequest request, ref UtilityClasses.HTTPResponse response)
        {
            response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeNotImplemented();
            return response;
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
