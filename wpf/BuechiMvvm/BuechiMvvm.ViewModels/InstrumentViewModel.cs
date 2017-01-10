using BuechiMvvm.DAL;
using BuechiMvvm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BuechiMvvm.ViewModels
{
    public class InstrumentViewModel : INotifyPropertyChanged
    {
        private IInstrumentManager instrumentManager;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Instrument> instruments;

        public ObservableCollection<Instrument> Instruments
        {
            get { return instruments; }
            set
            {
                instruments = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Instruments"));
                }
            }
        }

        private Instrument selectedInstrument;

        public Instrument SelectedInstrument
        {
            get { return selectedInstrument; }
            set
            {
                selectedInstrument = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedInstrument"));
                }
            }
        }



        public ICommand LoadInstrumentsCommand { get; set; }

        public ICommand AddInstrumentsCommand { get; set; }


        public InstrumentViewModel()
        {
            this.instrumentManager = new InstrumentManager();

            this.LoadInstrumentsCommand = new RelayCommand(LoadInstruments);

            this.AddInstrumentsCommand = new RelayCommand(p => this.Instruments.Add(new Instrument()
            {
                Name = "L200",
                Ip = new IpAddress(10,10,10,1)
            }));

            LoadInstruments(null);
        }

        private void LoadInstruments(object obj)
        {
            this.Instruments = new ObservableCollection<Instrument>(this.instrumentManager.GetInstruments());
        }
    }
}
