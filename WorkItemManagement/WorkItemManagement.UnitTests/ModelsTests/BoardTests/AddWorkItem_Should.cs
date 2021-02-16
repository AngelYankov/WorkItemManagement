using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.BoardTests
{
    [TestClass]
    public class AddWorkItem_Should //to do
    {
        [TestMethod]
        public void WorkItem_Added()
        {
            var board = new Board("Board1");
            var feedback = new Feedback("1023", "Feedbacktitle", 3, FeedbackStatusType.Done, "This is a description for feedback");
            board.AddWorkItem(feedback);

            Assert.AreEqual("1023", board.WorkItems[0].Id);
        }
    }
}
