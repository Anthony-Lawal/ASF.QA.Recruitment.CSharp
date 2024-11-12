namespace Application.Interfaces;

public interface ITimeApiService
{
    Task<DateTimeOffset> GetDateTimeAsync(string timezone);
}