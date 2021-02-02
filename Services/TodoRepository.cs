using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }
        public async Task AddItem(ItemData item)
        {
            var itemAdd = await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteItem(int id)
        {
            var findItem =await GetItemById(id);
            if (findItem != null)
            {
                _context.Items.Remove(findItem);
               await _context.SaveChangesAsync();
               return true;
            }
           return false;
        }

        public async Task EditItem(int id, ItemData item)
        {
            var result =await GetItemById(id);
            if (result != null)
            {
                result.Title = item.Title;
                result.Description = item.Description;
                result.Done = item.Done;
                _context.Items.Update(result);
               await _context.SaveChangesAsync();
                
            }
            
        }

        public async Task<IEnumerable<ItemData>> GetAllItems() => await _context.Items.ToListAsync();

        public async Task<ItemData> GetItemById(int id) =>await _context.Items.FirstOrDefaultAsync(c => c.Id == id);


    }
}