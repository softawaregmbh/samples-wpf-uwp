using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMenuDemo
{
    public interface IMenuViewModel
    {
        string Title { get; }

        IEnumerable<IFeature> Features { get; }
    }
}
