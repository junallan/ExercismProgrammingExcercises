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
        (string AreaCode, string PrefixCode, string LocalNumber) phoneNumberParsed = (phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2]);

        bool isNewYorkAreaCode = IsNewYorkAreaCode(phoneNumberParsed.AreaCode);
        (bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo = (isNewYorkAreaCode, IsFakePrefixCode(phoneNumberParsed.PrefixCode), phoneNumberParsed.LocalNumber);
 
        return (isNewYorkAreaCode, IsFake(phoneNumberInfo), phoneNumberParsed.LocalNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}
