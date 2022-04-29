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

            //    Dictionary<string, string> keys = new Dictionary<string, string>();
            //    keys.Add(signs.ElementAt(0).Key, "0");
            //    keys.Add(signs.ElementAt(1).Key, "1");
            //    int countBuf = signs.ElementAt(0).Value + signs.ElementAt(1).Value;
            //    signs.Remove(signs.ElementAt(0).Key);
            //    signs.Remove(signs.ElementAt(0).Key);
            //    byte plug = 0;
            //    signs.Add(Convert.ToString(plug), countBuf);
            //    int countNewSymb = 0;
            //Here:
            //    for (int i = 0; i < 3; i++)
            //    {
            //        if (signs.Count > 2)
            //        {
            //            if (signs.ElementAt(i).Value + signs.ElementAt(i + 1).Value <= signs.ElementAt(i + 1).Value + signs.ElementAt(i + 2).Value)
            //            {
            //                for (int j = 0; j < keys.Count - countNewSymb; j++)
            //                {
            //                    keys[keys.ElementAt(j).Key] = string.Concat(keys.ElementAt(j).Value, "0");
            //                }
            //                keys.Add(signs.ElementAt(i + 1).Key, "1");
            //                int countBufF = signs.ElementAt(i).Value + signs.ElementAt(i + 1).Value;
            //                signs.Remove(signs.ElementAt(i).Key);
            //                signs.Remove(signs.ElementAt(i).Key);
            //                //signs.Reverse();
            //                plug++;
            //                signs.Add(Convert.ToString(plug), countBufF);
            //                //Sorted(ref signs);
            //                //signs.Reverse();
            //                goto Here;
            //            }
            //            else
            //            {
            //                if (!keys.ContainsKey(signs.ElementAt(i + 1).Key) && !keys.ContainsKey(signs.ElementAt(i + 2).Key))
            //                {
            //                    keys.Add(signs.ElementAt(i + 1).Key, "0");
            //                    keys.Add(signs.ElementAt(i + 2).Key, "1");
            //                    countNewSymb += 2;
            //                    int countBufF = signs.ElementAt(i + 1).Value + signs.ElementAt(i + 2).Value;
            //                    signs.Remove(signs.ElementAt(i + 1).Key);
            //                    signs.Remove(signs.ElementAt(i + 1).Key);
            //                    //signs.Reverse();
            //                    plug++;
            //                    signs.Add(Convert.ToString(plug), countBufF);
            //                    //Sorted(ref signs);
            //                        //signs.Reverse();
            //                    goto Here;
            //                }
            //                else
            //                {
            //                    for (int k = keys.Count - 1; k > keys.Count - countNewSymb; i--)
            //                    {
            //                        keys[keys.ElementAt(k).Key] = string.Concat(keys.ElementAt(k).Value, "0");
            //                    }
            //                    keys.Add(signs.ElementAt(i + 2).Key, "1");
            //                    countNewSymb += 1;
            //                    int countBufF = signs.ElementAt(i + 1).Value + signs.ElementAt(i + 2).Value;
            //                    signs.Remove(signs.ElementAt(i + 1).Key);
            //                    signs.Remove(signs.ElementAt(i + 1).Key);
            //                    //signs.Reverse();
            //                    plug++;
            //                    signs.Add(Convert.ToString(plug), countBufF);
            //                    //Sorted(ref signs);
            //                        //signs.Reverse();
            //                    goto Here;
            //                }
            //            }
            //        }
            //    }




            List<Node> child = new List<Node>();
            Node firstSign = new Node(signs.ElementAt(0).Value), secondSign = new Node(signs.ElementAt(1).Value);
            List<NodeSParent> sParent = new List<NodeSParent>();
            List<NodeLParent> lParent = new List<NodeLParent>();
            firstSign.OriginCode = "0";
            secondSign.OriginCode = "1";
            child.Add(firstSign);
            child.Add(secondSign);
            signs.Remove(signs.ElementAt(0).Key);
            signs.Remove(signs.ElementAt(0).Key);
            byte plug = 0;
            signs.Add(Convert.ToString(plug), firstSign.OriginValue + secondSign.OriginValue);
        Here:
            for (int i = 0; i < 3; i++)
            {
                if (signs.Count > 2)
                {
                    if (signs.ElementAt(i).Value + signs.ElementAt(i + 1).Value <= signs.ElementAt(i + 1).Value + signs.ElementAt(i + 2).Value)
                    {
                        Node c = new Node(signs.ElementAt(i).Value, signs.ElementAt(i + 1).Value);
                        NodeSParent nSP = new NodeSParent(signs.ElementAt(i).Value);
                        nSP.Code = "0";
                        c.SmallParent = nSP;
                        sParent.Add(nSP);
                        NodeLParent nLP = new NodeLParent(signs.ElementAt(i + 1).Value);
                        nLP.Code = "1";
                        c.LargeParent = nLP;
                        lParent.Add(nLP);
                        child.Add(c);
                        signs.Remove(signs.ElementAt(i).Key);
                        signs.Remove(signs.ElementAt(i).Key);
                        plug++;
                        signs.Add(Convert.ToString(plug), c.SmallParent.Value + c.LargeParent.Value);
                        Sorted(ref signs);
                        goto Here;
                    }
                    else
                    {
                        Node anotherFirstOriginSign = new Node(signs.ElementAt(i + 1).Value);
                        Node anotherSecondOriginSign = new Node(signs.ElementAt(i + 2).Value);
                        anotherFirstOriginSign.OriginCode = "0";
                        anotherSecondOriginSign.OriginCode = "1";
                        child.Add(anotherFirstOriginSign);
                        child.Add(anotherSecondOriginSign);
                        signs.Remove(signs.ElementAt(i + 1).Key);
                        signs.Remove(signs.ElementAt(i + 1).Key);
                        plug++;
                        signs.Add(Convert.ToString(plug), anotherFirstOriginSign.OriginValue + anotherSecondOriginSign.OriginValue);
                        Sorted(ref signs);
                        goto Here;
                    }
                }
            }
            byte byteParse;
            if (byte.TryParse(signs.ElementAt(0).Key, out byteParse) == true && byte.TryParse(signs.ElementAt(1).Key, out byteParse) == true)
            {
                Node c = new Node(signs.ElementAt(0).Value, signs.ElementAt(1).Value);
                NodeSParent nSP = new NodeSParent(signs.ElementAt(0).Value);
                nSP.Code = "0";
                c.SmallParent = nSP;
                sParent.Add(nSP);
                NodeLParent nLP = new NodeLParent(signs.ElementAt(1).Value);
                nLP.Code = "1";
                c.LargeParent = nLP;
                lParent.Add(nLP);
                child.Add(c);
                signs.Remove(signs.ElementAt(0).Key);
                signs.Remove(signs.ElementAt(0).Key);
            }
            else if (byte.TryParse(signs.ElementAt(0).Key, out byteParse) == true && byte.TryParse(signs.ElementAt(1).Key, out byteParse) == false)
            {
                Node c = new Node(signs.ElementAt(0).Value, signs.ElementAt(1).Value);
                NodeSParent nSP = new NodeSParent(signs.ElementAt(0).Value);
                nSP.Code = "0";
                c.SmallParent = nSP;
                sParent.Add(nSP);
                Node anotherSecondOriginSign = new Node(signs.ElementAt(1).Value);
                anotherSecondOriginSign.OriginCode = "1";
                child.Add(anotherSecondOriginSign);
                signs.Remove(signs.ElementAt(0).Key);
                signs.Remove(signs.ElementAt(0).Key);
            }
            else if (byte.TryParse(signs.ElementAt(1).Key, out byteParse) == true)
            {
                Node anotherFirstOriginSign = new Node(signs.ElementAt(0).Value);
                anotherFirstOriginSign.OriginCode = "0";
                child.Add(anotherFirstOriginSign);

                Node c = new Node(signs.ElementAt(0).Value, signs.ElementAt(1).Value);
                NodeLParent nLP = new NodeLParent(signs.ElementAt(1).Value);
                nLP.Code = "1";
                c.LargeParent = nLP;
                lParent.Add(nLP);

                signs.Remove(signs.ElementAt(0).Key);
                signs.Remove(signs.ElementAt(0).Key);
            }
            else
            {
                Node anotherFirstOriginSign = new Node(signs.ElementAt(0).Value);
                Node anotherSecondOriginSign = new Node(signs.ElementAt(1).Value);
                anotherFirstOriginSign.OriginCode = "0";
                anotherSecondOriginSign.OriginCode = "1";
                child.Add(anotherFirstOriginSign);
                child.Add(anotherSecondOriginSign);
                signs.Remove(signs.ElementAt(0).Key);
                signs.Remove(signs.ElementAt(0).Key);
            }

            for (int i = 0; i < child.Count; i++)
            {
                string huffCode0 = "", huffCode1 = "";
                if (child[i].OriginCode == null)
                {
                    huffCode0 += child[i].SmallParent.Code;
                    huffCode1 += child[i].LargeParent.Code;
                }
            }

            Console.ReadKey();
        }
    }
}