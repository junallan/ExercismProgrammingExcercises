using System;
using System.Collections.Generic;

public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private readonly int _mask;
    private Dictionary<Allergen, int> _foodAllergiesMaping = new Dictionary<Allergen, int>
    {
        { Allergen.Eggs, 1 },
        { Allergen.Peanuts, 2 },
        { Allergen.Shellfish, 4 },
        { Allergen.Strawberries, 8 },
        { Allergen.Tomatoes, 16 },
        { Allergen.Chocolate, 32 },
        { Allergen.Pollen, 64 },
        { Allergen.Cats, 128 }
    }; 
    private List<Allergen> _foodAllergies = new List<Allergen>();

    public Allergies(int mask)
    {
        _mask = mask;

        DetermineFoodAllergies();
    }

    private void DetermineFoodAllergies()
    {
        if (IsAllergicTo(Allergen.Eggs)) { _foodAllergies.Add(Allergen.Eggs); }
        if (IsAllergicTo(Allergen.Peanuts)) { _foodAllergies.Add(Allergen.Peanuts); }
        if (IsAllergicTo(Allergen.Shellfish)) { _foodAllergies.Add(Allergen.Shellfish); }
        if (IsAllergicTo(Allergen.Strawberries)) { _foodAllergies.Add(Allergen.Strawberries); }
        if (IsAllergicTo(Allergen.Tomatoes)) { _foodAllergies.Add(Allergen.Tomatoes); }
        if (IsAllergicTo(Allergen.Chocolate)) { _foodAllergies.Add(Allergen.Chocolate); }
        if (IsAllergicTo(Allergen.Pollen)) { _foodAllergies.Add(Allergen.Pollen); }
        if (IsAllergicTo(Allergen.Cats)) { _foodAllergies.Add(Allergen.Cats); }
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        var allergyMaskValue = _foodAllergiesMaping[allergen];


        return (_mask & allergyMaskValue) > 0;
    }

    public Allergen[] List()
    {
        return _foodAllergies.ToArray();
    }
}