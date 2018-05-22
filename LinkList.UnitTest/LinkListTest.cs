using System;
using System.Collections.Generic;
using NUnit.Framework;
using LinkList;

namespace LinkList.UnitTest
{
    /**
     * UnitTest for the methods in LinkList class
     * All test method names have the following format:
     *  [methodName]_[scenario]_[expectedBehavior]
     *  
     *  Note that some of the methods are overloaded, in that case the methodName may not match exactly
     *  
     *  This project uses Nunit Framework 
     *  In order to run in visual studio, use the NunitAdapter package
     * */

    [TestFixture]
    public class LinkListTest
    {
        [Test]
        public void LinkList_NewInitialization_NotNull()
        {
            LinkList newList = new LinkList();
            Assert.NotNull(newList);
        }

        [Test]
        public void LinkedList_ExistingInitialization_NotNull()
        {
            LLNode head = new LLNode();
            LLNode tail = new LLNode();
            head.Next = tail;

            LinkList newList = new LinkList(head, tail);
            Assert.NotNull(newList);
        }

        [Test]
        public void LinkList_NullHead_ArgumentNullException()
        {
            LLNode tail = new LLNode();
            Assert.Throws<ArgumentNullException>(() => new LinkList(null, tail));
        }

        [Test]
        public void LinkList_NullTail_ArgumentNullException()
        {
            LLNode head = new LLNode();
            Assert.Throws<ArgumentNullException>(() => new LinkList(head, null));
        }

        [Test]
        public void LinkList_TailNextNotNull_ArgumentException()
        {
            LLNode head = new LLNode();
            LLNode tail = new LLNode
            {
                Next = head
            };

            Assert.Throws<ArgumentException>(() => new LinkList(head, tail));
        }

        [Test]
        public void LinkList_UnconnectedHeadTail_ArgumentException()
        {
            LLNode head = new LLNode();
            LLNode tail = new LLNode();

            Assert.Throws<ArgumentException>(() => new LinkList(head, tail));
        }

        [Test]
        public void AddToStart_NullNewNode_ArgumentNullException()
        {
            LinkList newList = new LinkList();
            LLNode newNode = null;
            Assert.Throws<ArgumentNullException>(() => newList.AddToStart(newNode));
        }

        [Test] 
        public void AddToStart_ValidNewNode_Equals()
        {
            LinkList newList = new LinkList();
            LLNode newNode = new LLNode();
            newList.AddToStart(newNode);
            var result = newList.GetHead();

            Assert.AreSame(newNode, result);
        }

        [Test]
        public void AddToEnd_NullNewNode_ArgumentNullException()
        {
            LinkList newList = new LinkList();
            LLNode newNode = null;
            Assert.Throws<ArgumentNullException>(() => newList.AddToEnd(newNode));
        }

        [Test]
        public void AddToEnd_ValidNewNode_AreSame()
        {
            LinkList newList = new LinkList();
            LLNode newNode = new LLNode();
            newList.AddToEnd(newNode);
            var result = newList.GetTail();

            Assert.AreSame(newNode, result);
        }

        [Test]
        public void SearchByIndex_NullHead_NullReferenceException()
        {
            LinkList newList = new LinkList();

            Assert.Throws<NullReferenceException>(() => newList.Search(0));
        }

        [Test]
        public void SearchByIndex_IndexOutOfRange_IndexOutOfRangeException()
        {
            LinkList newList = new LinkList();
            newList.AddToStart(new LLNode());

            Assert.Throws<IndexOutOfRangeException>(() => newList.Search(1));
        }

        [Test]
        public void SearchByIndex_NegativeIndex_IndexOutOfRangeException()
        {
            LinkList newList = new LinkList();
            newList.AddToStart(new LLNode());

            Assert.Throws<IndexOutOfRangeException>(() => newList.Search(-1));
        }

        [Test]
        public void SearchByIndex_ValidIndex_AreSame()
        {
            LinkList newList = new LinkList();
            LLNode newNode = new LLNode();
            newList.AddToStart(newNode);
            var result = newList.Search(0);

            Assert.AreSame(newNode, result);
        }

        [Test]
        public void SearchByString_NullParameter_ArgumentNullException()
        {
            LinkList newList = new LinkList();
            newList.AddToStart(new LLNode());

            Assert.Throws<ArgumentNullException>(() => newList.Search(null));
        }

        [Test]
        public void SearchByString_NullHead_NullReferenceException()
        {
            LinkList newList = new LinkList();

            Assert.Throws<NullReferenceException>(() => newList.Search(""));
        }
        
        [Test]
        public void SearchByString_DataDoesNotExist_KeyNotFoundException()
        {
            LinkList newList = new LinkList();
            newList.AddToStart(new LLNode());

            Assert.Throws<KeyNotFoundException>(() => newList.Search("Doesn't Exist"));
        }

        [Test] 
        public void SearchByString_ValidString_SameData()
        {
            LinkList linkList = new LinkList();
            LLNode newNode = new LLNode();
            newNode.Data = "data";
            linkList.AddToStart(newNode);

            LLNode foundNode = linkList.Search("data");

            Assert.AreEqual(foundNode.Data, "data");
        }

        [Test]
        public void DeleteHead_NullHead_NullReferenceException()
        {
            LinkList linklist = new LinkList();

            Assert.Throws<NullReferenceException>(() => linklist.DeleteHead());
        }

        [Test]
        public void DeleteHead_OneNode_EqualsNull()
        {
            LinkList linklist = new LinkList();
            LLNode firstNode = new LLNode();
            linklist.AddToStart(firstNode);
            linklist.DeleteHead();

            var result = linklist.GetHead();

            Assert.IsNull(result);
        }

        [Test]
        public void DeleteHead_MultipleNodes_EqualsNull()
        {
            LLNode firstNode = new LLNode();
            LLNode secondNode = new LLNode();
            LLNode thirdNode = new LLNode();
            firstNode.Next = secondNode;
            secondNode.Next = thirdNode;

            LinkList newList = new LinkList(firstNode, thirdNode);
            newList.DeleteHead();
            var result = newList.GetHead();

            Assert.AreSame(result, secondNode);
        }

        [Test]
        public void DeleteHead_NullTail_NullReferenceException()
        {
            LinkList linklist = new LinkList();

            Assert.Throws<NullReferenceException>(() => linklist.DeleteTail());
        }

        [Test]
        public void DeleteTail_OneNode_EqualsNull()
        {
            LinkList linklist = new LinkList();
            LLNode firstNode = new LLNode();
            linklist.AddToStart(firstNode);
            linklist.DeleteTail();

            var result = linklist.GetTail();

            Assert.IsNull(result);
        }

        [Test]
        public void DeleteTail_MultipleNodes_EqualsNull()
        {
            LLNode firstNode = new LLNode();
            LLNode secondNode = new LLNode();
            LLNode thirdNode = new LLNode();
            firstNode.Next = secondNode;
            secondNode.Next = thirdNode;

            LinkList newList = new LinkList(firstNode, thirdNode);
            newList.DeleteTail();
            var result = newList.GetTail();

            Assert.AreSame(result, secondNode);
        }
    }
}
