using DineDash.Application.Common.Interfaces.Services;

namespace DineDash.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
