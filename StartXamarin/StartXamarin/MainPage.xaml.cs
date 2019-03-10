using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartXamarin.SubModule.Callphone;
using StartXamarin.Views.DoToo;
using Xamarin.Forms;
using Swiper = StartXamarin.SubModule.Swiper.Swiper;

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

		private async void DoToo_OnClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (Resolver.Resolve<MainView> ());
		}

		private async void Swiper_OnClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new SubModule.Swiper.Swiper ());
		}
	}
}
