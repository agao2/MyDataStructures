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

            g.AddVertiex("v1");
            g.AddEdge("v1", "v1");
            Console.Write(g.ToString());
        }
    }
}
