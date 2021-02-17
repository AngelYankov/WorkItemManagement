using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Abstract;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class ChangeStatus_Should : Cleaner
    {
        [TestMethod]
        public void StatusChanged_NewStatus()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            feedback.ChangeStatus(FeedbackStatusType.Scheduled);
            Assert.AreEqual(FeedbackStatusType.Scheduled, feedback.FeedbackStatus);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StatusNotChanged_SameStatus()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            feedback.ChangeStatus(FeedbackStatusType.New);
        }
        
    }
}
