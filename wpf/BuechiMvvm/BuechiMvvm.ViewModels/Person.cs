using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuechiMvvm.ViewModels
{
    public class Person : ViewModelBase
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;

                this.RaisePropertyChanged();
                this.RaisePropertyChanged(() => this.FullName);
            }
        }


        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

    }
}
