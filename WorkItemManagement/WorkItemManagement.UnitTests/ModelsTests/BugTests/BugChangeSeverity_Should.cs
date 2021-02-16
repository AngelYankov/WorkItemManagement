using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class BugChangeSeverity_Should
    {
        [TestMethod]
        public void SeverityChanged_NewSeverity()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1035", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            bug.ChangeSeverity(SeverityType.Major);
            Assert.AreEqual(SeverityType.Major, bug.Severity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SeveritysNotChanged_SameSeverity()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1036", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            bug.ChangeSeverity(SeverityType.Critical);
        }
    }
}
