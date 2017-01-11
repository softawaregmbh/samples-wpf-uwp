using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6News
{
    class Program
    {
        private static IList<Theme> themes;

        static void Main(string[] args)
        {
            InitializeThemes();

            DoSomethingWithCSharp6();
        }

        private static void DoSomethingWithCSharp6()
        {
            // TODO
        }

        private static void InitializeThemes()
        {
            themes = new List<Theme>()
            {
                new Theme(),
                new Theme("Dark", ConsoleColor.Black, ConsoleColor.White),
                new Theme("Light", ConsoleColor.White, ConsoleColor.Black),
                new Theme("Winter", ConsoleColor.Gray, ConsoleColor.Gray)
            };
        }
    }
}
