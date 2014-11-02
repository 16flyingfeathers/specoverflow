using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class OrderingAnswersSteps
    {
        private readonly QuestionPage _questionPage;

        public OrderingAnswersSteps(QuestionPage page)
        {
            _questionPage = page;
        }

        [Given(@"There is a question ""(.*)"" with the answers")]
        public void GivenThereIsAQuestionWithTheAnswers(string question, Table table)
        {
            _questionPage.question = question;
            var answers = table.CreateSet<Answer>();
            _questionPage.answers.UnionWith(answers);

            Assert.AreEqual(2, _questionPage.answers.Count());
        }

        [When(@"you upvote answer ""(.*)""")]
        public void WhenYouUpvoteAnswer(string answer)
        {
            _questionPage.VoteUpquestion(answer);
        }

        [Then(@"The answer ""(.*)"" should be on top")]
        public void ThenTheAnswerShouldBeOnTop(string answer)
        {
            Assert.AreEqual(answer, _questionPage.topAnswer);
        }
    }
}
