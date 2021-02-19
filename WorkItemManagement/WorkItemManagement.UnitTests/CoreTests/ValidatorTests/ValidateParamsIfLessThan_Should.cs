using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class ValidateParamsIfLessThan_Should
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhen_DiffCountParams()
        {
            Validator.ValidateParameters(new List<string>(), 1);
        }
    }
}
