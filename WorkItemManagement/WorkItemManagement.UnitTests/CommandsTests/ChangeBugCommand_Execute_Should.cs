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
    public class ChangeBugCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void ChangeBug_ThrowWhen_NoBug()
        {
            var factory = new Mock<IFactory>();
            var result = Assert.ThrowsException<ArgumentException>(() 
                => new ChangeBugCommand(new List<string>() { "1", "status", "active" }, database, factory.Object).Execute());
            Assert.AreEqual("Bug: '1' does not exist",result.Message);
        }

        [TestMethod]
        public void ChangeBug_ThrowWhen_PriorityWrong()
        {
            var factory = new Mock<IFactory>();
            IBug bug = new FakeBug("1");
            database.AddWorkItemToDB(bug);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeBugCommand(new List<string>() { "1", "priority", "aaa" }, database, factory.Object).Execute());
            Assert.AreEqual("'aaa' is not a valid priority type", result.Message);
        }

        [TestMethod]
        public void ChangeBug_ThrowWhen_SeverityWrong()
        {
            var factory = new Mock<IFactory>();
            IBug bug = new FakeBug("1");
            database.AddWorkItemToDB(bug);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeBugCommand(new List<string>() { "1", "severity", "aaa" }, database, factory.Object).Execute());
            Assert.AreEqual("'aaa' is not a valid severity type", result.Message);
        }

        [TestMethod]
        public void ChangeBug_ThrowWhen_StatusWrong()
        {
            var factory = new Mock<IFactory>();
            IBug bug = new FakeBug("1");
            database.AddWorkItemToDB(bug);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeBugCommand(new List<string>() { "1", "status", "aaa" }, database, factory.Object).Execute());
            Assert.AreEqual("'aaa' is not a valid status type", result.Message);
        }

        [TestMethod]
        public void ChangeBug_ThrowWhen_PropertyWrong()
        {
            var factory = new Mock<IFactory>();
            IBug bug = new FakeBug("1");
            database.AddWorkItemToDB(bug);

            var result = Assert.ThrowsException<ArgumentException>(()
                => new ChangeBugCommand(new List<string>() { "1", "wrong", "aaa" }, database, factory.Object).Execute());
            Assert.AreEqual("Property type is not valid.", result.Message);
        }
    }
}
