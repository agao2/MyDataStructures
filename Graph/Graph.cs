using System;
using System.Collections.Generic;
using LinkListModel;
using System.Linq;
namespace GraphModel
{

    /**
     * There are two common ways to represent a graph in code, one is a 2d array which stores all the edges for the vertices in this 2d array
     * The other common way is to use an array of linklists, where the elements in the array are vertices and each linklist entry at that
     * index represents an edge to another vertex
     * 
     * In this particular implmenetation, it wil be similar to an array of linklists, it will utilize a list instead of an array so its dynamic at runtime
     * */
    public class Graph
    {
        // Dictionary is used to hold the index of a particular vertex, you would use that index to access the 
        // appropriate linklist which will contain all the edges.
        private Dictionary<string,int> Vertices;
        private List<LinkList> _Graph;

        public Graph()
        {
            Vertices = new Dictionary<string, int>();
            _Graph = new List<LinkList>();
        }

        public override string ToString()
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
            if (Vertices.ContainsKey(vertex))
                throw new ArgumentException("Duplicate vertexes are not allowed");

            LinkList newList = new LinkList();
            _Graph.Add(newList);
            Vertices.Add(vertex, _Graph.Count - 1);
        }

        public void AddEdge(string vertex1, string vertex2)
        {

            if (!Vertices.TryGetValue(vertex1, out int index1))
                throw new ArgumentException("Vertex1 does not exist");

            if (!Vertices.TryGetValue(vertex2,out int index2))
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

        public LinkList GetEdges(string vertex)
        {
            if (!Vertices.TryGetValue(vertex, out int index))
                throw new ArgumentException("Vertex1 does not exist");

            return _Graph[index];
        }

        public string[] GetVertices()
        {
            return Vertices.Keys.ToArray();
        }
  
    }
}
