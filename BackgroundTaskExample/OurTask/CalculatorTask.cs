using System;
using Windows.ApplicationModel.Background;
using Windows.Storage;

namespace OurTask
{
    public sealed class CalculatorTask: IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            //Support for async task executions. 
            var deferral = taskInstance.GetDeferral();

            //Generate random numbers.
            int a = new Random().Next();
            int b = new Random().Next();

            //Sum them.
            int sum = a + b;

            ApplicationDataContainer localSettings
                = ApplicationData.Current.LocalSettings;

            //Store the result in ApplicationSettings.
            localSettings.Values["a"] = a;
            localSettings.Values["b"] = b;
            localSettings.Values["result"] = sum;

            localSettings.Values["time"] = DateTime.Now.ToString();
            
            deferral.Complete();
        }
    }
}
