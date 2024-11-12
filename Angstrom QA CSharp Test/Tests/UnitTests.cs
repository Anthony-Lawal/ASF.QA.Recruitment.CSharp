using System.Globalization;
using Application.Data;
using Application.Interfaces;
using Application.Service;
using Moq;

namespace Tests;

[TestClass]
public class UnitTests
{
    private Mock<ITimeApiService> _mockTimeService;
    private TimeDifferenceEvaluator _timeDifferenceEvaluator;

    [TestMethod]
    public void DisplayTimeDifferenceShouldReturnCorrectMessageWhenCanadaIsAheadOfUk()
    {
        var ukTime = new DateTimeOffset(2023, 1, 1, 5, 0, 0, TimeSpan.Zero);
        var canadaTime = new DateTimeOffset(2023, 1, 1, 12, 0, 0, TimeSpan.FromHours(-5));

        var result = _timeDifferenceEvaluator.GetTimeDifferenceMessage(ukTime, canadaTime);
        Assert.AreEqual("Canada is 420 minutes ahead of the UK", result);
    }

    [TestMethod]
    public async Task DisplayTimeDifferenceShouldReturnCorrectMessageWhenUkIsAheadOfCanada()
    {
        // Arrange
        var ukTime = new DateTimeOffset(2023, 1, 1, 12, 0, 0, TimeSpan.Zero);
        var canadaTime = new DateTimeOffset(2023, 1, 1, 7, 0, 0, TimeSpan.FromHours(-5));

        _mockTimeService.Setup(s => s.GetDateTimeAsync(ApplicationTimeZones.Uk)).ReturnsAsync(ukTime);
        _mockTimeService.Setup(s => s.GetDateTimeAsync(ApplicationTimeZones.Canada)).ReturnsAsync(canadaTime);

        // Act
        var response = await _timeDifferenceEvaluator.DisplayTimeDifference(ApplicationTimeZones.Uk, ApplicationTimeZones.Canada);

        // Assert
        var expectedMessage = $"UK Time: {ukTime.ToString("dddd dd MMMM yyyy HH:mm:ss")}\n" + $"Canada Time: {canadaTime.ToString("dddd dd MMMM yyyy HH:mm:ss")}\n" + "UK is 300 minutes ahead of Canada";
        Assert.AreEqual(expectedMessage, response);
    }

    [TestMethod]
    public void FormatDateTimeShouldReturnFormattedDateTime()
    {
        // Create a date in the wrong format
        var dateTime = DateTimeOffset.ParseExact("Sunday January 01 2023 17:00:00", "dddd MMMM dd yyyy HH:mm:ss", new CultureInfo("en-GB"));

        // Use the method to reformat the date
        var result = _timeDifferenceEvaluator.FormatDateTime(dateTime);

        // Verify that the date is in the right format
        Assert.AreEqual("Sunday 01 January 2023 17:00:00", result);
    }

    public void GetTimeDifferenceShouldReturnCorrect()
    {
        var ukTime = new DateTimeOffset(2023, 1, 1, 5, 0, 0, TimeSpan.Zero);
        var canadaTime = new DateTimeOffset(2023, 1, 1, 12, 0, 0, TimeSpan.FromHours(-5));

        var result = _timeDifferenceEvaluator.GetTimeDifferenceMessage(ukTime, canadaTime);
        Assert.AreEqual("Canada is 420 minutes ahead of the UK", result);
    }

    [TestInitialize]
    public void Setup()
    {
        _mockTimeService = new Mock<ITimeApiService>();
        _timeDifferenceEvaluator = new TimeDifferenceEvaluator(_mockTimeService.Object);
    }
}