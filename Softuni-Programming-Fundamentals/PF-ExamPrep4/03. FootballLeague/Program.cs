using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.FootballLeague
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> leagueStandings = new Dictionary<string, int>();
            Dictionary<string, long> teamGoals = new Dictionary<string, long>();
            string key = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "final")
                {
                    break;
                }

                string keyPattern = Regex.Escape(key) + @"(\w+)" + Regex.Escape(key) + @".+" + Regex.Escape(key) + @"(\w+)" + Regex.Escape(key) + @"[^\d]+([\d]+:\d+)";
                Match matchResult = Regex.Match(input, keyPattern);
                string[] teamsPointsCurrentMatch = GiveTeamsPoints(matchResult, teamGoals, input);
                AddTeamsPointsToLeagueStangings(leagueStandings, teamsPointsCurrentMatch);
            }
            PrintLeagueStandingsAndGoals(leagueStandings, teamGoals);
        }

        private static void PrintLeagueStandingsAndGoals(Dictionary<string, int> leagueStandings, Dictionary<string, long> teamGoals)
        {
            Console.WriteLine("League standings:");
            int num = 1;
            foreach (var team in leagueStandings.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{num}. {team.Key} {team.Value}");
                num++;
            }
            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in teamGoals.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(3))
            {
                Console.WriteLine($"- {team.Key} -> {team.Value}");
            }

        }

        private static void AddTeamsPointsToLeagueStangings(Dictionary<string, int> leagueStandings, string[] teamsPointsCurrentMatch)
        {
            string teamA = teamsPointsCurrentMatch[0];
            int teamAPoints = int.Parse(teamsPointsCurrentMatch[1]);
            string teamB = teamsPointsCurrentMatch[2];
            int teamBPoints = int.Parse(teamsPointsCurrentMatch[3]);

            if (!leagueStandings.ContainsKey(teamA))
            {
                leagueStandings.Add(teamA, teamAPoints);
            }
            else
            {
                leagueStandings[teamA] += teamAPoints;
            }

            if (!leagueStandings.ContainsKey(teamB))
            {
                leagueStandings.Add(teamB, teamBPoints);
            }
            else
            {
                leagueStandings[teamB] += teamBPoints;
            }
        }

        private static string[] GiveTeamsPoints(Match matchResult, Dictionary<string, long> teamGoals, string input)
        {
            string teamA = new string(matchResult.Groups[1].ToString().ToUpper().Reverse().ToArray());
            string teamB = new string(matchResult.Groups[2].ToString().ToUpper().Reverse().ToArray());
            string score = matchResult.Groups[3].ToString();

            string[] tokens = input.Split(' ');
            long[] goals = tokens[2].Split(':').Select(long.Parse).ToArray();
            long teamAGoals = goals[0];
            long teamBGoals = goals[1];

            CountTeamGoals(teamGoals, teamA, teamAGoals, teamB, teamBGoals);

            string teamAPoints = "0";
            string teamBPoints = "0";

            if (teamAGoals > teamBGoals)
            {
                teamAPoints = "3";
            }
            else if (teamBGoals > teamAGoals)
            {
                teamBPoints = "3";
            }
            else if (teamAGoals == teamBGoals)
            {
                teamAPoints = "1";
                teamBPoints = "1";
            }

            string[] teamsPoints = new string[4];
            teamsPoints[0] = teamA;
            teamsPoints[1] = teamAPoints;
            teamsPoints[2] = teamB;
            teamsPoints[3] = teamBPoints;

            return teamsPoints;
        }

        private static void CountTeamGoals(Dictionary<string, long> teamGoals, string teamA, long teamAGoals, string teamB, long teamBGoals)
        {
            if (!teamGoals.ContainsKey(teamA))
            {
                teamGoals.Add(teamA, teamAGoals);
            }
            else
            {
                teamGoals[teamA] += teamAGoals;
            }

            if (!teamGoals.ContainsKey(teamB))
            {
                teamGoals.Add(teamB, teamBGoals);
            }
            else
            {
                teamGoals[teamB] += teamBGoals;
            }
        }
    }
}
