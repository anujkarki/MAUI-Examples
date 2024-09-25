namespace NoInternetApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent(); 
        }

        private void btnCheckInternet_Clicked(object sender, EventArgs e)
        {
            _ = CheckInternetAccess();
        }

        async Task CheckInternetAccess()
        {
            string message = string.Empty;
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;

            if (accessType == NetworkAccess.Internet)
            {
                message = "Device has internet access";
            }
            else
            {
                message = "Device has no internet access";
            }
            var result = await DisplayAlert("Information!", message, "Close Application", "Okay");
            if (result)
            {
                Application.Current.Quit();
            }

        }
    }

}
