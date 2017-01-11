using HelloUWP.Data;
using HelloUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.DataContext = new MainViewModel(new OfflinePeopleManager(new OnlinePeopleManager()));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameter = e.Parameter;

            Application.Current.Suspending += Current_Suspending;

            RefreshLiveTile();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Application.Current.Suspending -= Current_Suspending;
        }

        private void Current_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values["Id"] = 4711;
        }

        private void RefreshLiveTile()
        {
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();

            // uncomment this line if you want more than one live tile
            //updater.EnableNotificationQueue(true);
            
            var xml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Image);

            var all = xml.GetXml();
            var image = xml.GetElementsByTagName("image")[0] as XmlElement;
            
            image.SetAttribute("src", "http://softaware-new.azurewebsites.net/blog/images/2016-08-01-leberkaese.jpg");

            updater.Update(new TileNotification(xml));
        }

        public MainViewModel ViewModel
        {
            get
            {
                return this.DataContext as MainViewModel;
            }
        }

        private void btnHamburger_Click(object sender, RoutedEventArgs e)
        {
            this.splitView.IsPaneOpen = !this.splitView.IsPaneOpen;
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AboutPage));
        }
    }
}
