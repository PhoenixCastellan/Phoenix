namespace DataStructure.Collections.Tree.RBTree
{
    public class RedBlackTree
    {
        private RedBlackTreeNode nil;//叶节点(Black)

        private RedBlackTreeNode root;//根节点(Black)

        public RedBlackTree()
        {
            nil = new RedBlackTreeNode(EColor.Black);
            root = nil;
            root.p = nil;
        }

        public RedBlackTree(int k)//构造函数
        {
            nil = new RedBlackTreeNode(EColor.Black);
            root = new RedBlackTreeNode(k,EColor.Black);
            root.p = nil;
            root.left = nil;
            root.right = nil;
        } 

        public RedBlackTree(int[] arr)
        {
            nil = new RedBlackTreeNode(EColor.Black);
            root = nil;
            root.p = nil;
            foreach (int intItem in arr)
            {
                RedBlackTreeNode z = new RedBlackTreeNode(intItem);
                RBInsert(z);
            }    
        }

        private void LeftRotate(RedBlackTreeNode x) //x.right != nil 且 根节点的父节点为nil
        {
            RedBlackTreeNode y = x.right;
            x.right = y.left;
            if (y.left != nil)
            {
                y.left.p = x;
            }
            y.p = x.p;
            if (x.p == nil)
            {
                root = y;
            }
            else if (x == x.p.left)
            {
                x.p.left = y;
            } 
            else
            {
                x.p.left = y;
            }
            y.left = x;
            x.p = y;
        }

        private void RightRotate(RedBlackTreeNode y)//y.left != nil 且 根节点的父节点为nil
        {
            RedBlackTreeNode x = y.left;
            y.left = x.right;
            if (x.right != nil)
            {
                x.right.p = y;
            }
            x.p = y.p;
            if (y.p == nil)
            {
                root = x;
            }
            else if (y==y.p.left)
            {
                y.p.left = x;
            }
            else
            {
                y.p.right = x;
            }
            x.right = y;
            y.p = x;
        }
   
        private void RBInsertFixUp(RedBlackTreeNode z)//辅助程序
        {
#region 
            while (z.p.color == EColor.Red)
            {
                if (z.p == z.p.p.left)
                {
                    RedBlackTreeNode y = z.p.p.right;
                    if (y.color == EColor.Red)//case 1
                    {
                        z.p.color = EColor.Black;
                        y.color = EColor.Black;
                        z.p.p.color = EColor.Red;
                        z = z.p.p;
                    }
                    else if (z == z.p.right) // case 2
                    {
                        z = z.p;
                        LeftRotate(z);
                    }
                    else// case 3 z = z.p.left
                    {
                        z.p.color = EColor.Black;
                        z.p.p.color = EColor.Red;
                        RightRotate(z.p.p);
                    }
                }
                else
                {
                    RedBlackTreeNode y = z.p.p.left;
                    if (y.color == EColor.Red)//case 1
                    {
                        z.p.color = EColor.Black;
                        y.color = EColor.Black;
                        z.p.p.color = EColor.Red;
                        z = z.p.p;
                    }
                    else if (z == z.p.left) // case 2
                    {
                        z = z.p;
                        RightRotate(z);
                    }
                    else// case 3 z = z.p.left
                    {
                        z.p.color = EColor.Black;
                        z.p.p.color = EColor.Red;
                        LeftRotate(z.p.p);
                    }
                }
            }
#endregion
          
            root.color = EColor.Black;
        }

        public void RBInsert(RedBlackTreeNode z)//插入数据
        {
            RedBlackTreeNode y = nil;
            RedBlackTreeNode x = root;
            while(x != nil)
            {
                y = x;
                if (z.key < x.key)
                {
                    x = x.left;
                } 
                else
                {
                    x = x.right;
                }
            }
            z.p = y;
            if (y == nil)
            {
                root = z;
            }
            else if (z.key < y.key)
            {
                y.left = z;
            }
            else
            {
                y.right = z;
            }
            z.left = nil;
            z.right = nil;
            z.color = EColor.Red;
            RBInsertFixUp(z);
        }

        private void RBTransplant(RedBlackTreeNode u,RedBlackTreeNode v)//v替代u
        {
            if (u.p == nil)
            {
                root = v;
            } 
            else if(u == u.p.left)
            {
                u.p.left = v;
            }
            else
            {
                u.p.right = v;
            }
            v.p = u.p;
        }

        public RedBlackTreeNode TreeMinmum(RedBlackTreeNode x)//获得节点x下的最小值
        {
            while (x.left != nil)
            {
                x = x.left;
            }
            return x;
        }

        public void RBDelete(RedBlackTreeNode m)//删除数据
        {
            RedBlackTreeNode z = Search(m.key);

            RedBlackTreeNode y = z;
            RedBlackTreeNode x;
            EColor yOriginalColor = y.color;
            if (z.left == nil)
            {
                x = z.right;//记录下x
                RBTransplant(z, z.right);
            } 
            else if(z.right == nil)
            {
                x = z.left;
                RBTransplant(z, z.left);
            }
            else
            {
                y = TreeMinmum(z.right);
                yOriginalColor = y.color;
                x = y.right;
                if (y.p==z)
                {
                    x.p = y;
                } 
                else
                {
                    RBTransplant(y, y.right);
                    y.right = z.right;
                    y.right.p = y;
                }
                RBTransplant(z, y);
                y.left = z.left;
                y.left.p = y;
                y.color = z.color;
            }
            if (yOriginalColor == EColor.Black)
            {
                RBDeleteFixUp(x);
            }
        }

        private void RBDeleteFixUp(RedBlackTreeNode x)//删除元素后维持红黑性质
        {
#region 
            while (x != root && x.color == EColor.Black)
            {
                if (x == x.p.left)
                {
                    RedBlackTreeNode w = x.p.right;
                    if (w.color == EColor.Red)
                    {
                        w.color = EColor.Black;
                        x.p.color = EColor.Red;
                        LeftRotate(x.p);
                        w = x.p.right;
                    }
                    if (w.left.color == EColor.Black && w.right.color == EColor.Black)
                    {
                        w.color = EColor.Red;
                        x = x.p;
                    }
                    else if (w.right.color == EColor.Black)
                    {
                        w.left.color = EColor.Black;
                        w.color = EColor.Red;
                        RightRotate(w);
                        w = x.p.right;
                    }
                    else
                    {
                        w.color = x.p.color;
                        x.p.color = EColor.Black;
                        w.right.color = EColor.Black;
                        LeftRotate(x.p);
                        x = root;
                    }
                }
                else
                {
                    RedBlackTreeNode w = x.p.left;
                    if (w.color == EColor.Red)
                    {
                        w.color = EColor.Black;
                        x.p.color = EColor.Red;
                        RightRotate(x.p);
                        w = x.p.left;
                    }
                    if (w.left.color == EColor.Black && w.right.color == EColor.Black)
                    {
                        w.color = EColor.Red;
                        x = x.p;
                    }
                    else if (w.left.color == EColor.Black)
                    {
                        w.right.color = EColor.Black;
                        w.color = EColor.Red;
                        LeftRotate(w);
                        w = x.p.left;
                    }
                    else
                    {
                        w.color = x.p.color;
                        x.p.color = EColor.Black;
                        w.left.color = EColor.Black;
                        RightRotate(x.p);
                        x = root;
                    }
                }
            }
#endregion 
            x.color = EColor.Black;
        }

        private string strTreeWalk = "";

        public string InoderRBTreeWalk(RedBlackTreeNode x)//中根遍历
        {
            if (x != nil)
            {
                InoderRBTreeWalk(x.left);
                strTreeWalk += x.key.ToString() + " ";
                InoderRBTreeWalk(x.right);
            }
            return strTreeWalk;
        }

        public RedBlackTreeNode Search(int k) //为了将root作为可迭代参数，这里需要一个x作为过渡
        {
            RedBlackTreeNode x = root;
            return RBTreeSearch(x, k);
        }

        private RedBlackTreeNode RBTreeSearch(RedBlackTreeNode x, int k)//在树上进行搜索
        {
            if (x == nil || k == x.key)
            {
                return x;
            }
            if (k < x.key)
            {
                return RBTreeSearch(x.left, k);
            }
            else
            {
                return RBTreeSearch(x.right, k);
            }
        }

        public override string ToString()
        {
            strTreeWalk = "";
            return InoderRBTreeWalk(root);
        }    
    }
}
