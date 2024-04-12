using System;

namespace Logger;

public static class BaseLoggerMixins
{
    #nullable enable
    public static void Error(this BaseLogger? baseLogger, string message, params object[] args)
    {
        Helper(baseLogger, LogLevel.Error, message, args);
    }

    public static void Warning(this BaseLogger? baseLogger, string message, params object[] args)
    {
        Helper(baseLogger, LogLevel.Warning, message, args);
    }

    public static void Information(this BaseLogger? baseLogger, string message, params object[] args)
    {
        Helper(baseLogger, LogLevel.Information, message, args);
    }

    public static void Debug(this BaseLogger? baseLogger, string message, params object[] args)
    {
        Helper(baseLogger, LogLevel.Debug, message, args);
    }

    private static void Helper(this BaseLogger? baseLogger, LogLevel logLevel, string message, object[] args){
       if(baseLogger == null){
            throw new ArgumentNullException();
        }
        string formattedMessage = string.Format(message, args);
        baseLogger.Log(logLevel, formattedMessage);
    }
}
