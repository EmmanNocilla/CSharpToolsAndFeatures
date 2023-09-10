using System;

namespace DelegatesExample
{
    internal class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public int Grade { get; set; }
            public DateTime Birthday { get; set; }
        }

        public static void ProcessStudents(List<Student> students, Action<Student> action)
        {
            foreach (var student in students)
            {
                action(student);
            }
        }

        public static void Main()
        {
            List<Student> students = GetStudents(); 

            // 1. Print each student's name.
            ProcessStudents(students, s => Console.WriteLine(s.Name));

            // 2. Check if a student has passed.
            Func<Student, bool> hasPassed = s => s.Grade >= 50;
            foreach (var student in students)
            {
                if (hasPassed(student))
                {
                    Console.WriteLine($"{student.Name} has passed.");
                }
            }

            // 3. Send an email to students who have a birthday today.
            ProcessStudents(students, s =>
            {
                if (s.Birthday.Date == DateTime.Today)
                {
                    SendBirthdayEmail(s);
                }
            });
        }

        private static void SendBirthdayEmail(Student s)
        {
            throw new NotImplementedException();
        }

        private static List<Student> GetStudents()
        {
            throw new NotImplementedException();
        }
    }
}