using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.CoreTests.FactoryTests
{
    [TestClass]
    public class CreateMember_Should
    {
        [TestMethod]
        public void CreateMember_CreatedSuccessfully()
        {
            var member = Factory.Instance.CreateMember("Member1");
            Assert.IsInstanceOfType(member, typeof(IMember));
        }
    }
}
