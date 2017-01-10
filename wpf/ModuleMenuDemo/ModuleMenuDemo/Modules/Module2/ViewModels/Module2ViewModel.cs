using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMenuDemo.Modules.Module2.ViewModels
{
    public class Module2ViewModel : ViewModelBase, IMenuViewModel, ILicenseable
    {
        public string Code
        {
            get
            {
                return "M2";
            }
        }

        public IEnumerable<IFeature> Features
        {
            get
            {
                yield return new FeatureC();
            }
        }

        public string Title
        {
            get
            {
                return "Modul 2";
            }
        }
    }
}
