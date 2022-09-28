using System.Net.Http.Json;

namespace ToDoApplication_WebAPI_Blazor.Client.Services.TodoItemService
{
    public class TodoItemService : ITodoItemService
    {
        private readonly HttpClient _http;

        public TodoItemService(HttpClient http)
        {
            _http = http;
        }

        public List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();

        public Task GetSingleTodoItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetTodoItems()
        {
            var response = await _http.GetFromJsonAsync<List<TodoItem>>("api/todoItem");

            if(response != null)
            {
                TodoItems = response;
            }
        }
    }
}
