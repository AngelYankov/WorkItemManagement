using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.TeamTests
{
    [TestClass]
    public class AddBoard_Should
    {
        [TestMethod]
        public void AddBoardShould_BoardAdded()
        {
            var board = new Board("Board1");
            var team = new Team("Team1");
            team.AddBoard(board);
            Assert.AreEqual(team.Boards.Count, 1);
        }
    }
}
