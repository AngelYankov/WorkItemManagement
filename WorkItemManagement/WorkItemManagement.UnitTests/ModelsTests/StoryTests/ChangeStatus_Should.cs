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
    public class ChangeStatus_Should : Cleaner
    {
        [TestMethod]
        public void StatusChanged_NewStatus()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            story.ChangeStatus(StoryStatusType.Done);
            Assert.AreEqual(StoryStatusType.Done, story.StoryStatus);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StatusNotChanged_SameStatus()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            story.ChangeStatus(StoryStatusType.NotDone);
        }
       
    }
}
