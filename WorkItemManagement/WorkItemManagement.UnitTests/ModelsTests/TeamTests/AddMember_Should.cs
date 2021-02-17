using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.TeamTests
{
    [TestClass]
    public class AddMember_Should
    {
        [TestMethod]
        public void AddMemberShould_MemberAdded()
        {
            var member = new Member("Bruce");
            var team = new Team("Team1");
            team.AddMember(member);
            Assert.AreEqual(team.Members.Count, 1);
        }
    }
}
