using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Commands.Contracts;

namespace WorkItemManagement.UnitTests.CoreTests.CommandManagerTests
{
    [TestClass]
    public class ParseCommand_Should
    {
        [TestMethod]
        [DataRow("createteam")]
        [DataRow("createmember")]
        [DataRow("createboard")]
        [DataRow("createbug")]
        [DataRow("createstory")]
        [DataRow("createfeedback")]
        [DataRow("showallmembers")]
        [DataRow("showallteams")]
        [DataRow("showallboards")]
        [DataRow("showpersonactivity")]
        [DataRow("showallteammembers")]
        [DataRow("showteamactivity")]
        [DataRow("showboardactivity")]
        [DataRow("listworkitems")]
        [DataRow("addmember")]
        [DataRow("addcomment")]
        [DataRow("assign")]
        [DataRow("unassign")]
        [DataRow("changebug")]
        [DataRow("changestory")]
        [DataRow("changefeedback")]
        [DataRow("help")]
        public void ParseCommand_Should_ReturnICommand(string input)
        {
            var commandManager = new Core.CommandManager();
            var command = commandManager.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(ICommand));
        }
        
        [TestMethod]
        public void ParseCommand_Should_ThrowInvalidOperationException_WrongCommand()
        {
            var commandManager = new Core.CommandManager();
            var result = Assert.ThrowsException<InvalidOperationException>(() => commandManager.ParseCommand("wrongCommand"));
            Assert.AreEqual("Command does not exist.", result.Message);
        }
    }
}
