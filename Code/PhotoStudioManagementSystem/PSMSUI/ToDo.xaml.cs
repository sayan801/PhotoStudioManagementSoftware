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
    /// Interaction logic for ToDo.xaml
    /// </summary>
    public partial class ToDo : Window
    {
        public ToDo()
        {
            InitializeComponent();
        }

        private void closeTodoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addTodoBtn_Click(object sender, RoutedEventArgs e)
        {
            PSMSData.ToDoInfo newTodo = new PSMSData.ToDoInfo();

            newTodo.id = GenerateId();
            newTodo.date = DateTime.Now;
            newTodo.details = todoTaskTB.Text;

            PSMSDatabase.DbInteraction.DoRegisterNewTodo(newTodo);

            todoTaskTB.Clear();
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
    }
}
