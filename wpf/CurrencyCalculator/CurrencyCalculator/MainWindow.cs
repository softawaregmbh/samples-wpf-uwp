using CurrencyCalculator.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CurrencyCalculator
{
    public class MainWindow : Window
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application application = new Application();

            Window window = new MainWindow();

            window.Title = "BÜCHI WPF Code Sample";
            window.Width = 800;
            window.Height = 600;

            window.Show();

            application.Run();
        }

        private TextBox txtLeftValue;
        private TextBox txtRightValue;
        private ComboBox cmbLeftCurrency;
        private ComboBox cmbRightCurrency;

        private ICurrencyCalculator currencyCalculator;

        public MainWindow()
        {
            this.currencyCalculator = CurrencyCalculatorFactory.GetCalculator();

            this.txtLeftValue = new TextBox()
            {
                Width = 80,
                Margin = new Thickness(10)
            };

            this.txtRightValue = new TextBox()
            {
                Width = 80,
                Margin = new Thickness(10)
            };

            this.cmbLeftCurrency = new ComboBox()
            {
                Margin = new Thickness(10)
            };

            this.cmbRightCurrency = new ComboBox()
            {
                Margin = new Thickness(10)
            };

            // Version 1:
            //foreach (var currency in currencyCalculator.GetCurrencyData())
            //{
            //    this.cmbLeftCurrency.Items.Add(currency);
            //    this.cmbRightCurrency.Items.Add(currency);
            //}

            // Version 2:
            var currencies = currencyCalculator.GetCurrencyData();
            this.cmbLeftCurrency.ItemsSource = currencies;
            this.cmbRightCurrency.ItemsSource = currencies;

            StackPanel panel = new StackPanel();
            panel.Children.Add(txtLeftValue);
            panel.Children.Add(cmbLeftCurrency);
            panel.Children.Add(txtRightValue);
            panel.Children.Add(cmbRightCurrency);

            panel.Orientation = Orientation.Horizontal;

            this.cmbLeftCurrency.SelectedItem = currencies.Where(p => p.Symbol == "CHF").First();
            this.cmbRightCurrency.SelectedItem = currencies.Where(p => p.Symbol == "EUR").First();

            this.cmbLeftCurrency.SelectionChanged += OnSelectionChanged;
            this.cmbRightCurrency.SelectionChanged += OnSelectionChanged;

            this.Content = panel;

            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        enum Conversion { LeftToRight, RightToLeft }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == cmbLeftCurrency)
                Convert(Conversion.LeftToRight);
            else
                Convert(Conversion.RightToLeft);

        }

        private void Convert(Conversion conversion)
        {
            if (cmbLeftCurrency.SelectedItem == null || cmbRightCurrency.SelectedItem == null)
                return;

            string leftCurrency = ((CurrencyData)cmbLeftCurrency.SelectedItem).Symbol;
            string rightCurrency = ((CurrencyData)cmbRightCurrency.SelectedItem).Symbol;

            double input;
            if (conversion == Conversion.LeftToRight)
            {
                if (double.TryParse(txtLeftValue.Text, out input))
                { 
                    txtRightValue.Text = currencyCalculator.Convert(input, leftCurrency, rightCurrency).ToString("F2");
                }
            }
            else
            {
                if (double.TryParse(txtRightValue.Text, out input))
                { 
                    txtLeftValue.Text = currencyCalculator.Convert(input, rightCurrency, leftCurrency).ToString("F2");
                }
            }
        }
    }
}
