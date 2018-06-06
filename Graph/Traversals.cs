using LinkListModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphModel
{
    // Class contains methods that takes in a Graph object and returns
    // graph traversals for it
    // Note that the all the methods are static, this class is not meant
    // to be used as an object, it is only a collection of methods. 
    public class Traversals
    {
        // helper method to DFS
        // this is the recursive method being called in DFS 
        private static void DFS_Recur(string vertex, Dictionary<string,bool> visited , Graph g)
        {
            visited[vertex] = true;
            Console.WriteLine(vertex);

            // we want to recursively call this for all adjacent vertices that have not been visited
            LinkList adjacentVertices = g.GetEdges(vertex);
            while(adjacentVertices.GetHead() != null)
            {
                string adjacentVertex = adjacentVertices.GetHead().Data;
                adjacentVertices.DeleteHead();
                if (visited[adjacentVertex] == false)
                    DFS_Recur(adjacentVertex,visited,g);
            }
        }

        // this method takes a graph, and does DFS on it
        // the starting vertex is specified in the parameter
        
        public static string[] DFS(Graph g , string vertex)
        {
            string[] dfsResult = new string[g.GetVertices().Length];

            // construct visited dictionary
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            string[] vertices = g.GetVertices();
            foreach (string vert in vertices)
            {
                visited.Add(vert, false);
            }

            DFS_Recur(vertex, visited ,g);

            return dfsResult;
        }


        public static void BFS(Graph g,string vertex)
        {
            // We will use a queue object detailed below to expand the frontier
            // Since this is a graph that may contain cycles, we will also need a visited dictionary
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            string[] vertices = g.GetVertices();
            foreach (string vert in vertices)
            {
                visited.Add(vert, false);
            }

            Queue q = new Queue();
            q.Push(vertex);
            visited[vertex] = true;
            while (!q.IsEmpty())
            {
                string expandedVertex = q.Pop();
                Console.WriteLine(expandedVertex);

                LinkList adjacentVertices = g.GetEdges(expandedVertex);
                while(adjacentVertices.GetHead() != null)
                {
                    string adjacentVertex = adjacentVertices.GetHead().Data;
                    adjacentVertices.DeleteHead();
                    if (visited[adjacentVertex] == false)
                    {
                        visited[adjacentVertex] = true;
                        q.Push(adjacentVertex);
                    }
                }

            }

        }
    }

    // To implement some of the searches, we will need a queue
    // for depthFirst, we can just use recursion which functions essentially like a stack
    // To create this class, use a link list
    public class Queue
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
            if (s == null)
                throw new ArgumentNullException();
            _queue.AddToEnd(new LLNode { Data = s });
        }

        public bool IsEmpty()
        {
            if (_queue.GetHead() == null)
                return true;
            else
                return false;
        }
    }
}


