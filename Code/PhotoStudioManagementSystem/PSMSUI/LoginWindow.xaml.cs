﻿using System;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public delegate void delegateOnSucccesfulLogin(bool IsSuccess);
        public event delegateOnSucccesfulLogin OnSucccesfulLogin;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OnSucccesfulLogin != null)
                OnSucccesfulLogin(false);
            this.Close();

            
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userNameTB.Text.Equals(PSMSDatabase.DbInteraction.FetcheId()) && passwordPB.Password.Equals(PSMSDatabase.DbInteraction.FetchePassword()))
            {
                if (OnSucccesfulLogin != null)
                    OnSucccesfulLogin(true);

                this.Hide();
            }
            else
                errorMsgLbl.Content = "Wrong User Name or Password.";


            userNameTB.Text = String.Empty;
            passwordPB.Password = String.Empty;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("comming soon");
        }

        private void loginResetBtn_Click(object sender, RoutedEventArgs e)
        {
            typeComboB.SelectedIndex = 2;
            userNameTB.Text = string.Empty;
            passwordPB.Password = string.Empty;
        }
    }
}
