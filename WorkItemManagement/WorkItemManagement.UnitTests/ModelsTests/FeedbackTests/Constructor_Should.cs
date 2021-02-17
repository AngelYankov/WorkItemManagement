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
        [ExpectedException(typeof(ArgumentException))]
        public void Min_Rating()
        {
            new Feedback("1", "TheFirstFeedback", -1, "This is a feedback created");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Max_Rating()
        {
            new Feedback("1", "TheFirstFeedback", 11, "This is a feedback created");
        }
        
        
    }
   
}
