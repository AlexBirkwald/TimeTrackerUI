using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// Interaction logic for TimeRegistrationsPage.xaml
    /// </summary>
    public partial class TimeRegistrationsPage : Page
    {
        private List<TimeRegistrationModel> registrations = GlobalConfig.Connection.Registrations_GetAll();
        
                

        public TimeRegistrationsPage()
        {
            InitializeComponent();
            InitializeGrid();

        }


        private void InitializeGrid()
        {
            RegistrationsDataGrid.ItemsSource = null;
            RegistrationsDataGrid.ItemsSource = registrations;
        }



        private void DeleteRegistration_Click(object sender, RoutedEventArgs e)
        {
            TimeRegistrationModel tr = (TimeRegistrationModel)RegistrationsDataGrid.SelectedItem;


           MessageBoxResult result = MessageBox.Show("This Will Delete The Registration Permanently, Are You Sure You Wish To Continue?", 
                                     "Delete Registration", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            
            if(result == MessageBoxResult.Yes)
            {
                if (tr != null)
                {
                    registrations.Remove(tr);
                    GlobalConfig.Connection.UpdateRegistrationsFile(registrations);
                    InitializeGrid();
                }
            }

        }
    }
}
