using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using StartXamarin.SubModule.Blog10.Models;
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
	        Experience newExp = new Experience ()
	        {
                Title = titleEntry.Text,
                Content = contentEditor.Text,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
	        };

	        int insertedItems = 0;

	        using (SQLiteConnection conn = new SQLiteConnection (App.DatabasePath))
	        {
	            conn.CreateTable<Experience> ();
	            insertedItems = conn.Insert (newExp);
	        }

	        if (insertedItems > 0)
	        {
	            titleEntry.Text = "";
	            contentEditor.Text = "";
            }
	        else
	        {
	            DisplayAlert ("Error", "There was an error inserting the Experience", "Please try again", "OK");
	        }
	    }

	    private async void Cancel_OnClicked (object sender, EventArgs e)
	    {
	        await Navigation.PopAsync (true);
	    }
	}
}