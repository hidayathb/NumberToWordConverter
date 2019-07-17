using System;

namespace NumberToWordConverter
{
    public class NumberConverter
    {

        static readonly string[] MoreThanHundreds = { "", "thousand", "million" };
                
        static readonly string[] LessThanHundred = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        static readonly string[] LessThanTwenty = { "zero", "one", "two", "three", "four", "five", "six",
                                                    "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen",
                                                    "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        const int MULTIPLIER = 3;

        /// <summary>
        /// Converts the given number into word
        /// </summary>
        /// <param name="number">number to convert</param>
        /// <returns>returns the word from number. Invalid if number is < 0 or > 999999999 </returns>
        public static string ToWord(Int32 number)
        {
            if (number < 0 || number > 999999999)
                return "Invalid input";

            if (number < 1000)
                return ToLessThanThousand(number);

            return ToMoreThanThousands(number);
        }

        private static string ToMoreThanThousands(int number)
        {
            var totalDigits = number.ToString().Length;
            var totalCounter = DeriveNumberOfThreeMultiples(totalDigits);
            var startIndex = 0;
            var word = string.Empty;

            /*
             *  Here, total counter drives to iterate the number of times by multiples of 3.
             *  Ex: 1,000 --> here we need to iterate only once
             *  1,000,000 --> here we need to iterate 2 times.
             * 
             */

            while (totalCounter >= 0)
            {
                // using counter, take the digits by multiples of 3
                var nextThreePlaces = totalDigits - totalCounter * MULTIPLIER > MULTIPLIER ? MULTIPLIER : totalDigits - totalCounter * MULTIPLIER;

                // If remaining digits itself is less than three places, then take only remaining
                var nextNumberOfPlaces = totalDigits - startIndex < nextThreePlaces ? totalDigits - startIndex : nextThreePlaces;

                var numberToConvert = Convert.ToInt32(number.ToString().Substring(startIndex, nextNumberOfPlaces));
                if (numberToConvert > 0)
                    word += ToLessThanThousand(numberToConvert) + " " + MoreThanHundreds[totalCounter] + " ";

                startIndex += nextThreePlaces;
                totalCounter--;
            }

            return word.Trim();
        }

        private static int DeriveNumberOfThreeMultiples(int totalDigits)
        {
            var div = totalDigits / MULTIPLIER;
            var mod = totalDigits % MULTIPLIER;
            // if mod is pure round then it falls within that format. Ex: 100,000
            var totalCounter = (mod == 0) ? div - 1 : div; 
            return totalCounter;
        }

        private static string ToTens(Int32 val)
        {
            var lastDigitMod = val % 10;
            var firstDigitDiv = (val / 10) - 2; // reduce 2 as less than 20 will be treated earlier itself.

            return LessThanHundred[firstDigitDiv] + " " + LessThanTwenty[lastDigitMod];
        }

        private static string ToHundreds(Int32 val)
        {
            string word = string.Empty;
            int div = val / 100;
            int mod = val % 100;

            word = LessThanTwenty[div] + " hundred";
            if (mod > 0) word = word + " and " + ToTens(mod);

            return word;
        }

        private static string ToLessThanThousand(Int32 val)
        {
            if (val < 20)
                return LessThanTwenty[val];

            if (val < 100)
                return ToTens(val);

            return ToHundreds(val);
        }
    }
}
