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

                if (i == input.Length - 1) encodedInput.Append($"{numberOfRepeatedInput}{input[i]}");
            }
            else
            {              
                encodedInput.Append($"{((numberOfRepeatedInput == 1) ? string.Empty : numberOfRepeatedInput)}{input[i-1]}");

                if (i == input.Length - 1) encodedInput.Append(input[i].ToString());

                numberOfRepeatedInput = 1;
            }

           
        }

        return encodedInput.ToString();
        //return input.Aggregate(string.Empty, (encodedInput, element) => encodedInput.Last() == element ? )
    }

    public static string Decode(string input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
