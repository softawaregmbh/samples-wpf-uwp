using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private string title;

        public string Title
        {
            get { return title; }
            set { this.Set(ref title, value); }
        }

        public MainViewModel()
        {
            this.Title = "Hello, UWP!";
        }


    }
}
