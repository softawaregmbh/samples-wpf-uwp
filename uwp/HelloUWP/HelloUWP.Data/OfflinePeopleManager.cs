using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HelloUWP.Data
{
    public class OfflinePeopleManager : IPeopleManager
    {
        private IPeopleManager onlineManager;
        private bool isOnline = false;

        public OfflinePeopleManager(IPeopleManager onlineManager)
        {
            this.onlineManager = onlineManager;
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            if (isOnline)
            {
                var people = await this.onlineManager.GetPeopleAsync();

                // store the people in the cache
                await UpdateCacheAsync(people);

                return people;
            }
            else
            {
                // read from cache
                var people = await ReadCacheAsync();

                return people;
            }
        }

        private async Task UpdateCacheAsync(IEnumerable<Person> people)
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalCacheFolder;

            var file = await folder.CreateFileAsync("people.json",
                CreationCollisionOption.ReplaceExisting);

            var json = JsonConvert.SerializeObject(people);

            await FileIO.WriteTextAsync(file, json);
        }

        private async Task<IEnumerable<Person>> ReadCacheAsync()
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalCacheFolder;
            var file = await folder.GetFileAsync("people.json");
            var json = await FileIO.ReadTextAsync(file);

            var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(json);

            return people;
        }
    }
}
