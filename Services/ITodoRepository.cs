using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Services
{
    public interface ITodoRepository
    {
         Task AddItem(ItemData item);
        Task<IEnumerable<ItemData>> GetAllItems();

        Task<ItemData> GetItemById(int id);

        Task EditItem(int id,ItemData item);

        Task<bool> DeleteItem(int id);
    }
}