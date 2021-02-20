using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class ChangePriority_Should : Cleaner
    {
        [TestMethod]
        public void PriorityChanged_NewPriority()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            bug.ChangePriority(PriorityType.Low);
            Assert.AreEqual(PriorityType.Low, bug.Priority);
        }

        [TestMethod]
        public void PrioritysNotChanged_SamePriority()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            var result = Assert.ThrowsException<ArgumentException>(() => bug.ChangePriority(PriorityType.High));
            Assert.AreEqual("Bug priority already at 'High'", result.Message);
        }
    }
}
