﻿using System.Diagnostics;

namespace Abstraction;

public interface IDataWriter
{
    public void Write(string text);
    public void Write(int number);
    public void Write(Stopwatch stopWatch);
}