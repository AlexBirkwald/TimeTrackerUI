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
    /// Interaction logic for NewCustomerPage.xaml
    /// </summary>
    public partial class NewCustomerPage : Page
    {
        public NewCustomerPage()
        {
            InitializeComponent();
        }

        private void createCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCustomer())
            {
                CustomerModel cm = new CustomerModel();

                cm.Name = customerNameTextBox.Text;
                cm.PhoneNumber = customerPhoneNumberTextBox.Text;
                cm.Address = customerAddressTextBox.Text;
                cm.Email = customerEmailTextBox.Text;

                cm.Cvr = 0;
                if(customerCvrTextBox.Text.Length != 0)
                {
                    cm.Cvr = int.Parse(customerCvrTextBox.Text);
                }

                GlobalConfig.Connection.CreateCustomer(cm);
                ResetWindow();
                

            }
        }

        private bool ValidateCustomer()
        {
            bool output = true;

            if(customerNameTextBox.Text.Length == 0)
            {
                output = false;
            }

            if(customerPhoneNumberTextBox.Text.Length == 0)
            {
                output = false;
            }

            if(customerAddressTextBox.Text.Length == 0)
            {
                output = false;
            }

            if(customerEmailTextBox.Text.Length == 0)
            {
                output = false;
            }

            if (!customerEmailTextBox.Text.Contains("@"))
            {
                output = false;
            }


            return output;
        }

        private void ResetWindow()
        {
            customerNameTextBox.Text = "";
            customerPhoneNumberTextBox.Text = "";
            customerAddressTextBox.Text = "";
            customerEmailTextBox.Text = "";
            customerCvrTextBox.Text = "";
        }
    }
}
