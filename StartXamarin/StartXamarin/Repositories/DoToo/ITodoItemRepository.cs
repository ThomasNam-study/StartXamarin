using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StartXamarin.Models.DoToo;

namespace StartXamarin.Repositories.DoToo
{
    public interface ITodoItemRepository
    {
        event EventHandler<TodoItem> OnItemAdded;
        event EventHandler<TodoItem> OnItemUpdated;

        Task<List<TodoItem>> GetItems();
        Task AddItem(TodoItem item);
        Task UpdateItem(TodoItem item);
        Task AddOrUpdate(TodoItem item);
    }
}
