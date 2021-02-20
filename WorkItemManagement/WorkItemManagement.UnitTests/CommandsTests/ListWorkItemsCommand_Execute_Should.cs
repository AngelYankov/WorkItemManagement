using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;
using System.Linq;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.UnitTests.FakeClasses;
using WorkItemManagement.Models.Enums;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class ListWorkItemsCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void ListItems_ThrowWhen_InvalidInput()
        {
            var factory = new Mock<IFactory>();
            var result = Assert.ThrowsException<ArgumentException>(()=>new ListWorkItemsCommand(new List<string>() { "wrong" },database,factory.Object).Execute());
            Assert.AreEqual("Not a valid filtering command", result.Message);
        }

        [TestMethod]
        public void ListItem_ListAll()
        {
            var factory = new Mock<IFactory>();
            var bug = new FakeBug("10");
            database.AddWorkItemToDB(bug);
            var result = new ListWorkItemsCommand(new List<string>() { "all" }, database, factory.Object).Execute();
            var allItems = database.GetAllWorkItems();
            Assert.AreEqual(string.Join("\n", allItems), result);
        }

        [TestMethod]
        public void ListItem_ListBugs()
        {
            var factory = new Mock<IFactory>();
            var bug = new FakeBug("10");
            database.AddWorkItemToDB(bug);
            var result = new ListWorkItemsCommand(new List<string>() { "bug" }, database, factory.Object).Execute();
            var allBugs = database.GetAllWorkItems().OfType<IBug>();
            Assert.AreEqual(string.Join("\n", allBugs), result);
        }

        [TestMethod]
        public void ListItem_ListFeedbacks()
        {
            var factory = new Mock<IFactory>();
            var result = new ListWorkItemsCommand(new List<string>() { "feedback" }, database, factory.Object).Execute();
            var allFeedbacks = database.GetAllWorkItems().OfType<IFeedback>();
            Assert.AreEqual(string.Join("\n", allFeedbacks), result);
        }

        [TestMethod]
        public void ListItem_ListStories()
        {
            var factory = new Mock<IFactory>();
            var result = new ListWorkItemsCommand(new List<string>() { "story" }, database, factory.Object).Execute();
            var allStories = database.GetAllWorkItems().OfType<IStory>();
            Assert.AreEqual(string.Join("\n", allStories), result);
        }
        // listworkitems all/bug/story/feedback  
        //listworkitems status or/and assignee
        //listworkitems title/priority/severity/size/rating

        [TestMethod]
        public void ListItem_ListBugsStatusActive() // done
        {
            var factory = new Mock<IFactory>();
            var bug = new FakeBug("10");
            database.AddWorkItemToDB(bug);
            var allBugs = database.GetAllWorkItems().OfType<FakeBug>().Where(b=>b.Status.ToString().Equals("active",StringComparison.OrdinalIgnoreCase)).ToList();
            var result = new ListWorkItemsCommand(new List<string>() { "bug","active" }, database, factory.Object).Execute();
            Assert.AreEqual(string.Join("\n", allBugs), result);
        }

        [TestMethod]
        public void ListItem_ListBugsStatusFixed() // done
        {
            var factory = new Mock<IFactory>();
            var bug = new FakeBug("10");
            database.AddWorkItemToDB(bug);
            bug.ChangeStatus(BugStatus.Fixed);
            var allBugs = database.GetAllWorkItems().OfType<FakeBug>().Where(b => b.Status.ToString().Equals("fixed",StringComparison.OrdinalIgnoreCase)).ToList();
            var result = new ListWorkItemsCommand(new List<string>() { "bug", "fixed" }, database, factory.Object).Execute();
            Assert.AreEqual(string.Join("\n", allBugs), result);
        }

        [TestMethod]
        public void ListItem_ThrowWhen_StatusWrong()
        {
            var factory = new Mock<IFactory>();
            var result = Assert.ThrowsException<ArgumentException>(()=>new ListWorkItemsCommand(new List<string>() { "bug", "status" }, database, factory.Object).Execute());
            Assert.AreEqual("There is no filter: 'status' for bug.", result.Message);
        }
        [TestMethod]
        public void ListItem_ListBugsAssignee()
        {
            var factory = new Mock<IFactory>();
            var bug = new FakeBug("10");
            var member = new FakeMember("Member10");
            bug.AddAssignee(member);
            database.AddMemberToDB(member);
            database.AddWorkItemToDB(bug);
            var allBugs = database.GetAllWorkItems().OfType<IBug>()
                                                    .Where(b => b.Assignee != null && b.Assignee.Name.Equals("Member10", StringComparison.OrdinalIgnoreCase)).ToList();
            var result = new ListWorkItemsCommand(new List<string>() { "bug", "Member10" }, database, factory.Object).Execute();

            Assert.AreEqual(string.Join("\n", allBugs), result);
        }

        [TestMethod]
        public void ListItem_ListBugsStatusAndAssignee()
        {
            var factory = new Mock<IFactory>();
            var bug = new FakeBug("10");
            var member = new FakeMember("Member10");
            bug.AddAssignee(member);
            database.AddMemberToDB(member);
            database.AddWorkItemToDB(bug);
            var allBugs = database.GetAllWorkItems().OfType<IBug>()
                                                    .Where(b => b.Assignee != null && b.Assignee.Name.Equals("Member10", StringComparison.OrdinalIgnoreCase)).ToList();
            var result = new ListWorkItemsCommand(new List<string>() { "bug", "active","Member10" }, database, factory.Object).Execute();

            Assert.AreEqual(string.Join("\n", allBugs), result);
        }








    }
}
