using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	public partial class TenBlogList : ContentPage
    {
        private readonly ExperiencesVM viewModel;

        public TenBlogList ()
		{
			InitializeComponent ();

            viewModel = new ExperiencesVM();

            BindingContext = viewModel;

        }

	    private async void NewItem_OnClicked (object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new TenBlog2Page());
        }

	    protected override void OnAppearing ()
	    {
	        base.OnAppearing ();

            viewModel.ReadExperiences();
	    }
	}
}