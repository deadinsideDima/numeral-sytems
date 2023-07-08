using System;
using System.Globalization;

namespace NumeralSystems
{
    public static class Converter
    {
        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the octal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the octal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveOctal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number can not be less than zero.", nameof(number));
            }

            string str = string.Empty;
            while (number != 0)
            {
                str = (number % 8) + str;
                number /= 8;
            }

            return str;
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the decimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the decimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveDecimal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number can not be less than zero.", nameof(number));
            }

            return number.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the hexadecimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the hexadecimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveHex(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number can not be less than zero.", nameof(number));
            }

            string str = string.Empty;
            while (number != 0)
            {
                int temp = number % 16;
                if (temp == 10)
                {
                    str = "A" + str;
                }
                else if (temp == 11)
                {
                    str = "B" + str;
                }
                else if (temp == 12)
                {
                    str = "C" + str;
                }
                else if (temp == 13)
                {
                    str = "D" + str;
                }
                else if (temp == 14)
                {
                    str = "E" + str;
                }
                else if (temp == 15)
                {
                    str = "F" + str;
                }
                else
                {
                    str = temp + str;
                }

                number /= 16;
            }

            return str;
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveRadix(this int number, int radix)
        {
            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Error.");
            }

            if (radix == 8)
            {
                return GetPositiveOctal(number);
            }
            else if (radix == 10)
            {
                return GetPositiveDecimal(number);
            }
            else
            {
                return GetPositiveHex(number);
            }
        }

        /// <summary>
        /// Gets the value of a signed integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        public static string GetRadix(this int number, int radix)
        {
            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Error.");
            }

            string str = Convert.ToString(number, radix);
            char[] temp = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                temp[i] = char.ToUpper(temp[i], CultureInfo.InvariantCulture);
            }

            return new string(temp);
        }
    }
}
