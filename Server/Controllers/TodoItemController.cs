using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApplication_WebAPI_Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        public static List<TodoItem> todoItems = new List<TodoItem> {
            new TodoItem { Id=1, Name="Thesis", Description="Final the final thesis", DateAndTime=DateTime.Now, Priority="Medium", isDone=false },
            new TodoItem { Id=2, Name="Final", Description="Final the FEE", DateAndTime=DateTime.Now, Priority="High", isDone=false },
        };

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItems()
        {
            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TodoItem>>> GetSingleTodoItem(int id)
        {
            var todoItem = todoItems.FirstOrDefault(x => x.Id == id);

            if(todoItem == null)
            {
                return NotFound("Sorry, there is not To Do Item");
            }
            return Ok(todoItem);
        }
    }
}
