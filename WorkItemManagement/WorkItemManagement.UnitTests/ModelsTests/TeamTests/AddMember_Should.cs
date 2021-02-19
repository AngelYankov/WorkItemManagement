using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.TeamTests
{
    [TestClass]
    public class AddMember_Should
    {
        [TestMethod]
        public void AddMemberShould_MemberAdded()
        {
            var member = new FakeMember();
            var team = new Team("Team1");
            team.AddMember(member);
            Assert.AreEqual(team.Members.Count, 1);
        }
    }
}
