using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class CreateStoryCommand_Execute_Should : TestBaseClass //createstory team board id title priority status size description
    {
        [TestMethod]
        public void CreateStory_Succesfully()
        {
            var factory = new Mock<IFactory>();
            var result = new CreateStoryCommand(new List<string>() { "Team1", "Board1", "5", "Title for Story", "high", "large", "Description for story." },
                database,factory.Object).Execute();
            Assert.AreEqual("Created story: 'Title for Story' with id: '5'. Added to board: 'Board1' in team: 'Team1'",result);
        }
    }
}
