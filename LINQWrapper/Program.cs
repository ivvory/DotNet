using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Generics;
using Structures;

namespace LINQWrapper
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
//            var tree = new BinaryTree<Student>();
//            
//            int[] marks = {1, 2, 3, 2, -1};
//            for (var i = 0; i < 5; i++)
//            {
//                tree.Insert(new Student("Name"+i, "Surname"+i, "Test"+i, DateTime.Now, marks[i]));
//            }
//            IFormatter formatter = new BinaryFormatter();  
//            Stream stream = new FileStream("/tmp/test_tree.bin", FileMode.Create, FileAccess.Write, FileShare.None);  
//            formatter.Serialize(stream, tree);  
//            stream.Close(); 
            
            IFormatter formatter = new BinaryFormatter();  
            Stream stream = new FileStream("/tmp/test_tree.bin", FileMode.Open, FileAccess.Read, FileShare.Read);  
            var tree = (BinaryTree<Student>) formatter.Deserialize(stream);  
            stream.Close(); 
            
            Console.WriteLine("Enter a mark threshold.");
            var mark = Int32.Parse(Console.ReadLine());

            var f = new Func<Student, bool>(ss => ss.Mark > mark);
            var service = new FilterService<Student>(tree);

            foreach (var v in service.Where(f).Take(3))
            {
                Console.WriteLine(v);
            }
        }
    }
}