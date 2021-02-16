using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class FeedbackConstructor_Should
    {
        [TestMethod]
        public void SetProperties()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            Assert.AreEqual("1", feedback.Id);
            Assert.AreEqual("TheFirstFeedback", feedback.Title);
            Assert.AreEqual(3, feedback.Rating);
            Assert.AreEqual(FeedbackStatusType.Done, feedback.FeedbackStatus);
            Assert.AreEqual("This is a feedback created", feedback.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullTitle()
        {
            new Feedback("1022", null, 3, FeedbackStatusType.Done, "This is a feedback created");
        } 
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_IdExists()
        {
             new Feedback("1202", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
             new Feedback("1202", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullId()
        {
            new Feedback(null, "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Max_Id()
        {
            new Feedback(new string('a', 11), "TheFirstFeedback", 1, FeedbackStatusType.Done, "This is a feedback created");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullDescription()
        {
            new Feedback("1003", "TheFirstFeedback", 3, FeedbackStatusType.Done, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MinLength_Title()
        {
            new Feedback("1004", new string('a',9), 3, FeedbackStatusType.Done, "This is a feedback created");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxLength_Title()
        {
            new Feedback("1005", new string('a',51), 3, FeedbackStatusType.Done, "This is a feedback created");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MinLength_Description()
        {
            new Feedback("1006", "TheFirstFeedback", 3, FeedbackStatusType.Done, new string('a', 9));
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxLength_Description()
        {
            new Feedback("1007", "TheFirstFeedback", 3, FeedbackStatusType.Done, new string('a', 501));
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Min_Rating()
        {
            new Feedback("1008", "TheFirstFeedback", -1, FeedbackStatusType.Done, "This is a feedback created");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Max_Rating()
        {
            new Feedback("1009", "TheFirstFeedback", 11, FeedbackStatusType.Done, "This is a feedback created");
        }
    }
}
