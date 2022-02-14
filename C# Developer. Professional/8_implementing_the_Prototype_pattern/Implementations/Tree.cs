using Abstractions;

namespace Implementations
{
    public class Tree : ICloneable, IMyCloneable<Tree>
    {
        public string TreeColor;

        public Tree(string treeColor)
        {
            TreeColor = treeColor;
        }

        public virtual Tree MyClone()
        {
            return new Tree(TreeColor);
        }

        public virtual object Clone()
        {
            return MyClone();
        }
    }
}