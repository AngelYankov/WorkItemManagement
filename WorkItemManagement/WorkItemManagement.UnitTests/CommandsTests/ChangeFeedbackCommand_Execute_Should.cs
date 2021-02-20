using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class ChangeFeedbackCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void ChangeFeedback_ThrowWhen_NoFeedback()
        {
            var factory = new Mock<IFactory>();
            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeFeedbackCommand(new List<string>() { "10", "rating", "5" }, database, factory.Object).Execute());
            Assert.AreEqual("Feedback: '10' does not exist.", result.Message);
        }

        [TestMethod]
        public void ChangeFeedback_ThrowWhen_RatingWrong()
        {
            var factory = new Mock<IFactory>();
            IFeedback feedback = new FakeFeedback("1");
            database.AddWorkItemToDB(feedback);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeFeedbackCommand(new List<string>() { "1", "rating", "15" }, database, factory.Object).Execute());
            Assert.AreEqual("Rating '15' should be between 1 an 10.", result.Message);
        }

        [TestMethod]
        public void ChangeFeedback_ThrowWhen_RatingNotNumber()
        {
            var factory = new Mock<IFactory>();
            IFeedback feedback = new FakeFeedback("1");
            database.AddWorkItemToDB(feedback);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeFeedbackCommand(new List<string>() { "1", "rating", "bigrating" }, database, factory.Object).Execute());
            Assert.AreEqual("Rating should be a number.", result.Message);
        }

        [TestMethod]
        public void ChangeFeedback_ThrowWhen_StatusWrong()
        {
            var factory = new Mock<IFactory>();
            IFeedback feedback = new FakeFeedback("1");
            database.AddWorkItemToDB(feedback);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeFeedbackCommand(new List<string>() { "1", "status", "aaa" }, database, factory.Object).Execute());
            Assert.AreEqual("'aaa' is not a valid status type.", result.Message);
        }

        [TestMethod]
        public void ChangeFeedback_ThrowWhen_PropertyWrong()
        {
            var factory = new Mock<IFactory>();
            IFeedback feedback = new FakeFeedback("1");
            database.AddWorkItemToDB(feedback);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeFeedbackCommand(new List<string>() { "1", "wrong", "aaa" }, database, factory.Object).Execute());
            Assert.AreEqual("Property type is not valid.", result.Message);
        }
    }
}
