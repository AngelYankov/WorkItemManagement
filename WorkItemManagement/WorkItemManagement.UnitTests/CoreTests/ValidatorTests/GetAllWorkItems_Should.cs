using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class GetAllWorkItems_Should
    {
        [TestMethod]
        public void GetAllWorkItemsShould_ReturnAll()
        {
            var fakeData = new FakeDatabase();
            var list = Validator.GetAllWorkItems(fakeData);
            Assert.IsInstanceOfType(list, typeof(IList<IWorkItem>));
        }
    }
}
