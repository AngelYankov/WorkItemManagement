using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class ShowTeamActivityCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void ShowTeamActivity_ShowMemberAndBoardActivity()
        {
            var factory = new Mock<IFactory>();
            StringBuilder sb = new StringBuilder();
            var team = new FakeTeam("Team5");
            database.AddTeamToDB(team);
            var board = new FakeBoard();
            team.AddBoard(board);
            var f1 = new FakeFeedback("5");
            board.AddWorkItem(f1);
            var f2 = new FakeFeedback("6");
            board.AddWorkItem(f2);
            var member = new FakeMember("Member5");
            database.AddMemberToDB(member);
            team.AddMember(member);
            var f3 = new FakeFeedback("7");
            member.AddWorkItems(f3);

            sb.AppendLine($"Team: 'Team5' - Boards activity: ");
            var activityTeam = team.Boards.SelectMany(b => b.ActivityHistory).ToList();
            sb.AppendLine(string.Join("; ", activityTeam));

            sb.AppendLine($"Team: 'Team5' - Members activity: ");
            var activityMembers = team.Members.SelectMany(m => m.ActivityHistory).ToList();
            sb.AppendLine(string.Join("; ", activityMembers));

            var result = new ShowTeamActivityCommand(new List<string>() { "Team5" }, database, factory.Object).Execute();
            Assert.AreEqual(sb.ToString(), result);
        }
    }
}
