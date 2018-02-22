using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace First48.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
		public MainPage ()
		{
			InitializeComponent ();

            CheckForCrashes();
        }

        async void CheckForCrashes()
        {
            bool didAppCrash = await Crashes.HasCrashedInLastSessionAsync();
            if (didAppCrash)
            {
                await DisplayAlert("Oh snap!",
                    "Your app crashed. Would you like to uninstall it?", 
                    "Yah!", "No!");
            }
        }
    }
}