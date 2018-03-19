using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.MagicExchangeableWord
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(' ').ToArray();
            string str1 = words[0];
            string str2 = words[1];
            Dictionary<char, char> chars = new Dictionary<char, char>();
            bool isExchangeable = true;
            int length = str1.Length > str2.Length ? str2.Length : str1.Length;

            if (str1.Distinct().ToList().Count != str2.Distinct().ToList().Count)
            {
                Console.WriteLine("false");
                return;
            }

            for (int currentCHar = 0; currentCHar < length; currentCHar++)
            {
                if (!chars.ContainsKey(str1[currentCHar]))
                {
                    chars.Add(str1[currentCHar], str2[currentCHar]);
                }
                else
                {
                    if (chars[str1[currentCHar]] == str2[currentCHar])
                    {
                        continue;
                    }
                    else
                    {
                        isExchangeable = false;
                        break;
                    }
                }
            }
            if (str1.Length != str2.Length)
            {
                if (str1.Length > str2.Length )
                {
                    for (int currentChar = length; currentChar < str1.Length; currentChar++)
                    {
                        if (!chars.ContainsKey(str1[currentChar]))
                        {
                            isExchangeable = false;
                            break;
                        }
                    }
                }
                else
                {
                    for (int currentChar = length; currentChar < str2.Length; currentChar++)
                    {
                        if (!chars.ContainsValue(str2[currentChar]))
                        {
                            isExchangeable = false;
                            break;
                        }
                    }
                }
            }

            if (isExchangeable)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            
        }
    }
}
