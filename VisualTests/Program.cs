using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphModel;

namespace VisualTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();

            g.AddVertex("0");
            g.AddVertex("1");
            g.AddVertex("2");
            g.AddVertex("3");


            g.AddEdge("0", "1");
            g.AddEdge("0", "2");
            g.AddEdge("1", "2");
            g.AddEdge("2", "3");
            g.AddEdge("3", "3");

            //Traversals.DFS(g,"2");
            Traversals.BFS(g, "2");

        }
    }
}
