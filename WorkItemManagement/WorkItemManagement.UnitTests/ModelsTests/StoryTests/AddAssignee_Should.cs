using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Abstract;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.StoryTests
{
    [TestClass]
    public class AddAssignee_Should : Cleaner
    {
        [TestMethod]
        public void AddAssigneeShould_AssigneeAdded()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, StoryStatusType.Done, SizeType.Large, "this is the story 12 description");
            var member = new Member("Member1");

            story.AddAssignee(member);
            Assert.IsTrue(story.Assignee == member);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddAssigneeShould_ThrowWhen_AssigneeExists()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, StoryStatusType.Done, SizeType.Large, "this is the story 12 description");
            var member = new Member("Member1");
            story.AddAssignee(member);
            story.AddAssignee(member);
        }

    }
}
