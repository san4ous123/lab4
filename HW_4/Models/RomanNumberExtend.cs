using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4.Models
{
    public class RomanNumberExtend : RomanNumber
    {
        public ushort UshortValue() => this._number;
        public RomanNumberExtend(string num) : base(romanToInt(num)) { }
        public RomanNumberExtend(ushort n) : base(n) { }
        private static ushort value(char r)
        {
            if (r == 'I')
                return 1;
            if (r == 'V')
                return 5;
            if (r == 'X')
                return 10;
            if (r == 'L')
                return 50;
            if (r == 'C')
                return 100;
            if (r == 'D')
                return 500;
            if (r == 'M')
                return 1000;
            throw new RomanNumberException();
        }

        private static ushort romanToInt(string s)
        {
            if (!RomanNumberValidator.Validate(s))
            {
                throw new RomanNumberException();
            }

            ushort total = 0;
            for (int i = 0; i < s.Length; i++)
            {
                ushort s1 = value(s[i]);
                if (i + 1 < s.Length)
                {
                    ushort s2 = value(s[i + 1]);
                    if (s1 >= s2)
                    {
                        total = (ushort)(total + s1);
                    }
                    else
                    {
                        total = (ushort)(total - s1);
                    }
                }
                else
                {
                    total = (ushort)(total + s1);
                }
            }
            return total;
        }
    }
}
