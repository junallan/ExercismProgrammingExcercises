using System;
using System.Linq;
using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (input.Length == 0) return string.Empty;

        StringBuilder encodedInput = new StringBuilder();
        int numberOfRepeatedInput = 1;

        for(int i=1; i<input.Length; i++)
        {
            if(input[i-1] == input[i])
            {
                numberOfRepeatedInput++;

                //if (i == input.Length - 1) encodedInput.Append($"{numberOfRepeatedInput}{input[i]}");
            }
            else
            {              
                encodedInput.Append($"{((numberOfRepeatedInput == 1) ? string.Empty : numberOfRepeatedInput)}{input[i-1]}");

                //if (i == input.Length - 1) encodedInput.Append(input[i].ToString());

                numberOfRepeatedInput = 1;
            }
        }

        if(input.ElementAt(input.Length -2) == input.Last())
        {
            encodedInput.Append($"{numberOfRepeatedInput}{input.Last()}");
        }
        else
        {
            encodedInput.Append(input.Last());
        }

        return encodedInput.ToString();
        //return input.Aggregate(string.Empty, (encodedInput, element) => encodedInput.Last() == element ? )
    }

    private static bool IsLetterOrWhiteSpace(this char input) => Char.IsLetter(input) || Char.IsWhiteSpace(input);

    public static string Decode(string input)
    {
        if (input.Length == 0) return string.Empty;
        if (input.Length == 1) return input;

        StringBuilder decodedInput = new StringBuilder();
        int startPositionOfNumber = 0;

        if (input.First().IsLetterOrWhiteSpace() && input[1].IsLetterOrWhiteSpace()) decodedInput.Append(input.First());
        
        for(int i=0; i<input.Length-1; i++)
        {
           
            if(input[i].IsLetterOrWhiteSpace() && input[i+1].IsLetterOrWhiteSpace())
            {
                decodedInput.Append(input[i+1]);
                startPositionOfNumber++;
            }
            else if(Char.IsNumber(input[i]) && input[i+1].IsLetterOrWhiteSpace())
            {            
                int numberOfRepetitionOfLetter = int.Parse(input.Substring(startPositionOfNumber, i - startPositionOfNumber + 1));

                if(numberOfRepetitionOfLetter == 0)
                {
                    decodedInput.Insert(decodedInput.Length, input[i + 1].ToString(), int.Parse(input[i].ToString()));
                }
                else
                {
                    decodedInput.Insert(decodedInput.Length, input[i + 1].ToString(), numberOfRepetitionOfLetter);
                }

                startPositionOfNumber = i + 2;
            }
        }

        return decodedInput.ToString();
    }
}
