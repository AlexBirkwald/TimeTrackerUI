using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using TimeTrackerLibrary;
using TimeTrackerLibrary.Models;

namespace TimeTrackerUI
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
       

        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        

       
        public string timeStart = "";
        public string timeStop = "";
      
       


        private List<TaskModel> existingTasks = GlobalConfig.Connection.Tasks_GetAll();
        private List<CustomerModel> existingCustomers = GlobalConfig.Connection.Customer_GetAll();
       


        public MainPage()
        {
            InitializeComponent();
            WireUpLists();
            dt.Tick += new EventHandler(TickCounter);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);

         

        }

        private void WireUpLists()
        {
            TaskComboBox.ItemsSource = existingTasks;
            TaskComboBox.DisplayMemberPath = "Name";

            CustomerComboBox.ItemsSource = existingCustomers;
            CustomerComboBox.DisplayMemberPath = "Name";

        }


        void TickCounter(object sender, EventArgs e)
        {
            if(sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;

                if(ts.Seconds < 10)
                {
                    secondCounter.Content = "0" + ts.Seconds;
                }
                if(ts.Seconds >= 10)
                {
                    secondCounter.Content = ts.Seconds;
                }
                
                if(ts.Minutes < 10)
                {
                    minuteCounter.Content = "0" + ts.Minutes;
                }
                if(ts.Minutes >= 10)
                {
                    minuteCounter.Content = ts.Minutes;
                }
                
                if(ts.Hours < 10)
                {
                    hourCounter.Content = "0" + ts.Hours;
                }
                if(ts.Hours >= 10)
                {
                    hourCounter.Content = ts.Hours;
                }
               
            }
        }



        private void StartTimer_Click(object sender, RoutedEventArgs e)
        {           
            sw.Start();
            dt.Start();

            if (StartTimer.Content.ToString() == "Start")
            {
                timeStart = TimeStampNow();
            }

            StartTimer.Content = "Running";
            StopTimer.Content = "Pause";


        }



        private void StopTimer_Click(object sender, RoutedEventArgs e)
        {
            
            if (sw.IsRunning)
            {
                PauseTimer();
            }
            else
            if(!sw.IsRunning)
            {
                timeStop = TimeStampNow();

                if (ValidateRegistration())
                {
                    TimeRegistrationModel model = CollectModel();

                    ResetFields();

                    sw.Reset();

                    RegistrationSumaryWindow rsw = new RegistrationSumaryWindow(model);
                    rsw.Show();
                }
                else
                {
                    MessageBox.Show("All fields must be filled. Make sure you have chosen a customer and task");
                }


            }

        }



        private string TimeStampNow()
        {            
            return DateTime.UtcNow.ToLocalTime().ToString();            
        }
        

        private string CombineTime()
        {
            string output = $"{ hourCounter.Content }:{ minuteCounter.Content }:{ secondCounter.Content }";
            return output;           
        }


        private void ResetFields()
        {
            hourCounter.Content = "00";
            minuteCounter.Content = "00";
            secondCounter.Content = "00";
            StartTimer.Content = "Start";
            StopTimer.Content = "Pause";
        }


        private void PauseTimer()
        {
            sw.Stop();
            StopTimer.Content = "Finish";
            StartTimer.Content = "Continue";
        }

        private TimeRegistrationModel CollectModel()
        {
            TimeRegistrationModel model = new TimeRegistrationModel();            
            model.TimeElapsed = CombineTime();
            model.TimeStart = timeStart;
            model.TimeStop = timeStop;
            model.Customer = (CustomerModel)CustomerComboBox.SelectedItem;
            model.Task = (TaskModel)TaskComboBox.SelectedItem;        
            return model;
        }


        private bool ValidateRegistration()
        {
            bool output = true;

            if(CombineTime() == null)
            {
                output = false;
            }

            if(CustomerComboBox.SelectedItem == null)
            {
                output = false;
            }

            if(TaskComboBox.SelectedItem == null)
            {
                output = false;
            }

            return output;
        }
    }
}
