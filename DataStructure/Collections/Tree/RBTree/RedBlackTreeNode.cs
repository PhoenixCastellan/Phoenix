namespace DataStructure.Collections.Tree.RBTree
{
    public class RedBlackTreeNode
    {
        public EColor color;
        public int key;
        public RedBlackTreeNode left;
        public RedBlackTreeNode right;
        public RedBlackTreeNode p;
        public RedBlackTreeNode(int k,EColor clr)
        {
            key = k;
            color = clr;
            left = null;
            right = null;
            p = null;
        }
        public RedBlackTreeNode()
        {
            key = -1;
            color = EColor.Red;
            left = null;
            right = null;
            p = null;
        }
        public RedBlackTreeNode(EColor clr)
        {
            color = clr;
            left = null;
            right = null;
            p = null;
            key = -1;
        }
        public RedBlackTreeNode(int k)//颜色默认为红色
        {
            key = k;
            color = EColor.Red;
            left = null;
            right = null;
            p = null;
        }
    }
}
