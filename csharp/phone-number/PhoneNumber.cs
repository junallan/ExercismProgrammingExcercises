using System;
using System.Linq;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        bool areaCodeIsValid(string parsedNumber) =>  parsedNumber.ElementAt(0) != '0' && parsedNumber.ElementAt(0) != '1';
        bool exchangeCodeIsValid(string parsedNumber) => parsedNumber.ElementAt(3) != '0' && parsedNumber.ElementAt(3) != '1';

        var parsedDigits = new String(phoneNumber.Where(Char.IsDigit).ToArray());
        if (parsedDigits.Length == 11 
                && parsedDigits.ElementAt(0) == '1' 
                && areaCodeIsValid(parsedDigits[1..])
                && exchangeCodeIsValid(parsedDigits[1..]))
        {
            return parsedDigits[1..];
        }

        return parsedDigits.Length == 10
                && areaCodeIsValid(parsedDigits[0..])
                && exchangeCodeIsValid(parsedDigits[0..]) ? parsedDigits : throw new ArgumentException();
    }
}