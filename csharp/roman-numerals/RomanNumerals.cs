using System;
using System.Collections.Generic;
using System.Linq;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        List<RomanNumeralMapping> romanNumeralMapping = new List<RomanNumeralMapping>
        {
            new RomanNumeralMapping { Number = 1000, RomanNumeral = "M" },
            new RomanNumeralMapping { Number = 900,  RomanNumeral = "CM" },
            new RomanNumeralMapping { Number = 500,  RomanNumeral = "D" },
            new RomanNumeralMapping { Number = 400,  RomanNumeral = "CD" },
            new RomanNumeralMapping { Number = 100,  RomanNumeral = "C" },
            new RomanNumeralMapping { Number = 90,   RomanNumeral = "XC" },
            new RomanNumeralMapping { Number = 50,   RomanNumeral = "L" },
            new RomanNumeralMapping { Number = 40,   RomanNumeral = "XL" },
            new RomanNumeralMapping { Number = 10,   RomanNumeral = "X" },
            new RomanNumeralMapping { Number = 9,    RomanNumeral = "IX" },
            new RomanNumeralMapping { Number = 5,    RomanNumeral = "V" },
            new RomanNumeralMapping { Number = 4,    RomanNumeral = "IV" },
            new RomanNumeralMapping { Number = 1,    RomanNumeral = "I" }
        };

        var mappedSymbol = romanNumeralMapping.Find(x => x.Number <= value);
        if (mappedSymbol == null) { return string.Empty; }

        return mappedSymbol.Number == value ? mappedSymbol.RomanNumeral : $"{mappedSymbol.RomanNumeral}{(value - mappedSymbol.Number).ToRoman()}";
    }

    public class RomanNumeralMapping
    { 
        public int Number { get; set; }
        public string RomanNumeral { get; set; }
    }
}