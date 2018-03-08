using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.HornetComm
{
    class Program
    {
        static void Main()
        {
            var broadcastList = new List<Broadcast>();
            var PMList = new List<PrivateMessage>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Hornet is Green")
                {
                    break;
                }

                string pmPattern = @"^([\d]+) <-> ([\da-zA-Z]+)$";
                string broadcastPattern = @"^([^\d]+) <-> ([\da-zA-Z]+)$";
                if (Regex.IsMatch(input, pmPattern))
                {
                    AddPMToList(input, PMList, pmPattern);
                }
                else if (Regex.IsMatch(input, broadcastPattern))
                {
                    AddBroadcastToList(input, broadcastList, broadcastPattern);
                }
                else
                {
                    continue;
                }
            }
            PrintBroadcastsAndPMs(broadcastList, PMList);
        }

        private static void PrintBroadcastsAndPMs(List<Broadcast> broadcastList, List<PrivateMessage> pMList)
        {
            if (broadcastList.Count == 0)
            {
                Console.WriteLine("Broadcasts:");
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine("Broadcasts:");
                foreach (var broadcast in broadcastList)
                {
                    Console.WriteLine($"{broadcast.Frequency} -> {broadcast.Message}");
                }
            }

            if (pMList.Count == 0)
            {
                Console.WriteLine("Messages:");
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine("Messages:");
                foreach (var message in pMList)
                {
                    Console.WriteLine($"{message.Recipient} -> {message.Message}");
                }
            }
        }

        private static void AddBroadcastToList(string input, List<Broadcast> broadcastList, string broadcastPattern)
        {
            string frequency = Regex.Match(input, broadcastPattern).Groups[2].Value;
            string message = Regex.Match(input, broadcastPattern).Groups[1].Value;
            string frequencyDecrypted = DecryptFrequency(frequency);
            var newBroadcast = new Broadcast();
            newBroadcast.Frequency = frequencyDecrypted;
            newBroadcast.Message = message;
            broadcastList.Add(newBroadcast);
        }

        private static string DecryptFrequency(string frequency)
        {
            char[] frequencyCharArr = frequency.ToCharArray();
            for (int i = 0; i < frequencyCharArr.Length; i++)
            {
                if (char.IsLower(frequencyCharArr[i]))
                {
                    frequencyCharArr[i] = char.ToUpper(frequencyCharArr[i]);
                }
                else if (char.IsUpper(frequencyCharArr[i]))
                {
                    frequencyCharArr[i] = char.ToLower(frequencyCharArr[i]);
                }
            }
            string frequencyDecrypted = new string(frequencyCharArr);
            return frequencyDecrypted;
                
        }

        private static void AddPMToList(string input, List<PrivateMessage> PMList, string pmPattern)
        {
            string recipient = Regex.Match(input, pmPattern).Groups[1].Value;
            string reversedRecipient = new string(recipient.Reverse().ToArray());
            string message = Regex.Match(input, pmPattern).Groups[2].Value;
            var newPM = new PrivateMessage();
            newPM.Recipient = reversedRecipient;
            newPM.Message = message;
            PMList.Add(newPM);
        }
    }

    class Broadcast
    {
        public string Frequency { get; set; }
        public string Message { get; set; }
    }

    class PrivateMessage
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
    }
}
