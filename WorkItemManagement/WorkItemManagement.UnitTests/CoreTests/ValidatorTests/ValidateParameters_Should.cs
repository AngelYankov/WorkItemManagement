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
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhen_WrongCountParameters()
        {
            Validator.ValidateParameters(new List<string>(), 1);
        }
    }
}
