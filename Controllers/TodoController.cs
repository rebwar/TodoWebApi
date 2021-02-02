using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
           var result=await _repository.GetAllItems();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemData item)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddItem(item);
                return CreatedAtAction("GetItemById", new { item.Id }, item);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var result = await _repository.GetItemById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditeItem(int id, ItemData item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await _repository.EditItem(id, item);
                    return NoContent();

                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteItem(int id)
        {
            var result =await _repository.DeleteItem(id);
            if (result is true)
            {
                return Ok();

            }
            return NotFound();

        }


    }
}