using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StartXamarin.SubModule.Blog10
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TenBlogPage : ContentPage
	{
		public TenBlogPage ()
		{
			InitializeComponent ();
		}

	    private void SayHello_OnClicked (object sender, EventArgs e)
	    {
	        if (!string.IsNullOrWhiteSpace (nameEntry.Text))
	        {
	            greetingLabel.Text = $"Hello {nameEntry.Text}, welcome to 10 Days";
	        }
	        else
	        {
	            DisplayAlert ("Error", "Your name can't be empry", "Oh Right");
	        }
	    }

	    private async void TwoDayStart_OnClicked (object sender, EventArgs e)
	    {
	        await Navigation.PushAsync (new TenBlog2Page ());
	    }


	    private async void FiveDayStart_OnClicked (object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new TenBlogList());
        }
	}
}