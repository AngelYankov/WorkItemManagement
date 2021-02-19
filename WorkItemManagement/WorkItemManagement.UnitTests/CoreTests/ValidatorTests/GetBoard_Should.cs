using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class GetBoard_Should
    {
        [TestMethod]
        public void GetBoard_ReturnExistingBoard()
        {
            var team = new Team("Team1");
            team.AddBoard(new Board("Board1"));
            var board = Validator.GetBoard("Board1", team);
            Assert.IsInstanceOfType(board, typeof(IBoard));
            Assert.AreEqual("Board1", board.Name);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBoard_ThrowWhen_BoardDoesNotExist()
        {
            var team = new Team("Team1");
            team.AddBoard(new Board("Board1"));
            Validator.GetBoard("Board2", team);
        }
    }
}
