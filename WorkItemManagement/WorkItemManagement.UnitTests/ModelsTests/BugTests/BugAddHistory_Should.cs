using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class BugAddHistory_Should
    {
        [TestMethod]
        public void AddHistorySuccessfully_HistoryAdded()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1040", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            bug.AddHistory("Adding history to bug");
            Assert.AreEqual("Adding history to bug", string.Join("", bug.History));
        }
    }
}
