using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using StartXamarin.SubModule.Blog10.ViewModels;

namespace StartXamarin.SubModule.Blog10.Commands
{
    public class NewExperienceCommand : ICommand
    {
        private ExperiencesVM viewModel;

        public NewExperienceCommand(ExperiencesVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.NewExperience();
        }

        public event EventHandler CanExecuteChanged;
    }
}
