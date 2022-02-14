using Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class SheetTest : BaseTest
    {
        [TestMethod]
        public void TestCloneSheet()
        {
            var leaf = GetLeaf();
            var cloneLeaf = (Leaf)leaf.Clone();
            Assert.IsNotNull(cloneLeaf);
            Assert.AreNotSame(leaf, cloneLeaf);
            Assert.AreEqual(leaf.TreeColor, cloneLeaf.TreeColor);
            Assert.AreEqual(leaf.BranchColor, cloneLeaf.BranchColor);
            Assert.AreEqual(leaf.NumberOfBranch, cloneLeaf.NumberOfBranch);
            Assert.AreEqual(leaf.LeafColor, cloneLeaf.LeafColor);
            Assert.AreEqual(leaf.NumberOfLeaf, cloneLeaf.NumberOfLeaf);

            cloneLeaf.TreeColor = "white";
            cloneLeaf.BranchColor = "white";
            cloneLeaf.NumberOfBranch = 5;
            cloneLeaf.LeafColor = "white";
            cloneLeaf.NumberOfLeaf = 5;

            Assert.AreNotEqual(leaf.TreeColor, cloneLeaf.TreeColor);
            Assert.AreNotEqual(leaf.BranchColor, cloneLeaf.BranchColor);
            Assert.AreNotEqual(leaf.NumberOfBranch, cloneLeaf.NumberOfBranch);
            Assert.AreNotEqual(leaf.LeafColor, cloneLeaf.LeafColor);
            Assert.AreNotEqual(leaf.NumberOfLeaf, cloneLeaf.NumberOfLeaf);
        }

        [TestMethod]
        public void TestMyCloneSheet()
        {
            var leaf = GetLeaf();
            var cloneLeaf = leaf.MyClone();
            Assert.IsNotNull(cloneLeaf);
            Assert.AreNotSame(leaf, cloneLeaf);
            Assert.AreEqual(leaf.TreeColor, cloneLeaf.TreeColor);
            Assert.AreEqual(leaf.BranchColor, cloneLeaf.BranchColor);
            Assert.AreEqual(leaf.NumberOfBranch, cloneLeaf.NumberOfBranch);
            Assert.AreEqual(leaf.LeafColor, cloneLeaf.LeafColor);
            Assert.AreEqual(leaf.NumberOfLeaf, cloneLeaf.NumberOfLeaf);

            cloneLeaf.TreeColor = "white";
            cloneLeaf.BranchColor = "white";
            cloneLeaf.NumberOfBranch = 5;
            cloneLeaf.LeafColor = "white";
            cloneLeaf.NumberOfLeaf = 5;

            Assert.AreNotEqual(leaf.TreeColor, cloneLeaf.TreeColor);
            Assert.AreNotEqual(leaf.BranchColor, cloneLeaf.BranchColor);
            Assert.AreNotEqual(leaf.NumberOfBranch, cloneLeaf.NumberOfBranch);
            Assert.AreNotEqual(leaf.LeafColor, cloneLeaf.LeafColor);
            Assert.AreNotEqual(leaf.NumberOfLeaf, cloneLeaf.NumberOfLeaf);
        }
    }
}