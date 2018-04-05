using System;
using System.Collections.Generic;

namespace P06_TrafficLights
{
    public class Startup
    {
        public static void Main()
        {
            TrafficLights[] greeYellowRed = { TrafficLights.Green, TrafficLights.Yellow, TrafficLights.Red };
            List<Queue<TrafficLights>> listTrafficLights = new List<Queue<TrafficLights>>();

            string[] lightsString = Console.ReadLine().Split();
            foreach (var lightStr in lightsString)
            {
                Queue<TrafficLights> lightsQueue = new Queue<TrafficLights>(greeYellowRed);
                for (int i = 0; i < 3; i++)
                {
                    if (lightsQueue.Peek().ToString() == lightStr)
                    {
                        break;
                    }
                    lightsQueue.Enqueue(lightsQueue.Dequeue());
                }

                listTrafficLights.Add(lightsQueue);
            }

            int numTimesChange = int.Parse(Console.ReadLine());

            for (int i = 0; i < numTimesChange; i++)
            {
                List<string> currentStatusLights = new List<string>();

                foreach (var trafficLight in listTrafficLights)
                {
                    trafficLight.Enqueue(trafficLight.Dequeue());
                    currentStatusLights.Add(trafficLight.Peek().ToString());
                }

                Console.WriteLine(string.Join(" ", currentStatusLights));
            }
        }
    }
}
