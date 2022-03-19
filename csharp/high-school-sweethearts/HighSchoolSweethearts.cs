using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    private const int LinePaddingLength = 29;
    private const int BannerPaddingLength = 10;
    private static CultureInfo GermanCulture = new CultureInfo("de-DE");    

    public static string DisplaySingleLine(string studentA, string studentB) => $"{studentA,LinePaddingLength} ♡ {studentB,-LinePaddingLength}";

    public static string DisplayBanner(string studentA, string studentB) =>
    $@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
{DisplayBannerContent(studentA, studentB)}
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";
    public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours) 
                            => $"{studentA} and {studentB} have been dating since {start.ToString("d", GermanCulture)} - that's {hours.ToString("N2", GermanCulture)} hours";

    private static string DisplayBannerContent(string studentA, string studentB)
                            => $"**{studentA.TrimEnd(),BannerPaddingLength}  +  {studentB.TrimStart(),-BannerPaddingLength}**";
    
}     
