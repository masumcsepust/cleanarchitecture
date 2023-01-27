using cleanarchitecture.Application.Common.Interfaces.Services;

namespace cleanarchitecture.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}