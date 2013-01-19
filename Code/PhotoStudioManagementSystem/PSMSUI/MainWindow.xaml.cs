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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PSMSData;

namespace PSMSUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            PSMSController contrl = new PSMSData.PSMSController();

            EmployeeManager mngr = new EmployeeManager();

            PSMSUI.LoginWindow LoginWindowobj = new PSMSUI.LoginWindow();
            LoginWindowobj.Show();
        }
    }
}
