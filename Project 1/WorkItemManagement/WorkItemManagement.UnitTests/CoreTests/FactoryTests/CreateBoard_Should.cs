using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.CoreTests.FactoryTests
{
    [TestClass]
    public class CreateBoard_Should
    {
        [TestMethod]
        public void CreateBoard_Should_CreateBoardSuccessfully()
        {
            var board = Factory.Instance.CreateBoard("board1");
            Assert.IsInstanceOfType(board, typeof(IBoard));
        }
    }
}
