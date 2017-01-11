using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace HelloUWP
{
    public class ContinuumStateTrigger : StateTriggerBase
    {
        public ContinuumStateTrigger()
        {
            Window.Current.SizeChanged += Current_SizeChanged;
        }

        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            var mode = UIViewSettings.GetForCurrentView().UserInteractionMode;

            this.SetActive(mode == UserInteractionMode.Touch);
        }

    }
}
