using System;

public static class ReverseString
{
    public static string Reverse(string input) => input == string.Empty || input.Length == 1 ? input : $"{ Reverse(input.Substring(1))}{input[0]}";
}