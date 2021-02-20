using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void RemoveAsssigneeShould_ThrowWhen_AssigneeIsNull()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            var result = Assert.ThrowsException<ArgumentException>(() => story.RemoveAssignee());
            Assert.AreEqual("Story has no assignee.", result.Message);
        }
    }
}
