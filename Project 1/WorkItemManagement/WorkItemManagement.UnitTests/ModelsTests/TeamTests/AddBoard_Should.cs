using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.TeamTests
{
    [TestClass]
    public class AddBoard_Should
    {
        [TestMethod]
        public void AddBoardShould_BoardAdded()
        {
            var board = new FakeBoard();
            var team = new Team("Team1");
            team.AddBoard(board);
            Assert.AreEqual(team.Boards.Count, 1);
        }
    }
}
