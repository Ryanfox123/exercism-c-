public static class LogAnalysis
{

    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string marker)
    {
        int markerIndex = str.IndexOf(marker);
        return str[(markerIndex + marker.Length)..];
    }
    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string start, string end)
    {
        int startIndex = str.IndexOf(start);
        int endIndex = str.IndexOf(end);
        return str[(startIndex + start.Length)..endIndex];
    }
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }
    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}