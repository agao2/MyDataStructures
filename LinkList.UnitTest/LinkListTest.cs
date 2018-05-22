using System;
using NUnit.Framework;
using LinkList;

namespace LinkList.UnitTest
{
    /**
     * This test class tests adding items to the link list. 
     * All test method names have the following format:
     *  [methodName]_[scenario]_[expectedBehavior]
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
    }
}
