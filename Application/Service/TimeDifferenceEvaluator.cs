using Application.Interfaces;

namespace Application.Service;

public class TimeDifferenceEvaluator
{
    private readonly string _dateTimeFormatter = "dddd dd MMMM yyyy HH:mm:ss";
    private readonly ITimeApiService _timeService;

    public TimeDifferenceEvaluator(ITimeApiService timeService)
    {
        _timeService = timeService;
    }

    public DateTimeOffset? CanadaDateTime { get; private set; }
    public DateTimeOffset? UkDateTime { get; private set; }

    public async Task<string> DisplayTimeDifference(string ukTimezone, string canadaTimezone)
    {
        await SetDateTime(ukTimezone, canadaTimezone);

        var timeDifferenceMessage = GetTimeDifferenceMessage(UkDateTime.Value, CanadaDateTime.Value);
        var displayedMessage = $"UK Time: {FormatDateTime(UkDateTime.Value)}\nCanada Time: {FormatDateTime(CanadaDateTime.Value)}\n{timeDifferenceMessage}";
        Console.WriteLine(displayedMessage);

        return $"UK Time: {FormatDateTime(UkDateTime.Value)}\nCanada Time: {FormatDateTime(CanadaDateTime.Value)}\n{timeDifferenceMessage}";
    }

    public string FormatDateTime(DateTimeOffset dateTime)
    {
        return dateTime.ToString(_dateTimeFormatter);
    }

    public string GetTimeDifferenceMessage(DateTimeOffset ukDateTimeOffset, DateTimeOffset canadaDateTimeOffset)
    {
        var ukDateTime = ukDateTimeOffset.DateTime;
        var canadaDateTime = canadaDateTimeOffset.DateTime;

        if (ukDateTime > canadaDateTime)
        {
            var minutesAhead = Math.Round(ukDateTime.Subtract(canadaDateTime).TotalMinutes, 0);
            return $"UK is {minutesAhead} minutes ahead of Canada";
        }
        else
        {
            var minutesAhead = Math.Round(canadaDateTime.Subtract(ukDateTime).TotalMinutes, 0);
            return $"Canada is {minutesAhead} minutes ahead of the UK";
        }
    }

    public async Task SetDateTime(string ukTimezone, string canadaTimezone)
    {
        UkDateTime = await _timeService.GetDateTimeAsync(ukTimezone);
        CanadaDateTime = await _timeService.GetDateTimeAsync(canadaTimezone);
    }
}