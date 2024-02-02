using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void Deconstruct()
        {
            Name name = new("firstName", "lastName");
            (string firstName, string lastName) = name;
            Assert.AreEqual(("firstName", "lastName"), (firstName, lastName));
        }
    }
}
