using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;

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
