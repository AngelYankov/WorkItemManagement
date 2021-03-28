using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class ShowAllTeamMembersCommand_Should : TestBaseClass
    {
        [TestMethod]
        public void ShowAllTeamMembers_ShowAll()
        {
            var factory = new Mock<IFactory>();
            var result = new ShowAllTeamMembersCommand(new List<string>() { "Team2" }, database, factory.Object).Execute();
            Assert.AreEqual(result, string.Join(", ", database.GetTeam("Team2").Members.Select(b => b.Name)));
        }
        
        [TestMethod]
        public void ShowAllTeamMembers_NoTeamMembers()
        {
            var factory = new Mock<IFactory>();
            var result = new ShowAllTeamMembersCommand(new List<string>() { "Team1" }, database, factory.Object).Execute();
            Assert.AreEqual(result, "There are no members in team: 'Team1'.");
        }
    }
}
