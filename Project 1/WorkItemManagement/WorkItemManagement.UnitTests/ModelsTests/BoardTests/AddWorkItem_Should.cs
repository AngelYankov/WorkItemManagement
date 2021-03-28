using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.BoardTests
{
    [TestClass]
    public class AddWorkItem_Should 
    {
        [TestMethod]
        public void WorkItem_Added()
        {
            var board = new Board("Board1");
            var feedback = new FakeFeedback();
            board.AddWorkItem(feedback);
            Assert.IsTrue(board.WorkItems.Contains(feedback));
        }
    }
}
