namespace Logger;
#nullable enable
public class LogFactory
{
    private string? _filePath;
    public void configureFileLogger(string filePath){
        _filePath = filePath;
    }

    /*
    not sure what was meant by "the name of the class that created the logger" but based on this provided arg it can only mean any class that uses a LogFactory to make the logger
    otherwise it's inclusion in the base provided code wouldn't make sense, even though this is the class that creates the logger.
    */
    public BaseLogger? CreateLogger(string className) 
    {
        if(_filePath == null) return null;

        BaseLogger logger = new FileLogger(_filePath){
            ClassName = className
        };

        return logger;
    }
}
