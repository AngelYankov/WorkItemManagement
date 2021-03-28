using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class ChangeStatus_Should : CleanerID
    {
        [TestMethod]
        public void StatusChanged_NewStatus()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            bug.ChangeStatus(BugStatus.Fixed);
            Assert.AreEqual(BugStatus.Fixed, bug.Status);
        }

        [TestMethod]
        public void StatusNotChanged_SameStatus()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            var result = Assert.ThrowsException<ArgumentException>(() => bug.ChangeStatus(BugStatus.Active));
            Assert.AreEqual("Bug status already at 'Active'", result.Message);
        }
    }
}
