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
    public class ChangeSize_Should : Cleaner
    {
        [TestMethod]
        public void SizeChange_NewStatus()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Small, "this is the story 12 description");
            story.ChangeSize(SizeType.Large);
            Assert.AreEqual(SizeType.Large, story.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PrioritysNotChanged_SamePriority()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            story.ChangeSize(SizeType.Large);
        }
       
    }
}
