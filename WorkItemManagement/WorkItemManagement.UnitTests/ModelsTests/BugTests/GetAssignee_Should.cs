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
    public class GetAssignee_Should : Cleaner
    {
        [TestMethod]
        public void GetAssigneeShould_ReturnAssignee()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, steps, "This is a description for a bug");
            var member = new Member("Member1");

            bug.AddAssignee(member);
            Assert.IsTrue(bug.GetAssignee() == member);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetAssigneeShould_ThrowWhen_IsNull()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, steps, "This is a description for a bug");
            bug.GetAssignee();
        }

    }
}
