using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StartXamarin.SubModule.Blog10.ViewModels
{
    public class ExperiencesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
