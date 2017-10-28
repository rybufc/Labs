using System;
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
            if (Base == 0)
            {
                return $"{Numerator}:{Denominator}";
            }
            if (Base * Denominator == Numerator)
            {
                return $"{Base}";
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
            if (input == "")
            {
                result = default(Rational);
                return false;
            }

            Regex regexp = new Regex("^((-?\\d+)([.])?)?((-?\\d+)[:](-?\\d+))?$");
            if (!regexp.IsMatch(input))
            {
                result = default(Rational);
                return false;
            }

            string[] tokens = input.Split('.');
            if (tokens.Length == 2)
            {
                int z = int.Parse(tokens[0]);
                int numerator = int.Parse(tokens[1].Split(':')[0]);
                int denominator = int.Parse(tokens[1].Split(':')[1]);
                numerator = z < 0 && numerator > 0 ? -numerator : numerator;
                result = new Rational(numerator + z * denominator, denominator);
            }
            else if (tokens[0].Split(':').Length == 2)
            {
                int numerator = int.Parse(tokens[0].Split(':')[0]);
                int denominator = int.Parse(tokens[0].Split(':')[1]);
                result = new Rational(numerator, denominator);
            }
            else
            {
                result = new Rational(int.Parse(tokens[0]), 1);
            }

            return true;
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

        public static implicit operator int(Rational r)
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
