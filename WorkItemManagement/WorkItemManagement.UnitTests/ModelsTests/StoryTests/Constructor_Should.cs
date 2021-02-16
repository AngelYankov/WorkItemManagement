using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.StoryTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod] 
        public void SetProperties()
        {
            var story = new Story("12", "This is the story 12 title", PriorityType.High, StoryStatusType.Done, SizeType.Large, "this is the story 12 description");

            Assert.AreEqual("12", story.Id);
            Assert.AreEqual("This is the story 12 title", story.Title);
            Assert.AreEqual(PriorityType.High, story.Priority);
            Assert.AreEqual(StoryStatusType.Done, story.StoryStatus);
            Assert.AreEqual(SizeType.Large, story.Size);
            Assert.AreEqual("this is the story 12 description", story.Description);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullTitle()
        {
            new Story("15", null, PriorityType.High, StoryStatusType.Done, SizeType.Large, "this is the story 12 description");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_IdExists()
        {
            new Story("13", "This is the story 12 title", PriorityType.High, StoryStatusType.Done, SizeType.Large, "this is the story 12 description");
            new Story("13", "This is the story 12 title", PriorityType.High, StoryStatusType.Done, SizeType.Large, "this is the story 12 description");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullId()
        {
            new Story(null, "This is the story 12 title", PriorityType.High, StoryStatusType.Done, SizeType.Large, "this is the story 12 description");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Max_Id()
        {
            new Story(new string('a',11), "This is the story 12 title", PriorityType.High, StoryStatusType.Done, SizeType.Large, "this is the story 12 description");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullDescription()
        {
            new Story("188", "This is the story 12 title", PriorityType.High, StoryStatusType.Done, SizeType.Large, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MinLength_Title()
        {
            new Story("25", new string('a', 9), PriorityType.High, StoryStatusType.Done, SizeType.Large, "this is the story 12 description");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxLength_Title()
        {
            new Story("111", new string('a', 51), PriorityType.High, StoryStatusType.Done, SizeType.Large, "this is the story 12 description");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MinLength_Description()
        {
            new Story("17", "This is the story 12 title", PriorityType.High, StoryStatusType.Done, SizeType.Large, new string('a', 9));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxLength_Description()
        {
            new Story("19", "This is the story 12 title", PriorityType.High, StoryStatusType.Done, SizeType.Large, new string('a', 501));
        }





    }
}
