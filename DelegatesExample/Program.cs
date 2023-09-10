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

            ProcessStudents(students, s => Console.WriteLine(s.Name));

            Func<Student, bool> hasPassed = s => s.Grade >= 50;
            foreach (var student in students)
            {
                if (hasPassed(student))
                {
                    Console.WriteLine($"{student.Name} has passed.");
                }
            }

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