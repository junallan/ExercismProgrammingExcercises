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
        _baseWordSortedLowercase = new string(_baseWordLowercase.OrderBy(x => x).ToArray());
    }

    public string[] FindAnagrams(string[] potentialMatches) 
        => potentialMatches.Where(pm => pm.ToLower() != _baseWordLowercase
                                   && _baseWordSortedLowercase == new string(pm.ToLower().OrderBy(x => x).ToArray()))
                           .ToArray();
}