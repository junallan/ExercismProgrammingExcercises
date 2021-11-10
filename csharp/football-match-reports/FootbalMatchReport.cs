using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatchReports
{
    public class PlayAnalyzer
    {
        public static string AnalyzeOnField(int position)
        {
            switch (position)
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
}
