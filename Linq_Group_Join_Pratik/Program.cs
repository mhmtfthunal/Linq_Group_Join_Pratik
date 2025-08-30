using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqGroupJoinExample
{
    // Öğrenci tablosu
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int ClassId { get; set; }
    }

    // Sınıf tablosu
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Öğrenciler
            var students = new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Ali",    ClassId = 1 },
                new Student { StudentId = 2, StudentName = "Ayşe",   ClassId = 2 },
                new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 1 },
                new Student { StudentId = 4, StudentName = "Fatma",  ClassId = 3 },
                new Student { StudentId = 5, StudentName = "Ahmet",  ClassId = 2 }
            };

            // Sınıflar
            var classes = new List<Class>
            {
                new Class { ClassId = 1, ClassName = "Matematik" },
                new Class { ClassId = 2, ClassName = "Türkçe" },
                new Class { ClassId = 3, ClassName = "Kimya" }
            };

            // Group Join
            var result =
                from c in classes
                join s in students on c.ClassId equals s.ClassId into studentGroup
                select new
                {
                    ClassName = c.ClassName,
                    Students = studentGroup
                };

            // Ekrana yazdır
            foreach (var group in result)
            {
                Console.WriteLine($"Sınıf: {group.ClassName}");
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"  - {student.StudentName}");
                }
                Console.WriteLine();
            }
        }
    }
}
