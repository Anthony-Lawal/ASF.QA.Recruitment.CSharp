namespace Tests;

[TestClass]
public class Tests
{
    private readonly Helpers _helpers;

    public Tests()
    {
        _helpers = new Helpers();
    }

    [TestMethod]
    public void ExampleTest()
    {
        // Runs the app and returns the output from Console.WriteLine
        var capturedStdOut = _helpers.CapturedStdOut(_helpers.RunApp);

        // Run an assertion on the captured output
        Assert.IsTrue(capturedStdOut.Contains("UK Time"));
    }
}