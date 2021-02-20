using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class UnassignCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void Assign_Removed()
        {
            var factory = new Mock<IFactory>();
            var member = new FakeMember("Member5");
            var story = new FakeStory("5");
            database.AddMemberToDB(member);
            database.AddWorkItemToDB(story);
            story.AddAssignee(member);
            var result = new UnassignCommand(new List<string>() { "5" }, database, factory.Object).Execute();
            Assert.IsTrue(story.Assignee == null);
            Assert.AreEqual("Work item: '5' unassigned",result);
        }
    }
}
