using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class AddAssignee_Should : CleanerID
    {
        [TestMethod]
        public void AddAssigneeShould_AssigneeAdded()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            var member = new FakeMember();
            bug.AddAssignee(member);
            Assert.IsTrue(bug.Assignee == member);
        }

        [TestMethod]
        public void AddAssigneeShould_ThrowWhen_AssigneeExists()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            var member = new FakeMember("Member1");
            bug.AddAssignee(member);
            var result = Assert.ThrowsException<ArgumentException>(() => bug.AddAssignee(member));
            Assert.AreEqual("Bug already assigned to 'Member1'", result.Message);
        }
    }
}
