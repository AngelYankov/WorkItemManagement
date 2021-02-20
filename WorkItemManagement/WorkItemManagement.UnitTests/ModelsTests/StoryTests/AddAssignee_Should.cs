using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.StoryTests
{
    [TestClass]
    public class AddAssignee_Should : Cleaner
    {
        [TestMethod]
        public void AddAssigneeShould_AssigneeAdded()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            var member = new FakeMember();

            story.AddAssignee(member);
            Assert.IsTrue(story.Assignee == member);
        }

        [TestMethod]
        public void AddAssigneeShould_ThrowWhen_AssigneeExists()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            var member = new FakeMember("Member1");
            story.AddAssignee(member);
            var result =Assert.ThrowsException<ArgumentException>(() => story.AddAssignee(member));
            Assert.AreEqual("Story already assigned to 'Member1'", result.Message);
        }
    }
}
