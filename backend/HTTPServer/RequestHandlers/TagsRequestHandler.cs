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

    class TagsRequestHandler : AbstractRequestHandler
    {
        public TagsRequestHandler() : base("tags")
        {
            tagsDAO = new DAOs.TagsDAO();
        }
        

        private DAOs.TagsDAO tagsDAO;

        private class TagsContainer
        {
            public TagsContainer(List<Tag> tags)
            {
                this.tags = tags;
            }

            public List<Tag> tags { get; set; }
        }

        public override object HandleGET(System.Net.HttpListenerRequest request, ref UtilityClasses.HTTPResponse response)
        {
            try
            {
                response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeOK();
                return tagsDAO.GetAllTags();
            }
            catch (Exception e)
            {
                response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeInternalServerError();
                return response;
            }
        }

        public override object HandlePOST(System.Net.HttpListenerRequest request, ref UtilityClasses.HTTPResponse response)
        {
            try
            {
                string json = GetRequestData(request);
                response = ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeCreated();

                return tagsDAO.SaveTags(json);
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
