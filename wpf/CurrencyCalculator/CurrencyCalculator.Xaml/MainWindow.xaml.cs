using CurrencyCalculator.BL;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CurrencyCalculator.Xaml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICurrencyCalculator currencyCalculator;


        public MainWindow()
        {
            InitializeComponent();

            this.currencyCalculator = CurrencyCalculatorFactory.GetCalculator();

            var currencies = this.currencyCalculator.GetCurrencyData();
            this.cmbLeftCurrency.ItemsSource = currencies;
            this.cmbRightCurrency.ItemsSource = currencies;

            this.cmbLeftCurrency.SelectedIndex = 0;
            this.cmbRightCurrency.SelectedIndex = 0;

            rates.ItemsSource = this.currencyCalculator.MonthlyRatesOfExchange("CHF", "EUR", new DateTime(2016, 1, 1), new DateTime(2017, 1, 1));
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
