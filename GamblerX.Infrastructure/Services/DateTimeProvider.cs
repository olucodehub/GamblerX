using GamblerX.Application.Common.Interfaces.Services;


namespace GamblerX.Infrastructure.Services;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

