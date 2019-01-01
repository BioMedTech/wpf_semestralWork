using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Expence_Tracker.View
{
    /// <summary>
    /// Логика взаимодействия для CategoryManager.xaml
    /// </summary>
    public partial class CategoryManager : Window
    {
        ToggleButton tb = null;
        public CategoryManager()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (tb != null)
            {
                tb.IsChecked = false;
            }
            tb =(ToggleButton)e.Source;
        }
    }
}
