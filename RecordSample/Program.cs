using System;
using System.Xml.Linq;

namespace DelegatesExample
{
    internal class Program
    {
        record Person(string FirstName, string LastName);

        //INHERETANCE
        #region Records for inheritance example
        // Base record
        record Shape(string Name);

        // Derived record
        record Circle(string Name, double Radius) : Shape(Name);

        // Another derived record
        record Rectangle(string Name, double Width, double Height) : Shape(Name);
        #endregion
        public static void Main()
        {         

            //WITH EXPRESSION
            var john = new Person("John", "Doe");
            var jane = john with { FirstName = "Jane" };
            Console.WriteLine(jane);

            //VALUE-BASED EQUALITY
            var person1 = new Person("John", "Doe");
            var person2 = new Person("John", "Doe");
            Console.WriteLine(person1 == person2);

            //DECONSTRUCTION
            var (firstName, lastName) = john;
            Console.WriteLine($"{firstName} {lastName}");

        }
    }
}

 