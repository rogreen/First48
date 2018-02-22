using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using First48.Models;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

namespace First48.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            //Cause a crash
            //Crashes.GenerateTestCrash();
            Analytics.TrackEvent("New item",
                new Dictionary<string, string> {
                    { "Day", DateTime.Today.ToShortDateString() },
                    { "Time", DateTime.Today.ToShortTimeString() }
                });

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //Cause a crash
            //Crashes.GenerateTestCrash();
            Analytics.TrackEvent("New item saved",
                new Dictionary<string, string> {
                    { "Day", DateTime.Today.ToShortDateString() },
                    { "Time", DateTime.Today.ToShortTimeString() }
                });

            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}