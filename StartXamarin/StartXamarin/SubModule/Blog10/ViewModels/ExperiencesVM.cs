using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using StartXamarin.SubModule.Blog10.Commands;
using StartXamarin.SubModule.Blog10.Models;

namespace StartXamarin.SubModule.Blog10.ViewModels
{
    public class ExperiencesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public NewExperienceCommand NewExperienceCommand { get; set; }

        public ObservableCollection<Experience> Experiences { get; set; }

        public ExperiencesVM()
        {
            NewExperienceCommand = new NewExperienceCommand(this);

            Experiences = new ObservableCollection<Experience>();
            ReadExperiences();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NewExperience()
        {
            App.Current.MainPage.Navigation.PushAsync(new TenBlog2Page());
        }

        public void ReadExperiences()
        {
            // added using TenDaysOfXamarin.Model;
            var experiences = Experience.GetExperiences();

            Experiences.Clear();

            foreach (var experience in experiences)
            {
                Experiences.Add(experience);
            }
        }
    }
}
