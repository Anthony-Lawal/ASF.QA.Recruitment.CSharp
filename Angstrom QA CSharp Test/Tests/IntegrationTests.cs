using Application.Data;
using Application.Service;

namespace Tests;

[TestClass]
public class IntegrationTests
{
    private TimeDifferenceEvaluator _timeDifferenceEvaluator;

    [TestInitialize]
    public void Setup()
    {
        _timeDifferenceEvaluator = new TimeDifferenceEvaluator(new WorldTimeApiService(new HttpClient()));
    }

    [TestMethod]
    public async Task VerifyThatTheUserCanGetTimeFromService()
    {
        // Arrange
        var ukTimezone = ApplicationTimeZones.Uk;
        var canadaTimezone = ApplicationTimeZones.Canada;

        // Act
        await _timeDifferenceEvaluator.SetDateTime(ukTimezone, canadaTimezone);
        var isUkTimeValid = _timeDifferenceEvaluator.UkDateTime > DateTime.MinValue;
        var isCanadaTimeValid = _timeDifferenceEvaluator.CanadaDateTime > DateTime.MinValue;

        // Assert
        Assert.IsTrue(isUkTimeValid, $"Expected UK is not returned from the service. Returned time: {_timeDifferenceEvaluator.UkDateTime.ToString()}");
        Assert.IsTrue(isCanadaTimeValid, $"Expected UK is not returned from the service.Returned time: {_timeDifferenceEvaluator.UkDateTime.ToString()}");
    }
}