using BuechiMvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuechiMvvm.DAL
{
    public interface IInstrumentManager
    {
        Task<IEnumerable<Instrument>> GetInstrumentsAsync();

        Task<IEnumerable<InstrumentStatus>> GetAvailableStatusAsync();
    }
}
