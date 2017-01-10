using System;

namespace ModuleMenuDemo.Modules.Module2.ViewModels
{
    public class FeatureC : IFeature
    {
        public string Name
        {
            get
            {
                return "Feature 3";
            }
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}