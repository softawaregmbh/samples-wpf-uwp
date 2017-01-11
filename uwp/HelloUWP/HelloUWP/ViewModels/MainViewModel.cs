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

        private IEnumerable<PersonViewModel> people;

        public IEnumerable<PersonViewModel> People
        {
            get { return people; }
            set { this.Set(ref people, value); }
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { this.Set(ref searchText, value); }
        }


        public MainViewModel()
        {
            this.Title = "Hello, UWP!";

            Initialize();
        }

        private void Initialize()
        {
            this.People = new List<PersonViewModel>()
            {
                new PersonViewModel()
                {
                    FirstName = "Gabriele",
                    LastName = "Käferböck",
                    ImageUrl = "http://softaware-new.azurewebsites.net/about-us/team/images/gabriele-kaeferboeck.jpg"
                },
                new PersonViewModel()
                {
                    FirstName = "Roman",
                    LastName = "Schacherl",
                    ImageUrl = "http://softaware-new.azurewebsites.net/about-us/team/images/roman-schacherl.jpg"
                },
                new PersonViewModel()
                {
                    FirstName = "Daniel",
                    LastName = "Sklenitzka",
                    ImageUrl = "http://softaware-new.azurewebsites.net/about-us/team/images/daniel-sklenitzka.jpg"
                }
            };

            this.SearchResult = this.People;
        }

        private IEnumerable<PersonViewModel> searchResult;

        public IEnumerable<PersonViewModel> SearchResult
        {
            get { return searchResult; }
            set { this.Set(ref searchResult, value); }
        }


        public void Search()
        {
            var result = this.People
                .Where(p => p.LastName.ToLower().Contains(this.SearchText.ToLower())).ToList();

            this.SearchResult = result;
        }
    }
}
