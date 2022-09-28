namespace ToDoApplication_WebAPI_Blazor.Client.Services.TodoItemService
{
    public interface ITodoItemService
    {
        List<TodoItem> TodoItems { get; set; }

        Task GetTodoItems();

        Task GetSingleTodoItem(int id);
    }
}
