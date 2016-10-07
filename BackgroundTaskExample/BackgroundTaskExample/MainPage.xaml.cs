using System.Linq;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace BackgroundTaskExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private const string MyTask = "CalculatorTask";

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            CheckTask();
            GetTaskresult();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }



        /// <summary>
        /// This method checks if our task has already been registered..  if not it registers it. 
        /// </summary>
        void CheckTask()
        {
            var registration = BackgroundTaskRegistration.AllTasks.Values.FirstOrDefault(x => x.Name == MyTask);
            if (registration == null)
            {
                RegisterTask();
            }
            else
            {
                registration.Completed += taskRegistration_Completed;
            }
        }

      
        void RegisterTask()
        {
            //Specify the name of the bacground Task
            BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder
            {
                Name = MyTask
            };


            //Specify the Trigger. 
            var trigger = new SystemTrigger(SystemTriggerType.TimeZoneChange, false);
            taskBuilder.SetTrigger(trigger);

            //Specify the condition if available. 
            var condition = new SystemCondition(SystemConditionType.UserPresent);
            taskBuilder.AddCondition(condition);

            //Specify the entry point of the TASK. 
            taskBuilder.TaskEntryPoint = typeof (OurTask.CalculatorTask).Name;

            BackgroundTaskRegistration taskRegistration = taskBuilder.Register();
            taskRegistration.Completed += taskRegistration_Completed;

        }

        void taskRegistration_Completed(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
            GetTaskresult();
        }

        //Fetch values from AppSettings
        private void GetTaskresult()
        {
            ApplicationDataContainer localsettings = ApplicationData.Current.LocalSettings;

            if (localsettings.Values.Keys.Contains("result"))
            {

                int sum = (int)localsettings.Values["result"];
                int a = (int)localsettings.Values["a"];
                int b = (int)localsettings.Values["b"];
                string time = localsettings.Values["time"].ToString();

                tbResult.Text = string
                    .Format(
                    "The sum of {0} and {1} is {2}, task ran at {3}",a,b,sum,time
                    );

            }
        }

    }
}
