using System;

namespace ModuleMenuDemo.Modules.Module1.ViewModels
{
    internal class FeatureB : IFeature
    {
        public string Name
        {
            get
            {
                return "Feature 2";
            }
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}