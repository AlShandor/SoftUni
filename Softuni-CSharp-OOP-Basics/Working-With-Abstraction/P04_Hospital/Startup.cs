using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();
            
            string command;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] tokens = command.Split();
                var currentDepartment = tokens[0];
                var doctorName = tokens[1] + tokens[2];
                var patient = tokens[3];

                if (!doctors.ContainsKey(doctorName))
                {
                    doctors[doctorName] = new List<string>();
                }
                if (!departments.ContainsKey(currentDepartment))
                {
                    departments[currentDepartment] = new List<List<string>>();
                    for (int room = 0; room < 20; room++)
                    {
                        departments[currentDepartment].Add(new List<string>());
                    }
                }

                bool hasFreeRoom = departments[currentDepartment].SelectMany(x => x).Count() < 60;
                if (hasFreeRoom)
                {
                    int room = 0;
                    doctors[doctorName].Add(patient);
                    for (int currentRoom = 0; currentRoom < departments[currentDepartment].Count; currentRoom++)
                    {
                        if (departments[currentDepartment][currentRoom].Count < 3)
                        {
                            room = currentRoom;
                            break;
                        }
                    }
                    departments[currentDepartment][room].Add(patient);
                }
            }

            command = Console.ReadLine();
            PrintRequiredInformation(command, departments, doctors);
        }

        private static void PrintRequiredInformation(string command, 
            Dictionary<string, List<List<string>>> departments, Dictionary<string, List<string>> doctors)
        {
            while (command!= "End") 
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                }

                command = Console.ReadLine();
            }
        }
    }
}
