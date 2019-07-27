using System;
using System.Collections.Generic;
using Finance.Model;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace Finance.View
{
    public partial class PostPage : ContentPage
    {
        public PostPage()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
        }

        public PostPage(Item item)
        {
            InitializeComponent();
            try
            {
                //throw (new Exception("Unable to load RSS"));        // illustrate App Center tracking by throwing exception (inside try/catch)
                //Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);

                webView.Source = item.ItemLink;
                var properties = new Dictionary<string, string>    // crash diagnostics dictionary string for key, string for value
                {
                    {"RSS_Post", $"{item.Title}" }                  // give further info - current item's title
                };

                TrackEvent(properties);                             // DRY tracking call

            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>    // crash diagnostics dictionary string for key, string for value
                {
                    {"RSS_Post", $"{item.Title}" }                  // give further info - current item's title
                };
                // Crashes.TrackError(ex);                  // can track by exception only
                Crashes.TrackError(ex, properties);       // dictionary (2nd) argument optional

            }
        }

        // bespoke method to send analytics/tracking to App Center

        private async void TrackEvent(IDictionary<string, string> properties)
        {

            if (await Analytics.IsEnabledAsync())       // check first whether tracking is actually enabled
            {
                // Analytics.TrackEvent("Blog_Post_Opened");   // can use 1 argument only
                Analytics.TrackEvent("Blog_Post_Opened", properties);

            }
        }
    }
}
