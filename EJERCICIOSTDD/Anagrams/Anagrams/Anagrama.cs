using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Anagrams
{
    public class Anagrama
    {
        public string Palabra1 { get; set; }
        public string Palabra2 { get; set; }

        public Anagrama()
        {

        }

        public Anagrama(string palabra1, string palabra2)
        {
            Palabra1 = palabra1;
            Palabra2 = palabra2;
        }

        public bool esMayorQue1()
        {
            if (!string.IsNullOrEmpty(Palabra1) || !string.IsNullOrEmpty(Palabra2))
            {
                return true;
            }
            return false;
        }

        public bool noEsNumero()
        {
            if (Regex.IsMatch(Palabra1, @"[0-9]") || Regex.IsMatch(Palabra2, @"[0-9]"))
            {
                return false;
            }
            return true;
        }

        
        public string esAnagrama()
        {
            if (Regex.IsMatch(Palabra1, @"[0-9]") || Regex.IsMatch(Palabra2, @"[0-9]"))
            {
                return "No Es Anagrama";
            }

            if (string.IsNullOrEmpty(Palabra1) || string.IsNullOrEmpty(Palabra2))
            {
                return "No Es Anagrama";
            }
            if (Palabra1 == Palabra2)
            {
                return "Es Anagrama";
            }
            var charMap = new Dictionary<char, int>();
            foreach (char c in Palabra1.Trim().ToLowerInvariant())
            {
                if (!char.IsLetterOrDigit(c)) { continue; }
                if (charMap.ContainsKey(c))
                {
                    charMap[c]++;
                }
                else
                {
                    charMap.Add(c, 1);
                }

            }

            foreach (char c in Palabra2.Trim().ToLowerInvariant())
            {
                if (!char.IsLetterOrDigit(c)) { continue; }

                if (!charMap.ContainsKey(c))
                {
                    return "No Es Anagrama";
                }
                if (--charMap[c] < 0)
                {
                    return "No Es Anagrama";
                }
            }

            foreach (int i in charMap.Values)
            {
                if (i != 0)
                {
                    return "No Es Anagrama";
                }
            }
            return "Es Anagrama";
        }
    }
}
