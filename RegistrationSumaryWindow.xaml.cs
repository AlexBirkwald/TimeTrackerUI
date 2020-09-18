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
using System.Windows.Shapes;
using TimeTrackerLibrary;
using TimeTrackerLibrary.Models;

namespace TimeTrackerUI
{
    /// <summary>
    /// Interaction logic for RegistrationSumaryWindow.xaml
    /// </summary>
    public partial class RegistrationSumaryWindow : Window
    {
        TimeRegistrationModel trModel = new TimeRegistrationModel();

        public RegistrationSumaryWindow(TimeRegistrationModel model)
        {
            InitializeComponent();
            trModel = model;
            FillForm(trModel);
           
        }


        private void FillForm(TimeRegistrationModel model)
        {
            TimeElapsed.Content = model.TimeElapsed;
            TimeStart.Content = model.TimeStart;
            TimeStop.Content = model.TimeStop;
            Customer.Content = model.Customer.Name;
            Task.Content = model.Task.Name;            
        }

        private void Discard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            GlobalConfig.Connection.CreateRegistration(trModel);
            this.Close();
                
        }

    }
}
