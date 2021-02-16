using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class FeedbackChangeStatus_Should
    {
        [TestMethod]
        public void StatusChanged_NewStatus()
        {
            var feedback = new Feedback("1000", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            feedback.ChangeStatus(FeedbackStatusType.Scheduled);
            Assert.AreEqual(FeedbackStatusType.Scheduled, feedback.FeedbackStatus);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StatusNotChanged_SameStatus()
        {
            var feedback = new Feedback("1001", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            feedback.ChangeStatus(FeedbackStatusType.Done);
        }
    }
}
