namespace Logger;

public abstract class BaseLogger(string className)
{
    public string ClassName { get; } = className;
    public abstract void Log(LogLevel logLevel, string message);
}

