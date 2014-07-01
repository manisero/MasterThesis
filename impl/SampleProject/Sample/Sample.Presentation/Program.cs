using System;
using Sample.Presentation.Domain;

namespace Sample.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
                {
                    FirstName = "John",
                    LastName = "Doe"
                };

            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.LastName);
        }
    }
}
