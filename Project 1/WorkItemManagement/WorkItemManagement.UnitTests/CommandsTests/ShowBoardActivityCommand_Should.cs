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
    public class ShowBoardActivityCommand_Should : TestBaseClass
    {
        [TestMethod]
        public void ShowBoard_NoBoardActivity()
        {
            var factory = new Mock<IFactory>();
            var result = new ShowBoardActivityCommand(new List<string>() { "Board3", "Team2" }, database, factory.Object).Execute();
            var board = database.GetTeam("Team2").Boards.First(b => b.Name.Equals("Board3"));
            Assert.AreEqual(result, "No activity history for board: 'Board3'.") ;
        }
        
        [TestMethod]
        public void ShowBoard_ShowsBoardsActivity()
        {
            var factory = new Mock<IFactory>();
            var result = new ShowBoardActivityCommand(new List<string>() { "Board1", "Team1" }, database, factory.Object).Execute();
            var board = database.GetTeam("Team1").Boards.First(b => b.Name.Equals("Board1"));
            Assert.AreEqual(result, string.Join("; ", board.ActivityHistory));
        }
    }
}
