using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kattis.Test
{
    [TestClass]
    public class QuadrantSelectionTest
    {
        [TestMethod]
        public void FirstQuadrant()
        {
            Assert.AreEqual(1, QuadrantSelection.GetQuadrant(10, 6));
        }

        [TestMethod]
        public void ForthQuadrant()
        {
            Assert.AreEqual(4, QuadrantSelection.GetQuadrant(9, -13));
        }
    }
}
