using BuechiMvvm.DAL;
using BuechiMvvm.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
    public class InstrumentViewModel : ViewModelBase
    {
        private IInstrumentManager instrumentManager;

        //implemented in ObservableObject base class
        //public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Instrument> instruments;

        public ObservableCollection<Instrument> Instruments
        {
            get { return instruments; }
            set
            {
                //instruments = value;
                //this.RaisePropertyChanged();

                this.Set(ref instruments, value);
            }
        }

        private Instrument selectedInstrument;

        public Instrument SelectedInstrument
        {
            get { return selectedInstrument; }
            set { this.Set(ref selectedInstrument, value); }
        }

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set { this.Set(ref isLoading, value);  }
        }

        public ICommand LoadInstrumentsCommand { get; set; }

        public ICommand AddInstrumentsCommand { get; set; }

        public InstrumentViewModel(IInstrumentManager instrumentManager)
        {
            this.instrumentManager = instrumentManager;

            this.LoadInstrumentsCommand = new RelayCommand(LoadInstruments);

            this.AddInstrumentsCommand = new RelayCommand(() => this.Instruments.Add(new Instrument()
            {
                Name = "L200",
                Ip = new IpAddress(10,10,10,1)
            }));

            LoadInstruments();
        }

        private void LoadInstruments()
        {
            this.IsLoading = true;

            this.Instruments = new ObservableCollection<Instrument>(this.instrumentManager.GetInstruments());

            this.IsLoading = false;
        }
    }
}
