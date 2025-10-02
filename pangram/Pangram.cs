using System.Text;

public static class Pangram

{
    public static bool IsPangram(string input)
    {
        if (string.IsNullOrEmpty(input)) return false;

        return input
            .ToLower()                  
            .Where(char.IsLetter)
            .Distinct()
            .Count() == 26;     
    }

}
