using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class BugAddComment_Should
    {
        [TestMethod]
        public void AddingCommentSuccessfully_CommentAdded()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1039", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            IMember member = new Member("Bruce");
            IList<string> comment = new List<string>();
            comment.Add("This is a comment for bug");

            IDictionary<IMember, IList<string>> comments = new Dictionary<IMember, IList<string>>();
            comments.Add(member, comment);

            bug.AddComment(member, comment);
            CollectionAssert.AreEquivalent((ICollection)comments, (ICollection)bug.Comments);
        }
    }
}
