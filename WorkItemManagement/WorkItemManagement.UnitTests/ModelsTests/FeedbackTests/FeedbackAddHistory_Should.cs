using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class FeedbackAddHistory_Should
    {
        [TestMethod]
        public void AddHistorySuccessfully_HistoryAdded()
        {
            var feedback = new Feedback("1021", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            feedback.AddHistory("Adding history to feedback");
            Assert.AreEqual("Adding history to feedback", string.Join("",feedback.History));
        }
    }
}
