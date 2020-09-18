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

namespace TimeTrackerUI
{
    /// <summary>
    /// Interaction logic for ManageTaskCustomerPage.xaml
    /// </summary>
    public partial class ManageTaskCustomerPage : Page
    {
        public ManageTaskCustomerPage()
        {
            InitializeComponent();
            CustomerTaskFrame.Content = new ManageCustomerPage();
        }

        private void CustomerSectionButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerTaskFrame.Content = new ManageCustomerPage();
            TasksSectionButton.Opacity = 0.5;
            CustomerSectionButton.Opacity = 1;
            
        }

        private void TasksSectionButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerTaskFrame.Content = new ManageTasksPage();
            CustomerSectionButton.Opacity = 0.5;
            TasksSectionButton.Opacity = 1;
        }
    }
}
