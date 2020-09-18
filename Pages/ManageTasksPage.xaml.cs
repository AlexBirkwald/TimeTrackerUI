using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeTrackerLibrary;
using TimeTrackerLibrary.Models;
using TimeTrackerLibrary.DataAcess;

namespace TimeTrackerUI
{
    /// <summary>
    /// Interaction logic for ManageTasksPage.xaml
    /// </summary>
    public partial class ManageTasksPage : Page
    {

        private bool isUpdate = false;

        private List<TaskModel> existingTasks = GlobalConfig.Connection.Tasks_GetAll();

        public ManageTasksPage()
        {
            InitializeComponent();
            WireUpList();
            
        }

        private void WireUpList()
        {
            TasksDataGrid.ItemsSource = null;
            TasksDataGrid.ItemsSource = existingTasks;
            
        }


        private void CreateUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isUpdate)
            {
                if (ValidateNewTask())
                {
                    TaskModel t = new TaskModel();
                    t.Name = TaskNameTextBox.Text;

                    GlobalConfig.Connection.CreateTask(t);

                    existingTasks.Add(t);
                    WireUpList();

                    TaskNameTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("The task must have a name");
                }
            }

            if (isUpdate)
            {
                if (ValidateNewTask())
                {
                    TaskModel t = (TaskModel)TasksDataGrid.SelectedItem;

                    foreach (TaskModel tm in existingTasks)
                    {
                        if (t.Id == tm.Id)
                        {
                            tm.Name = TaskNameTextBox.Text;

                            GlobalConfig.Connection.UpdateTasksFile(existingTasks);
                            WireUpList();
                            TaskNameTextBox.Text = "";
                        }
                    }
                }

                CreateUpdateButton.Content = "Create Task";
                isUpdate = false;
            }


        }

        private void DeleteSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            TaskModel t = (TaskModel)TasksDataGrid.SelectedItem;

            if(t != null)
            {
                existingTasks.Remove(t);
                GlobalConfig.Connection.UpdateTasksFile(existingTasks);
                WireUpList();
            }

        }

        private void EditSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            TaskModel t = (TaskModel)TasksDataGrid.SelectedItem;

            if(t != null)
            {
                isUpdate = true;
                CreateUpdateButton.Content = "Update Task";

                TaskNameTextBox.Text = t.Name;
            }
        }



        private bool ValidateNewTask()
        {
            bool output = true;

            if(TaskNameTextBox.Text.Length == 0)
            {
                output = false;
            }

            return output;
        }
    }
}
