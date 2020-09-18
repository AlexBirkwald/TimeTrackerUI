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

namespace TimeTrackerUI
{
    /// <summary>
    /// Interaction logic for ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        List<CustomerModel> existingCustomers = GlobalConfig.Connection.Customer_GetAll();
        List<TaskModel> existingTasks = GlobalConfig.Connection.Tasks_GetAll();
        List<TimeRegistrationModel> result = new List<TimeRegistrationModel>();


        public ReportsPage()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }



        private void InitializeComboBoxes()
        {
            CustomerComboBox.ItemsSource = null;
            CustomerComboBox.ItemsSource = existingCustomers;
            CustomerComboBox.DisplayMemberPath = "Name";

            TaskComboBox.ItemsSource = null;
            TaskComboBox.ItemsSource = existingTasks;
            TaskComboBox.DisplayMemberPath = "Name";

        }




        private void ShowResult()
        {
            ReportDataGrid.ItemsSource = null;
            ReportDataGrid.ItemsSource = result;
        }




        private void LoadReportButton_Click(object sender, RoutedEventArgs e)
        {
            QueryModel query = CollectQuery();

            query.PeriodStart = ValidateStartDate(query.PeriodStart);
            query.PeriodEnd = ValidateEndDate(query.PeriodEnd);

            
            if (CustomerComboBox.SelectedItem == null && TaskComboBox.SelectedItem == null)
            {
                result = GlobalConfig.Query.TimeRegistration_GetByPeriod(query);
            }

            if (CustomerComboBox.SelectedItem == null && TaskComboBox.SelectedItem != null)
            {
                result = GlobalConfig.Query.TimeRegistration_GetByPeriod(query);
                result = GlobalConfig.Query.TimeRegistration_GetByTask(result, query);
            }

            if (CustomerComboBox.SelectedItem != null && TaskComboBox.SelectedItem == null)
            {
                result = GlobalConfig.Query.TimeRegistration_GetByPeriod(query);
                result = GlobalConfig.Query.TimeRegistration_GetByCustomer(result, query);
            }

            if (CustomerComboBox.SelectedItem != null && TaskComboBox.SelectedItem != null)
            {
                result = GlobalConfig.Query.TimeRegistration_GetByPeriod(query);
                result = GlobalConfig.Query.TimeRegistration_GetByCustomerTask(result, query);
            }
            
            ShowResult();            
        }





        private QueryModel CollectQuery()
        {
            QueryModel output = new QueryModel();

            if(CustomerComboBox.SelectedItem != null && TaskComboBox.SelectedItem != null)
            {
                CustomerModel customer = (CustomerModel)CustomerComboBox.SelectedItem;
                TaskModel task = (TaskModel)TaskComboBox.SelectedItem;

                output.PeriodStart = PeriodStart.Text;
                output.PeriodEnd = PeriodEnd.Text;
                output.Customer = (CustomerModel)CustomerComboBox.SelectedItem;
                output.Task = (TaskModel)TaskComboBox.SelectedItem;
            }

            if(CustomerComboBox.SelectedItem != null && TaskComboBox.SelectedItem == null)
            {
                output.PeriodStart = PeriodStart.Text;
                output.PeriodEnd = PeriodEnd.Text;
                output.Customer = (CustomerModel)CustomerComboBox.SelectedItem;
            }

            if (CustomerComboBox.SelectedItem == null && TaskComboBox.SelectedItem != null)
            {
                output.PeriodStart = PeriodStart.Text;
                output.PeriodEnd = PeriodEnd.Text;
                output.Task = (TaskModel)TaskComboBox.SelectedItem;
            }

            if (CustomerComboBox.SelectedItem == null && TaskComboBox.SelectedItem == null)
            {
                output.PeriodStart = PeriodStart.Text;
                output.PeriodEnd = PeriodEnd.Text;
            }
            return output;
        }




        private void ResetSearchButton_Click(object sender, RoutedEventArgs e)
        {
            PeriodStart.Text = "00-00-0000";
            PeriodEnd.Text = "00-00-0000";
            TaskComboBox.SelectedItem = null;
            CustomerComboBox.SelectedItem = null;
        }

        private string ValidateStartDate(string date)
        {
            string output = string.Empty;

            try
            {
                DateTime start = Convert.ToDateTime(date);
                output = date;
            }
            catch
            {
                output = "01-01-1950";
            }

            return output;
        }
        private string ValidateEndDate(string date)
        {
            string output = string.Empty;

            try
            {
                DateTime start = Convert.ToDateTime(date);
                output = date;
            }
            catch
            {
                output = "01-01-2100";
            }

            return output;
        }
    }
}
