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
    public class ChangeRating_Should : Cleaner
    {
        [TestMethod]
        public void RatingChanged_NewRating()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            feedback.ChangeRating(5);
            Assert.AreEqual(5, feedback.Rating);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RatingNotChanged_SameRating()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            feedback.ChangeRating(3);
        }
        
    }
}
