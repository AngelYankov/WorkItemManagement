using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Abstract;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.StoryTests
{
    [TestClass]
    public class RemoveAssignee_Should : Cleaner
    {
        [TestMethod]
        public void RemoveAssigneeShould_AssigneeRemoved()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            var member = new FakeMember();

            story.AddAssignee(member);
            story.RemoveAssignee();
            Assert.IsTrue(story.Assignee == null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveAsssigneeShould_ThrowWhen_AssigneeIsNull()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            story.RemoveAssignee();
        }
      
    }
}
