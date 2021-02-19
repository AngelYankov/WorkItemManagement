using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class GetBoard_Should
    {
        [TestMethod]
        public void ReturnBoard()
        {
            var db = Database.Instance;
            var board = new FakeBoard();
            board.Name = "Board1";
            var team = new FakeTeam();

            team.AddBoard(board);
            var expected = db.GetBoard("Board1", team);
            Assert.AreEqual(expected, board);
        }

        [TestMethod]
        public void ThrowWhen_BoardDoesNotExist()
        {
            var db = Database.Instance;
            var team = new FakeTeam();
            team.Name = "Team1";
            var result = Assert.ThrowsException<ArgumentException>(() => db.GetBoard("Board1", team));
            Assert.AreEqual("Board: 'Board1' does not exist in team:'Team1'.", result.Message);
        }
    }
}
