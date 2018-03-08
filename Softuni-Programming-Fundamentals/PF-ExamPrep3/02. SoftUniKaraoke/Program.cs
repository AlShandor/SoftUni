using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SoftUniKaraoke
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Participant> participantsDic = new Dictionary<string, Participant>();
            string[] participants = GetArrayFromInput();

            string[] songs = GetArrayFromInput();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "dawn")
                {
                    break;
                }

                string[] stagePerformance = GetArrayFromInput(input);
                string participantPerform = stagePerformance[0];
                string songPerformed = stagePerformance[1];
                string award = stagePerformance[2];
                if (!participants.Contains(participantPerform) || !songs.Contains(songPerformed))
                {
                    continue;
                }

                if (!participantsDic.ContainsKey(participantPerform))
                {
                    var newParticipant = new Participant();
                    newParticipant.AwardsList.Add(award);
                    participantsDic.Add(participantPerform, newParticipant);
                }
                else
                {
                    participantsDic[participantPerform].AwardsList.Add(award);
                }
            }

            foreach (var participant in participantsDic)
            {
                participant.Value.AwardsList = participant.Value.AwardsList.Distinct().ToList();
            }

            if (participantsDic.Count == 0)
            {
                Console.WriteLine("No awards");
            }
            else
            {
                PrintAwards(participantsDic);
            }
        }

        private static void PrintAwards(Dictionary<string, Participant> participantsDic)
        {
            foreach (var singer in participantsDic.OrderByDescending(x => x.Value.NumberUniqueAwards).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{singer.Key}: {singer.Value.NumberUniqueAwards} awards");
                foreach (var award in singer.Value.AwardsList.OrderBy(x => x))
                {
                    Console.WriteLine($"--{award}");
                }
            }
        }

        private static string[] GetArrayFromInput(string input)
        {
            string[] tokens = input
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            return tokens;
        }

        private static string[] GetArrayFromInput()
        {
            string[] tokens = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            return tokens;
        }

        class Participant
        {
            public int NumberUniqueAwards => AwardsList.Count;
            public List<string> AwardsList = new List<string>();
        }     
    }
}
