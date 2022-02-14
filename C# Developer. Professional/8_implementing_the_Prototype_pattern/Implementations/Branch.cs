namespace Implementations
{
    public class Branch : Tree, ICloneable
    {
        public string BranchColor;
        public int NumberOfBranch;
        
        public Branch(string TreeColor, string branchColor, int numberOfBranch) : base(TreeColor)
        {
            BranchColor = branchColor;
            NumberOfBranch = numberOfBranch;
        }

        public override Branch MyClone()
        {
            return new Branch(TreeColor, BranchColor, NumberOfBranch);
        }

        public override object Clone()
        {
            return MyClone();
        }
    }
}