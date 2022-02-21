using System;

public static class HighSchoolSweethearts
{
    private const int LinePaddingLength = 29;
    private const int BannerPaddingLength = 10;
     

    public static string DisplaySingleLine(string studentA, string studentB) => $"{studentA,LinePaddingLength} ♡ {studentB,-LinePaddingLength}";

    public static string DisplayBanner(string studentA, string studentB) =>
    $@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**{studentA.TrimEnd(),BannerPaddingLength}  +  {studentB.TrimStart(),-BannerPaddingLength}**
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";
    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        throw new NotImplementedException($"Please implement the (static) HighSchoolSweethearts.DisplayGermanExchangeStudents() method");
    }
}
