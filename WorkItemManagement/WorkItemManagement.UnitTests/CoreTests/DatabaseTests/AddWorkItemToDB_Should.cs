using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class AddWorkItemToDB_Should
    {
        [TestMethod]
        public void Should_AddWorkItem()
        {
            var db = Database.Instance;
            var feedback = new FakeFeedback();
            db.AddWorkItemToDB(feedback);
            Assert.IsTrue(db.AllWorkItems.Contains(feedback));
        }
    }
}
