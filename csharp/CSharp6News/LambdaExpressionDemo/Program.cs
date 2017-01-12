using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionDemo
{
    delegate int AddDelegate(int a, int b);
    delegate void LogDelegate(string msg);
    delegate DateTime TimeDelegate();

    class Program
    {
        private static IEnumerable<Person> people;

        static void Main(string[] args)
        {
            AddDelegate d = Add;
            d = (n1, n2) => n1 + n2;

            int result = d(17, 41);
            Console.WriteLine(result);

            d = (a, b) =>
            {
                a = a - 1;
                return a * b;
            };

            LogDelegate l = (m) => Console.WriteLine(m);
            l("Hello, world");

            TimeDelegate t = () => DateTime.Now;
            Console.WriteLine(t());

            InitializePeople();

            //Func<Person, bool>
            //var filteredResult = people.Where(Filter).ToList();
            var filteredResult = people
                .Where(p => p.LastName.StartsWith("M"))
                .OrderBy(p => p.LastName)
                .Select(p => p.FirstName)
                .ToList();

            var linqResult = from p in people
                             where p.LastName.StartsWith("M")
                             orderby p.LastName
                             select p.FirstName;

            foreach (var name in filteredResult)
            {
                Console.WriteLine(name);
            }

            foreach (var p in people.Where(p => p.LastName.StartsWith("M")).ToList())
            {
            }           

            Console.ReadKey();
        }

        private static bool Filter(Person p)
        {
            return (p.LastName.StartsWith("S"));
        }

        private static void InitializePeople()
        {
            people = new List<Person>()
            {
                new Person() { FirstName = "Roman", LastName = "Schacherl" },
                new Person() { FirstName = "Anna", LastName = "Muster" },
                new Person() { FirstName = "Maria", LastName = "Müller" },
                new Person() { FirstName = "Hans", LastName = "Meyer" },
            };
        }

        static int Add(int x, int y)
        {
            return x + y;
        }


    }
}
