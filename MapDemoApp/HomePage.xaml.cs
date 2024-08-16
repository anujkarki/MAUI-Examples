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
        MapView.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        MapView.PinClicked += OnPinClicked;
        MapView.MapClicked += OnMapClicked;
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

    private void OnPinClicked(object sender, PinClickedEventArgs e)
    {
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