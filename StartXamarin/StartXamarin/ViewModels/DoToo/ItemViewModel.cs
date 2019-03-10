using System;
using System.Windows.Input;
using StartXamarin.Models.DoToo;
using StartXamarin.Repositories.DoToo;
using Xamarin.Forms;

namespace StartXamarin.ViewModels.DoToo
{
    public class ItemViewModel : ViewModel
    {
        private TodoItemRepository repository;

        public TodoItem Item { get; set; }

        public ItemViewModel(TodoItemRepository repository)
        {
            this.repository = repository;
            Item = new TodoItem() { Due = DateTime.Now.AddDays(1) };
        }

        public ICommand Save => new Command(async () =>
        {
            await repository.AddOrUpdate(Item);
            await Navigation.PopAsync();
        });
    }
}
