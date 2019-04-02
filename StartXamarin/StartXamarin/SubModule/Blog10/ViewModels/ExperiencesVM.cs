using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using StartXamarin.SubModule.Blog10.Commands;

namespace StartXamarin.SubModule.Blog10.ViewModels
{
    public class ExperiencesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public NewExperienceCommand NewExperienceCommand { get; set; }

        public ExperiencesVM()
        {
            NewExperienceCommand = new NewExperienceCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NewExperience()
        {
            App.Current.MainPage.Navigation.PushAsync(new TenBlog2Page());
        }
    }
}
