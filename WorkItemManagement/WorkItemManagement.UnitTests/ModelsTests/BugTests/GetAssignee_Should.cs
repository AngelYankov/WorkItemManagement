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
    public class GetAssignee_Should : CleanerID
    {
        [TestMethod]
        public void GetAssigneeShould_ReturnAssignee()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            var member = new FakeMember();

            bug.AddAssignee(member);
            Assert.IsTrue(bug.GetAssignee() == member);
        }

        [TestMethod]
        public void GetAssigneeShould_ThrowWhen_IsNull()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            var result = Assert.ThrowsException<ArgumentException>(() => bug.GetAssignee());
            Assert.AreEqual("There is no assignee.", result.Message);
        }
    }
}
