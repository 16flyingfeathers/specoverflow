using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcceptanceTests
{
    public class QuestionPage
    {
        public SortedSet<Answer> answers { get; set; }

        public QuestionPage()
        {
            answers = new SortedSet<Answer>(new ByVotesComparer());
        }

        public void VoteUpquestion(string answer)
        {
            var result = answers.First(e => e.answer.Equals(answer));
            answers.Remove(result);
            result.votes = result.votes + 1;
            answers.Add(result);
        }

        public String topAnswer
        {
            get { return answers.Max.answer; }
        }

        public string question { get; set; }
    }

    public class ByVotesComparer : IComparer<Answer>
    {
        public int Compare(Answer x, Answer y)
        {
            int result = x.votes.CompareTo(y.votes);
            if (result == 0)
            {
                result = x.answer.CompareTo(y.answer);
            }
            return result;
        }
    }

    public class Answer
    {
        public string answer { get; set; }
        public int votes { get; set; }
    }
}
