using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Rational
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public int Base
        {
            get
            {
                return this.Numerator / this.Denominator;
            }
        }

        public int Fraction
        {
            get
            {
                return this.Numerator % this.Denominator;
            }
        }

        public Rational Add(Rational c)
        {
            Rational result = new Rational();
            result.Denominator = LeastCommonMultiple(this.Denominator, c.Denominator);
            result.Numerator = this.Numerator * result.Denominator / this.Denominator + c.Numerator * result.Denominator / c.Denominator;
            result.Even();
            return result;
        }

        public Rational Negate()
        {
            Rational result = new Rational();
            result.Numerator = 0 - this.Numerator;
            result.Denominator = this.Denominator;
            return result;
        }

        public Rational Multiply(Rational x)
        {
            Rational result = new Rational();
            result.Numerator = this.Numerator * x.Numerator;
            result.Denominator = this.Denominator * x.Denominator;
            result.Even();
            return result;
        }

        public Rational DivideBy(Rational x)
        {
            Rational result = new Rational();
            result.Numerator = this.Numerator * x.Denominator;
            result.Denominator = this.Denominator * x.Numerator;
            result.Even();
            return result;
        }

        public override string ToString()
        {
            
            return base.ToString();
        }
        
        public static bool TryParse(string input, out Rational result)
        {

        }

        private void Even()
        {
            int Divisor = GreatestCommonDivisor(this.Numerator, this.Denominator);
            this.Numerator /= Divisor;
            this.Denominator /= Divisor;
        }

        private static int LeastCommonMultiple(int first, int second)
        {
            int Multiple = first * second;
            for (int i = 0; i < (first * second + 1); i++)
            {
                if (i % first == 0 && i % second == 0)
                {
                    Multiple = i;
                }
            }
            return Multiple;
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
    }
}
