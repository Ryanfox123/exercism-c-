public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        Dictionary<int, int> counts = new Dictionary<int, int>();

        foreach ((int left, int right) in dominoes)
        {
            if (counts.ContainsKey(left))
            {
                counts[left]++;
            }
            else
            {
                counts[left] = 1;
            }
            if (counts.ContainsKey(right))
            {
                counts[right]++;
            }
            else
            {
                counts[right] = 1;
            }
        }
        foreach (var item in counts)
        {
            if (item.Value % 2 != 0)
            {
                return false;
            }
        }
        return true;

    }
}