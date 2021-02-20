using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class Constructor_Should : Cleaner
    {
        [TestMethod]
        public void SetProperties()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            Assert.AreEqual(PriorityType.High, bug.Priority);
            Assert.AreEqual(SeverityType.Critical, bug.Severity);
            Assert.AreEqual(BugStatus.Active, bug.Status);
        }
    }
}
