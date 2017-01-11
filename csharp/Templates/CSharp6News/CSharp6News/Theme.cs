using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6News
{
    public class Theme
    {
        public string Name { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("Theme {0}, BackgroundColor: {1}", this.Name, this.BackgroundColor);
            }
        }

        public ConsoleColor BackgroundColor { get; set; }

        public ConsoleColor ForegroundColor { get; set; }

        public Theme()
        {
            this.BackgroundColor = ConsoleColor.Yellow;
            this.ForegroundColor = ConsoleColor.Red;
        }

        public Theme(string name, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            this.Name = name;
            this.BackgroundColor = backgroundColor;
            this.ForegroundColor = foregroundColor;
        }
    }
}
