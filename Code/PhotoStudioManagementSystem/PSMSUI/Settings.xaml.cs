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

        private void createAcBtn_Click(object sender, RoutedEventArgs e)
        {

            if (!userNameTB.Text.Equals(string.Empty) &&
                    !newUsrIdTB.Text.Equals(string.Empty) &&
                    !newUserpssPB.Password.Equals(string.Empty))
            {
                if (!newUserpssPB.Password.Equals(retypePassTB.Password))
                    msgadNewUserLbl.Content = "Password not Matched";
                else
                {
                    PSMSData.UserInfo newUser = new PSMSData.UserInfo();

                    newUser.id = GenerateId();

                    newUser.name = userNameTB.Text;
                    newUser.type = newUserTypeComboB.Text;
                    newUser.userid = newUsrIdTB.Text;
                    newUser.passwrd = retypePassTB.Password;

                    PSMSDatabase.DbInteraction.DoRegisterNewUser(newUser);

                    msgadNewUserLbl.Content = "Successfully Created";
                    userNameTB.Clear();
                    newUserTypeComboB.SelectedIndex = 2;
                    newUsrIdTB.Clear();
                    newUserpssPB.Clear();
                    retypePassTB.Clear();
                }

            }
            else
            {
                msgadNewUserLbl.Content = "Correctly Enter Info ";

            }
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }

        private void resetNewUserBtn_Click(object sender, RoutedEventArgs e)
        {
            userNameTB.Clear();
            newUserTypeComboB.SelectedIndex = 2;
            newUsrIdTB.Clear();
            newUserpssPB.Clear();
            retypePassTB.Clear();
            msgadNewUserLbl.Content = "Successfully Reset";
        }
    }
}
