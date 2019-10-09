using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskReportsThreading
{
    class Program
    {

        static object lockObject = new object();
        static double result;
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №1 к уроку №5, Многопоточное программирование\n Выход по нажатию Q.");

            while (true)
            {
                if (Console.KeyAvailable == false)
                    Thread.Sleep(200);

                Console.Write($"Введите положительное число:");
                string input = Console.ReadLine();
                if (input == "Q" || input == "q" || input == "й" || input == "Й")
                    break;

                int inputNumber = 0;
                //Console.WriteLine($"Рекурсивный факториал: {Factorial(inputNumber)}");
                if (int.TryParse(input, out inputNumber))
                {
                    Console.WriteLine("\nВычисление факториала в отдельном потоке:");
                    Console.WriteLine($"Параллельный факториал: {ParallelFactorial(inputNumber)}");

                    Console.WriteLine("\nВычисление суммы целых чисел в отдельном потоке:");
                    Console.WriteLine($"Сумма целых чисел: {ParallelSum(inputNumber)}\n");
                }

            }
        }


        // ----------------
        // Факториал
        static double ParallelFactorial(int number)
        {
            double result = 1;

            int cpuCount = Environment.ProcessorCount;
            if (number <= cpuCount) result = Factorial(number);
            else
            {
                var tasks = new List<Thread>();
                for (int i = 0; i < number; i += number / cpuCount)
                {
                    int right = (i + number / cpuCount) > number ? number : i + number / cpuCount;
                    int left = i + 1;
                    tasks.Add(new Thread(() =>
                    {
                        double res = FactorialFromTo(left, right);
                        lock (lockObject)
                        {
                            result *= res;
                        }
                    }));
                }
                foreach (var item in tasks)
                {
                    item.Start();
                }
                foreach (var item in tasks)
                {
                    item.Join();
                }
            }
            return result;
        }
        static double Factorial(int number)
        {
            if (number == 0) return 1;
            return number * Factorial(number - 1);
        }

        static double FactorialFromTo(int start, int finish)
        {
            double result = start == 0 ? 1 : start;
            while (start < finish)
            {
                result *= (start + 1);
                start++;
            }
            return result;
        }

        // ----------------
        // Сумма чисел
        static double ParallelSum(int number)
        {
            double result = 0;

            int cpuCount = Environment.ProcessorCount;
            if (number <= cpuCount) result = SumFromTo(1, number);
            else
            {
                var tasks = new List<Thread>();
                for (int i = 0; i < number; i += number / cpuCount)
                {
                    int right = (i + number / cpuCount) > number ? number : i + number / cpuCount;
                    int left = i + 1;
                    tasks.Add(new Thread(() =>
                    {
                        double res = SumFromTo(left, right);
                        lock (lockObject)
                        {
                            result += res;
                        }
                    }));
                }
                foreach (var item in tasks)
                {
                    item.Start();
                }
                foreach (var item in tasks)
                {
                    item.Join();
                }

            }
            return result;
        }
        static double SumFromTo(int start, int finish)
        {
            double result = start;
            while (start < finish)
            {
                result += start + 1;
                start++;
            }
            return result;
        }


    }



}
