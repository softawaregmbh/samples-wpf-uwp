using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMenuDemo
{
    public interface IFeature
    {
        string Name { get; }

        void Execute();
    }
}
