using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatchReports
{
    public static class PlayAnalyzer
    {
        public static string AnalyzeOnField(int position) => position switch
        {
            1 => "goalie",
            2 => "left back",
            3 or 4 => "center back",
            5 => "right back",
            6 or 7 or 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => throw new ArgumentOutOfRangeException()
        };

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

    public class Incident
    {
        public virtual string GetDescription() => "An incident happened.";
    }

    public class Foul : Incident
    {
        public override string GetDescription() => "The referee deemed a foul.";
    }

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
