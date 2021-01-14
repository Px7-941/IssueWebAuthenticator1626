using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LoginTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var callbackUrl = new Uri(AuthConfiguration.Callback);
                var loginUrl = new Uri(AuthConfiguration.AuthorizationEndpoint);

                var authenticationResult = await WebAuthenticator.AuthenticateAsync(loginUrl, callbackUrl);

                NameLabel.Text = authenticationResult.Get("code");
                LogoutButton.IsVisible = !(LoginButton.IsVisible = false);

            }
            catch (TaskCanceledException)
            {
                //User closed browser
            }
        }

        private void LogoutButtonClicked(object sender, EventArgs e)
        {
            NameLabel.Text = string.Empty;
            LogoutButton.IsVisible = !(LoginButton.IsVisible = true);
        }
    }
}
