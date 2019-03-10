using Foundation;
using StartXamarin.iOS.SubModule.CallPhone;
using StartXamarin.SubModule.Callphone;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency (typeof (PhoneDialer))]
namespace StartXamarin.iOS.SubModule.CallPhone
{
	public class PhoneDialer : IDialer
	{
		public bool Dial (string number)
		{
			return UIApplication.SharedApplication.OpenUrl (new NSUrl ("tel:" + number));
		}	
	}
}