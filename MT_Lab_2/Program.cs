using System;
using System.Collections.Generic;
using System.Linq;

namespace MT_Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine(), resStr = "", doubleChar = Console.ReadLine(), strCopy = str;
            char[] chars = str.ToCharArray();
            int doubleCounter = 0;

            Dictionary<string, int> signs = new Dictionary<string, int>(), doubleSigns = new Dictionary<string, int>();

            foreach (char i in chars)
            {
                if (!signs.ContainsKey(Convert.ToString(i)))
                {
                    signs.Add(Convert.ToString(i), 0);
                }
            }
            foreach (KeyValuePair<string, int> kvp in signs)
            {
                resStr += $"'{kvp.Key}' : {kvp.Value}, ";
            }
            resStr = resStr.TrimEnd(new char[] { ',', ' ' });
            Console.WriteLine("\nИнициализированный словарь уникальных символов" + resStr);

            resStr = "";
            foreach (char i in str)
            {
                signs[Convert.ToString(i)] += 1;
            }
            foreach (KeyValuePair<string, int> kvp in signs)
            {
                resStr += $"'{kvp.Key}' : {kvp.Value}, ";
            }
            resStr = resStr.TrimEnd(new char[] { ',', ' ' });
            Console.WriteLine("\nКоличество вхождений уникальных символов в строку: " + resStr);

            while (strCopy.IndexOf(doubleChar) > -1)
            {
                strCopy = strCopy.Remove(strCopy.IndexOf(doubleChar), 2);
                doubleCounter += 1;
            }
            Console.WriteLine("\nКоличество вхождений пользовательской пары в строку: " + doubleCounter);

            resStr = "";
            for (int i = 0; i <= str.Length - 2; i++)
            {
                string buf = string.Concat(str[i], str[i + 1]);
                if (!doubleSigns.ContainsKey(buf))
                {
                    doubleSigns.Add(buf, 0);
                }
            }
            foreach (KeyValuePair<string, int> kvp in doubleSigns)
            {
                resStr += $"'{kvp.Key}' : {kvp.Value}, ";
            }
            resStr = resStr.TrimEnd(new char[] { ',', ' ' });
            Console.WriteLine("\nИнициализированный словарь уникальных двойных сочетаний: " + resStr);

            resStr = "";
            for (int i = 0; i <= str.Length - 2; i++)
            {
                string buf = string.Concat(str[i], str[i + 1]);
                doubleSigns[buf] += 1;
            }
            foreach (KeyValuePair<string, int> kvp in doubleSigns)
            {
                resStr += $"'{kvp.Key}' : {kvp.Value}, ";
            }
            resStr = resStr.TrimEnd(new char[] { ',', ' ' });
            Console.WriteLine("\nКоличество вхождений уникальных пар символов в строку: " + resStr);

            resStr = "";
            int frequency = 0;
            foreach (KeyValuePair<string, int> kvp in doubleSigns)
            {
                if (kvp.Value > frequency)
                {
                    frequency = kvp.Value;
                }
            }
            foreach (KeyValuePair<string, int> kvp in doubleSigns)
            {
                if (kvp.Value == frequency)
                {
                    signs.Add(kvp.Key, kvp.Value);
                }
            }
            ////Dictionary<string, int> abc = new Dictionary<string, int>();

            ////foreach (KeyValuePair<string, int> kvp in signs)
            ////{
            ////    abc.Add(kvp.Key, kvp.Value);
            ////}
            Sorted(ref signs);
            //Sorted(ref abc);
            //Console.WriteLine();
            //foreach (KeyValuePair<string, int> kvp in abc)
            //{
            //    Console.Write($"{kvp.Key}: {kvp.Value}");
            //}
            //Console.WriteLine();

            foreach (KeyValuePair<string, int> kvp in signs)
            {
                resStr += $"'{kvp.Key}' : {kvp.Value}, ";
            }
            resStr = resStr.TrimEnd(new char[] { ',', ' ' });
            Console.WriteLine("\nСловарь с добавленными самыми частовстречаемыми двойными комбинациями" + resStr);

            static void Sorted(ref Dictionary<string, int> signs)
            {
                signs = signs.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            }



            //ПОлучвение кодов
            int maxValue = signs.Max(v => v.Value);
            Dictionary<string, string> boolCode = new Dictionary<string, string>();
            for (int i = 0; i < signs.Count; i++)
            {
                if (signs.ContainsValue(i) && i < maxValue)
                {

                }







                foreach (KeyValuePair<string, int> kvp in signs)
                {
                    boolCode
                }
            }
        }
    }
}
