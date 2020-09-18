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
    /// Interaction logic for AllCustomersPage.xaml
    /// </summary>
    public partial class AllCustomersPage : Page
    {
        private List<CustomerModel> existingCustomers = GlobalConfig.Connection.Customer_GetAll();
        public AllCustomersPage()
        {
            InitializeComponent();
            WireUpList();
        }

        private void WireUpList()
        {

            allCustomersDatagrid.ItemsSource = null;
            allCustomersDatagrid.ItemsSource = existingCustomers;

        }
    }
}
