using System;
using NUnit.Framework;
using Structures;

namespace TestGenerics
{
    [TestFixture]
    public class TestStudent
    {
        private Student john;
        private Student jack;
        
        [SetUp]
        public void SetUpStudents()
        {
            this.john = new Student("John", "Dou", "Unitest", DateTime.Now, 10);
            this.jack = new Student("Jack", "Dou", "Unitest", DateTime.Now, 10);
        }

        [Test]
        public void TestLessThan()
        {
            this.jack.Mark = 9;
            
            Assert.True(((IComparable<Student>)this.jack).CompareTo(this.john) < 0);
        }

        [Test]
        public void TestEqual()
        {
            Assert.True(((IComparable<Student>)this.jack).CompareTo(this.john) == 0, "Wrong equal.");
        }
        
        [Test]
        public void TestMoreThan()
        {
            this.john.Mark = 9;
            
            Assert.True(((IComparable<Student>)this.jack).CompareTo(this.john) > 0);
        }
    }
}