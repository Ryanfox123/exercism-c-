using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < identifier.Length; i++)
        {
            char c = identifier[i];

            if (c == ' ')
            {
                sb.Append('_');
            }
            else if (char.IsControl(c))
            {
                sb.Append("CTRL");
            }
            else if (c == '-')
            {
                char nextChar = char.ToUpper(identifier[i + 1]);
                sb.Append(nextChar);
                i++;
            }
            else if (!char.IsLetter(c))
            {
                continue;
            }
             else if (c >= 'α' && c <= 'ω')
            {
                continue;
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();

    }
}
