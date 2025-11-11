using System.Diagnostics.CodeAnalysis;

namespace OverloadingOperatorsLib
{
    public struct Fraction
    {
        public int WholeNumber { get; set; }
        public int Numerator { get; set; }

        private int denominator = 1;

        public int Denominator
        {
            get { return denominator; }
            set {
                if (value == 0) throw new ArgumentException("The denominator can never be 0.");
                denominator = value;
            }
        }

        public Fraction()
        {
            Denominator = 1;
        }

        public Fraction(int whole = 0, int numerator = 0, int denominator = 1)
        {
            WholeNumber = whole;
            Numerator = numerator;
            Denominator = denominator;
        }

        public static int GCD(int m, int n) {
            if (m == 0) return n;
            else return GCD(n % m, m);
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            // Make both fractions improper
            f1.MakeImproper();
            f2.MakeImproper();

            // Create new fraction
            Fraction f3 = new Fraction();

            // Multiply both denoms to get and store the common denom
            // set result denom to common denom
            f3.Denominator = f1.Denominator * f2.Denominator;

            // Multiply each num by it's opposite denom
            f1.Numerator *= f2.Denominator;
            f2.Numerator *= f1.Denominator;

            // Add the new nums to get the result num
            f3.Numerator = f1.Numerator + f2.Numerator;

            // simplify result and return
            f3.Simplify();

            return f3;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            // Make both fractions improper
            f1.MakeImproper();
            f2.MakeImproper();

            // Create new fraction
            Fraction f3 = new Fraction();

            // Multiply both denoms to get and store the common denom
            // set result denom to common denom
            f3.Denominator = f1.Denominator * f2.Denominator;

            // Multiply each num by it's opposite denom
            f1.Numerator *= f2.Denominator;
            f2.Numerator *= f1.Denominator;

            // Add the new nums to get the result num
            f3.Numerator = f1.Numerator - f2.Numerator;

            // simplify result and return
            f3.Simplify();

            return f3;
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            // Make both fractions improper
            f1.MakeImproper();
            f2.MakeImproper();

            // Create new fraction
            Fraction f3 = new Fraction();

            // multiply the nums and denoms by eachother
            f3.Numerator = f1.Numerator * f2.Numerator;
            f3.Denominator = f1.Denominator * f2.Denominator;

            // simplify result and return
            f3.Simplify();

            return f3;
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            // Make both fractions improper
            f1.MakeImproper();
            f2.MakeImproper();

            // Create new fraction
            Fraction f3 = new Fraction();

            // Multiply both denoms to get and store the common denom
            // set result denom to common denom
            //f3.Denominator = f1.Denominator * f2.Denominator;

            // Multiply each num by it's opposite denom
            f3.Numerator = f1.Numerator * f2.Denominator;
            f3.Denominator = f2.Numerator * f1.Denominator;

            // Add the new nums to get the result num
            //f3.Numerator = f1.Numerator / f2.Numerator;

            // simplify result and return
            f3.Simplify();

            return f3;
        }


        public static bool operator ==(Fraction f1, Fraction f2)
        {
            // make improper
            f1.MakeImproper();
            f2.MakeImproper();
            // reduce both
            f1.Reduce();
            f2.Reduce();
            // check if num and denom are equal to eachother
            if ((f1.Numerator == f2.Numerator) && (f1.Denominator == f2.Denominator))
            {
                return true;
            } else
            {
                return false;
            }
        }
        
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Fraction other)
            {
                return this == other;
            }
            return false;
        }

        // Make proper
        public void MakeProper()
        {
            // divide num by denom using int set to whole
            WholeNumber += Numerator / Denominator;
            // mod num by denom using int set to num
            Numerator %= Denominator;
        }

        // divide the num and denom by the gcd
        public void Reduce()
        {
            int commonDivisor = GCD(Numerator, Denominator);
            Numerator /= commonDivisor;
            Denominator /= commonDivisor;
        }

        // Simplify (just calls reduce and make proper)
        public void Simplify()
        {
            Reduce();
            MakeProper();
        }

        private void MakeImproper()
        {
            Numerator = (WholeNumber * Denominator) + Numerator;
            WholeNumber = 0;
        }

        public override string ToString()
        {
            if (WholeNumber == 0) {
                return $"{Numerator}/{Denominator}";
            }
            else if (Numerator == 0)
            {
                return $"{WholeNumber}";
            }
            else
            {
                return $"{WholeNumber} {Numerator}/{Denominator}";
            }
        }
    }
}
