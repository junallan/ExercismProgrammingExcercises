using System;
using System.Collections.Generic;

public static class ResistorColorTrio
{
    private enum Colors
    {
        black,
        brown,
        red,
        orange,
        yellow,
        green,
        blue,
        violet,
        grey,
        white
    }
  
    public static string Label(string[] colors)
    {
        var firstColor = (int)(Enum.Parse(typeof(Colors), colors[0]));
        var secondColor = (int)(Enum.Parse(typeof(Colors), colors[1]));
        var thirdColor = (int)(Enum.Parse(typeof(Colors), colors[2]));
        var firstColorParsed = firstColor == 0 ? string.Empty : firstColor.ToString();
        var secondColorParsed = secondColor == 0 ? string.Empty : secondColor.ToString();

        string thirdColorParsed;

        if(thirdColor < (int)Colors.red)
        {
            thirdColorParsed = $"{new string('0',thirdColor)} ohms";
        }
        else
        {
            thirdColorParsed = $"{new string('0', thirdColor < (int)Colors.yellow ? 0 :  1)} kiloohms";
        }

        return $"{firstColorParsed}{secondColorParsed}{thirdColorParsed}";
    }
}
