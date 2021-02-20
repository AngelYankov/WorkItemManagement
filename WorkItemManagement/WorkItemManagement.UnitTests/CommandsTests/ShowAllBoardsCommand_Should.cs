using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class ShowAllBoardsCommand_Should : TestBaseClass
    {
        [TestMethod]
        public void ShowAllBoards_NoBoardsExist()
        {
            var factory = new Mock<IFactory>();
            database.AddTeamToDB(new FakeTeam("Team6"));
            var result = new ShowAllBoardsCommand(new List<string>(){"Team6"},database,factory.Object).Execute();
            Assert.AreEqual("There are no boards in team: 'Team6'.", result);
        }
        
        [TestMethod]
        public void ShowAllBoards_ShowExistingBoards()
        {
            var factory = new Mock<IFactory>();
            var result = new ShowAllBoardsCommand(new List<string>(){"Team1"},database,factory.Object).Execute();
            Assert.AreEqual(result, string.Join(", ",database.GetTeam("Team1").Boards.Select(b => b.Name)));
        }
    }
}
