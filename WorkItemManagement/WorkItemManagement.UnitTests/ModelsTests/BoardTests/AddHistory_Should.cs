﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Models.Enums;
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
            var feedback = new Feedback("1002", "Feedbacktitle", 3, FeedbackStatusType.Done, "This is a description for feedback");
            board.AddWorkItem(feedback);

            Assert.AreEqual("'Feedbacktitle' added.", string.Join("",board.ActivityHistory));
        }
    }
}
