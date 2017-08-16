using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructure.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Collections.Generic.Tests
{
    [TestClass()]
    public class LinkedListTests
    {
        private class Name
        {
            public string FirstName { get; }

            public Name(string fName)
            {
                this.FirstName = fName;
            }
        }

        [TestMethod()]
        public void LinkedListTest()
        {
            LinkedList<Name> linkedList = new LinkedList<Name>();
            Assert.IsInstanceOfType(linkedList, typeof(LinkedList<Name>));
        }

        [TestMethod()]
        public void AddFirstTest()
        {
            LinkedList<Name> linkedList = new LinkedList<Name>();
            var firstNode = linkedList.AddFirst(new Name("f"));
            Assert.IsTrue(linkedList.Head.Value.FirstName.Equals("f"));
            Assert.IsTrue(linkedList.Count == 1);

            Assert.IsTrue(firstNode.PreNode == null);
            Assert.IsTrue(firstNode.NextNode == null);

            Assert.IsTrue(firstNode.LinkedList == linkedList);
            Assert.IsTrue(linkedList.Head == firstNode);
            Assert.IsTrue(linkedList.Tail == firstNode);
        }
        [TestMethod()]
        public void AddFirstTest_NodeLink()
        {
            LinkedList<Name> linkedList = new LinkedList<Name>();
            var firstNode = linkedList.AddFirst(new Name("f"));
            var secondNode = linkedList.AddFirst(new Name("f2"));


            Assert.IsTrue(linkedList.Head == secondNode);
            Assert.IsTrue(linkedList.Tail == firstNode);

            Assert.IsTrue(secondNode.PreNode == null);
            Assert.IsTrue(secondNode.NextNode == firstNode);
            Assert.IsTrue(firstNode.PreNode == secondNode);
            Assert.IsTrue(firstNode.NextNode == null);

            Assert.IsTrue(firstNode.LinkedList == linkedList);
            Assert.IsTrue(secondNode.LinkedList == linkedList);
        }

        [TestMethod()]
        public void AddLastTest()
        {
            LinkedList<Name> linkedList = new LinkedList<Name>();
            var firstNode = linkedList.AddLast(new Name("f"));
            Assert.IsTrue(linkedList.Head.Value.FirstName.Equals("f"));
            Assert.IsTrue(linkedList.Count == 1);

            Assert.IsTrue(firstNode.PreNode == null);
            Assert.IsTrue(firstNode.NextNode == null);

            Assert.IsTrue(firstNode.LinkedList == linkedList);
            Assert.IsTrue(linkedList.Head == firstNode);
            Assert.IsTrue(linkedList.Tail == firstNode);
        }

        [TestMethod()]
        public void AddLastTest_NodeLink()
        {
            LinkedList<Name> linkedList = new LinkedList<Name>();
            var firstNode = linkedList.AddLast(new Name("f"));
            var secondNode = linkedList.AddLast(new Name("f2"));


            Assert.IsTrue(linkedList.Head == firstNode);
            Assert.IsTrue(linkedList.Tail == secondNode);

            Assert.IsTrue(firstNode.PreNode == null);
            Assert.IsTrue(firstNode.NextNode == secondNode);
            Assert.IsTrue(secondNode.PreNode == firstNode);
            Assert.IsTrue(secondNode.NextNode == null);

            Assert.IsTrue(firstNode.LinkedList == linkedList);
            Assert.IsTrue(secondNode.LinkedList == linkedList);
        }

        [TestMethod()]
        public void InsertBeforeTest()
        {
            LinkedList<Name> linkedList = new LinkedList<Name>();
            var node1 = linkedList.AddLast(new Name("f1"));
            var node2 = linkedList.AddLast(new Name("f2"));
            //var node3 = linkedList.AddLast(new Name("f3"));
            var node4 = linkedList.AddLast(new Name("f4"));
            var node5 = linkedList.AddLast(new Name("f5"));
            var node3 = linkedList.InsertBefore(node4, new Name("f3"));

            Assert.IsTrue(node2.NextNode == node3);
            Assert.IsTrue(node3.NextNode == node4);
            Assert.IsTrue(node4.NextNode == node5);
            Assert.IsTrue(node5.NextNode == null);

            Assert.IsTrue(node5.PreNode == node4);
            Assert.IsTrue(node4.PreNode == node3);
            Assert.IsTrue(node3.PreNode == node2);
            Assert.IsTrue(node2.PreNode == node1);
            Assert.IsTrue(node1.PreNode == null);

            Assert.IsTrue(node3.LinkedList==linkedList);
        }

        [TestMethod()]
        public void InsertAfterTest()
        {
            LinkedList<Name> linkedList = new LinkedList<Name>();
            var node1 = linkedList.AddLast(new Name("f1"));
            var node2 = linkedList.AddLast(new Name("f2"));
            //var node3 = linkedList.AddLast(new Name("f3"));
            var node4 = linkedList.AddLast(new Name("f4"));
            var node5 = linkedList.AddLast(new Name("f5"));
            var node3 = linkedList.InsertAfter(node2, new Name("f3"));

            Assert.IsTrue(node2.NextNode == node3);
            Assert.IsTrue(node3.NextNode == node4);
            Assert.IsTrue(node4.NextNode == node5);
            Assert.IsTrue(node5.NextNode == null);

            Assert.IsTrue(node5.PreNode == node4);
            Assert.IsTrue(node4.PreNode == node3);
            Assert.IsTrue(node3.PreNode == node2);
            Assert.IsTrue(node2.PreNode == node1);
            Assert.IsTrue(node1.PreNode == null);

            Assert.IsTrue(node3.LinkedList == linkedList);
        }

        [TestMethod()]
        public void ClearTest()
        {
            LinkedList<Name> linkedList = new LinkedList<Name>();
            var node1 = linkedList.AddLast(new Name("f1"));
            var node2 = linkedList.AddLast(new Name("f2"));
            var node3 = linkedList.AddLast(new Name("f3"));
            var node4 = linkedList.AddLast(new Name("f4"));
            var node5 = linkedList.AddLast(new Name("f5"));

            linkedList.Clear();

            Assert.IsTrue(linkedList.Count==0);
            Assert.IsTrue(linkedList.Head == null);
            Assert.IsTrue(linkedList.Tail == null);
        }
    }
}                                                            