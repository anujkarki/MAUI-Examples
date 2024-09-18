using Mapsui.Projections;
using Mapsui.Tiling;
using Mapsui.UI.Maui;
using Mapsui;
using Mapsui.Extensions;

namespace MapDemoApp;

public partial class HomePage : ContentPage
{
    private Pin _selectedPin;
    public HomePage()
    {
        InitializeComponent();
        InitializeMap();
    }

    private void InitializeMap()
    {
        // Example coordinates (latitude and longitude)
        double latitude = 27.6915; // Replace with your latitude
        double longitude = 85.3420; // Replace with your longitude

        // Create the map and set a tile layer (OpenStreetMap in this case)
        var map = new Mapsui.Map
        {
            CRS = "EPSG:3857" // Web Mercator projection
        };
        map.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());

        // Convert latitude and longitude to Mapsui's Point object
        var location = SphericalMercator.FromLonLat(longitude, latitude);

        //var nva = new Navigator().CenterOn(longitude, latitude);

        map.Home = n => n.CenterOn(location.x, location.y);

        MapView.Map = map;

        MapView.MapClicked += OnMapClicked;
        MapView.PinClicked += OnPinClicked;
    }

    private void OnMapClicked(object sender, MapClickedEventArgs e)
    {
        var position = e.Point;
        if (_selectedPin != null)
            MapView.Pins.Remove(_selectedPin);

        _selectedPin = new Pin(MapView)
        {
            Position = position,
            Label = "Selected Location",
            Color = Colors.Red,
            Type = PinType.Pin
        };
        MapView.Pins.Add(_selectedPin);
    }

    private async void OnPinClicked(object sender, PinClickedEventArgs e)
    {
        var item = MapView.Map.Navigator.Resolutions;
        string message = "Resolution is: " + MapView.Map.Navigator.Resolutions.FirstOrDefault().ToString();
        await DisplayAlert("Message", message, "ok");
        // You can add custom behavior when a pin is clicked
    }

    private async void OnSelectLocationClicked(object sender, EventArgs e)
    {
        if (_selectedPin != null)
        {
            var selectedPosition = _selectedPin.Position;
            await DisplayAlert("Selected Location",
                $"Latitude: {selectedPosition.Latitude}, Longitude: {selectedPosition.Longitude}",
                "OK");
            // Here you can save or use the selected location
        }
        else
        {
            await DisplayAlert("No Location Selected", "Please select a location on the map", "OK");
        }
    }
}