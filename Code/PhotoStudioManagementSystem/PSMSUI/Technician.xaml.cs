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
    /// Interaction logic for Technician.xaml
    /// </summary>
    public partial class Technician : Window
    {
        public Technician()
        {
            InitializeComponent();
        }

        private void tecCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
