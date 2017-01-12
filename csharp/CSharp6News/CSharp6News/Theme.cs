using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6News.Themes
{
    public class Theme : INotifyPropertyChanged
    {
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;

                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));

                // semantically equal to
                //if (PropertyChanged != null)
                //{
                //    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                //}
            }
        }


        //public string FullName
        //{
        //    get
        //    {
        //        return string.Format("Theme {0}, BackgroundColor: {1}", this.Name, this.BackgroundColor);
        //    }
        //}

        //public string FullName => string.Format("Theme {0}, BackgroundColor: {1}", this.Name, this.BackgroundColor);

        public string FullName => $"Theme {this.Name}, BackgroundColor: {this.BackgroundColor}";

        public bool IsValid => this.Name != null;

        public ConsoleColor BackgroundColor { get; } = ConsoleColor.Red;

        public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.Blue;

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

            if (this.BackgroundColor == this.ForegroundColor)
            {
                throw new TypeInitializationException(
                    this.GetType().FullName,
                    new ArgumentException("Background color mustn't be equal to foreground color."));
            }
        }

        public void Foo()
        {
            // cannot be set, property is readonly
            //this.BackgroundColor = ConsoleColor.Red;
        }
    }
}
