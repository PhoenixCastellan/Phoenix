using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Collections.Tree
{
    interface IBinaryTree<T>
    {
        BinaryTreeNode<T> GetRoot();
        BinaryTreeNode<T> Add(T data);
        bool Remove(BinaryTreeNode<T> node);

        IList<T> PreorderTraversal();
        IList<T> InorderTraversal();
        IList<T> PostorderTraversal();

        void Clear();
    }
}
