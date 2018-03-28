using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kattis.Test
{
    [TestClass]
    public class AClassyProblemTest
    {
        [TestMethod]
        public void Kalle()
        {
            var people = File
                .ReadAllLines("AClassyProblemTestInput.txt")
                .Select(AClassyProblem.Parse)
                .ToList();
            
            var result = AClassyProblem
                .Sort(people)
                .ToList();
            
            var expected = File
                .ReadAllLines("AClassyProblemTestOutput.txt")
                .ToList();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
