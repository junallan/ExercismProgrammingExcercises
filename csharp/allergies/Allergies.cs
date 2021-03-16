using System;
using System.Collections.Generic;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private readonly int _mask;
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
        return (_mask & (int)allergen) > 0;
    }

    public Allergen[] List()
    {
        return Enum.GetValues(typeof(Allergen)).Cast<Allergen>().Where(IsAllergicTo).ToArray();
    }
}