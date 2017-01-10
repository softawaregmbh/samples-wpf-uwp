using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMenuDemo.Licenser
{
    public class LicenseManager
    {
        private bool isLicensed;

        public bool IsModuleLicensed(int userId, string moduleCode)
        {
            return true;

            isLicensed = !isLicensed;

            return isLicensed;
        }
    }
}
