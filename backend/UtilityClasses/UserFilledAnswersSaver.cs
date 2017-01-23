using backend.DataObjects;
using backend.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.UtilityClasses
{
    class UserFilledAnswersSaver
    {
        private UserFilledAnswersSaver() { }
        private static UserFilledAnswersSaver instance;
        public static UserFilledAnswersSaver GetObject()
        {
            if (instance == null)
                instance = new UserFilledAnswersSaver();
            return instance;
        }

        public string SaveFilledPoll(Poll poll)
        {
            FilledAnswersDAO answersDAO = new FilledAnswersDAO();
            NewFilledPollDAO newFilledPollDAO = new NewFilledPollDAO();

            int intUserId = LoginKeeper.Instance.SearchIDByToken(poll.userID);
            if (intUserId == -1)
            {
                ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeUnauthorized();
                return "FAILED, User not authorized";
            }
            uint fillID = newFilledPollDAO.CreateNewFilledPoll((uint)intUserId, poll.id);
            foreach (Question question in poll.questions)
            {
                answersDAO.SaveAllFilledAnswersToQuestion(fillID, question.id, question.answers);
            }
            return "Success!";
        }
    }
}
