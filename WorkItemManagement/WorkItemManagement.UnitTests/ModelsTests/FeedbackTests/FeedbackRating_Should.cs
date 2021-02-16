using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class FeedbackRating_Should
    {
        [TestMethod]
        public void RatingChanged_NewRating()
        {
            var feedback = new Feedback("1010", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            feedback.ChangeRating(5);
            Assert.AreEqual(5, feedback.Rating);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RatingNotChanged_SameRating()
        {
            var feedback = new Feedback("1011", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            feedback.ChangeRating(3);
        }
    }
}
