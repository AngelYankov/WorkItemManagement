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
    public class GetWorkItem_Should : CleanerDatabase
    {
        [TestMethod]
        public void ReturnsWorkItem()
        {
            var db = Database.Instance;
            var feedback = new FakeFeedback();
            feedback.Id = "1";
            db.AddWorkItemToDB(feedback);
            var workItem = db.GetWorkItem("1");

            Assert.AreEqual(feedback, workItem);
        }

        [TestMethod]
        public void ThrowWhen_WorkItemDoesNotExist()
        {
            var db = Database.Instance;
            var result = Assert.ThrowsException<ArgumentException>(() => db.GetWorkItem("1"));
            Assert.AreEqual("Work item: '1' does not exist.", result.Message);
        }
    }
}
