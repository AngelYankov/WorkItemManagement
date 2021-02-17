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
    public class ChangePriority_Should : Cleaner
    {
        [TestMethod]
        public void PriorityChanged_NewPriority()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, steps, "This is a description for a bug");
            bug.ChangePriority(PriorityType.Low);
            Assert.AreEqual(PriorityType.Low, bug.Priority);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PrioritysNotChanged_SamePriority()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, steps, "This is a description for a bug");
            bug.ChangePriority(PriorityType.High);
        }
        
    }
}
