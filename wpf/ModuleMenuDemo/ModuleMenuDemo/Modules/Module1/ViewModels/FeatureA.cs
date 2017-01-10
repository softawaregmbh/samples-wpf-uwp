using System;

namespace ModuleMenuDemo.Modules.Module1.ViewModels
{
    public class FeatureA : IFeature
    {
        public string Name
        {
            get
            {
                return "Feature 1";
            }
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}