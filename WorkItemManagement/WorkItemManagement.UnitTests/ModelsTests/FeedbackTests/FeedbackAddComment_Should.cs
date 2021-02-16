using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class FeedbackAddComment_Should
    {
        [TestMethod]
        public void AddingCommentSuccessfully_CommentAdded()
        {
            var feedback = new Feedback("1012", "TheFirstFeedback", 3, FeedbackStatusType.Done, "This is a feedback created");
            IMember member = new Member("Bruce");
            IList<string> comment = new List<string>();
            comment.Add("This is a comment for feedback");

            IDictionary<IMember, IList<string>> comments = new Dictionary<IMember, IList<string>>();
            comments.Add(member, comment);

            feedback.AddComment(member, comment);
            CollectionAssert.AreEquivalent((ICollection)comments, (ICollection)feedback.Comments);
        }
    }
}
