using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonewordTranslator
{
    public static  class PhonewordTranslator
    {
        public static string? ToNumber(string raw)
        {
            if (string.IsNullOrEmpty(raw)) return null;

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (var c in raw)
            {
                //if c is a number get it
                if (" -0123456789".Contains(c))
                {
                    newNumber.Append(c);
                }
                //else translate char to number
                else
                {
                    var result = TranslateToNumber(c);
                    
                    if (result != null)
                    {
                        newNumber.Append(result);
                    }
                    
                }
            }
            return newNumber.ToString();

        }

        static readonly string[] digits = {
        "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
    };
        private static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                {
                    return 2+i;
                }
            }
            return null;
        }
    }
}
