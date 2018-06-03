using LinkListModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphModel
{
    class Traversals
    {
        public static void DepthFirst(Graph g)
        {

        }

        public static void BreadthFirst(Graph g)
        {

        }
    }

    // To implement some of the searches, we will need a queue
    // for depthFirst, we can just use recursion which functions essentially like a stack
    // To create this class, use a link list
    class Queue
    {
        private LinkList _queue;

        public Queue()
        {
            _queue = new LinkList();
        }

        public string Pop()
        {
            if (_queue.GetHead() == null)
                throw new NullReferenceException();

            string pop = _queue.GetHead().Data;
            _queue.DeleteHead();
            return pop;
        }

        public void Push(string s)
        {
            _queue.AddToEnd(new LLNode { Data = s });
        }
    }
}
