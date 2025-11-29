using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinqIntroApp
{
    public class CheckUpperCase
    {
        //private readonly IEnumerable<string> _words;

        //public CheckUpperCase(IEnumerable<string> words)
        //{
        //    _words = words;
        //}

        public static bool IsAnyWordUpperCase(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                bool areAllUpperCase = true;
                foreach (var letter in word)
                {
                    if (char.IsLower(letter))
                    {
                        areAllUpperCase = false;
                    }
                }
                if (areAllUpperCase)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsAnyWordUpperCaseLinq(IEnumerable<string> words)
        {
            return words.Any(word => word.All(letter => char.IsUpper(letter)));
        }
    }
}
