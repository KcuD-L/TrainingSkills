using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Learning
{
    public static class Input
    {
        public static int CheckInt()
        {
            int num;
            while (true)
            {
                var input = CheckString();
                if (int.TryParse(input, out num))
                {
                    break;
                }
                Console.Write("Введите число!");
            }
            return num;
        }

        public static string CheckString()
        {
            string? input;
            while (true)
            {
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                Console.WriteLine("Ввод не был предоставлен (null, пустая строка или пробелы).");
            }
            return input;
        }

        public static bool CheckBound(int number, int min, int max) => number >= min && number <= max;

        public static int CheckBoundRetry(int number, int min, int max)
        {
            while(true)
            {
                if(CheckBound(number, min, max))
                {
                    return number;
                }
                Console.WriteLine("Число выходит за диапазон! Попробуйте ещё раз");
                number = CheckInt();
            }            
        }
    }
}