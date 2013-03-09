using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PSMSUI
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void resetPassBtn_Click(object sender, RoutedEventArgs e)
        {
            userTB.Text = crntPassPB.Password = newPassPB.Password = retypPassPB.Password = string.Empty;
            userTypeComboB.SelectedIndex = 2;
        }

        private void resetInfoBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
