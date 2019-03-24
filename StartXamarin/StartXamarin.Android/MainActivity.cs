using System;
using System.IO;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Environment = System.Environment;

namespace StartXamarin.Droid
{
    [Activity(Label = "StartXamarin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
	    internal static MainActivity Instance { get; private set; }

		protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

	        Instance = this;

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
	        Bootstrapper.Init ();

	        CarouselViewRenderer.Init ();

            string fileName = "database.db3";

            string folderPath = System.Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);

            var fullPath = Path.Combine (folderPath, fileName);

            Xamarin.Essentials.Platform.Init (this, savedInstanceState);
			LoadApplication (new App(fullPath));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            // added using Plugin.Permissions;
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}