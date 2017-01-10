using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuechiMvvm.Models;
using System.Threading;

namespace BuechiMvvm.DAL
{
    public class InstrumentManager : IInstrumentManager
    {
        private IList<InstrumentStatus> status = null;

        public IEnumerable<InstrumentStatus> GetAvailableStatus()
        {
            if (status == null)
            {
                this.status = new List<InstrumentStatus>();
                this.status.Add(new InstrumentStatus()
                {
                    Id = 1,
                    Name = "Automatisch"
                });

                this.status.Add(new InstrumentStatus()
                {
                    Id = 2,
                    Name = "Manuell"
                });

                this.status.Add(new InstrumentStatus()
                {
                    Id = 3,
                    Name = "Init"
                });
            }

            return status;
        }

        public IEnumerable<Instrument> GetInstruments()
        {
            var status = GetAvailableStatus().ToList();
            Random rand = new Random();

            yield return new Instrument()
            {
                Name = "N500",
                ArticleNumber = "A12399",
                Ip = new IpAddress(10, 10, 10, 7),
                Status = status[rand.Next(status.Count)],
                SerialNumber = "ATER102394023523523"
            };

            yield return new Instrument()
            {
                Name = "N501",
                ArticleNumber = "A12394",
                Ip = new IpAddress(10, 10, 10, 9),
                Status = status[rand.Next(status.Count)],
                SerialNumber = "ATER102394023523525"
            };

            yield return new Instrument()
            {
                Name = "N502",
                ArticleNumber = "A12396",
                Ip = new IpAddress(10, 10, 10, 5),
                Status = status[rand.Next(status.Count)],
                SerialNumber = "ATER102394023523528"
            };
        }
    }
}
