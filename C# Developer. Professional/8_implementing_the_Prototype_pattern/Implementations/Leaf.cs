namespace Implementations
{
    public class Leaf : Branch, ICloneable
    {
        public string LeafColor;
        public int NumberOfLeaf;

        public Leaf(string TreeColor, string BranchColor, int NumberOfBranch, string leafColor, int numberOfLeaf) : base(TreeColor, BranchColor, NumberOfBranch)
        {
            LeafColor = leafColor;
            NumberOfLeaf = numberOfLeaf;
        }

        public override Leaf MyClone()
        {
            return new Leaf(TreeColor, BranchColor, NumberOfBranch, LeafColor, NumberOfLeaf);
        }

        public override object Clone()
        {
            return MyClone();
        }
    }
}