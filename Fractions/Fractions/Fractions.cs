using System;
using System.Dynamic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace Fractions
{
    public class Fractions
    {

        private int _denominator;

        public int Numerator { get; set; }

        public int Denominator
        {
            get
            {
                return _denominator;
            }
            set
            {
                if (value == 0)
                    throw new DivideByZeroException();
                else
                    _denominator = value;


            }
        
        }


        public Fractions(int numerator = 0, int denominator = 1)
        {
            if (denominator == 0)
                throw new DivideByZeroException();
            if (numerator < 0 && denominator < 0) //Checking and correcting negative values
            {
                numerator = -1 * numerator;
                denominator = -1 * denominator;

            }

            Numerator = numerator;
            Denominator = _denominator;


        }

        //NORMALIZING FRACTION (More math) IF POSSIBLE

        public static void NormalizeFraction(Fractions fractionToReduce)
        {//Check if numerator and denominator is the same number
            if (fractionToReduce.Numerator / fractionToReduce.Denominator == 1 &&
                fractionToReduce.Numerator % fractionToReduce.Denominator == 0)
            {
                fractionToReduce.Numerator = 1;
                fractionToReduce.Denominator = 1;
            }
            else
            {
                for (int i = fractionToReduce.Denominator; i >= 2; i--)
                {
                    if(fractionToReduce.Denominator % i == 0 && fractionToReduce.Numerator % i == 0)
                    {
                        fractionToReduce.Denominator = fractionToReduce.Denominator / i;
                        fractionToReduce.Numerator = fractionToReduce.Denominator / i;
                    }
                }
            }
        }




        //ORDER DENOMINATORS FOR SAKE OF CLARITY (Reason for it being only denominators is because we have to use them to find the GCD/Common denominator)

        private static int[] OrderDenominators(int firstDenominator, int secondDenominator)
        {
            int[] returnArray = new int[2];

            if (firstDenominator > secondDenominator)
            {
                returnArray[0] = firstDenominator;
                returnArray[1] = secondDenominator;
            }
            else
            {
                returnArray[0] = secondDenominator;
                returnArray[1] = firstDenominator;
            }

            return returnArray;
        }
        //GREATEST COMMON DEVISOR (How is  the math for this ? ) (How does math here work?)
        private static int smallestCommonDenominator(Fractions first, Fractions second)
        {
            int[] denominators = OrderDenominators(first.Denominator, second.Denominator);
            int largestDenominator = denominators[0];
            int smallestDenominator = denominators[1];

            int smallestCommonDenominator = 1;
            int[] values = new int[largestDenominator];

            for (int i = 0; i < largestDenominator; i++)
            {
                values[i] = largestDenominator * (i + 1);
            }

            for (int j = 0; j < largestDenominator; j++)
            {
                int currentValue = smallestCommonDenominator * (j + 1);
                if (values.Contains(currentValue))
                {
                    smallestCommonDenominator = currentValue;
                    break;
                }

            }
            return smallestCommonDenominator;
        }
    }
}