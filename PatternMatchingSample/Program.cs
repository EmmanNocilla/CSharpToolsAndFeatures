using System;
using static PatternMatchingSample.Program;

namespace PatternMatchingSample
{
    internal class Program
    {
        public static void Main()
        {
            #region List Pattern
            var ints = new int[] { 4, 6, 8, 9 };

            if (ints is [4, 6, 8, 9])
                Console.WriteLine("Match!");

            if (ints is [_, _, _, _])
                Console.WriteLine("Match!");

            if (ints is [_, _, ..])
                Console.WriteLine("Match!");

            if (ints is [_, _, .. { Length: 2 }])
                Console.WriteLine("Match!");

            if (ints is [var first, _, _, _])
                Console.WriteLine(first);

            if (ints is [_, _, .. var rest])
                Console.WriteLine(rest[0]);

            if (ints is [< 5, _, > 5, ..])
                Console.WriteLine("Match");

            if (ints is [4 or 5, _, > 5, ..])
                Console.WriteLine("Match");

            var k = "KnowledgeSharing";
            if (k is ['K' or 'k', ..])
                Console.WriteLine("Match");
            #endregion

            #region Type Pattern
            object obj = "Hello World";

            if (obj is string)
                Console.WriteLine("It's a string!");

            if (obj is string str)
                Console.WriteLine(str.ToLower());

            var typeDescription = obj switch
            {
                string sType => "It's a string with value: " + sType,
                int i => "It's an integer with value: " + i,
                double d => "It's a double with value: " + d,
                _ => "Unknown type"
            };
            Console.WriteLine(typeDescription);
            #endregion

            #region Var Pattern
            object objVar = "Hello";
            if (obj is var anyValue)
                Console.WriteLine(anyValue);

            if (obj is var captured && captured is string s && s.Length > 4)
                Console.WriteLine($"String with length greater than 4: {s}");
            #endregion

            #region Property Pattern
            Person person = new Person { Name = "Alice", Age = 30 };

            if (person is { Name: "Alice", Age: var age })
                Console.WriteLine($"Alice's age is {age}.");

            var description = person switch
            {
                { Name: "Alice" } => "It's Alice!",
                { Age: < 20 } => "A young person.",
                { Age: > 50 } => "An older person.",
                _ => "Unknown person."
            };
            Console.WriteLine(description);

            Employee employee = new Employee
            {
                Department = "IT",
                PersonalDetails = new Person { Name = "Charlie", Age = 25 }
            };
            if (employee is { Department: "IT", PersonalDetails: { Name: "Charlie" } })
                Console.WriteLine("Charlie works in the IT department.");

            #endregion

            #region Recursive Pattern
            object shape = new Rectangle { Width = 10, Height = 20 };

            if (shape is Rectangle { Width: 10, Height: var h })
                Console.WriteLine($"It's a rectangle with height {h}!");

            object shape2 = new Circle { Radius = 5 };

            var descriptionShape = shape2 switch
            {
                Circle { Radius: var r } => $"Circle with radius {r}",
                Rectangle { Width: var w, Height: var he } => $"Rectangle of width {w} and height {he}",
                _ => "Unknown shape"
            };
            #endregion

            #region Tuple Pattern
            var tuple = (3, 4);

            if (tuple is (3, 4))
                Console.WriteLine("The tuple contains the values (3, 4).");

            if (tuple is (var number, var number2))
                Console.WriteLine($"The tuple contains the values ({number}, {number2}).");

            var point = (x: 5, y: -5);

            switch (point)
            {
                case (var x, var y) when x == y:
                    Console.WriteLine("The point lies on the line y = x.");
                    break;
                case (var x, var y) when x == -y:
                    Console.WriteLine("The point lies on the line y = -x."); 
                    break;
                default:
                    Console.WriteLine("The point lies elsewhere.");
                    break;
            }
            #endregion
        }

        public class Circle
        {
            public double Radius { get; set; }
        }
        public class Rectangle
        {
            public double Width { get; set; }
            public double Height { get; set; }
        }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class Employee
        {
            public string Department { get; set; }
            public Person PersonalDetails { get; set; }
        }
    }
}