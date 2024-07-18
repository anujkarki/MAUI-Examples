namespace WebAuthenticatorMobile
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                try
                {
                    WebAuthenticatorResult authResult = await WebAuthenticator.Default.AuthenticateAsync(
                        new Uri("http://asptest.runasp.net/Authenticate/Google"),
                        new Uri("webauthenticatormobile://"));

                    string accessToken = authResult?.AccessToken;

                    await DisplayAlert("Access Token", accessToken, "Ok");
                    // Do something with the token
                }
                catch (TaskCanceledException e)
                {
                    // Use stopped auth
                }
            });
        }
    }

}
