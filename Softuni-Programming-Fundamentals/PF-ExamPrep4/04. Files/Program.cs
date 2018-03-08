using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _04.Files
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            List<string> files = new List<string>();
            for (int i = 0; i < num; i++)
            {
                string file = Console.ReadLine();
                files.Add(file);
            }
            string search = Console.ReadLine();
            Dictionary<string, BigInteger> filesFound = new Dictionary<string, BigInteger>();

            GetSearchedFiles(filesFound, files, search);

            if (filesFound.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                PrintFoundFiles(filesFound);
            }
        }

        private static void PrintFoundFiles(Dictionary<string, BigInteger> filesFound)
        {
            foreach (var file in filesFound.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{file.Key} - {file.Value} KB");
            }
        }

        private static void GetSearchedFiles(Dictionary<string, BigInteger> filesFound, List<string> files, string search)
        {

            string searchExtension = search.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).First();
            string searchRoot = search.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Skip(2).First();

            foreach (var file in files)
            {
                int indexFirstSlash = file.IndexOf(@"\");
                string fileRoot = file.Substring(0, indexFirstSlash);


                int indexLastSlash = file.LastIndexOf(@"\");
                string fileAndSize = file.Substring(indexLastSlash + 1, file.Length - 1 - indexLastSlash);
                BigInteger fileSize = BigInteger.Parse(fileAndSize.Split(';').Skip(1).First());
                string fileNameAndExtension = fileAndSize.Split(';').First();
                int indexLastDot = fileNameAndExtension.LastIndexOf(".");
                string fileExtension = fileNameAndExtension.Substring(indexLastDot + 1);

                if (fileRoot == searchRoot && fileExtension == searchExtension)
                {
                    if (!filesFound.ContainsKey(fileNameAndExtension))
                    {
                        filesFound.Add(fileNameAndExtension, fileSize);
                    }
                    else
                    {
                        filesFound[fileNameAndExtension] = fileSize;
                    }
                }
            }

        }

    }
}
