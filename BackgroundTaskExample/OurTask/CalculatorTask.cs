using System;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;

namespace OurTask
{
    public sealed class CalculatorTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            //Support for async task executions. 
            var deferral = taskInstance.GetDeferral();

            //Generate random numbers.
            var a = new Random().Next(0, 10);
            var b = new Random().Next(0, 10);

            //Sum them.
            var sum = a + b;

            var localSettings
                = ApplicationData.Current.LocalSettings;

            //Store the result in ApplicationSettings.
            localSettings.Values["a"] = a;
            localSettings.Values["b"] = b;
            localSettings.Values["result"] = sum;

            localSettings.Values["time"] = DateTime.Now.ToString();

            //Update Tile 
            UpdateTile();
            SendToast();

            deferral.Complete();
        }

        private void UpdateTile()
        {
            var tileDocument = new XmlDocument();
            var xml = @"<tile> " +
                      "<visual version=\"2\">" +
                      "<binding template=\"TileSquare150x150PeekImageAndText01\" fallback=\"TileSquarePeekImageAndText01\">" +
                      "<image id=\"1\" src=\"ms-appx:///Assets/Square150x150Logo.scale-240.png\"/>" +
                      "<text id=\"1\">This is my APP</text>" +
                      "<text id=\"2\">This app works.. try it out.</text>" +
                      " </binding>" +
                      " </visual>" +
                      "</tile>";

            tileDocument.LoadXml(xml);

            var tile = new TileNotification(tileDocument);

            var updater = TileUpdateManager
                .CreateTileUpdaterForApplication();

            updater.Update(tile);
        }


        void SendToast()
        {

            XmlDocument toastDocument = new XmlDocument();
            var xml = @"<toast> " +
                        "<visual>" +
                            "<binding template=\"ToastText02\" >" +
                                "<text id=\"1\">This is as toast</text>" +
                                "<text id=\"2\">This toast will launch an app</text>" +
                            " </binding>" +
                        " </visual>" +
                     "</toast>";

            toastDocument.LoadXml(xml);

            ToastNotification toastNotification = new ToastNotification(toastDocument);
            ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
        }
    }
}