using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class ChangeStoryCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void Changestory_ThrowWhen_NoStory()
        {
            var factory = new Mock<IFactory>();
            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeStoryCommand(new List<string>() { "5", "priority", "active" }, database, factory.Object).Execute());
            Assert.AreEqual("Story: '5' does not exist.", result.Message);
        }
        [TestMethod]
        public void Changestory_ThrowWhen_PriorityWrong()
        {
            var factory = new Mock<IFactory>();
            IStory story = new FakeStory("7");
            database.AddWorkItemToDB(story);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeStoryCommand(new List<string>() { "7", "priority", "aaa" }, database, factory.Object).Execute());
            Assert.AreEqual("'aaa' is not a valid priority type.", result.Message);
        }

        [TestMethod]
        public void Changestory_ThrowWhen_SizeWrong()
        {
            var factory = new Mock<IFactory>();
            IStory story = new FakeStory("7");
            database.AddWorkItemToDB(story);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeStoryCommand(new List<string>() { "7", "severity", "aaa" }, database, factory.Object).Execute());
            Assert.AreEqual("Property type is not valid.", result.Message);
        }

        [TestMethod]
        public void Changestory_ThrowWhen_StatusWrong()
        {
            var factory = new Mock<IFactory>();
            IStory story = new FakeStory("7");
            database.AddWorkItemToDB(story);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeStoryCommand(new List<string>() { "7", "status", "aaa" }, database, factory.Object).Execute());
            Assert.AreEqual("'aaa' is not a valid status type.", result.Message);
        }
        [TestMethod]
        public void Changestory_ThrowWhen_PropertyWrong()
        {
            var factory = new Mock<IFactory>();
            IStory story = new FakeStory("7");
            database.AddWorkItemToDB(story);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeStoryCommand(new List<string>() { "7", "wrong", "aaa" }, database, factory.Object).Execute());
            Assert.AreEqual("Property type is not valid.", result.Message);
        }
    }
}
