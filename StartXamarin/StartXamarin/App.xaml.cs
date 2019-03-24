using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace StartXamarin
{
	public partial class App : Application
	{
		public static IList<string> PhoneNumbers { get; set; }

	    public static string DatabasePath;

		public App (string databasePath)
		{
			InitializeComponent ();

		    DatabasePath = databasePath;

            PhoneNumbers = new List<string> ();

			MainPage = new NavigationPage(new MainPage ());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
