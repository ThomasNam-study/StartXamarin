using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartXamarin.SubModule.Swiper.Control;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StartXamarin.SubModule.Swiper
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Swiper : ContentPage
	{
		public Swiper ()
		{
			InitializeComponent ();

			AddInitialPhotos ();
		}

		private int _likeCount;
		private int _denyCount;

		private void UpdateGui ()
		{
			likeLabel.Text = _likeCount.ToString ();
			denyLabel.Text = _denyCount.ToString ();
		}

		private void Handle_OnLike (object sender, EventArgs e)
		{
			_likeCount++;
			InsertPhoto ();
			UpdateGui ();
		}

		private void Handle_OnDeny (object sender, EventArgs e)
		{
			_denyCount++;
			InsertPhoto ();
			UpdateGui ();
		}

		private void AddInitialPhotos ()
		{
			for (int i = 0; i < 10; i++)
			{
				InsertPhoto ();
			}
		}
		private void InsertPhoto ()
		{
			var photo = new SwiperControl ();

			photo.OnDeny += Handle_OnDeny;
			photo.OnLike += Handle_OnLike;

			this.MainGrid.Children.Insert (0, photo);
		}
	}
}