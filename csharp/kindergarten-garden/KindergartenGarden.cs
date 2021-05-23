using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public class KindergartenGarden
{
    private readonly string[] PlantArrangement;
    private readonly string[] StudentNames = new string[] { "Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry" };
    private readonly int NumberOfPlantsForStudentPerRow = 2;
 
    public KindergartenGarden(string diagram)
    {
        this.PlantArrangement = diagram.Split("\n");
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var studentPlantPlacementIndex = Array.IndexOf(this.StudentNames, student) * NumberOfPlantsForStudentPerRow;

        return new[] {  (Plant)this.PlantArrangement[0][studentPlantPlacementIndex], 
                        (Plant)this.PlantArrangement[0][studentPlantPlacementIndex + 1], 
                        (Plant)this.PlantArrangement[1][studentPlantPlacementIndex], 
                        (Plant)this.PlantArrangement[1][studentPlantPlacementIndex + 1] };
    }
}