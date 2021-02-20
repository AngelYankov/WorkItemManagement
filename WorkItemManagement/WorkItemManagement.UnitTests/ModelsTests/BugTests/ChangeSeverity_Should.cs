using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class ChangeSeverity_Should : CleanerID
    {
        [TestMethod]
        public void SeverityChanged_NewSeverity()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            bug.ChangeSeverity(SeverityType.Major);
            Assert.AreEqual(SeverityType.Major, bug.Severity);
        }

        [TestMethod]
        public void SeveritysNotChanged_SameSeverity()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            var result = Assert.ThrowsException<ArgumentException>(() => bug.ChangeSeverity(SeverityType.Critical));
            Assert.AreEqual("Bug severity type already at 'Critical'", result.Message);
        }
    }
}
