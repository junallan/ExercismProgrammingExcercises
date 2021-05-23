using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private readonly string[] PlantArrangement;
    private readonly string[] StudentNames = new string[] { "Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry" };
    private readonly int NumberOfPlantsForStudentPerRow = 2;
    private readonly int NumberOfPlantsForStudent = 4;

    public KindergartenGarden(string diagram)
    {
        this.PlantArrangement = diagram.Split(Environment.NewLine.ToCharArray());
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var studentPlantPlacementIndex = Array.IndexOf(this.StudentNames, student) * NumberOfPlantsForStudentPerRow;

        return  Enumerable.Range(0, NumberOfPlantsForStudent)
                          .Select(i => GetPlant(this.PlantArrangement[i / NumberOfPlantsForStudentPerRow][i % NumberOfPlantsForStudentPerRow + studentPlantPlacementIndex]));
    }

    private Plant GetPlant(char plantCode)
    {
        switch (plantCode)
        {
            case 'V':
                return Plant.Violets;
            case 'R':
                return Plant.Radishes;
            case 'C':
                return Plant.Clover;
            case 'G':
                return Plant.Grass;
            default:
                throw new ArgumentException();
        }
    }
}