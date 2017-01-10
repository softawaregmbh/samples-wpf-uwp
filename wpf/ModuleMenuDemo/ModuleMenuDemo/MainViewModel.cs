using GalaSoft.MvvmLight;
using ModuleMenuDemo.Modules.Module1.ViewModels;
using ModuleMenuDemo.Modules.Module2.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMenuDemo
{
    public class MainViewModel : ViewModelBase
    {

        private IEnumerable<IMenuViewModel> modules;

        public IEnumerable<IMenuViewModel> Modules
        {
            get { return modules; }
            set { this.Set(ref modules, value); }
        }

        private IMenuViewModel selectedModule;

        public IMenuViewModel SelectedModule
        {
            get { return selectedModule; }
            set { this.Set(ref selectedModule, value); }
        }


        public MainViewModel()
        {
            var licenseManager = new ModuleMenuDemo.Licenser.LicenseManager();

            var allModules = new List<IMenuViewModel>()
            {
                new Module1ViewModel(),
                new Module2ViewModel()
            };

            this.Modules =
                allModules
                .Where(m =>
                    !(m is ILicenseable) ||
                    licenseManager.IsModuleLicensed(1, ((ILicenseable)m).Code))
                .ToList();
        }


    }
}
