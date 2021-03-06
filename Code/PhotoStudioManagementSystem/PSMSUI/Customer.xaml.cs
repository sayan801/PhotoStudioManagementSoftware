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
using PSMSData;
using PSMSDatabase;
using System.Collections.ObjectModel;

namespace PSMSUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ObservableCollection<CustomerInfo> _customerCollection = new ObservableCollection<CustomerInfo>();


        public ObservableCollection<CustomerInfo> customerCollection
        {
            get
            {
                return _customerCollection;
            }
        }

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
            cstSaveBtn.IsEnabled = true;
            cstUpdateBtn.IsEnabled = false;
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
                    fetchCustomerData();

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            fetchCustomerData();
        }

        private void fetchCustomerData()
        {
            List<CustomerInfo> customers = DbInteraction.GetAllCustomerList();

            _customerCollection.Clear();

            foreach (CustomerInfo customer in customers)
            {
                _customerCollection.Add(customer);
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            fetchCustomerData();
        }

        private void serchCustBtn_Click(object sender, RoutedEventArgs e)
        {
            if (srchNameTB.Text == "")
                fetchCustomerData();
            else
            {
                CustomerInfo custinfo = new CustomerInfo();
                custinfo.name = srchNameTB.Text;


                List<CustomerInfo> customers = DbInteraction.searchCustomerList(custinfo);

                _customerCollection.Clear();

                foreach (CustomerInfo customer in customers)
                {
                    _customerCollection.Add(customer);
                }
            }

        }

        private CustomerInfo GetSelectedItem()
        {

            CustomerInfo customerToDelete = null;

            if (contactView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                CustomerInfo i = (CustomerInfo)contactView.SelectedItem;

                customerToDelete = _customerCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return customerToDelete;
        }

        public string customerID;

        private void cstEditInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            
            CustomerInfo customerToEdit = GetSelectedItem();
            if (customerToEdit != null)
            {
                cstUpdateBtn.IsEnabled = true;
                addCustmrEpndr.IsExpanded = true;
                cstSaveBtn.IsEnabled = false;
                cstNameTB.Text = customerToEdit.name;
                cstCntctTB.Text = customerToEdit.contact;
                cstAdrsTB.Text = customerToEdit.address;
                cstRmrkTB.Text = customerToEdit.remark;
                    

            }
        }

        private void cstUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerInfo customerToEdit = GetSelectedItem();
            
            customerToEdit.name = cstNameTB.Text;
            customerToEdit.contact = cstCntctTB.Text;
            customerToEdit.address = cstAdrsTB.Text;
            customerToEdit.remark = cstRmrkTB.Text;

            PSMSDatabase.DbInteraction.EditCustomer(customerToEdit);
           
        }

        private void cstDelInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerInfo customerToDelete = GetSelectedItem();
            if (customerToDelete != null)
            {
                _customerCollection.Remove(customerToDelete);
                PSMSDatabase.DbInteraction.DeleteCustomer(customerToDelete.id);
                fetchCustomerData();
               
            }

        }


    }
}
