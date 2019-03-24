using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using StartXamarin.SubModule.Blog10.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StartXamarin.SubModule.Blog10
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TenBlog2Page : ContentPage
	{
	    Position position;

	    private IGeolocator locator = CrossGeolocator.Current;

        public TenBlog2Page ()
		{
			InitializeComponent ();

		    locator.PositionChanged += LocatorOnPositionChanged;
        }

	    private void LocatorOnPositionChanged(object sender, PositionEventArgs e)
	    {
	        position = e.Position;
	    }

        private void CheckIfShouldBeEnabled()
	    {
	        saveButton.IsEnabled = false;

	        if (!string.IsNullOrWhiteSpace (titleEntry.Text) && !string.IsNullOrWhiteSpace (contentEditor.Text))
	            saveButton.IsEnabled = true;
	    }

	    private void TitleEntry_OnTextChanged (object sender, TextChangedEventArgs e)
	    {
	        CheckIfShouldBeEnabled ();
	    }

	    private void ContentEditor_OnTextChanged (object sender, TextChangedEventArgs e)
	    {
	        CheckIfShouldBeEnabled ();
        }

	    protected override void OnAppearing ()
	    {
	        base.OnAppearing ();

	        GetLocationPermission();
        }

	    private void SaveButton_OnClicked (object sender, EventArgs e)
	    {
	        Experience newExp = new Experience ()
	        {
                Title = titleEntry.Text,
                Content = contentEditor.Text,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
	        };

	        int insertedItems = 0;

	        using (SQLiteConnection conn = new SQLiteConnection (App.DatabasePath))
	        {
	            conn.CreateTable<Experience> ();
	            insertedItems = conn.Insert (newExp);
	        }

	        if (insertedItems > 0)
	        {
	            titleEntry.Text = "";
	            contentEditor.Text = "";
            }
	        else
	        {
	            DisplayAlert ("Error", "There was an error inserting the Experience", "Please try again", "OK");
	        }
	    }

	    private async void Cancel_OnClicked (object sender, EventArgs e)
	    {
	        await Navigation.PopAsync (true);
	    }

	    private async void GetLocationPermission()
	    {
	        // added using Plugin.Permissions;
	        // added using Plugin.Permissions.Abstractions;
	        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
	        if (status != PermissionStatus.Granted)
	        {
	            // Not granted, request permission
	            await DisplayAlert("Need your permission", "We need to access your location", "OK");
	        }

	        // Already granted (maybe), go on
	        var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);

	        if (results.ContainsKey(Permission.LocationWhenInUse))
	            status = results[Permission.LocationWhenInUse];

	        // Already granted (maybe), go on
	        if (status == PermissionStatus.Granted)
	        {
	            // Granted! Get the location
	            GetLocation();

	        }
	        else
	        {
	            await DisplayAlert("Access to location denied", "We don't have access to your location", "Ok");
	        }
	    }

	    private async void GetLocation()
	    {
	        position = await locator.GetPositionAsync();

	        await locator.StartListeningAsync(TimeSpan.FromMinutes(30), 500);
	    }

	    protected override void OnDisappearing()
	    {
	        locator.StopListeningAsync();
	    }
    }
}