using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuechiMvvm.Models
{
    // INotifyPropertyChanged could be implemented in that class as well
    // it's not WPF-specific
    public class Instrument
    {
        public string Name { get; set; }

        public string ArticleNumber { get; set; }

        public string SerialNumber { get; set; }

        public IpAddress Ip { get; set; }

        public InstrumentStatus Status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
