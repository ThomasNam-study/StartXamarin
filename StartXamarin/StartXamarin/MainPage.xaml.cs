using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartXamarin.SubModule.Callphone;
using Xamarin.Forms;

namespace StartXamarin
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		private async void CallPhone_OnClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new CallPhone ());
		}
	}
}
