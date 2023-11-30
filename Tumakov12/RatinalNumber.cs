using System;


namespace Tumakov12
{
    internal class RationalNumber
    {
        private int numerator;
        private int denominator;

        public int Numerator
        {
            get { return numerator; }
            set
            {
                numerator = value;
                Simplify();
            }
        }

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Denominator cannot be zero.");

                denominator = value;
                Simplify();
            }
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private void Simplify()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            RationalNumber other = (RationalNumber)obj;
            return numerator == other.numerator && denominator == other.denominator;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(RationalNumber a, RationalNumber b)
        {
            return !a.Equals(b);
        }

        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            return (a.numerator * b.denominator) < (b.numerator * a.denominator);
        }

        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            return (a.numerator * b.denominator) > (b.numerator * a.denominator);
        }

        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            return (a.numerator * b.denominator) <= (b.numerator * a.denominator);
        }

        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            return (a.numerator * b.denominator) >= (b.numerator * a.denominator);
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            int newNumerator = (a.numerator * b.denominator) + (b.numerator * a.denominator);
            int newDenominator = a.denominator * b.denominator;
            return new RationalNumber(newNumerator, newDenominator);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            int newNumerator = (a.numerator * b.denominator) - (b.numerator * a.denominator);
            int newDenominator = a.denominator * b.denominator;
            return new RationalNumber(newNumerator, newDenominator);
        }

        public static RationalNumber operator ++(RationalNumber a)
        {
            return a + new RationalNumber(1, 1);
        }

        public static RationalNumber operator --(RationalNumber a)
        {
            return a - new RationalNumber(1, 1);
        }

        public static implicit operator RationalNumber(int value)
        {
            return new RationalNumber(value, 1);
        }

        public static implicit operator RationalNumber(float value)
        {
            int precision = 1000000; // adjust based on required precision
            int denominator = precision;
            int numerator = (int)(value * precision);
            return new RationalNumber(numerator, denominator);
        }

        public static implicit operator RationalNumber(double value)
        {
            int precision = 1000000; // adjust based on required precision
            int denominator = precision;
            int numerator = (int)(value * precision);
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            int newNumerator = a.numerator * b.numerator;
            int newDenominator = a.denominator * b.denominator;
            return new RationalNumber(newNumerator, newDenominator);
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            if (b.numerator == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            int newNumerator = a.numerator * b.denominator;
            int newDenominator = a.denominator * b.numerator;
            return new RationalNumber(newNumerator, newDenominator);
        }

        public static RationalNumber operator %(RationalNumber a, RationalNumber b)
        {
            if (b.numerator == 0)
                throw new DivideByZeroException("Cannot find remainder when dividing by zero.");

            RationalNumber quotient = a / b;
            return a - (quotient * b);
        }

        public RationalNumber(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;

            Simplify();
        }
    }
}
