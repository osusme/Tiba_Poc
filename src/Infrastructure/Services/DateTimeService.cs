using FlexiStorageManager.Application.Common.Interfaces;

namespace FlexiStorageManager.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
