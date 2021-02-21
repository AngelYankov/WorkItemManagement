using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.BoardTests
{
    [TestClass]
    public class AddHistory_Should 
    {
        [TestMethod]
        public void History_Added()
        {
            var board = new Board("Board1");
            var feedback = new FakeFeedback();
            board.AddWorkItem(feedback);

            Assert.AreEqual("Item added.", string.Join("",board.ActivityHistory));
        }
    }
}
