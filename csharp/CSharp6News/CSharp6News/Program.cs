using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp6News.Themes;
using static System.Console;

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
            var themeConfig = ConfigurationManager.AppSettings["theme"]?.ToLower() ?? "light";
            var theme = themes.FirstOrDefault(t => t.Name?.ToLower() == themeConfig);

            var firstTheme = themes?[0];
            //var tmp = nameof(CSharp6News.Theme);

            // Dictionary intializers
            var dict = new Dictionary<string, object>()
            {
                ["key"] = 28,
                ["key2"] = 17,
            };

            var jsonObject = new JObject
            {
                ["firstName"] = "Roman",
                ["lastName"] = "Schacherl",
                ["dateOfBirth"] = new DateTime(1986,1,23),
            };

            string resourceString = "Hello {t.Name}!";

            foreach (var t in themes)
            {
                Console.WriteLine($"{t.Name,20};{t.ForegroundColor};{t.BackgroundColor}");
            }


            WriteLine(jsonObject.ToString());

            //Console.WriteLine(tmp);
            ReadLine();
        }

        private static async void InitializeThemes()
        {
            try
            {
                themes = new List<Theme>()
                {
                    new Theme(),
                    new Theme("Dark", ConsoleColor.Black, ConsoleColor.White),
                    new Theme("Light", ConsoleColor.White, ConsoleColor.Black),
                    new Theme("Winter", ConsoleColor.Gray, ConsoleColor.DarkGray)
                };
            }
            catch (TypeInitializationException ex) when (ex.InnerException is ArgumentException)
            {
                // handle argument exception

                // async/await in catch block 
                await LogException();
            }
            catch (TypeInitializationException ex) when (ex.InnerException is NullReferenceException)
            {
                // handle null reference exception

                await LogException();
            }
            catch (TypeInitializationException ex)
            {
                // handle all other TypeInitializationExceptions
            }
        }

        private static async Task LogException()
        {
            // logging..
            await Task.Delay(1000);
        }
    }
}
