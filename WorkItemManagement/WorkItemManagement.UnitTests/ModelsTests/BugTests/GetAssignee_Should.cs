using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Abstract;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class GetAssignee_Should : Cleaner
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
        [ExpectedException(typeof(ArgumentException))]
        public void GetAssigneeShould_ThrowWhen_IsNull()
        {
            var bug = new Bug("1", "TheFirstBug", PriorityType.High, SeverityType.Critical, new List<string>(), "This is a description for a bug");
            bug.GetAssignee();
        }

    }
}
