using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Organizations.Models
{
    public static class GameLevel
    {
        static Dictionary<char, int> CharScores = new Dictionary<char, int>
        {
            { '_', 0 },
            { '\'', 0 },
            { '.', 7 },
            { ',', 8 },
            { '-', 9 },
            { '?', 11 },
            { '!', 12 },
            { ')', 14 },
            { '(', 15 },

            { 'a', 10 },
            { 'b', 11 },
            { 'c', 12 },
            { 'd', 13 },
            { 'e', 14 },
            { 'f', 15 },
            { 'g', 0 },
            { 'h', 1 },
            { 'i', 2 },
            { 'j', 3 },
            { 'k', 4 },
            { 'l', 5 },
            { 'm', 6 },
            { 'n', 7 },
            { 'o', 8 },
            { 'p', 9 },
            { 'q', 10 },
            { 'r', 11 },
            { 's', 12 },
            { 't', 13 },
            { 'u', 14 },
            { 'v', 15 },
            { 'w', 0 },
            { 'x', 1 },
            { 'y', 2 },
            { 'z', 3 },

            { 'A', 4 },
            { 'B', 5 },
            { 'C', 6 },
            { 'D', 7 },
            { 'E', 8 },
            { 'F', 9 },
            { 'G', 10 },
            { 'H', 11 },
            { 'I', 12 },
            { 'J', 13 },
            { 'K', 14 },
            { 'L', 15 },
            { 'M', 0 },
            { 'N', 1 },
            { 'O', 2 },
            { 'P', 3 },
            { 'Q', 4 },
            { 'R', 5 },
            { 'S', 6 },
            { 'T', 7 },
            { 'U', 8 },
            { 'V', 9 },
            { 'W', 10 },
            { 'X', 11 },
            { 'Y', 12 },
            { 'Z', 13 },
        };
        static Dictionary<int, (int, int, int, int, string)> PlayerStats = new Dictionary<int, (int, int, int, int, string)>
        {
            { 0, (3, 3, 15, 5, "A") },
            { 1, (4, 3, 15, 4, "B") },
            { 2, (3, 4, 13, 5, "C") },
            { 3, (4, 4, 13, 4, "D") },
            { 4, (4, 4, 15, 5, "A") },
            { 5, (4, 4, 15, 5, "B") },
            { 6, (4, 4, 14, 5, "C") },
            { 7, (4, 4, 14, 5, "D") },
            { 8, (5, 5, 15, 5, "A") },
            { 9, (4, 5, 15, 6, "B") },
            { 10, (5, 4, 15, 5, "C") },
            { 11, (4, 4, 15, 6, "D") },
            { 12, (6, 6, 15, 5, "A") },
            { 13, (4, 6, 15, 7, "B") },
            { 14, (6, 4, 16, 5, "C") },
            { 15, (4, 4, 16, 7, "D") },
        };
        static Dictionary<string, (int, int, int, int)> GrowthRates = new Dictionary<string, (int, int, int, int)>
        {
            { "A", (1,2,1,2) },
            { "B", (2,1,2,1) },
            { "C", (1,1,2,2) },
            { "D", (2,2,1,1) },
        };
        static Dictionary<int, (int, (int, int), (int, int), (int, int), (int, int), string)> Levels = new Dictionary<int, (int, (int, int), (int, int), (int, int), (int, int), string)>
        {
            { 1, (0, (0,0), (0,0), (0,0), (0,0), string.Empty ) },
            { 2, (7, (1,1), (0,0), (7,6), (0,0), string.Empty ) },
            { 3, (23, (3,3), (2,2), (9,8), (0,0), "HEAL" ) },
            { 4, (47, (3,3), (4,4), (16,14), (11,10), "HURT" ) },
            { 5, (110, (8,7), (6,6), (23,21), (19,17), string.Empty ) },
            { 6, (220, (12,11), (6,6), (23,21), (19,17), string.Empty ) },
            { 7, (450, (14,13), (13,12), (25,23), (21,19), "SLEEP" ) },
            { 8, (800, (18,16), (16,15), (31,28), (24,22), string.Empty ) },
            { 9, (1300, (26,24), (18,16), (35,32), (31,28), "RADIANT" ) },
            { 10, (2000, (31,28), (27,24), (39,35), (35,32), "STOPSPELL" ) },
        };
        public static int NameScore(string name)
        {
            var chars = name.ToCharArray();
            var score = 0;
            foreach (var ch in chars)
            {
                score += CharScores[ch];
            }

            return score;
        }

        public static (int, int, int, int, string) NameStat(string name)
        {
            var score = NameScore(name);
            return PlayerStats[score % 15];
        }

        public static (int, int, int, int) GrowthRate(string nameStat)
        {
            return GrowthRates[nameStat];
        }
    }
}
