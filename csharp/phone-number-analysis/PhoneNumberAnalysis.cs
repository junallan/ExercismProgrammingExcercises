using System;

public static class PhoneNumber
{
    const string NewYorkAreaCode = "212";
    const string FakePrefixCode = "555";

    private static bool IsNewYorkAreaCode(string areaCode) => areaCode.Equals( NewYorkAreaCode, StringComparison.CurrentCultureIgnoreCase);
    private static bool IsFakePrefixCode(string prefixCode) => prefixCode.Equals(FakePrefixCode, StringComparison.CurrentCultureIgnoreCase);

    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string[] phoneNumberSplit = phoneNumber.Split("-");

        return (IsNewYorkAreaCode(phoneNumberSplit[0]), IsFakePrefixCode(phoneNumberSplit[1]), phoneNumberSplit[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}
