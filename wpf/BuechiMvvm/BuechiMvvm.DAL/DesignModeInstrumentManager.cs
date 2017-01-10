using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuechiMvvm.Models;

namespace BuechiMvvm.DAL
{
    public class DesignModeInstrumentManager : IInstrumentManager
    {
        public IEnumerable<InstrumentStatus> GetAvailableStatus()
        {
            yield return new InstrumentStatus()
            {
                Id = 1,
                Name = "DEMO"
            };
        }

        public IEnumerable<Instrument> GetInstruments()
        {
            yield return new Instrument()
            {
                Name = "DEMO N500",
                ArticleNumber = "A12399",
                Ip = new IpAddress(10, 10, 10, 7),
                Status = GetAvailableStatus().First(),
                SerialNumber = "ATER102394023523523"
            };
        }
    }
}
