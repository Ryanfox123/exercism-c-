static class LogLine
{
    public static string Message(string logLine)
    {
        int colonIndex = logLine.IndexOf(':');
        return logLine[(colonIndex+1)..].Trim();
    }

    public static string LogLevel(string logLine)
    {
        int startIndex = logLine.IndexOf('[') + 1;
        int endIndex = logLine.IndexOf(']');
        return logLine[startIndex..endIndex].ToLower();
        
    }

    public static string Reformat(string logLine)
    {
        string msg = Message(logLine);
        string log = LogLevel(logLine);

        return $"{msg} ({log})";
    }
}
