using System;
using NUnit.Framework;
using GraphModel;
using LinkListModel;

namespace GraphModel.UnitTest
{
    [TestFixture]
    public class GraphUnitTest
    {
        [Test]
        public void AddVertex_NullStringParam_NullReferenceException()
        {
            Graph g = new Graph();
            Assert.Throws<NullReferenceException>(() => g.AddVertex(null));
        }

        [Test]
        public void AddVertex_ValidStringParam_NoExceptions()
        {
            Graph g = new Graph();
            Assert.DoesNotThrow(() => g.AddVertex("valid"));
        }

        [Test]
        public void AddVertex_DuplicateVertex_ArugmentException()
        {
            Graph g = new Graph();
            g.AddVertex("s");
            Assert.Throws<ArgumentException>(() => g.AddVertex("s"));
        }

        [Test]
        public void AddEdge_ValidVertices_NoException()
        {
            Graph g = new Graph();
            g.AddVertex("a");
            g.AddVertex("s");

            Assert.DoesNotThrow(() => g.AddEdge("a", "s"));  
        }

        [Test]
        public void AddEdge_SameVertices_NoException()
        {
            Graph g = new Graph();
            g.AddVertex("a");

            Assert.DoesNotThrow(() => g.AddEdge("a", "a"));
        }

        [Test]
        public void AddEdge_EdgeAlreadyExists_ArgumentException()
        {
            Graph g = new Graph();
            g.AddVertex("a");
            g.AddEdge("a", "a");

            Assert.Throws<ArgumentException>(() => g.AddEdge("a", "a"));
        }

        [Test]
        public void GetEdges_ValidVertex_NotNull()
        {
            Graph g = new Graph();
            g.AddVertex("a");

            var result = g.GetEdges("a");

            Assert.NotNull(result);
        }

        [Test]
        public void GetEdges_VertexDoesNotExist_ArgumentException()
        {
            Graph g = new Graph();
            g.AddVertex("a");

            Assert.Throws<ArgumentException>(() => g.GetEdges("b"));
        }
        

    }
}
