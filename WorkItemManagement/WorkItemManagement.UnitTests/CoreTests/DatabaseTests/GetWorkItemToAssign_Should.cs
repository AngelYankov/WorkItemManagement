using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class GetWorkItemToAssign_Should : Cleaner
    {
        [TestMethod]
        public void ReturnsWorkItem()
        {
            var db = Database.Instance;
            var story = new FakeStory();
            story.Id = "1";
            db.AddWorkItemToDB(story);
            var expected = db.GetWorkItemToAssign("1");
            Assert.AreEqual(expected, story);
        }

        [TestMethod]
        public void ThrowsWhen_IsFeedback()
        {
            var db = Database.Instance;
            var feedback = new FakeFeedback();
            feedback.Id = "1";
            db.AddWorkItemToDB(feedback);
            var result = Assert.ThrowsException<ArgumentException>(() => db.GetWorkItemToAssign("1"));
            Assert.AreEqual("Feedback doesn't have an assignee.", result.Message);
        }

        [TestMethod]
        public void ThrowsWhen_WorkItemDoesNotExist()
        {
            var db = Database.Instance;
            var result = Assert.ThrowsException<ArgumentException>(() => db.GetWorkItemToAssign("1"));
            Assert.AreEqual("Work item: '1' does not exist.", result.Message);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Database.Instance.GetAllWorkItems().Clear();
        }
    }
}
