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
        class Name
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }

            public Name(string fName, string mName, string lName)
            {
                this.FirstName = fName;
                this.MiddleName = mName;
                this.LastName = lName;
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
            linkedList.AddFirst(new Name("f","m","l"));
            Assert.IsTrue(linkedList.Head.Value.FirstName.Equals("f"));
            Assert.IsTrue(linkedList.Count == 1);

            linkedList.AddFirst(new Name("f2", "m2", "l2"));
            Assert.IsTrue(linkedList.Head.Value.FirstName.Equals("f2"));
            Assert.IsTrue(linkedList.Head.NextNode.Value.FirstName.Equals("f"));
            Assert.IsTrue(linkedList.Head.NextNode.PreNode.Value.FirstName.Equals("f2"));
            Assert.IsTrue(linkedList.Count == 2);
        }

        [TestMethod()]
        public void AddLastTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddLast(10);
            Assert.IsTrue(linkedList.Head.Value == 10);
            Assert.IsTrue(linkedList.Count == 1);
            

        }

        [TestMethod()]
        public void InsertBeforeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertAfterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClearTest()
        {
            Assert.Fail();
        }
    }
}