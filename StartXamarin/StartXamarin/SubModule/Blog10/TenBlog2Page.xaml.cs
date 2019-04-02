using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using StartXamarin.SubModule.Blog10.Models;
using StartXamarin.SubModule.Blog10.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StartXamarin.SubModule.Blog10
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TenBlog2Page : ContentPage
	{
	    Position position;

	    private IGeolocator locator = CrossGeolocator.Current;

	    private MainVM viewModel;

        public TenBlog2Page ()
		{
			InitializeComponent ();

		    viewModel = new MainVM();

		    BindingContext = viewModel;


            locator.PositionChanged += LocatorOnPositionChanged;
        }

	    private void LocatorOnPositionChanged(object sender, PositionEventArgs e)
	    {
	        position = e.Position;
	    }

        private void CheckIfShouldBeEnabled()
	    {
	        saveButton.IsEnabled = false;

	        if (!string.IsNullOrWhiteSpace (viewModel.Title) && !string.IsNullOrWhiteSpace (viewModel.Content))
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

        /*
	    private void SaveButton_OnClicked (object sender, EventArgs e)
	    {
	        Experience newExp = new Experience ()
	        {
                Title = viewModel.Title,
                Content = viewModel.Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
	            VenueName = viewModel.SelectedVenue.name,
	            VenueCategory = viewModel.SelectedVenue.MainCategory,
	            VenueLat = float.Parse(viewModel.SelectedVenue.location.Coordinates.Split(',')[0]),
	            VenueLng = float.Parse(viewModel.SelectedVenue.location.Coordinates.Split(',')[1])
            };

	        int insertedItems = 0;

	        using (SQLiteConnection conn = new SQLiteConnection (App.DatabasePath))
	        {
	            conn.CreateTable<Experience> ();
	            insertedItems = conn.Insert (newExp);
	        }

	        if (insertedItems > 0)
	        {
	            viewModel.Title = string.Empty;
	            viewModel.Content = string.Empty;
	            viewModel.SelectedVenue = null;
            }
	        else
	        {
	            DisplayAlert ("Error", "There was an error inserting the Experience", "Please try again", "OK");
	        }
	    }
        */

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

            if (!locator.IsListening)
                await locator.StartListeningAsync(TimeSpan.FromMinutes(30), 500);
	    }

	    protected override void OnDisappearing()
	    {
	        locator.StopListeningAsync();
	    }

	    private async void SearchEntry_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        if (!string.IsNullOrWhiteSpace(searchEntry.Text))
	        {
	            //string url = $"https://api.foursquare.com/v2/venues/search?ll={position.Latitude},{position.Longitude}&radius=500&query={searchEntry.Text}&limit=3&client_id={Helpers.Constants.FOURSQR_CLIENT_ID}&client_secret={Helpers.Constants.FOURSQR_CLIENT_SECRET}&v={DateTime.Now.ToString("yyyyMMdd")}";
	            string url = $"https://api.foursquare.com/v2/venues/search?ll={position.Latitude},{position.Longitude}&radius=500&query={viewModel.Query}&limit=3&client_id={Helpers.Constants.FOURSQR_CLIENT_ID}&client_secret={Helpers.Constants.FOURSQR_CLIENT_SECRET}&v={DateTime.Now.ToString("yyyyMMdd")}";


                using (HttpClient client = new HttpClient())
	            {
	                string json = await client.GetStringAsync(url);

	                Search searchResult = JsonConvert.DeserializeObject<Search>(json);

	                venuesListView.IsVisible = true;
	                venuesListView.ItemsSource = searchResult.response.venues;

	            }
            }
            else
	        {
	            venuesListView.IsVisible = false;
	        }
	        
	    }

	    /*private void VenuesListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        if (venuesListView.SelectedItem != null)
	        {
	            selectedVenueStackLayout.IsVisible = true;
                viewModel.Query = string.Empty;
	            venuesListView.IsVisible = false;

                /*Venue selectedVenue = venuesListView.SelectedItem as Venue;

	            venueNameLabel.Text = selectedVenue.name;
                venueCategoryLabel.Text = selectedVenue.categories.FirstOrDefault()?.name;
	            venueCoordinatesLabel.Text = $"{selectedVenue.location.lat:0.000}, {selectedVenue.location.lng:0.000}";#1#
	        }
	        else
	        {
	            selectedVenueStackLayout.IsVisible = false;
	        }
	    }*/
	}
}