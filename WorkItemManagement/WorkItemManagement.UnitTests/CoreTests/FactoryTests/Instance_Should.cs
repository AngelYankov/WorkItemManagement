using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.UnitTests.CoreTests.FactoryTests
{
    [TestClass]
    public class Instance_Should
    {
        [TestMethod]
        public void InstanceShould_ReturnNewInstance()
        {
            var factory = Factory.Instance;
            Assert.IsInstanceOfType(factory, typeof(IFactory));
        }
    }
}
