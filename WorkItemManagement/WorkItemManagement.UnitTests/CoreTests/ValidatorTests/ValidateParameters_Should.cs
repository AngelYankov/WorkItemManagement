using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class ValidateParameters_Should
    {
        [TestMethod]
        public void ThrowWhen_WrongCountParameters()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => Validator.ValidateParameters(new List<string>(), 1));
            Assert.AreEqual("Parameters count is not valid", result.Message);

        }
    }
}
