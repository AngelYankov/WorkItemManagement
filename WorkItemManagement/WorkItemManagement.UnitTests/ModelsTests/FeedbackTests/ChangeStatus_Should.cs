using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void StatusNotChanged_SameStatus()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            var result = Assert.ThrowsException<ArgumentException>(()=> feedback.ChangeStatus(FeedbackStatusType.New));
            Assert.AreEqual("Status already at 'New'.", result.Message);
        }
    }
}
