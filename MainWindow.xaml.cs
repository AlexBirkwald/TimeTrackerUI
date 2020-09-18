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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TimeTrackerLibrary.GlobalConfig.InitializeConnection();
            Main.Content = new MainPage();
        }

        private void MainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MainPage();
        }

        private void TimeRegistrationsButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TimeRegistrationsPage();
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ReportsPage();
        }

        private void ManageTasksCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ManageTaskCustomerPage();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SettingsPage();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
