using GalaSoft.MvvmLight;
using ModuleMenuDemo.Modules.Module2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMenuDemo.Modules.Module1.ViewModels
{
    public class Module1ViewModel : ViewModelBase, IMenuViewModel, ILicenseable
    {
        public string Code
        {
            get
            {
                return "M1";
            }
        }

        public IEnumerable<IFeature> Features
        {
            get
            {
                yield return new FeatureA();
                yield return new FeatureB();
                yield return new FeatureC();
            }
        }

        public string Title
        {
            get
            {
                return "Modul 1 - Demo";
            }
        }
    }
}
