using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class ChangeRating_Should : CleanerID
    {
        [TestMethod]
        public void RatingChanged_NewRating()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            feedback.ChangeRating(5);
            Assert.AreEqual(5, feedback.Rating);
        }
        
        [TestMethod]
        public void RatingNotChanged_SameRating()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            var result = Assert.ThrowsException<ArgumentException>(()=> feedback.ChangeRating(3));
            Assert.AreEqual("Rating already at '3'.", result.Message);
        }
    }
}
