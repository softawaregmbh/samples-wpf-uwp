using GalaSoft.MvvmLight;

namespace HelloUWP.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { this.Set(ref firstName, value); }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { this.Set(ref lastName, value); }
        }

        private string imageUrl;

        public string ImageUrl
        {
            get { return imageUrl; }
            set { this.Set(ref imageUrl, value); }
        }

    }
}