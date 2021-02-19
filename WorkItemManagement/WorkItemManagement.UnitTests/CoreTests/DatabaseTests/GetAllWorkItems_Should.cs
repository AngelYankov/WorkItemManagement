using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class GetAllWorkItems_Should
    {
        [TestMethod]
        public void ReturnsAllWorkItems()
        {
            var db = Database.Instance;
            var workItems = db.GetAllWorkItems();
            Assert.IsInstanceOfType(workItems, typeof(IList<IWorkItem>));
        }
    }
}
