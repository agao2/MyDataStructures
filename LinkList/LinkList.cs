
using System;
using System.Collections.Generic;


namespace LinkList
{
    public class LLNode
    {
        public String Data;
        public LLNode Next;

        public LLNode()
        {
            this.Data = "";
        }

        public LLNode(string Data)
        {
            this.Data = Data;
        }
        
    }

    public class LinkList
    {
        private LLNode Head;
        private LLNode Tail;

        public LinkList()
        {
            this.Head = null;
            this.Tail = null;
        }

        public LinkList(LLNode Head, LLNode Tail)
        {
            if(Head == null || Tail == null)
                throw new ArgumentNullException("Parameter(s) cannot be null");

            if (Tail.Next != null)
                throw new ArgumentException("Tail is not the end of a linked list");

            //check to see if the head and tail are connected
            LLNode iterator = Head;
            while(iterator.Next != Tail)
            {
                iterator = iterator.Next;
                if(iterator == null)
                    throw new ArgumentException("Head and tail parameters are not connected");
            }

            this.Head = Head;
            this.Tail = Tail;
        }

        public void AddToStart(LLNode NewNode)
        {
            if (NewNode == null)
                throw new System.ArgumentNullException("Parameter cannot be null , NewNode");

            if (this.Head == null)
            {
                this.Head = NewNode;
                this.Tail = NewNode;
                NewNode.Next = null;
            }
            else
            {
                NewNode.Next = this.Head;
                this.Head = NewNode;
            }
        }

        public void AddToEnd(LLNode NewNode)
        {
            if (NewNode == null)
                throw new System.ArgumentNullException("Parameter cannot be null , NewNode");

            if (this.Head == null)
            {
                this.Head = NewNode;
                this.Tail = NewNode;
                NewNode.Next = null;
            }
            else
            {
                this.Tail.Next = NewNode;
                this.Tail = NewNode;
            }
        }

        public LLNode GetTail()
        {
            return this.Tail;
        }

        public LLNode GetHead()
        {
            return this.Head;
        }

        public LLNode Search(int Index)
        {
            if (this.Head == null)
                throw new System.NullReferenceException("The head of the linked list is null");

            if( Index <0)
                throw new System.IndexOutOfRangeException("Index must be greater than 0");

            int counter = 0;
            LLNode Iterator = this.Head;
            while (counter < Index)
            {
                counter++;
                if (Iterator.Next == null)
                    throw new System.IndexOutOfRangeException("There aren't that many nodes in the link list!");
                Iterator = Iterator.Next;
            }
            return Iterator;
        }

        public LLNode Search(string data)
        {
            if (this.Head == null)
                throw new System.NullReferenceException("The head of the linked list is null");

            if (data == null)
                throw new System.ArgumentNullException("Parameter cannot be null , data");

            LLNode Iterator = this.Head;
            while(Iterator != null)
            {
                if (Iterator.Data.Equals(data))
                    return Iterator;
                else
                    Iterator = Iterator.Next;
            }
            throw new KeyNotFoundException("Cannot find node with the specified data");
        }
       
    }
}
