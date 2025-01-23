﻿using System.Drawing;
using QuadTrees.QTreeRectF;

namespace QuadTrees.Tests
{
    [TestClass]
    public class TestRectPoint
    {
        class QTreeObject : IRectFQuadStorable
        {
            private RectangleF _rect;

            public RectangleF Rect
            {
                get { return _rect; }
            }

            public QTreeObject(RectangleF rect)
            {
                _rect = rect;
            }
        }
        [TestMethod]
        public void TestListQuery()
        {
            QuadTreeRectPointFInverse<QTreeObject> qtree = new QuadTreeRectPointFInverse<QTreeObject>(new RectangleF(float.MinValue/2,float.MinValue/2,float.MaxValue,float.MaxValue));
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new RectangleF(10,10,10,10)),
                new QTreeObject(new RectangleF(-1000,1000,10,10))
            });

            var list = qtree.GetObjects(new PointF(11,11));
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void TestListQueryOutput()
        {
            var list = new List<QTreeObject>();
            QuadTreeRectPointFInverse<QTreeObject> qtree = new QuadTreeRectPointFInverse<QTreeObject>(new RectangleF(float.MinValue/2,float.MinValue/2,float.MaxValue,float.MaxValue));
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new RectangleF(10,10,10,10)),
                new QTreeObject(new RectangleF(-1000,1000,10,10))
            });

            qtree.GetObjects(new PointF(11, 11), list);
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void TestListQueryEnum()
        {
            QuadTreeRectPointFInverse<QTreeObject> qtree = new QuadTreeRectPointFInverse<QTreeObject>(new RectangleF(float.MinValue/2,float.MinValue/2,float.MaxValue,float.MaxValue));
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new RectangleF(10,10,10,10)),
                new QTreeObject(new RectangleF(-1000,1000,10,10))
            });

            var list = qtree.EnumObjects(new PointF(11, 11));
            Assert.AreEqual(1, list.Count());
        }
        [TestMethod]
        public void TestListGetAll()
        {
            QuadTreeRectPointFInverse<QTreeObject> qtree = new QuadTreeRectPointFInverse<QTreeObject>(new RectangleF(float.MinValue/2,float.MinValue/2,float.MaxValue,float.MaxValue));
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new RectangleF(10,10,10,10)),
                new QTreeObject(new RectangleF(-1000,1000,10,10))
            });

            var list = qtree.GetAllObjects();
            Assert.AreEqual(2, list.Count());
        }
    }
}
