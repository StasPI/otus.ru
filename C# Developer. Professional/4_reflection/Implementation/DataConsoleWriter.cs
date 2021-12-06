using Abstraction;
using System.Diagnostics;

namespace Implementation;

public class DataConsoleWriter : IDataWriter
{
    public virtual void Write(string text)
    {
        Console.WriteLine(text);
    }

    public virtual void Write(int number)
    {
        Console.WriteLine(number);
    }

    public virtual void Write(Stopwatch stopWatch)
    {
        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("RunTime " + elapsedTime);
        Console.ResetColor();
    }
}