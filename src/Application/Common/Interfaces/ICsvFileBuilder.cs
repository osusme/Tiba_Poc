using FlexiStorageManager.Application.TodoLists.Queries.ExportTodos;

namespace FlexiStorageManager.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
