using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApplication_WebAPI_Blazor.Server.Data;

namespace ToDoApplication_WebAPI_Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TodoItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItems()
        {
            var todoItems = await _db.TodoItems.ToListAsync();
            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetSingleTodoItem(int id)
        {
            var todoItem = await _db.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (todoItem == null)
            {
                return NotFound("Sorry, there is not To Do Item");
            }
            return Ok(todoItem);
        }

        [HttpPost]
        public async Task<ActionResult<List<TodoItem>>> CreateTodoItem(TodoItem todoItem)
        {
            _db.TodoItems.Add(todoItem);
            await _db.SaveChangesAsync();

            return Ok(await GetDbTodoItems());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TodoItem>>> UpdateTodoItem(TodoItem todoItem, int id)
        {
            var dbTodoItem = await _db.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            if(dbTodoItem == null)
            {
                return NotFound("Sorry, there is not To Do Item");
            }

            dbTodoItem.Name = todoItem.Name;
            dbTodoItem.Description = todoItem.Description;
            dbTodoItem.DateAndTime = todoItem.DateAndTime;
            dbTodoItem.Priority = todoItem.Priority;
            dbTodoItem.isDone = todoItem.isDone;

            await _db.SaveChangesAsync();

            return Ok(await GetDbTodoItems());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TodoItem>>> UpdateTodoItem(TodoItem todoItem, int id)
        {
            var dbTodoItem = await _db.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (dbTodoItem == null)
            {
                return NotFound("Sorry, there is not To Do Item");
            }

            dbTodoItem.Name = todoItem.Name;
            dbTodoItem.Description = todoItem.Description;
            dbTodoItem.DateAndTime = todoItem.DateAndTime;
            dbTodoItem.Priority = todoItem.Priority;
            dbTodoItem.isDone = todoItem.isDone;

            await _db.SaveChangesAsync();

            return Ok(await GetDbTodoItems());
        }

        private async Task<List<TodoItem>> GetDbTodoItems()
        {
            return await _db.TodoItems.ToListAsync();
        }
    }
}
