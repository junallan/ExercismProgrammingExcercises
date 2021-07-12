using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private readonly string _baseWordLowercase;
    private readonly string _baseWordSortedLowercase;

    public Anagram(string baseWord)
    {
        _baseWordLowercase = baseWord.ToLower();
        _baseWordSortedLowercase = SortedWord(_baseWordLowercase);
    }

    public string[] FindAnagrams(string[] potentialMatches) => potentialMatches.Where(pm => pm.ToLower() != _baseWordLowercase 
                                                                                        && _baseWordSortedLowercase == SortedWord(pm.ToLower()))
                                                                                .ToArray();
    private string SortedWord(string word)
    {
        char[] wordSort = word.ToCharArray();
        Array.Sort(wordSort);

        return new string(wordSort);
    }
}