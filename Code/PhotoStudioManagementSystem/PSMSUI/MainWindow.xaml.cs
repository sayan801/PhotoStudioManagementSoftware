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


        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedIn == false)
            {
                

            }
            else
            {
                
                mainDocPanel.IsEnabled = false;

                loginBtn.Content = "Login";
                loginBtn.ToolTip = "Click to Login";
                LoggedIn = false;

                loginWin.ShowDialog();
            }
        }


        void LoginWindowObj_OnSucccesfulLogin(bool IsSuccess)
        {
            if (IsSuccess)
            {
                mainDocPanel.IsEnabled = true;
                loginBtn.Content = "Logout";
                loginBtn.ToolTip = "Click to Logout";
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

        private void customerBtn_Click(object sender, RoutedEventArgs e)
        {
            PSMSUI.Window1 CustObj = new PSMSUI.Window1();
            CustObj.Show();
        }

        private void techniBtn_Click(object sender, RoutedEventArgs e)
        {
            PSMSUI.Technician tecwinObj = new PSMSUI.Technician();
            tecwinObj.Show();
        }

        private void workOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            PSMSUI.WorkOrder OrderObj = new PSMSUI.WorkOrder();
            OrderObj.Show();
        }

        private void billGenBtn_Click(object sender, RoutedEventArgs e)
        {
            PSMSUI.BillGeneration BillGenerationObj = new PSMSUI.BillGeneration();
            BillGenerationObj.Show();
        }

        private void todoBtn_Click(object sender, RoutedEventArgs e)
        {
            PSMSUI.ToDo ToDoObj = new PSMSUI.ToDo();
            ToDoObj.Show();
        }

        private void salesreportBtn_Click(object sender, RoutedEventArgs e)
        {
            PSMSUI.SalesReport SalesReportObj = new PSMSUI.SalesReport();
            SalesReportObj.Show();
        }

        private void settingsBtn_Click(object sender, RoutedEventArgs e)
        {
            PSMSUI.Settings SettingsObj = new PSMSUI.Settings();
            SettingsObj.ShowDialog();
        }

        private void photogalleryBtn_Click(object sender, RoutedEventArgs e)
        {
            PSMSUI.PhotoGallery PhotoGalleryObj = new PSMSUI.PhotoGallery();
            PhotoGalleryObj.Show();
        }

        private void photoEditBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = System.Environment.CurrentDirectory + "\\iplab\\iplab.exe";
            System.Diagnostics.Process.Start(filePath);
        }

        private void mobSyncBtn_Click(object sender, RoutedEventArgs e)
        {
            MobileSyncWindow mobSync = new MobileSyncWindow();
            mobSync.OnSucccesfulLogin += new MobileSyncWindow.delegateOnSucccesfulLogin(mobSync_OnSucccesfulLogin);
            mobSync.Show();

        }

        void mobSync_OnSucccesfulLogin(bool IsSuccess)
        {
            MessageBox.Show("Mobile Sync Successful");
        }

        private void webcBtn_Click(object sender, RoutedEventArgs e)
        {
            WebSyncWindow webSync = new WebSyncWindow();
            webSync.OnSucccesfulLogin += new WebSyncWindow.delegateOnSucccesfulLogin(webSync_OnSucccesfulLogin);
            webSync.Show();
        }

        void webSync_OnSucccesfulLogin(bool IsSuccess)
        {
            MessageBox.Show("Web Sync Successful");
        }
        
    }
}
