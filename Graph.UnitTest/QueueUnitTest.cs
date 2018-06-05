using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GraphModel;

namespace Graph.UnitTest
{
    [TestFixture]
    public class QueueUnitTest
    {
        [Test]
       public void Pop_EmptyQueue_NullReferenceException()
       {
            Queue q = new Queue();

            Assert.Throws<NullReferenceException>(() => q.Pop());
       }

        [Test]
       public void Push_NullParameter_ArgumentNullException()
        {
            Queue q = new Queue();
            Assert.Throws<ArgumentNullException>(() => q.Push(null));
        }

        [Test]
        public void PushPop_SucessfulPop_AreSame()
        {
            Queue q = new Queue();
            string s = "value";
            q.Push(s);
            var result = q.Pop();

            Assert.AreSame(s, result);
;        }
    }
}
