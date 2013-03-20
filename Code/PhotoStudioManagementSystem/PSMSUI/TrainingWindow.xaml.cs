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
using PSMSData;
using PSMSDatabase;
using System.Collections.ObjectModel;

namespace PSMSUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TrainingWindow : Window
    {
        ObservableCollection<TrainingInfo> _trainingCollection = new ObservableCollection<TrainingInfo>();


        public ObservableCollection<TrainingInfo> trainingCollection
        {
            get
            {
                return _trainingCollection;
            }
        }

        public TrainingWindow()
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
                    PSMSData.TrainingInfo newtraining = new PSMSData.TrainingInfo();

                    newtraining.id = GenerateId();

                    newtraining.name = cstNameTB.Text;
                    newtraining.address = cstAdrsTB.Text;
                    newtraining.contact = cstCntctTB.Text;
                    newtraining.remark = cstRmrkTB.Text;

                    PSMSDatabase.DbInteraction.DoRegisterNewtraining(newtraining);

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
                    fetchtrainingData();

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

            fetchtrainingData();
        }

        private void fetchtrainingData()
        {
            List<TrainingInfo> trainings = DbInteraction.GetAlltrainingList();

            _trainingCollection.Clear();

            foreach (TrainingInfo training in trainings)
            {
                _trainingCollection.Add(training);
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            fetchtrainingData();
        }

        private void serchCustBtn_Click(object sender, RoutedEventArgs e)
        {
            if (srchNameTB.Text == "")
                fetchtrainingData();
            else
            {
                TrainingInfo custinfo = new TrainingInfo();
                custinfo.name = srchNameTB.Text;


                List<TrainingInfo> trainings = DbInteraction.searchtrainingList(custinfo);

                _trainingCollection.Clear();

                foreach (TrainingInfo training in trainings)
                {
                    _trainingCollection.Add(training);
                }
            }

        }

        private TrainingInfo GetSelectedItem()
        {

            TrainingInfo trainingToDelete = null;

            if (contactView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                TrainingInfo i = (TrainingInfo)contactView.SelectedItem;

                trainingToDelete = _trainingCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return trainingToDelete;
        }

        public string trainingID;

        private void cstEditInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            
            TrainingInfo trainingToEdit = GetSelectedItem();
            if (trainingToEdit != null)
            {
                cstUpdateBtn.IsEnabled = true;
                addCustmrEpndr.IsExpanded = true;
                cstSaveBtn.IsEnabled = false;
                cstNameTB.Text = trainingToEdit.name;
                cstCntctTB.Text = trainingToEdit.contact;
                cstAdrsTB.Text = trainingToEdit.address;
                cstRmrkTB.Text = trainingToEdit.remark;
                    

            }
        }

        private void cstUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            TrainingInfo trainingToEdit = GetSelectedItem();
            
            trainingToEdit.name = cstNameTB.Text;
            trainingToEdit.contact = cstCntctTB.Text;
            trainingToEdit.address = cstAdrsTB.Text;
            trainingToEdit.remark = cstRmrkTB.Text;

            PSMSDatabase.DbInteraction.Edittraining(trainingToEdit);
           
        }

        private void cstDelInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            TrainingInfo trainingToDelete = GetSelectedItem();
            if (trainingToDelete != null)
            {
                _trainingCollection.Remove(trainingToDelete);
                PSMSDatabase.DbInteraction.Deletetraining(trainingToDelete.id);
                fetchtrainingData();
               
            }

        }


    }
}
