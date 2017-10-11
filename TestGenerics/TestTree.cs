using System;
using System.Collections.Generic;
using Generics;
using NUnit.Framework;
using Structures;

namespace TestGenerics
{
    [TestFixture]
    public class TestIntTree
    {
        private BinaryTree<int> TestTree = new BinaryTree<int>();

        [TestFixtureSetUp]
        public void SetUpClass()
        {
            int[] values = {1, 2, 3, 2, -1};
            foreach (var v in values)
            {
                this.TestTree.Insert(v);
            }
        }

        [Test]
        public void TestTraversals()
        {
            int[] preorderMustBe = {1, -1, 2, 3, 2};
            Assert.AreEqual(this.TestTree.Preorder(), preorderMustBe);
            int[] inorderMustBe = {-1, 1, 2, 2, 3};
            Assert.AreEqual(this.TestTree.Inorder(), inorderMustBe);
            int[] postorderMustBe = {-1, 2, 3, 2, 1};
            Assert.AreEqual(this.TestTree.Postorder(), postorderMustBe);
        }
    }

    [TestFixture]
    public class TestStringTree
    {
        private BinaryTree<string> TestTree = new BinaryTree<string>();

        [TestFixtureSetUp]
        public void SetUpClass()
        {
            string[] values = {"2", "1", "0", "a", "b", };
            foreach (var v in values)
            {
                this.TestTree.Insert(v);
            }
        }

        [Test]
        public void TestTraversals()
        {
            string[] preorderMustBe = {"2", "1", "0", "a", "b"};
            Assert.AreEqual(this.TestTree.Preorder(), preorderMustBe);
            string[] inorderMustBe = {"0", "1", "2", "a", "b"};
            Assert.AreEqual(this.TestTree.Inorder(), inorderMustBe);
            string[] postorderMustBe = {"0", "1", "b", "a", "2"};
            Assert.AreEqual(this.TestTree.Postorder(), postorderMustBe);
        }
    }

    [TestFixture]
    public class TestStudentsTree
    {
        private BinaryTree<Student> TestTree = new BinaryTree<Student>();

        [TestFixtureSetUp]
        public void SetUpClass()
        {
            Student s;
            int[] marks = {1, 2, 3, 2, -1};
            foreach (var m in marks)
            {
                s = new Student("Name", "Surname", "Test", DateTime.Now, m);
                this.TestTree.Insert(s);
            }
        }

        [Test]
        public void TestTraversals()
        {
            int[] preorderMustBe = {1, -1, 2, 3, 2};
            IEnumerable<Student> preorderActual = this.TestTree.Preorder();
            int counter = 0;
            foreach (var student in preorderActual)
            {
                Assert.AreEqual(student.Mark, preorderMustBe[counter]);
                counter++;
            }
            
            int[] inorderMustBe = {-1, 1, 2, 2, 3};
            IEnumerable<Student> inorderActual = this.TestTree.Inorder();
            counter = 0;
            foreach (var student in inorderActual)
            {
                Assert.AreEqual(student.Mark, inorderMustBe[counter]);
                counter++;
            }
            
            int[] postorderMustBe = {-1, 2, 3, 2, 1};
            IEnumerable<Student> postorderActual = this.TestTree.Postorder();
            counter = 0;
            foreach (var student in postorderActual)
            {
                Assert.AreEqual(student.Mark, postorderMustBe[counter]);
                counter++;
            }
        }
    }
    [TestFixture]
    public class TestPointTree
    {
        private BinaryTree<Point> TestTree = new BinaryTree<Point>(new PointComparer());

        [TestFixtureSetUp]
        public void SetUpClass()
        {
            this.TestTree.Insert(new Point(1, 1));
            this.TestTree.Insert(new Point(0, 0));
            this.TestTree.Insert(new Point(2, 2));

        }

        [Test]
        public void TestTraversals()
        {
            int[] preorderXMustBe = {1, 0, 2};
            int[] preorderYMustBe = {1, 0, 2};
            IEnumerable<Point> preorderActual = this.TestTree.Preorder();
            int counter = 0;
            foreach (var point in preorderActual)
            {
                Assert.AreEqual(point.X, preorderXMustBe[counter]);
                Assert.AreEqual(point.Y, preorderYMustBe[counter]);
                counter++;
            }
            int[] inorderXMustBe = {0, 1, 2};
            int[] inorderYMustBe = {0, 1, 2};
            IEnumerable<Point> inorderActual = this.TestTree.Inorder();
            counter = 0;
            foreach (var point in inorderActual)
            {
                Assert.AreEqual(point.X, inorderXMustBe[counter]);
                Assert.AreEqual(point.Y, inorderYMustBe[counter]);
                counter++;
            }
            int[] postorderXMustBe = {0, 2, 1};
            int[] postorderYMustBe = {0, 2, 1};
            IEnumerable<Point> postorderActual = this.TestTree.Postorder();
            counter = 0;
            foreach (var point in postorderActual)
            {
                Assert.AreEqual(point.X, postorderXMustBe[counter]);
                Assert.AreEqual(point.Y, postorderYMustBe[counter]);
                counter++;
            }
        }
    }
}