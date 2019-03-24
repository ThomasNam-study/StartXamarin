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
	public partial class TenBlog2Page : ContentPage
	{
		public TenBlog2Page ()
		{
			InitializeComponent ();
		}

	    private void CheckIfShouldBeEnabled()
	    {
	        saveButton.IsEnabled = false;

	        if (!string.IsNullOrWhiteSpace (titleEntry.Text) && !string.IsNullOrWhiteSpace (contentEditor.Text))
	            saveButton.IsEnabled = true;
	    }

	    private void TitleEntry_OnTextChanged (object sender, TextChangedEventArgs e)
	    {
	        CheckIfShouldBeEnabled ();
	    }

	    private void ContentEditor_OnTextChanged (object sender, TextChangedEventArgs e)
	    {
	        CheckIfShouldBeEnabled ();
        }

	    private void SaveButton_OnClicked (object sender, EventArgs e)
	    {
	        titleEntry.Text = "";
	        contentEditor.Text = "";
	    }

	    private async void Cancel_OnClicked (object sender, EventArgs e)
	    {
	        await Navigation.PopAsync (true);
	    }
	}
}