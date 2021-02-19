using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class MemberExistsInTeam_Should
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhen_AlreadyExists()
        {
            var fakeData = new FakeDatabase();
            var team = new Team("Team1");
            fakeData.AddTeam(team);
            team.AddMember(new Member("Member1"));
            Validator.MemberExistsInTeam("Member1", team);
        }
    }
}
