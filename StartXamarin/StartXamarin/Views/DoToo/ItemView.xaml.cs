using StartXamarin.ViewModels.DoToo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StartXamarin.Views.DoToo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemView : ContentPage
	{
		public ItemView (ItemViewModel viewmodel)
		{
			InitializeComponent ();
            viewmodel.Navigation = Navigation;
            BindingContext = viewmodel;
        }
	}
}