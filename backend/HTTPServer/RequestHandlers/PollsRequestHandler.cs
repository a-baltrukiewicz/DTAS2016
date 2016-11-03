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
            Answer answer = new Answer("Tak", 45);
            List<Answer> answers = new List<Answer>();
            answers.Add(answer);
            answer = new DataObjects.Answer("Nie", 30);
            answers.Add(answer);

            Tag tag = new DataObjects.Tag("strona", 5);
            List<Tag> tags = new List<Tag>();
            tags.Add(tag);
            tag = new DataObjects.Tag("sprawywewnetrzne", 4);
            tags.Add(tag);

            Poll poll = new Poll(answers, tags, "Czy nasza strona powinna być fajna?");

            List<Poll> polls = new List<Poll>();
            polls.Add(poll);
            polls.Add(poll);

            return new PollsContainer(polls);
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
