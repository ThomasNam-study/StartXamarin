using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using SQLite;
using StartXamarin.SubModule.Blog10.Models;
using Xamarin.Forms;

namespace StartXamarin.SubModule.Blog10.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;

        private string query;

        private Venue selectedVenue;

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
                OnPropertyChanged("CanSave");
            }
        }

        public string Query
        {
            get => query;
            set
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        public Venue SelectedVenue
        {
            get => selectedVenue;
            set
            {
                selectedVenue = value;

                if (selectedVenue != null)
                {
                    ShowVenues = false;
                    Query = string.Empty;
                }
                OnPropertyChanged("SelectedVenue");
                OnPropertyChanged("ShowSelectedVenue");
            }
        }


        private string content;
        public string Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged("Content");
                OnPropertyChanged("CanSave");
            }
        }

        public bool CanSave
        {
            get { return !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Content); }
        }

        public bool ShowSelectedVenue
        {
            get { return SelectedVenue != null; }
        }

        private bool showVenues;
        public bool ShowVenues
        {
            get { return showVenues; }
            set
            {
                showVenues = value;
                OnPropertyChanged("ShowVenues");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainVM()
        {
            CancelCommand = new Command(CancelAction);

            SaveCommand = new Command<bool>(SaveAction, CanExecuteSave);
        }

        bool CanExecuteSave(bool arg)
        {
            return arg;
        }

        void SaveAction(bool obj)
        {
            Experience newExp = new Experience()
            {
                Title = Title,
                Content = Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                VenueName = SelectedVenue.name,
                VenueCategory = SelectedVenue.MainCategory,
                VenueLat = float.Parse(SelectedVenue.location.Coordinates.Split(',')[0]),
                VenueLng = float.Parse(SelectedVenue.location.Coordinates.Split(',')[1])
            };

            int insertedItems = 0;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Experience>();
                insertedItems = conn.Insert(newExp);
            }

            if (insertedItems > 0)
            {
                Title = string.Empty;
                Content = string.Empty;
                SelectedVenue = null;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "There was an error inserting the Experience", "Please try again", "OK");
            }
        }



        void CancelAction(object obj)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
