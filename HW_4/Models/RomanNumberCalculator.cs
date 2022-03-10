using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_4.Models
{
    public static class RomanNumberCalculator
    {
        private static string[] separateInput(string input)
        {
            char[] separators = { '+', '-', '*', '/' };
            return input.Split(separators);
        }
        public static RomanNumberExtend Calculate(string input)
        {
            var splittedInputByOperands = Regex.Split(input, @"([*()\^\/]|(?<!E)[\+\-])");


            string output = "";
            foreach (var element in splittedInputByOperands)
            {
                if (element != "+" && element != "-" && element != "*" && element != "/")
                {
                    if (!RomanNumberValidator.Validate(element))
                    {
                        throw new RomanNumberException();
                    }

                    output += (new RomanNumberExtend(element)).UshortValue().ToString();

                }
                else
                {
                    output += element;
                }

            }
            DataTable dt = new DataTable();

            return new RomanNumberExtend(Convert.ToUInt16(dt.Compute(output, "")));
        }
    }
}
