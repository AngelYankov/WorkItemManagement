using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Abstract;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class ChangeStatus_Should : Cleaner
    {
        [TestMethod]
        public void StatusChanged_NewStatus()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            bug.ChangeStatus(BugStatus.Fixed);
            Assert.AreEqual(BugStatus.Fixed, bug.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StatusNotChanged_SameStatus()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            bug.ChangeStatus(BugStatus.Active);
        }
        
    }
}
