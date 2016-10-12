using System;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace MyMaps
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private Geolocator geolocator;
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            geolocator = new Geolocator();
            geolocator.MovementThreshold = 100;
            //geolocator.PositionChanged += geolocator_PositionChanged;

            MyMap.Drop += MyMap_Drop;
        }

        void MyMap_Drop(object sender, DragEventArgs e)
        {
            MapIcon mapIcon = new MapIcon();
            Geopoint mypoint; 
            //MyMap.GetLocationFromOffset()
        }

        

       


        void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {

            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MyMap.Center = new Geopoint(new BasicGeoposition()
                {
                    Latitude = args.Position.Coordinate.Latitude,
                    Longitude = args.Position.Coordinate.Longitude,
                });
            });
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

        private async void  Page_Loaded(object sender, RoutedEventArgs e)
        {
            Geopoint centerGeopoint  = new Geopoint(new BasicGeoposition(){Latitude = -1.2,Longitude = 36.7},0);
            MyMap.Center = centerGeopoint;
            MyMap.ZoomLevel = 6;

            //Adding map Elements. 
            // Map Icon.
            MapIcon mapIcon = new MapIcon();
            mapIcon.Location = centerGeopoint; // Set it to the center of the map
            mapIcon.Title = "Center";
            mapIcon.Image=   
                RandomAccessStreamReference
                .CreateFromUri(new Uri("ms-appx:///Assets/marker.png"));


            MyMap.MapElements.Add(mapIcon);

            //Gettting the location without using the location changed events. 
            Geoposition gpsPosition = await geolocator.GetGeopositionAsync(); 

              MyMap.Center = new Geopoint(new BasicGeoposition()
                {
                    Latitude = gpsPosition.Coordinate.Latitude,
                    Longitude = gpsPosition.Coordinate.Longitude,
                });


           
        }
    }
}
