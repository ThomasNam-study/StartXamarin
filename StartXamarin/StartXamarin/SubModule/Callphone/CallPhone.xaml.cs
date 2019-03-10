using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StartXamarin.SubModule.Callphone
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CallPhone : ContentPage
	{
		private int count = 0;

		private string translatedNumber;

		public CallPhone ()
		{
			InitializeComponent ();
		}

		private void Button_OnClicked (object sender, EventArgs e)
		{
			count++;

			((Button)sender).Text = $"You Clicked {count} times.";
		}

		private void onTranslate (object sender, EventArgs e)
		{
			translatedNumber = PhonewordTranslator.ToNumber (phoneNumberText.Text);

			if (!string.IsNullOrWhiteSpace (translatedNumber))
			{
				callButton.IsEnabled = true;
				callButton.Text = "Call " + translatedNumber;
			}
			else
			{
				callButton.IsEnabled = false;
				callButton.Text = "Call";
			}
		}

		async private void OnCall (object sender, EventArgs e)
		{
			if (await this.DisplayAlert ("Dial a Number", "Word you like to call " + translatedNumber + "?", "Yes",
				"No"))
			{
				var dialer = DependencyService.Get<IDialer> ();

				if (dialer != null)
				{
					App.PhoneNumbers.Add (translatedNumber);
					callButtonHistory.IsEnabled = true;
					dialer.Dial (translatedNumber);
				}
			}
		}

		async private void CallButtonHistory_OnClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new CallHistoryPage ());
		}
	}
}