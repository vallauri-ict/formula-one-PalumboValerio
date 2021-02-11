using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/ToDoItems")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoItemsController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemDTO>>> GetToDoItems() {
            return await _context.TodoItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemDTO>> GetToDoItem(long id) {
            var ToDoItem = await _context.TodoItems.FindAsync(id);

            if (ToDoItem == null) {
                return NotFound();
            }

            return ItemToDTO(ToDoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoItem(long id, ToDoItemDTO ToDoItemDTO) {
            if (id != ToDoItemDTO.Id) {
                return BadRequest();
            }

            var ToDoItem = await _context.TodoItems.FindAsync(id);
            if (ToDoItem == null) {
                return NotFound();
            }

            ToDoItem.Name = ToDoItemDTO.Name;
            ToDoItem.IsComplete = ToDoItemDTO.IsComplete;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ToDoItemExists(id)) {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemDTO>> CreateToDoItem(ToDoItemDTO ToDoItemDTO) {
            var ToDoItem = new ToDoItem {
                IsComplete = ToDoItemDTO.IsComplete,
                Name = ToDoItemDTO.Name
            };

            _context.TodoItems.Add(ToDoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetToDoItem),
                new { id = ToDoItem.Id },
                ItemToDTO(ToDoItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(long id) {
            var ToDoItem = await _context.TodoItems.FindAsync(id);

            if (ToDoItem == null) {
                return NotFound();
            }

            _context.TodoItems.Remove(ToDoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoItemExists(long id) =>
             _context.TodoItems.Any(e => e.Id == id);

        private static ToDoItemDTO ItemToDTO(ToDoItem ToDoItem) =>
            new ToDoItemDTO {
                Id = ToDoItem.Id,
                Name = ToDoItem.Name,
                IsComplete = ToDoItem.IsComplete
            };
    }
}
