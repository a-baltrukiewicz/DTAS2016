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

        public override object HandleGET(System.Net.HttpListenerRequest request)
        {
            //List<Tag> tags = tagsDAO.GetAllTags();
            //return new TagsContainer(tags);
            return tagsDAO.GetAllTags();
        }

        public override object HandlePOST(System.Net.HttpListenerRequest request)
        {
            throw new NotImplementedException();
        }

        public override object HandlePUT(System.Net.HttpListenerRequest request)
        {
            throw new NotImplementedException();
        }

        public override object HandleDELETE(System.Net.HttpListenerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
