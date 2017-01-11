using GalaSoft.MvvmLight;
using HelloUWP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IPeopleManager peopleManager;

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


        public MainViewModel(IPeopleManager peopleManager)
        {
            this.Title = "Hello, UWP!";

            this.peopleManager = peopleManager;

            Initialize();
        }

        private async Task Initialize()
        {
            var people = await peopleManager.GetPeopleAsync();

            this.People = people.Select(p => new ViewModels.PersonViewModel()
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                ImageUrl = p.ImageUrl
            });

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
