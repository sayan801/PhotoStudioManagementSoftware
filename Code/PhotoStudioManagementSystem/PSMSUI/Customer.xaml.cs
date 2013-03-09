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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void cusCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            cstNameTB.Clear();
            cstCntctTB.Clear();
            cstAdrsTB.Clear();
            cstRmrkTB.Clear();
            custErorMsgLbl.Content = "";
        }

        private void cstSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!cstNameTB.Text.Equals(string.Empty) && 
                !cstAdrsTB.Text.Equals(string.Empty) && 
                !cstCntctTB.Text.Equals(string.Empty))
                {
                    PSMSData.CustomerInfo newCustomer = new PSMSData.CustomerInfo();

                    newCustomer.id = GenerateId();

                    newCustomer.name = cstNameTB.Text;
                    newCustomer.address = cstAdrsTB.Text;
                    newCustomer.contact = cstCntctTB.Text;
                    newCustomer.remark = cstRmrkTB.Text;

                    PSMSDatabase.DbInteraction.DoRegisterNewCustomer(newCustomer);

                    //addCustmrEpndr.Visibility = Visibility.Collapsed;
                    //loginExpndr.Visibility = Visibility.Visible;
                    //loginExpndr.IsExpanded = true;
                    //dNBSNUserIDTB.Clear();
                    //dNBSNpassPB.Clear();
                    custErorMsgLbl.Content = "Successfully Added";
                    cstNameTB.Clear();
                    cstCntctTB.Clear();
                    cstAdrsTB.Clear();
                    cstRmrkTB.Clear();

                }
            else
            {
                custErorMsgLbl.Content = "Correctly Enter Info ";

            }
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
    }
}
