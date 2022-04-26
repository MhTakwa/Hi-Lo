using System;

namespace Hi_Lo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pick Minimum Number :");
            var min = ReadNumber();
            Console.WriteLine("Pick Maximum Number :");
            int max= ReadNumber();
            while (!IsMax(min, max))
            {
                Console.WriteLine("Pick a number >" + min);
                max = ReadNumber();
            }
            var mystery = Mystery(min, max) ;
            Console.WriteLine($"Pick A Number Between {min} and {max}");
            int number;
            int count = 1;
                     
            bool isMystery=false;

            do
            {
                PickNumber(min, max, out number);
                IsMystery(number, mystery, out isMystery,ref count);  

            }
            while (!isMystery);
            





        }

        static int Mystery(int minValue, int maxValue )
        {
            Random random = new Random();
            return random.Next(minValue, maxValue);
        }

        static int ReadNumber()
        {
            bool isNumber= false;
            int number=-1;

            do
            {
                try
                {
                   number= int.Parse(Console.ReadLine());
                    isNumber = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("This is Not a Number!");
                }
            }
            while (! isNumber);
            return number;
            
        }

        static bool IsMax(int min, int max)
        {
            return max > min;
        }
        static bool IsBetween(int number, int min, int max)
        {
            return (number>= min) && (number <= max);
        }

        static void IsMystery(int number , int mystery, out bool isMystery,ref int count)
        {
            isMystery = false;
            if (number == mystery)
            {
                Console.WriteLine($"Bravo you guessed the number in {count} iterations");
                isMystery = true;
            }
            else if (number < mystery)
            {
                count++;
                Console.WriteLine($"The mystery number > {number}");
            }
            else
            {
                count++;
                Console.WriteLine($"The mystery number < {number}");
            }
        }

        static void PickNumber(int min, int max, out int number)
        {
            number = ReadNumber();
            while (!IsBetween(number, min, max))
            {
                Console.WriteLine($"the number you picked isn't between {min} and {max}");
                number = ReadNumber();

            }
        }

    }
}
