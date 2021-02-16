using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class BugChangeStatus_Should
    {
        [TestMethod]
        public void StatusChanged_NewStatus()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1033", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            bug.ChangeStatus(BugStatus.Fixed);
            Assert.AreEqual(BugStatus.Fixed, bug.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StatusNotChanged_SameStatus()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1034", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            bug.ChangeStatus(BugStatus.Active);
        }
    }
}
