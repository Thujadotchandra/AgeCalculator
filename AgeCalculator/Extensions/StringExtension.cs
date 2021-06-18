using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeCalculator.Extensions
{
    public static class StringExtension
    {
        public static int CountVowels(this string name)
        {
            int total = 0;

            if (string.IsNullOrEmpty(name))
            {
                return total;
            }

            name = name.ToLower();

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == 'a' || name[i] == 'e' || name[i] == 'i' || name[i] == 'o' || name[i] == 'u')
                {
                    total++;
                }
            }

            return total;
        }
    }
}