using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Abstract;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.BoardTests
{
    [TestClass]
    public class AddWorkItem_Should : Cleaner
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
