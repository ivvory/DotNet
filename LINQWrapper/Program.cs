using System;
using System.Collections.Generic;
using System.Linq;
using Generics;
using Structures;

namespace LINQWrapper
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new BinaryTree<Student>();
            
            int[] marks = {1, 2, 3, 2, -1};
            for (var i = 0; i < 5; i++)
            {
                tree.Insert(new Student("Name"+i, "Surname"+i, "Test"+i, DateTime.Now, marks[i]));
            }
            
            Console.WriteLine("Enter a condition field('FirstName', 'Surname', 'TestName', 'Mark').");
            var field = Console.ReadLine();
            Console.WriteLine("Enter an operator('=', '!=', '>', '<').");
            var condition = Console.ReadLine();
            Console.WriteLine("Enter a value.");
            var value = Console.ReadLine();

            var f = new Func<Student, bool>(ss => ss.Mark > 2);
            var students = 
                from s in tree 
                where get_condition(s, field, condition, value)
                select s;

            Console.WriteLine("Enter orderby field.");
            var orderbyField = Console.ReadLine();
            Console.WriteLine("Is descent(y/N).");
            var order = Console.ReadLine();
            Console.WriteLine("Row number.");
            var rowNumber = int.Parse(Console.ReadLine());
            if (order != "y")
                students.OrderBy(s => get_field(s, orderbyField));
            else
                students.OrderByDescending(s => get_field(s, orderbyField));

            foreach (var v in students.Take(rowNumber))
            {
                Console.WriteLine(v);
            }
        }

        private static bool get_condition(Student s, string field, string condition, string value)
        {
            var studentValue = s.GetType().GetProperty(field)?.GetValue(s, null);

            if (studentValue == null)
                return false;
            
            if (studentValue is string)
                switch (condition)
                {
                    case "=":
                        return (string) studentValue == value;
                    case "!=":
                        return (string) studentValue != value;
                    default:
                        return false;
                }
            else if (studentValue is int)
            {
                int intValue = int.Parse(value);
                switch (condition)
                {
                    case "=":
                        return (int) studentValue == intValue;
                    case "!=":
                        return (int) studentValue != intValue;
                    case ">":
                        return (int) studentValue > intValue;
                    case "<":
                        return (int) studentValue < intValue;
                    default:
                        return false;
                }
            }
            return false;
        }

        private static object get_field(Student s, string field)
        {
            var studentValue = s.GetType().GetProperty(field)?.GetValue(s, null);

            if (studentValue == null)
                throw new InvalidCastException();

            return studentValue;
        }
    }
}