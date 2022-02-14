using Implementations;

namespace UnitTests
{
    public class BaseTest
    {
        public Leaf GetLeaf()
        {
            return new Leaf("woody", "brown", 10, "green", 10);
        }

        public Branch GetBranch()
        {
            return new Branch("woody", "brown", 10);
        }

        public Tree GetTree()
        {
            return new Tree("woody");
        }
    }
}