using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.WorkItemTests
{
    [TestClass]
    public class Constructor_Should : Cleaner
    {
        [TestMethod]
        public void SetProperties()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            Assert.AreEqual("1", feedback.Id);
            Assert.AreEqual("TheFirstFeedback", feedback.Title);
            Assert.AreEqual("This is a feedback created", feedback.Description);
        }

        [TestMethod]
        public void ThrowArgumentNullException_NullTitle()
        {
            var result = Assert.ThrowsException<ArgumentNullException>(() => new Feedback("1", null, 3, "This is a feedback created"));
            Assert.AreEqual("Value cannot be null.", result.Message);
        }

        [TestMethod]
        public void MinLength_Title()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => new Feedback("1", new string('a', 9), 3, "This is a feedback created"));
            Assert.AreEqual("Title should be between 10 and 50 characters.", result.Message);
        }

        [TestMethod]
        public void MaxLength_Title()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => new Feedback("1", new string('a', 51), 3, "This is a feedback created"));
            Assert.AreEqual("Title should be between 10 and 50 characters.", result.Message);
        }

        [TestMethod]
        public void ThrowArgumentNullException_NullId()
        {
            var result = Assert.ThrowsException<ArgumentNullException>(() => new Feedback(null, "TheFirstFeedback", 3, "This is a feedback created"));
            Assert.AreEqual("Value cannot be null.", result.Message);
        }

        [TestMethod]
        public void ThrowArgumentException_IdExists()
        {
            new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            var result = Assert.ThrowsException<ArgumentException>(() => new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created"));
            Assert.AreEqual("ID already exists.", result.Message);
        }

        [TestMethod]
        public void Max_Id()
        {
            var result = Assert.ThrowsException<ArgumentException>(() 
                => new Feedback(new string('a', 11), "TheFirstFeedback", 1, "This is a feedback created"));
            Assert.AreEqual("ID should be less than 10 characters.", result.Message);
        }

        [TestMethod]
        public void ThrowArgumentNullException_NullDescription()
        {
            var result = Assert.ThrowsException<ArgumentNullException>(() => new Feedback("1", "TheFirstFeedback", 3, null));
            Assert.AreEqual("Value cannot be null.", result.Message);
        }

        [TestMethod]
        public void MinLength_Description()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => new Feedback("1", "TheFirstFeedback", 3, new string('a', 9)));
            Assert.AreEqual("Description should be between 10 and 500 characters.", result.Message);
        }

        [TestMethod]
        public void MaxLength_Description()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => new Feedback("1", "TheFirstFeedback", 3, new string('a', 501)));
            Assert.AreEqual("Description should be between 10 and 500 characters.", result.Message);
        }

        [TestMethod]
        public void History_Initialized()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            Assert.AreEqual(feedback.History.Count, 0);
        }
        [TestMethod]
        public void Comments_Initialized()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            Assert.AreEqual(feedback.Comments.Count, 0);
        }

        [TestMethod]
        public void AddHistoryShould_AddSuccessfully()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            feedback.AddHistory("History added.");
            Assert.AreEqual("History added.", string.Join("", feedback.History));
        }

        [TestMethod]
        public void AddCommentsShould_AddSuccesfully()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            var member = new FakeMember();
            var list = new List<string>() { "Comments added." };
            IDictionary<IMember, IList<string>> comments = new Dictionary<IMember, IList<string>>();

            comments.Add(member, list);
            feedback.AddComment(member,list);
            CollectionAssert.AreEquivalent((ICollection)feedback.Comments, (ICollection)comments);
        }
    }
}
