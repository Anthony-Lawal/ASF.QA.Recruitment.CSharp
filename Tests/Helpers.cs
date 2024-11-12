using Application;

namespace Tests;

public class Helpers
{
    public string CapturedStdOut(Action callback)
    {
        var originalStdOut = Console.Out;

        using var newStdOut = new StringWriter();
        Console.SetOut(newStdOut);

        callback.Invoke();
        var capturedOutput = newStdOut.ToString();

        Console.SetOut(originalStdOut);

        return capturedOutput;
    }

    public void RunApp()
    {
        var entryPoint = typeof(Program).Assembly.EntryPoint!;
        entryPoint.Invoke(null, new object[] { Array.Empty<string>() });
    }
}