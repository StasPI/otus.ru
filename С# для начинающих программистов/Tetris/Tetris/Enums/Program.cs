using System;

namespace Enums
{
    class Program
    {
        static void Main(string[] args)
        {
            Day day = Day.Mon;

            if (day == Day.Mon)
            {
                Console.WriteLine("Понедельник");
                Console.WriteLine((int)day);
            }

        }
    }
}
