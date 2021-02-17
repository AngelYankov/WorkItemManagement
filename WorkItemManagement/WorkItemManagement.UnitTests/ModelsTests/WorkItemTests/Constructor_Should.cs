using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Abstract;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.WorkItemTests
{
    [TestClass]
    public class Constructor_Should : Cleaner
    {
        [TestMethod]
        public void SetProperties()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            Assert.AreEqual("1", feedback.Id);
            Assert.AreEqual("TheFirstFeedback", feedback.Title);
            Assert.AreEqual("This is a feedback created", feedback.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullTitle()
        {
            new Feedback("1", null, 3, FeedbackStatusType.Done, "This is a feedback created");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MinLength_Title()
        {
            new Feedback("1", new string('a', 9), 3, FeedbackStatusType.Done, "This is a feedback created");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxLength_Title()
        {
            new Feedback("1", new string('a', 51), 3, FeedbackStatusType.Done, "This is a feedback created");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullId()
        {
            new Feedback(null, "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_IdExists()
        {
            new Feedback("1", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            new Feedback("1", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
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
            new Feedback("1", "TheFirstFeedback", 3, FeedbackStatusType.Done, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MinLength_Description()
        {
            new Feedback("1", "TheFirstFeedback", 3, FeedbackStatusType.Done, new string('a', 9));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxLength_Description()
        {
            new Feedback("1", "TheFirstFeedback", 3, FeedbackStatusType.Done, new string('a', 501));
        }

        [TestMethod]
        public void History_Initialized()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            Assert.AreEqual(feedback.History.Count, 0);
        }
        [TestMethod]
        public void Comments_Initialized()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            Assert.AreEqual(feedback.Comments.Count, 0);
        }
        [TestMethod]
        public void AddHistoryShould_AddSuccessfully()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            feedback.AddHistory("History added.");
            Assert.AreEqual("History added.", string.Join("", feedback.History));
        }
        [TestMethod]
        public void AddCommentsShould_AddSuccesfully()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            var member = new FakeMember();
            var list = new List<string>() { "Comments added." };
            IDictionary<IMember, IList<string>> comments = new Dictionary<IMember, IList<string>>();

            comments.Add(member, list);
            feedback.AddComment(member,list);
            CollectionAssert.AreEquivalent((ICollection)feedback.Comments, (ICollection)comments);
        }
        private class FakeMember : IMember
        {
            public string Name => throw new NotImplementedException();

            public IList<IWorkItem> WorkItems => throw new NotImplementedException();

            public IList<string> ActivityHistory => throw new NotImplementedException();

            public void AddActivityHistory(string info)
            {
                throw new NotImplementedException();
            }

            public void AddWorkItems(IWorkItem item)
            {
                throw new NotImplementedException();
            }

            public void RemoveWorkItems(IWorkItem item)
            {
                throw new NotImplementedException();
            }
        }
        
    }
}
