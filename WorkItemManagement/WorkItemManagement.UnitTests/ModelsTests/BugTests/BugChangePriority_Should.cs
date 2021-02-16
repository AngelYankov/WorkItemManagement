using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class BugChangePriority_Should
    {
        [TestMethod]
        public void SeverityChanged_NewSeverity()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1075", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            bug.ChangePriority(PriorityType.Low);
            Assert.AreEqual(PriorityType.Low, bug.Priority);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SeveritysNotChanged_SameSeverity()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1038", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            bug.ChangePriority(PriorityType.High);
        }
    }
}
