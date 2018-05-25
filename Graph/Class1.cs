using System;
using System.Collections.Generic;
using LinkListModel;
using System.Linq;
namespace GraphModel
{

    /**
     * There are two common ways to represent a graph in code, one is a 2d array where the first row and column are vertices 
     * and value at the coordinate of the two represent an endge.
     * The other common way is to use an array of linklists, where the elements in the array are vertices and each linklist entry at that
     * index represents an edge
     * 
     * In this particular implmenetation, we wil be using an array of linklists
     * */
    public class Graph
    {
       
        private Dictionary<string,int> Vertices;
        private List<LinkList> _Graph;

        public Graph()
        {
            Vertices = new Dictionary<string, int>();
            _Graph = new List<LinkList>();
        }

        public string ToString()
        {
            string toString = "";
            for(int i = 0; i < _Graph.Count; i++)
            {
                
                // get the vertex
                string vertex = Vertices.FirstOrDefault(v => v.Value == i).Key;
                toString += (vertex + ": ");

                LLNode iterator = _Graph[i].GetHead();
                while(iterator != null)
                {
                    toString += iterator.Data + "  ";
                    iterator = iterator.Next;
                }
                toString += "\n";
            }
            return toString;
        }

        public void AddVertiex(string vertex)
        {
            LinkList newList = new LinkList();
            _Graph.Add(newList);
            Vertices.Add(vertex, _Graph.Count - 1);
        }

        public void AddEdge(string vertex1, string vertex2)
        {
            int index1;
            int index2;
            
            // see if the two vertices exist
            if (!Vertices.TryGetValue(vertex1, out index1))
                throw new ArgumentException("Vertex1 does not exist");

            if(!Vertices.TryGetValue(vertex2,out index2))
                throw new ArgumentException("Vertex2 does not exist");

            LinkList edges1 = _Graph[index1];
            LinkList edges2 = _Graph[index2];
            if(index1 != index2)
            {
                edges1.AddToEnd(new LLNode() { Data = vertex2 });
                edges2.AddToEnd(new LLNode() { Data = vertex1 });
            }
            else
            {
                edges1.AddToEnd(new LLNode() { Data = vertex2 });
            }

        }

        
  
    }
}
