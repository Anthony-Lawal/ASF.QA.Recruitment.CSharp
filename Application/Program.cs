using Application.Service;
using AppTimeZone = Application.Data.ApplicationTimeZones;

namespace Application;

public class Program
{
    public static async Task Main(string[] args)
    {
        using HttpClient client = new();
        var timeService = new WorldTimeApiService(client);
        var evaluator = new TimeDifferenceEvaluator(timeService);
        await evaluator.DisplayTimeDifference(AppTimeZone.Uk, AppTimeZone.Canada);
    }
}