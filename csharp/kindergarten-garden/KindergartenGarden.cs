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
 
    public KindergartenGarden(string diagram)
    {
        this.PlantArrangement = diagram.Split("\n");
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var studentPlantPlacementIndex = Array.IndexOf(this.StudentNames, student) * NumberOfPlantsForStudentPerRow;

        Func<char, Plant> getPlant = (plantCode) => { 
            switch (plantCode) 
            { 
                case 'V': return Plant.Violets;
                case 'R': return Plant.Radishes;
                case 'C': return Plant.Clover;
                case 'G': return Plant.Grass;
                default: throw new ArgumentException();
            }   
        };

        return new[] {  getPlant(this.PlantArrangement[0][studentPlantPlacementIndex]), 
                        getPlant(this.PlantArrangement[0][studentPlantPlacementIndex + 1]), 
                        getPlant(this.PlantArrangement[1][studentPlantPlacementIndex]), 
                        getPlant(this.PlantArrangement[1][studentPlantPlacementIndex + 1]) };
    }
}