using Microsoft.VisualStudio.TestTools.UnitTesting;
using MajorityElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorityElement.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MajorityElementTest()
        {
            int[] inputArr = { 1, 9, 5, 9, 5, 5, 5, 9, 9, 9, 9 };
            int expected = 9;
            int result = Program.MajorityElement(inputArr);

            Assert.AreEqual(expected, result);
        }
    }
}