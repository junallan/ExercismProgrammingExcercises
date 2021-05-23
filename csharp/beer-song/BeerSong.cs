using System;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        int numberBottlesRemaining = startBottles - 1;
        string bottleNumberSubtractedWord = numberBottlesRemaining == 1 ? "bottle" : "bottles";

        string firstSentence = startBottles == 0 
                                ? "No more bottles of beer on the wall, no more bottles of beer.\n" 
                                  : startBottles == 1 
                                    ? "1 bottle of beer on the wall, 1 bottle of beer.\n" 
                                      : $"{startBottles} bottles of beer on the wall, {startBottles} bottles of beer.\n";

        string secondSentence = startBottles == 0 
                                 ? "Go to the store and buy some more, 99 bottles of beer on the wall." 
                                   : startBottles == 1 
                                     ? "Take it down and pass it around, no more bottles of beer on the wall." 
                                       : $"Take one down and pass it around, {numberBottlesRemaining} {bottleNumberSubtractedWord} of beer on the wall.";

        return $"{firstSentence}" +
               $"{secondSentence}" +
               (takeDown == 1 ? string.Empty : "\n\n" + Recite(numberBottlesRemaining, --takeDown));
    }
}