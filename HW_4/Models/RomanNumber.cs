using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        protected ushort _number;

        //Конструктор получает представление числа n в римской записи
        public RomanNumber(ushort n)
        {
            if (n <= 0 || n >= 4000)
            {
                throw new RomanNumberException();
            }
            _number = n;
        }

        //Сложение римских чисел
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1._number + n2._number));
        }

        //Вычитание римских чисел
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            if (n1._number <= n2._number) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1._number - n2._number));
        }

        //Умножение римских чисел
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1._number * n2._number));
        }

        //Целочисленное деление римских чисел
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            if (
                n1._number % n2._number == 0 &&
                n1._number >= n2._number
            )
            {
                return new RomanNumber((ushort)(n1._number / n2._number));
            }
            else
            {
                throw new RomanNumberException();
            }
        }

        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            return ToRoman(_number);
        }
        private static string ToRoman(int number)
        {
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new RomanNumberException();
        }

        public object Clone()
        {
            return new RomanNumber(_number);
        }

        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber num) return _number.CompareTo(num._number);
            else throw new RomanNumberException("ERROR: Invalid argument");
        }
    }
}