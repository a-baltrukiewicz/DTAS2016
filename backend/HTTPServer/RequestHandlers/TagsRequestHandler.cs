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

        public override object HandleRequest(HttpListenerRequest request)
        {
            List<Tag> tags = tagsDAO.GetAllTags();
            return new TagsContainer(tags);
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

    }
}
