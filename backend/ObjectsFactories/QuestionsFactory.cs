using backend.DataObjects;
using backend.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.ObjectsFactories
{
    class QuestionsFactory
    {
        public QuestionsFactory()
        {
        }

        public QuestionsFactory CreateFilledQuestion(uint questionID)
        {
            questions = new List<Question>();
            FilledQuestionsDAO dao = new FilledQuestionsDAO();
            questions.Add(dao.GetFilledQuestion(questionID));
            return this;
        }

        public QuestionsFactory CreateFilledQuestions(uint pollID)
        {
            questions = new List<Question>();
            FilledQuestionsDAO dao = new FilledQuestionsDAO();
            questions = dao.GetAllFilledQuestionsToPoll(pollID);
            return this;
        }

        public QuestionsFactory WithFilledAnswers()
        {
            FilledAnswersDAO dao = new FilledAnswersDAO();
            foreach (Question question in questions)
            {
                question.answers = dao.GetAllFilledAnswersToQuestion(question.id);
            }
            return this;
        }

        public QuestionsFactory WithAllFilled()
        {
            this.WithFilledAnswers();
            return this;
        }

        public List<Question> GetQuestions()
        {
            return questions;
        }

        public Question GetQuestion()
        {
            return questions[0];
        }

        private List<Question> questions;
    }
}
