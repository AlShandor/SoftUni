using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.RoliTheCoder
{
    class Program
    {
        static void Main()
        {
            Dictionary<int, Event> events = new Dictionary<int, Event>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Time for Code")
                {
                    break;
                }
                GetEvent(events, input);
            }
            PrintEvents(events);
        }

        private static void PrintEvents(Dictionary<int, Event> events)
        {
            foreach (var e in events)
            {
                e.Value.Participants = e.Value.Participants.Distinct().ToList();
            }

            foreach (var ev in events.OrderByDescending(x => x.Value.Participants.Count).ThenBy(x => x.Value.Name))
            {
                string name = ev.Value.Name.Substring(1);
                Console.WriteLine($"{name} - {ev.Value.Participants.Count}");
                foreach (var participant in ev.Value.Participants.OrderBy(x => x))
                {
                    Console.WriteLine(participant);
                }
            }
        }

        private static void GetEvent(Dictionary<int, Event> events, string input)
        {
            string[] tokens = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int id = int.Parse(tokens[0]);
            string eventName = tokens[1];
            if (!eventName.StartsWith("#"))
            {
                return;
            }

            List<string> newParticipants = new List<string>();
            if (tokens.Length != 2)
            {
                newParticipants = GetParticipants(input);
            }
            
            if (!events.ContainsKey(id))
            {
                var newEvent = new Event();
                newEvent.Name = eventName;
                newEvent.Participants.AddRange(newParticipants);
                events.Add(id, newEvent);
            }
            else
            {
                if (events[id].Name != eventName)
                {
                    return;
                }
                events[id].Participants.AddRange(newParticipants);
            }
        }

        private static List<string> GetParticipants(string input)
        {
            int indexFirst = input.IndexOf("@");
            string participantsStr = input.Substring(indexFirst);
            string participantPattern = @"@[A-Za-z\d'\-]+";
            var participantsMatches = Regex.Matches(participantsStr, participantPattern);
            List<string> matchedParticipants = participantsMatches
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList();
            return matchedParticipants;
        }

        class Event
        {
            public string Name { get; set; }
            public List<string> Participants = new List<string>();
        }
    }
}
