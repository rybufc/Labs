using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Lab2
{
    public struct Rational
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public int Base => Numerator / Denominator;
        public int Fraction => Numerator % Denominator;

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }

            Numerator = numerator;
            Denominator = denominator;
            Even();

            if (Denominator < 0)
            {
                Numerator *= -1;
                Denominator *= -1;
            }
        }

        #region Binary Operations
        public Rational Add(Rational c)
        {
            return this + c;
        }

        public Rational Negate()
        {
            return 0 - this;
        }

        public Rational Multiply(Rational r)
        {
            return this + r;
        }

        public Rational DivideBy(Rational r)
        {
            return this / r;
        }
        #endregion

        public override string ToString()
        {
            if (Numerator == 0 || Base * Denominator == Numerator)
            {
                return Base.ToString();
            }
            if (Base == 0)
            {
                return $"{Numerator}:{Denominator}";
            }
            int numerator = Numerator - Base * Denominator;
            numerator = Numerator < 0 ? -numerator : numerator;

            return $"{Base}.{numerator}:{Denominator}";
        }
        
        /// <summary>
        /// распознаёт строки форматов:
        /// {int} - приводит к дроби с основанием 1
        /// {int1}:{int2} - приводит дроби int1 / int2
        /// {int1}.{int2}:{int3} - приводит к дроби (int1 * int3 + int2) / int 3;
        /// </summary>
        /// <param name="input">входная строка</param>
        /// <param name="result">результат распознавания</param>
        /// <returns>Если распознание удалось, вернёт true. Иначе - false.</returns>
        public static bool TryParse(string input, out Rational result)
        {
            result = default(Rational);
            try
            {
                result = Parse(input);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private static Rational Parse(string input)
        {
            if (input == "")
            {
                throw new Exception("Была передана пустая строка");
            }

            Regex regexp = new Regex("^(([+-]?\\d+)[.]?)?(([+-]?\\d+)[:]([+-]?\\d+))?$");
            Match match = regexp.Match(input);
            if (!match.Success)
            {
                throw new Exception($"`{input}` - не является рациональным числом.");
            }
            var tokens = match.Groups;

            int denominator = 1;
            int numerator = 0;
            int z = 0;

            try
            {
                if (tokens[2].Value != "")
                    z = int.Parse(tokens[2].Value);
            }
            catch (Exception e)
            {
                throw new Exception("Произошла ошибка при попытке распознать целую часть в числе: '" + input
                                    + "'\n'" + e.Message + "'");
            }

            try
            {
                if (tokens[4].Value != "")
                    numerator = int.Parse(tokens[4].Value);
                if (z < 0) numerator *= -1;
            }
            catch (Exception e)
            {
                throw new Exception("Произошла ошибка при попытке распознать числитель в числе: '" + input
                                    + "'\n'" + e.Message + "'");
            }

            try
            {
                if (tokens[5].Value != "")
                    denominator = int.Parse(tokens[5].Value);
            }
            catch (Exception e)
            {
                throw new Exception("Произошла ошибка при попытке распознать знаменатель в числе: '" + input
                           + "'\n'" + e.Message + "'");
            }
            
            return new Rational(numerator + z * denominator, denominator);
        }

        #region Helpers
        private void Even()
        {
            int divisor = GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= divisor;
            Denominator /= divisor;
        }

        private static int LeastCommonMultiple(int first, int second)
        {
            int multiple = first * second;
            for (int i = 0; i < (first * second + 1); i++)
            {
                if (i % first == 0 && i % second == 0)
                {
                    multiple = i;
                }
            }
            return multiple;
        }

        private static int GreatestCommonDivisor(int first, int second)
        {
            while (second != 0)
            {
                int temp = second;
                second = first % second;
                first = temp;
            }
            return first;
        }
        #endregion

        #region Операторы

        public static explicit operator int(Rational r)
        {
            return r.Base;
        }

        public static implicit operator Rational(int num)
        {
            return new Rational(num, 1);
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            int denominator = LeastCommonMultiple(r1.Denominator, r2.Denominator);
            int numerator = r1.Numerator * denominator / r1.Denominator + r2.Numerator * denominator / r2.Denominator;
            Rational result = new Rational(numerator, denominator);
            return result;
        }

        public static Rational operator +(Rational r1, int num)
        {
            return new Rational(r1.Numerator + num * r1.Denominator, r1.Denominator);
        }

        public static Rational operator +(int num, Rational r1)
        {
            return new Rational(r1.Numerator + num * r1.Denominator, r1.Denominator);
        }

        public static Rational operator -(Rational r1, Rational r2)
        {
            int denominator = LeastCommonMultiple(r1.Denominator, r2.Denominator);
            int numerator = r1.Numerator * denominator / r1.Denominator - r2.Numerator * denominator / r2.Denominator;
            return new Rational(numerator, denominator);
        }

        public static Rational operator -(Rational r1, int num)
        {
            return new Rational(r1.Numerator - num * r1.Denominator, r1.Denominator);
        }

        public static Rational operator -(int num, Rational r1)
        {
            return new Rational(num * r1.Denominator - r1.Numerator, r1.Denominator);
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            int denominator = r1.Denominator * r2.Denominator;
            int numerator = r1.Numerator * r2.Numerator;
            return new Rational(numerator, denominator);
        }

        public static Rational operator *(Rational r1, int num)
        {
            return new Rational(r1.Numerator * num, r1.Denominator);
        }

        public static Rational operator *(int num, Rational r1)
        {
            return new Rational(r1.Numerator * num, r1.Denominator);
        }

        public static Rational operator /(Rational r1, Rational r2)
        {
            int denominator = r1.Denominator * r2.Numerator;
            int numerator = r1.Numerator * r2.Denominator;
            return new Rational(numerator, denominator);
        }

        public static Rational operator /(Rational r1, int num)
        {
            return new Rational(r1.Numerator, r1.Denominator * num);
        }

        public static Rational operator /(int num, Rational r1)
        {
            return new Rational(r1.Denominator * num, r1.Numerator);
        }
        #endregion
    }
}
