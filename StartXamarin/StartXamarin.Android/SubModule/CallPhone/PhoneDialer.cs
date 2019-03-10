using Android.Net;
using Android.Telephony;
using StartXamarin.Droid.SubModule.CallPhone;
using StartXamarin.SubModule.Callphone;
using System.Linq;
using Android.Content;
using Xamarin.Forms;

[assembly: Dependency (typeof (PhoneDialer))]
namespace StartXamarin.Droid.SubModule.CallPhone
{
	public class PhoneDialer : IDialer
	{
		public bool Dial (string number)
		{
			var context = MainActivity.Instance;
			if (context == null)
				return false;

			var intent = new Intent (Intent.ActionDial);
			intent.SetData (Uri.Parse ("tel:" + number));

			if (IsIntentAvailable (context, intent))
			{
				context.StartActivity (intent);
				return true;
			}

			return false;
		}

		public static bool IsIntentAvailable (Context context, Intent intent)
		{
			var packageManager = context.PackageManager;

			var list = packageManager.QueryIntentServices (intent, 0)
				.Union (packageManager.QueryIntentActivities (intent, 0));

			if (list.Any ())
				return true;

			var manager = TelephonyManager.FromContext (context);
			return manager.PhoneType != PhoneType.None;
		}
	}
}