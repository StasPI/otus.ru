using Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TreeTest : BaseTest
    {
        [TestMethod]
        public void TestCloneTree()
        {
            var tree = GetTree();
            var cloneTree = (Tree)tree.Clone();
            Assert.IsNotNull(cloneTree);
            Assert.AreNotSame(tree, cloneTree);
            Assert.AreEqual(tree.TreeColor, cloneTree.TreeColor);
            cloneTree.TreeColor = "white";
            Assert.AreNotEqual(tree.TreeColor, cloneTree.TreeColor);
        }

        [TestMethod]
        public void TestMyCloneTree()
        {
            var tree = GetTree();
            var cloneTree = tree.MyClone();
            Assert.IsNotNull(cloneTree);
            Assert.AreNotSame(tree, cloneTree);
            Assert.AreEqual(tree.TreeColor, cloneTree.TreeColor);
            cloneTree.TreeColor = "white";
            Assert.AreNotEqual(tree.TreeColor, cloneTree.TreeColor);
        }
    }
}