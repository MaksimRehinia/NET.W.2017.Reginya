﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public class Algorithm
    {
        /// <summary>
        /// Inserts first number bits from the jth to the ith position into second number
        /// so that the bits of second number occupy positions from bit j to bit i. </summary>        
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <param name="i">Start position</param>
        /// <param name="j">End position</param>
        /// <exception cref="ArgumentException">
        /// Throws when i is greater than j or
        /// (i &lt; 0) || (i &gt; 31) || (j &lt; 0) || (j &gt; 31) or
        /// (number1 &lt; 0) || (number2 &lt; 0) </exception>        
        /// <returns> 
        /// Result of bit insertion </returns>
        public static int InsertNumber(int number1, int number2, int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentException(nameof(i) + " must be less than " + nameof(j));
            }

            if (i < 0 || i > 31 || j < 0 || j > 31)
            {
                throw new ArgumentException(nameof(i) + " and " + nameof(j) + " must be not negative and less than 32");
            }

            if (number1 < 0 || number2 < 0)
            {
                throw new ArgumentException(nameof(number1) + " and " + nameof(number2) + " must not be negative");
            }

            var number1BitArray = new BitArray(new[] { number1 });
            var number2BitArray = new BitArray(new[] { number2 });

            int l = 0;
            for (int k = i; k <= j; k++)
                number1BitArray.Set(k, number2BitArray.Get(l++));

            // Convert bit array to single int
            var result = new int[1];            
            number1BitArray.CopyTo(result, 0);
            return result[0];
        }

        /// <summary>
        /// Finds the nearest largest integer that consists of digits of the original number. </summary>
        /// <param name="source">Source number</param>       
        /// <exception cref="ArgumentException">Throws if source number is not positive</exception>
        /// <returns>
        /// Nearest largest integer consisting of digits of the original number.
        /// Or -1 if a required number does not exist. </returns>        
        public static int FindNextBiggerNumber(int source)
        {
            if (source < 1)
            {
                throw new ArgumentException(nameof(source) + " must be positive");
            }
            
            var numerals = source.ToString().ToCharArray();
            var list = new List<char>();
            int i = 0;
            for (i = numerals.Length - 1; i > 0; i --)
            {
                if (numerals[i] > numerals[i - 1])
                {
                    list.Add(numerals[i - 1]);

                    char temp = numerals[i];
                    numerals[i] = numerals[i - 1];
                    numerals[i - 1] = temp;    
                    
                    break;
                }
                else
                {
                    list.Add(numerals[i]);
                }
            }

            if (i == 0)
            {
                return -1;
            }

            list.Sort();
            foreach (var item in list)
            {
                numerals[i] = item;
                i++;
            }


            return Int32.Parse(new String(numerals));
        }                
    }
}
