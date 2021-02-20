using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.StoryTests
{
    [TestClass]
    public class ChangePriority_Should : CleanerID
    {
        [TestMethod]
        public void PriorityChanged_NewPriority()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");

            story.ChangePriority(PriorityType.Low);
            Assert.AreEqual(PriorityType.Low, story.Priority);
        }

        [TestMethod]
        public void PrioritysNotChanged_SamePriority()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            var result = Assert.ThrowsException<ArgumentException>(() => story.ChangePriority(PriorityType.High));
            Assert.AreEqual("Priority already at 'High'.", result.Message);
        }
    }
}
