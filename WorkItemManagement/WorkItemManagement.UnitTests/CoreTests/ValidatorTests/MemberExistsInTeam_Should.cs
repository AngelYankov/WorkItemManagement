using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class MemberExistsInTeam_Should : TestBaseClass
    {
        [TestMethod]
        public void ThrowWhen_AlreadyExists()
        {
            var validator = new Validator(database);

            var member = new FakeMember("Member1");
            var team = new FakeTeam("Team1");
            team.AddMember(member);
            var result = Assert.ThrowsException<ArgumentException>(()=>validator.MemberExistsInTeam("Member1", team));
            Assert.AreEqual("Member: 'Member1' already exist in team: 'Team1'.", result.Message);
        }
    }
}
