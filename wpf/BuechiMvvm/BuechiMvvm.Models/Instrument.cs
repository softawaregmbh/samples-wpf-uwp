using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuechiMvvm.Models
{
    public class Instrument
    {
        public string Name { get; set; }

        public string ArticleNumber { get; set; }

        public string SerialNumber { get; set; }

        public IpAddress Ip { get; set; }

        public InstrumentStatus Status { get; set; }
    }
}
