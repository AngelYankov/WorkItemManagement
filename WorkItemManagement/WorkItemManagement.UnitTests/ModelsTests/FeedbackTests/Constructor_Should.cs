using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class Constructor_Should : Cleaner
    {
        [TestMethod]
        public void SetProperties()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            Assert.AreEqual(3, feedback.Rating);
            Assert.AreEqual(FeedbackStatusType.New, feedback.FeedbackStatus);
        }
        
        [TestMethod]
        public void Min_Rating()
        {
            var result = Assert.ThrowsException<ArgumentException>(()=> new Feedback("1", "TheFirstFeedback", -1, "This is a feedback created"));
            Assert.AreEqual("Rating should be between 1 and 10.", result.Message);
        }
        
        [TestMethod]
        public void Max_Rating()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => new Feedback("1", "TheFirstFeedback", 11, "This is a feedback created"));
            Assert.AreEqual("Rating should be between 1 and 10.", result.Message);
        }
    }
}
