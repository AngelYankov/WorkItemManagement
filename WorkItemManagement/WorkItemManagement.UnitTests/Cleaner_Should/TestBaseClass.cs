using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.Cleaner_Should
{
    [TestClass]
    public class TestBaseClass
    {
        public readonly IDatabase database = new FakeDatabase();
        [TestInitialize]
        public void SeedData()
        {
            var member1 = new FakeMember("Member1");
            var member2 = new FakeMember("Member2");
            var team1 = new FakeTeam("Team1");
            var team2 = new FakeTeam("Team2");
            var board1 = new FakeBoard("Board1");
            var board2 = new FakeBoard("Board2");
            var feedback = new FakeFeedback("1");
            var story = new FakeStory("2");

            database.AddTeamToDB(team1);
            database.AddTeamToDB(team2);
            database.AddMemberToDB(member1);
            database.AddMemberToDB(member2);
            database.AddWorkItemToDB(feedback);
            database.AddWorkItemToDB(story);

            team2.AddMember(member1);

            team1.AddBoard(board1);
            team2.AddBoard(board2);

            board1.AddWorkItem(feedback);
            board2.AddWorkItem(story);

            member1.AddWorkItems(story);
            member1.AddWorkItems(feedback);

        }
        [TestCleanup]
        public void ClearDatabase()
        {
            database.AllMembers.Clear();
            database.AllWorkItems.Clear();
            database.AllTeams.Clear();
        }
    }
}
