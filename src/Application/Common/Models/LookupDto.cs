using FlexiStorageManager.Application.Common.Mappings;
using FlexiStorageManager.Domain.Entities;

namespace FlexiStorageManager.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
