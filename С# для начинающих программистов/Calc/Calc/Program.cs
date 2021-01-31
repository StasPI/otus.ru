using System;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                GetCalc();
            } while (AskContinue());
        }

        private static void GetCalc()
        {
            int x = GetNumber("Пожалуйста, введите первое число:");
            int y = GetNumber("Пожалуйста, введите второе число:");

            Console.WriteLine("Пожалуйста, выберите команду: +, -, *, /, min, max");
            string cmd = Console.ReadLine();

            int result = GetResult(x, y, cmd);
            Console.WriteLine($"{x} {cmd} {y} = {result}");
        }

        private static bool AskContinue()
        {
            while (true)
            {
                Console.WriteLine("Продолжить использование калькулятора? Y/N");
                string status = Console.ReadLine();
                status = status.ToLower();
                if (status == "y")
                    return true;
                else if (status == "n")
                    return false;
                else
                    Console.WriteLine("Ответ не опознан");
            }
        }

        private static int GetResult(int x, int y, string cmd)
        {
            int result;
            switch(cmd)
            {
                case "+":
                    result = x + y;
                    break;
                case "-": 
                    result = x - y;
                    break;
                case "*":
                    result = x * y;
                    break;
                case "/":
                    result = x / y;
                    break;
                case "min":
                    result = GetMin(x, y);
                    break;
                case "max":
                    result = GetMax(x, y);
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        private static int GetNumber(string text)
        {
            Console.WriteLine(text);
            while(true)
            {
                string strInput = Console.ReadLine();
                int result;
                if (Int32.TryParse(strInput, out result))
                    return result;
                else
                    Console.WriteLine("Неправильный формат числа. Попробуйте еще раз");
            }
        }

        static int GetMax(int a, int b)
        {
            int max = 0;
            if (a > b)
                max = a;
            else if (a < b)
                max = b;
            return max;
        }

        static int GetMin(int a, int b)
        {
            int min = 0;
            if (a < b)
                min = a;
            else if (a > b)
                min = b;
            return min;
        }
    }
}