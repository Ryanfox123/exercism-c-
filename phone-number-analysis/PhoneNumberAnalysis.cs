public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        bool isNyNumber = phoneNumber[0..3] == "212";
        bool isNumFake = phoneNumber[4..7] == "555";
        string localNum = phoneNumber[8..];

        return (isNyNumber, isNumFake, localNum);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
