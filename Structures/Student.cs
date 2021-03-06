﻿using System;

namespace Structures
{
    [Serializable]
    public class Student : IComparable<Student>
    {
        public String FirstName { get; set; }
        public String Surname { get; set; }
        public String TestName { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }

        public Student(string firstName, string surname, string testName, DateTime date, int mark)
        {
            FirstName = firstName;
            Surname = surname;
            TestName = testName;
            Date = date;
            Mark = mark;
        }

        public int CompareTo(Student other)
        {
            return this.Mark - other.Mark;
        }
        
        public override string ToString()
        {
            return $"Student {FirstName} {Surname} completed test {TestName} with mark {Mark} on {Date}";
        }
    }
}