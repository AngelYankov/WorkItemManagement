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
    public class AddAssignee_Should : Cleaner
    {
        [TestMethod]
        public void AddAssigneeShould_AssigneeAdded()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            var member = new Member("Member1");

            bug.AddAssignee(member);
            Assert.IsTrue(bug.Assignee == member);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddAssigneeShould_ThrowWhen_AssigneeExists()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            var member = new Member("Member1");
            bug.AddAssignee(member);
            bug.AddAssignee(member);
        }

    }
}
