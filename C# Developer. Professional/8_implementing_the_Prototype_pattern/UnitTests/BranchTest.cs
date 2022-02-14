using Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BranchTest : BaseTest
    {
        [TestMethod]
        public void TestCloneBranch()
        {
            var branch = GetBranch();
            var cloneBranch = (Branch)branch.Clone();
            Assert.IsNotNull(cloneBranch);
            Assert.AreNotSame(branch, cloneBranch);
            Assert.AreEqual(branch.TreeColor, cloneBranch.TreeColor);
            Assert.AreEqual(branch.BranchColor, cloneBranch.BranchColor);
            Assert.AreEqual(branch.NumberOfBranch, cloneBranch.NumberOfBranch);

            cloneBranch.TreeColor = "white";
            cloneBranch.BranchColor = "white";
            cloneBranch.NumberOfBranch = 5;

            Assert.AreNotEqual(branch.TreeColor, cloneBranch.TreeColor);
            Assert.AreNotEqual(branch.BranchColor, cloneBranch.BranchColor);
            Assert.AreNotEqual(branch.NumberOfBranch, cloneBranch.NumberOfBranch);
        }

        [TestMethod]
        public void TestMyCloneBranch()
        {
            var branch = GetBranch();
            var cloneBranch = branch.MyClone();
            Assert.IsNotNull(cloneBranch);
            Assert.AreNotSame(branch, cloneBranch);
            Assert.AreEqual(branch.TreeColor, cloneBranch.TreeColor);
            Assert.AreEqual(branch.BranchColor, cloneBranch.BranchColor);
            Assert.AreEqual(branch.NumberOfBranch, cloneBranch.NumberOfBranch);

            cloneBranch.TreeColor = "white";
            cloneBranch.BranchColor = "white";
            cloneBranch.NumberOfBranch = 5;

            Assert.AreNotEqual(branch.TreeColor, cloneBranch.TreeColor);
            Assert.AreNotEqual(branch.BranchColor, cloneBranch.BranchColor);
            Assert.AreNotEqual(branch.NumberOfBranch, cloneBranch.NumberOfBranch);
        }
    }
}
