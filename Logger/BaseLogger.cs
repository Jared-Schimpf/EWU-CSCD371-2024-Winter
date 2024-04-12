namespace Logger;
#nullable enable
public abstract class BaseLogger
{
    public string? ClassName{get; set;}
    public abstract void Log(LogLevel logLevel, string message);
}

