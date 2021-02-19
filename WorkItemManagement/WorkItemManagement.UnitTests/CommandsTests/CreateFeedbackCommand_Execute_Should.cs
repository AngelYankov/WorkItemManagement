using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class CreateFeedbackCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void CreateFeedback_FailToParse() //createfeedback team board id title rating status description
        {
            var factory = new Mock<IFactory>();
            var result = Assert.ThrowsException<ArgumentException>(()
                        =>new CreateFeedbackCommand(new List<string>() { "Team1", "Board1", "5", "Title for Feedback", "one", "done", "Description for Feedback." },
                        database, factory.Object).Execute());
            Assert.AreEqual("Rating should be a valid number.", result.Message);
        }
        [TestMethod]
        public void CreateFeedback_Succesfully()
        {
            var factory = new Mock<IFactory>();
            var result = new CreateFeedbackCommand(new List<string>() { "Team1", "Board1", "5", "Title for Feedback", "1", "done", "Description for Feedback." },
                        database, factory.Object).Execute();
            Assert.AreEqual("Created feedback: 'Title for Feedback' with id: '5'. Added to board: 'Board1' in team: 'Team1'", result);
            
        }
    }
}
