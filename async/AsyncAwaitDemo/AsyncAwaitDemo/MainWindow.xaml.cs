using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwaitDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Task t = Task.Run(() => Task.Delay(3000));
            //Task t2 = Task.Run(() => Task.Delay(5000));
            //Task t3 = Task.Run(() => Task.Delay(500));

            try
            {

                var webClient = new WebClient();

                Task<byte[]> t = webClient.DownloadDataTaskAsync("http://softaware-new.azurewebsites.net/blog/blog.html");
            
                await t;

                //await Task.Delay(5000);

                //byte[] dataSynchron = webClient.DownloadData("http://www.buchi.comasdf");

                byte[] data = await webClient.DownloadDataTaskAsync("asdfasdf://www.buchi.com");
            }
            catch (WebException ex)
            {

                
            }
            //..
            //..
        }
    }
}
