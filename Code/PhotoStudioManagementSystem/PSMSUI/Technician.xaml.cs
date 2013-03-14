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
    /// Interaction logic for Technician.xaml
    /// </summary>
    public partial class Technician : Window
    {
        public Technician()
        {
            InitializeComponent();
        }

        private void techiCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void techiInfoSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            PSMSData.TechnicianInfo newTechnician = new PSMSData.TechnicianInfo();


            newTechnician.id = GenerateId();
            newTechnician.name = techiNameTB.Text;
            newTechnician.contact = techiContactTB.Text;
            newTechnician.email = techiEmailTB.Text;
            newTechnician.homenumber = techiHomenoTB.Text;
            newTechnician.address = techiAdrsTB.Text;
            newTechnician.joiningdate = techiJoinDP.SelectedDate.Value;
            newTechnician.salary = Convert.ToDouble(techiSlryTB.Text);
            newTechnician.remark = techiRmrkTB.Text;
            


            PSMSDatabase.DbInteraction.DoRegisterNewTechnician(newTechnician);
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
    }
}
