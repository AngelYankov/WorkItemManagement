using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Models.Abstract;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.BoardTests
{
    [TestClass]
    public class AddHistory_Should : Cleaner
    {
        [TestMethod]
        public void History_Added()
        {
            var board = new Board("Board1");
            var feedback = new Feedback("1", "Feedbacktitle", 3, "This is a description for feedback");
            board.AddWorkItem(feedback);

            Assert.AreEqual("'Feedbacktitle' added.", string.Join("",board.ActivityHistory));
        }
        
    }
}
