using System;

namespace NumberToWordConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to convert into word:");

            int number = -1;
            if (int.TryParse(Console.ReadLine(), out number))
                Console.WriteLine(NumberConverter.ToWord(number));
            else
                Console.WriteLine("Invalid number.");

            Console.Read();
        }
    }
}
