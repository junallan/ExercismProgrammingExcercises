using System;

public static class HighSchoolSweethearts
{
    private const int LinePaddingLength = 29;
    private const int BannerPaddingLength = 10;

    private static string LineContents(string studentA, string studentB)
    {
        return $"**{studentA,BannerPaddingLength}  +  {studentB,-BannerPaddingLength}**";
    }
     

    public static string DisplaySingleLine(string studentA, string studentB) => $"{studentA,LinePaddingLength} ♡ {studentB,-LinePaddingLength}";

    public static string DisplayBanner(string studentA, string studentB)
    {
        var test = LineContents(studentA.Trim(), studentB.Trim());
        // var test2 = $"{studentA.TrimEnd(),BannerPaddingLength}  +  {studentB.TrimStart(),-BannerPaddingLength}";
        // var test3 = $"**{test2,12}**";
           
return $@"
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
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        throw new NotImplementedException($"Please implement the (static) HighSchoolSweethearts.DisplayGermanExchangeStudents() method");
    }
}
