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

    public static string Decode(string input)
    {
        if (input.Length == 0) return string.Empty;

        StringBuilder decodedInput = new StringBuilder();
        int startPositionOfNumber = 0;

        for(int i=0; i<input.Length; i++)
        {
            if (Char.IsLetter(input[i]))
            {
                if(i==0)
                {
                    decodedInput.Append(input[i]);
                    startPositionOfNumber++;
                }       
                else
                {
                    if(Char.IsNumber(input[i-1]))
                    {
                        int numberOfRepetitionOfLetter = int.Parse(input.Substring(startPositionOfNumber, i - startPositionOfNumber));
                        decodedInput.Insert(decodedInput.Length, input[i].ToString(), numberOfRepetitionOfLetter);
                        startPositionOfNumber = i + 1;
                    }
                    else
                    {
                        decodedInput.Append(input[i]);
                    }

                 
                }
            }
            //else
            //{
            //    startPositionOfNumber = i;
            //}
           
            
        }

        return decodedInput.ToString();
    }
}
