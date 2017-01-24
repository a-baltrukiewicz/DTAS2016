using backend.DAOs;
using backend.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.UtilityClasses
{
    class TemplatePollSaver
    {
        static private TemplatePollSaver instance;
        private TemplatePollSaver() { }
        static public TemplatePollSaver GetObject()
        {
            if (instance == null)
                instance = new TemplatePollSaver();
            return instance;
        }

        public string SaveTemplatePoll(Poll poll)
        {
            TemplatePollsDAO templatePollsDAO = new TemplatePollsDAO();
            TagsDAO tagsDAO = new TagsDAO();
            TemplateQuestionsDAO templateQuestionsDAO = new TemplateQuestionsDAO();

            uint pollID = templatePollsDAO.SaveTemplatePoll(poll);
            tagsDAO.ConnectTagsWithPoll(pollID, poll.tags);

            templateQuestionsDAO.SaveQuestions(pollID, poll.questions);

            return "Success!";
        }
    }
}
