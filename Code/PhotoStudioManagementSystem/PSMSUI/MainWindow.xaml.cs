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
        LoginWindow loginWin;

        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };

            loginWin = new LoginWindow();
            loginWin.OnSucccesfulLogin += new PSMSUI.LoginWindow.delegateOnSucccesfulLogin(LoginWindowObj_OnSucccesfulLogin);
        }


        bool LoggedIn = false;


        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedIn == false)
            {
                

            }
            else
            {
                
                mainDocPanel.IsEnabled = false;

                loginButton.Content = "Login";
                loginButton.ToolTip = "Click to Login";
                LoggedIn = false;

                loginWin.ShowDialog();
            }
        }


        void LoginWindowObj_OnSucccesfulLogin(bool IsSuccess)
        {
            if (IsSuccess)
            {
                mainDocPanel.IsEnabled = true;
                loginButton.Content = "Logout";
                loginButton.ToolTip = "Click to Logout";
                LoggedIn = true;
            }
            else
            {
                this.Close();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!LoggedIn)
            {
                loginWin.ShowDialog();
            }
        }

        private void customer_button(object sender, RoutedEventArgs e)
        {
            PSMSUI.Window1 CustObj = new PSMSUI.Window1();
            CustObj.Show();
        }

        private void technician_button(object sender, RoutedEventArgs e)
        {
            PSMSUI.Technician tecwinObj = new PSMSUI.Technician();
            tecwinObj.Show();
        }

        private void workorder_button(object sender, RoutedEventArgs e)
        {
            PSMSUI.WorkOrder OrderObj = new PSMSUI.WorkOrder();
            OrderObj.Show();
        }

        private void bill_button(object sender, RoutedEventArgs e)
        {
            PSMSUI.BillGeneration BillGenerationObj = new PSMSUI.BillGeneration();
            BillGenerationObj.Show();
        }

        private void todo_button(object sender, RoutedEventArgs e)
        {
            PSMSUI.ToDo ToDoObj = new PSMSUI.ToDo();
            ToDoObj.Show();
        }

        private void salesreport_button(object sender, RoutedEventArgs e)
        {
            PSMSUI.SalesReport SalesReportObj = new PSMSUI.SalesReport();
            SalesReportObj.Show();
        }

        private void settings_button(object sender, RoutedEventArgs e)
        {
            PSMSUI.Settings SettingsObj = new PSMSUI.Settings();
            SettingsObj.Show();
        }

        private void photogallery_button(object sender, RoutedEventArgs e)
        {
            PSMSUI.PhotoGallery PhotoGalleryObj = new PSMSUI.PhotoGallery();
            PhotoGalleryObj.Show();
        }
    }
}
