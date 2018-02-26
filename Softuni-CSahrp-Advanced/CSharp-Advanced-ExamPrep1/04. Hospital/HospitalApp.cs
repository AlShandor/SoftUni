using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class HospitalApp
    {
        class Hospital
        {
            public Dictionary<string, Department> Departments = new Dictionary<string, Department>();
        }

        class Department
        {
            public string Name { get; set; }
            public int NumberOfFullRooms { get; set; }
            public Dictionary<int, Room> Rooms = new Dictionary<int, Room>();
        }

        class Room
        {
            public int NumberOfPatients { get; set; }
            public List<Patient> Patients = new List<Patient>();
        }

        class Patient
        {
            public string Name { get; set; }
            public bool IsAccepted { get; set; } = true;
        }

        class Doctor
        {
            public string Name { get; set; }
            public Dictionary<string, Patient> Patients = new Dictionary<string, Patient>();
        }

        static void Main()
        {
            Hospital hospital = new Hospital();
            Dictionary<string, Doctor> doctors = new Dictionary<string, Doctor>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Output")
                {
                    break;
                }

                Patient newPatient = CreateNewPatient(input);
                AssignPatientToRoom(input, hospital, newPatient);
                if (newPatient.IsAccepted)
                {
                    AssignPatientToDoctor(input, newPatient, doctors);
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                PrintCommand(input, doctors, hospital);
            }
        }

        private static void PrintCommand(string input, Dictionary<string, Doctor> doctors, Hospital hospital)
        {

            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (tokens.Length == 1)
            {
                PrintDepartmentPatients(tokens[0], hospital);
            }
            else if (hospital.Departments.ContainsKey(tokens[0]))
            {
                PrintRoomPatients(tokens, hospital);
            }
            else if (doctors.ContainsKey(tokens[0] + " " + tokens[1]))
            {
                PrintDoctorPatients(tokens, doctors);
            }
        }

        private static void PrintDoctorPatients(string[] tokens, Dictionary<string, Doctor> doctors)
        {
            var doctorName = tokens[0] + " " + tokens[1];
            foreach (var patient in doctors[doctorName].Patients.OrderBy(p => p.Key))
            {
                Console.WriteLine(patient.Key);
            }

        }

        private static void PrintRoomPatients(string[] tokens, Hospital hospital)
        {
            var department = tokens[0];
            var roomNum = int.Parse(tokens[1]);
                foreach (var patient in hospital.Departments[department].Rooms[roomNum - 1].Patients.OrderBy(n => n.Name))
                {
                    Console.WriteLine(patient.Name);
                }
        }

        private static void PrintDepartmentPatients(string departmentName, Hospital hospital)
        {
            foreach (var room in hospital.Departments[departmentName].Rooms)
            {
                foreach (var patient in room.Value.Patients)
                {
                    Console.WriteLine(patient.Name);
                }
            }
        }

        private static void AssignPatientToDoctor(string input, Patient newPatient, Dictionary<string, Doctor> doctors)
        {
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var doctorName = tokens[1] + " " + tokens[2];

            // if there is no such doctor, create and add him to list of doctors
            if (!doctors.ContainsKey(doctorName))
            {
                Doctor newDoctor = new Doctor() { Name = doctorName };
                doctors.Add(doctorName, newDoctor);
            }
            // add patient to doctor
            doctors[doctorName].Patients.Add(newPatient.Name, newPatient);
        }

        private static Patient CreateNewPatient(string input)
        {
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var newPatientName = tokens[3];
            Patient newPatient = new Patient() { Name = newPatientName };
            return newPatient;
        }

        private static void AssignPatientToRoom(string input, Hospital hospital, Patient newPatient)
        {
            newPatient.IsAccepted = false;
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var currentDepartment = tokens[0];
            var currentPatient = tokens[3];

            // Create department, if not exist
            if (!hospital.Departments.ContainsKey(currentDepartment))
            {
                newPatient.Name = currentPatient;
                newPatient.IsAccepted = true;
                Room newRoom = new Room { NumberOfPatients = 1 };
                newRoom.Patients.Add(newPatient);
                Department newDepartment = new Department();
                newDepartment.Name = currentDepartment;
                newDepartment.NumberOfFullRooms = 0;
                newDepartment.Rooms.Add(0, newRoom);
                hospital.Departments.Add(newDepartment.Name, newDepartment);
            }
            else // Department exists
            {
                newPatient.IsAccepted = false;
                // If there are available rooms
                if (hospital.Departments[currentDepartment].NumberOfFullRooms < 20)
                {
                    // Go through each room
                    for (int currentRoomIndex = 0; currentRoomIndex < hospital.Departments[currentDepartment].Rooms.Count; currentRoomIndex++)
                    {
                        // if there is space in a room
                        if (hospital.Departments[currentDepartment].Rooms[currentRoomIndex].NumberOfPatients < 3)
                        {
                            // Add patient in the room
                            hospital.Departments[currentDepartment].Rooms[currentRoomIndex].Patients.Add(newPatient);
                            newPatient.IsAccepted = true;
                            hospital.Departments[currentDepartment].Rooms[currentRoomIndex].NumberOfPatients++;
                        }
                    }

                    // if there is no room in current rooms, add new room and accept patient
                    if (newPatient.IsAccepted == false)
                    {
                        Room newRoom = new Room();
                        newRoom.Patients.Add(newPatient);
                        newPatient.IsAccepted = true;
                        newRoom.NumberOfPatients = 1;
                        hospital.Departments[currentDepartment].NumberOfFullRooms++;
                        hospital.Departments[currentDepartment].Rooms.Add(hospital.Departments[currentDepartment].Rooms.Count, newRoom);
                    }
                }
                // if department is full, do not accept patient
                if (hospital.Departments[currentDepartment].NumberOfFullRooms == 20)
                {
                    newPatient.IsAccepted = false;
                }
            }
        }
    }
}
