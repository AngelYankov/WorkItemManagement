using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.BoardTests
{
    [TestClass]
    public class AddHistory_Should  // AddedSuccessfully_Scenario_ExpectedBehaviour
    {
        [TestMethod]
        public void History_Added()
        {
            var board = new Board("Board1");
            board.ActivityHistory.Add("history");
            Assert.AreEqual("history", string.Join("",board.ActivityHistory));
        }
    }
}
