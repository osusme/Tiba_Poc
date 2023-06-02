using FlexiStorageManager.Application.Common.Mappings;
using FlexiStorageManager.Domain.Entities;

namespace FlexiStorageManager.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
