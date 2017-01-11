using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP.Data
{
    public class OnlinePeopleManager : IPeopleManager
    {
        public Task<IEnumerable<Person>> GetPeopleAsync()
        {
            IEnumerable<Person> result = new List<Person>()
            {
                new Person()
                {
                    FirstName = "Gabriele",
                    LastName = "Käferböck",
                    ImageUrl = "http://softaware-new.azurewebsites.net/about-us/team/images/gabriele-kaeferboeck.jpg"
                },
                new Person()
                {
                    FirstName = "Roman",
                    LastName = "Schacherl",
                    ImageUrl = "http://softaware-new.azurewebsites.net/about-us/team/images/roman-schacherl.jpg"
                },
                new Person()
                {
                    FirstName = "Daniel",
                    LastName = "Sklenitzka",
                    ImageUrl = "http://softaware-new.azurewebsites.net/about-us/team/images/daniel-sklenitzka.jpg"
                }
            };

            return Task.FromResult(result);
        }
    }
}
