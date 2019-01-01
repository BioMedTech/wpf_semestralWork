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
using System.Windows.Shapes;

namespace Expence_Tracker.View
{
    /// <summary>
    /// Логика взаимодействия для Overview.xaml
    /// </summary>
    public partial class Overview : Window
    {
        public Overview()
        {
            InitializeComponent();
        }
        private void Open_Statistics(object sender, RoutedEventArgs e)
        {
            SettingsPanel.Visibility = Visibility.Collapsed;
            CurrencyPanel.Visibility = Visibility.Collapsed;
            ExpenceManagerPanel.Visibility = Visibility.Collapsed;
            StatisticsPanel.Visibility = Visibility.Visible;
        }
        private void Open_ExpenceManager(object sender, RoutedEventArgs e)
        {
            SettingsPanel.Visibility = Visibility.Collapsed;
            CurrencyPanel.Visibility = Visibility.Collapsed;
            ExpenceManagerPanel.Visibility = Visibility.Visible;
            StatisticsPanel.Visibility = Visibility.Collapsed;
        }
        private void Open_Currency(object sender, RoutedEventArgs e)
        {
            SettingsPanel.Visibility = Visibility.Collapsed;
            CurrencyPanel.Visibility = Visibility.Visible;
            ExpenceManagerPanel.Visibility = Visibility.Collapsed;
            StatisticsPanel.Visibility = Visibility.Collapsed;
        }
        private void Open_Settings(object sender, RoutedEventArgs e)
        {
            SettingsPanel.Visibility = Visibility.Visible;
            CurrencyPanel.Visibility = Visibility.Collapsed;
            ExpenceManagerPanel.Visibility = Visibility.Collapsed;
            StatisticsPanel.Visibility = Visibility.Collapsed;
        }
        private void AddExpense(object sender, RoutedEventArgs e)
        {
            AddExpense add = new AddExpense();
            add.ShowDialog();
        }
        private void AddCategory(object sender, RoutedEventArgs e)
        {
            CategoryManager categoryManager = new CategoryManager();
            categoryManager.ShowDialog();
        }
    }
}
