using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error (this BaseLogger logger, string message, params string[] data)
    {
        ArgumentNullException.ThrowIfNull(logger);
        logger.Log(LogLevel.Error, string.Format(message, data));
    }

}
