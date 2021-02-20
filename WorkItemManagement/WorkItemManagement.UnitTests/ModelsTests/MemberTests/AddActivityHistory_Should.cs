using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.MemberTests
{
    [TestClass]
    public class AddActivityHistory_Should
    {
        [TestMethod]
        public void ActivityHistory_Added()
        {
            var member = new Member("Bruce");
            member.AddActivityHistory("Item: '1020' added.");
            Assert.AreEqual("Item: '1020' added.", string.Join("", member.ActivityHistory));
        }
    }
}
