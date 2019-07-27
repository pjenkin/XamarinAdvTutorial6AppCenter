using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Finance.View;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Finance
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            // AppCenter error & crash tracking
            String androidAppSecret = "cf4318d5-9216-42d3-b3ed-ec25ffc0f5a0";
            String iOSAppSecret = "fb52859f-4e47-46e3-9bb8-4bc442980e65";
            // UWP secret would be needed too
            AppCenter.Start($"android={androidAppSecret}; iOS={iOSAppSecret}", typeof(Crashes));
            // Start with Crashes service started
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
