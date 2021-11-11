using System;

namespace FootballMatchReports
{
    public static class PlayAnalyzer
    {
        public static string AnalyzeOnField(int shirtNum) 
        { 
            switch (shirtNum) 
            { 
                case 1: return "goalie"; 
                case 2: return "left back"; 
                case 3 or 4: return "center back"; 
                case 5: return "right back"; 
                case 6 or 7 or 8: return "midfielder"; 
                case 9: return "left wing"; 
                case 10: return "striker"; 
                case 11: return "right wing"; 
                default: throw new ArgumentOutOfRangeException(); 
            } 
        }

        public static string AnalyzeOffField(object criteria) => criteria switch
        {
            int supporters => $"There are {supporters} supporters at the match.",
            string commentary => commentary,
            Incident incident => incident.GetDescription(),
            Manager manager => manager.ToString(),
            _ => throw new ArgumentException()
        };
    }

    public class Manager
    {
        public string Name { get; }
        public string? Club { get; }

        public Manager(string name, string? club)
        {
            this.Name = name;
            this.Club = club;
        }

        public override string ToString() => string.IsNullOrWhiteSpace(this.Club) ? this.Name : $"{this.Name} ({this.Club})";
    }


    public class Incident { public virtual string GetDescription() => "An incident happened."; }

    public class Foul : Incident { public override string GetDescription() => "The referee deemed a foul."; }

    public class Injury : Incident
    {
        private readonly int player;
        public Injury(int player)
        {
            this.player = player;
        }

        public override string GetDescription() => $"Oh no! Player {player} is injured. Medics are on the field.";
    }
}