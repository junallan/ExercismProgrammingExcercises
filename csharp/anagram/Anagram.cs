using System;
using System.Collections.Generic;

public class Anagram
{
    private readonly string _baseWordLowercase;
    private readonly string _baseWordSortedLowercase;

    public Anagram(string baseWord)
    {
        _baseWordLowercase = baseWord.ToLower();
        _baseWordSortedLowercase = SortedWord(_baseWordLowercase);
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> anagrams = new List<string>();

        foreach (var potentialMatch in potentialMatches)
        {
            if (_baseWordLowercase == potentialMatch.ToLower()) continue;
            if (_baseWordSortedLowercase == SortedWord(potentialMatch.ToLower())) anagrams.Add(potentialMatch);
        }

        return anagrams.ToArray();
    }
    private string SortedWord(string word)
    {
        char[] wordSort = word.ToCharArray();
        Array.Sort(wordSort);

        return new string(wordSort);
    }
}