using System;
using System.Collections.Generic;

public class Anagram
{
    private readonly string _baseWord;
    private readonly string _baseWordSortedLowercase;

    public Anagram(string baseWord)
    {
        _baseWord = baseWord;
        _baseWordSortedLowercase = SortedWord(baseWord.ToLower());
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> anagrams = new List<string>();

        foreach (var potentialMatch in potentialMatches)
        {
            if (_baseWord.ToLower() == potentialMatch.ToLower()) continue;
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