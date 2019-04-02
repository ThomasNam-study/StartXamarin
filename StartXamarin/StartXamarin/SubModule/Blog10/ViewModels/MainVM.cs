using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using StartXamarin.SubModule.Blog10.Models;

namespace StartXamarin.SubModule.Blog10.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;

        private string query;

        private Venue selectedVenue;

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
    }
}
