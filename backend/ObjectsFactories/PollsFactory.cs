using backend.DataObjects;
using backend.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.ObjectsFactories
{
    class PollsFactory
    {
        public PollsFactory()
        {
        }

        public PollsFactory CreateFilledPoll(uint id)
        {
            polls = new List<Poll>();
            FilledPollsDAO dao = new FilledPollsDAO();
            Poll poll = dao.GetFilledPoll(id);
            polls.Add(poll);
            return this;
        }

        public PollsFactory CreateFilledPolls()
        {
            polls = new List<Poll>();
            FilledPollsDAO dao = new FilledPollsDAO();
            polls = dao.GetFilledPolls();
            return this;
        }

        public PollsFactory WithTags()
        {
            TagsDAO dao = new TagsDAO();
            foreach (Poll poll in polls)
            {
                poll.tags = dao.GetPollTagsList(poll.id);
            }
            return this;
        }

        public PollsFactory WithFilledQuestions()
        {
            QuestionsFactory factory = new QuestionsFactory();
            foreach (Poll poll in polls)
            {
                poll.questions = factory.CreateFilledQuestions(poll.id).WithAllFilled().GetQuestions();
            }
            return this;
        }

        public PollsFactory WithAllFilled()
        {
            this.WithFilledQuestions();
            this.WithTags();
            return this;
        }

        public Poll GetPoll()
        {
            return polls[0];
        }

        public List<Poll> GetPolls()
        {
            return polls;
        }

        private List<Poll> polls;
    }
}
