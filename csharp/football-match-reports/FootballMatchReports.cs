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
}
