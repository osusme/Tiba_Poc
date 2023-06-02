using System.Globalization;
using FlexiStorageManager.Application.Common.Interfaces;
using FlexiStorageManager.Application.TodoLists.Queries.ExportTodos;
using FlexiStorageManager.Infrastructure.Files.Maps;
using CsvHelper;

namespace FlexiStorageManager.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
