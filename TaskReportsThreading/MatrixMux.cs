using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskReportsThreading
{
    public class MatrixMux
    {

        //Замеры времени, не реализовано пока
        public TimeSpan Span { get; private set; }
        private DateTime _startTS;
        private DateTime _endTS;

        // Матрицы        
        int[,] matrixA;
        int[,] matrixB;
        int[,] matrixC;

        int matrixLength;

        Random rnd = new Random();

        // конструктор без параметров
        public MatrixMux()
        {
            // Создаем матрицы, по заданию на 100*100
            InitMatrix(100);
        }

        public MatrixMux(int matrixLength)
        {
            // Создаем матрицы нужного размера
            InitMatrix(matrixLength);
        }


        public static void Lesson6()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Урок №6, Умножение матриц, матрицы заполнены случайными числами\n");
            Console.WriteLine("Задание: Даны 2 двумерных матрицы. Размерность 100х100, 500х500 и 1000х1000 каждая. Напишите приложение, производящее параллельное умножение матриц. Матрицы заполняются случайными целыми числами от 0 до 255.\n");
            Console.ResetColor();

            // ----------------------
            // Тест умножения матриц 3х3 = 1,2,3, результат 6,12,18
            Console.WriteLine("Вычисление тестовой матрицы 3х3 для проверки корректности счета:");
            int[,] matrixA = new int[3, 3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            int[,] matrixB = new int[3, 3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };

            MatrixMux matrixMux = new MatrixMux(3);
            int[,] matrixC = matrixMux.ParallelMatrixMux(matrixA, matrixB);

            matrixMux.Print(matrixC);

            Console.WriteLine("3 элементов требует на параллельные вычисления:" + matrixMux.Span.TotalMilliseconds + "ms\n");
                       
            // ТЕСТ
            // 100 элементов
            matrixMux = new MatrixMux(100);
            // конструктор по умолчанию использует матрицы со случайными числами
            matrixC = matrixMux.ParallelMatrixMux();

            Console.WriteLine("100 Элементов требует на параллельные вычисления:" + matrixMux.Span.TotalMilliseconds + "ms\n");

            // 500 элементов
            matrixMux = new MatrixMux(500);
            // конструктор по умолчанию использует матрицы со случайными числами
            matrixC = matrixMux.ParallelMatrixMux();

            Console.WriteLine("500 Элементов требует на параллельные вычисления:" + matrixMux.Span.TotalMilliseconds + "ms\n");

            // 1000 элементов
            matrixMux = new MatrixMux(1000);
            // конструктор по умолчанию использует матрицы со случайными числами
            matrixC = matrixMux.ParallelMatrixMux();

            Console.WriteLine("1000 Элементов требует на параллельные вычисления:" + matrixMux.Span.TotalMilliseconds + "ms\n");

            Console.ReadKey();
        }

        private void InitMatrix(int length)
        {

            matrixLength = length;

            matrixA = new int[length, length];
            matrixB = new int[length, length];
            matrixC = new int[length, length];

            // Заполнение матриц случайными числами (0-255)
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                {
                    matrixA[i, j] = rnd.Next(0, 256);
                    matrixB[i, j] = rnd.Next(0, 256);
                }
        }

        // вычисление со случайными числами
        public int[,] ParallelMatrixMux()
        {
            return ParallelMatrixMux(matrixA, matrixB);
        }

        // общий метод с запросом матриц
        public int[,] ParallelMatrixMux(int[,] matrixA, int[,] matrixB)
        {
            _startTS = DateTime.Now;

            // Под конец попалась ссылка с docs.microsoft.com, вариант 3 подглядел там
            // https://docs.microsoft.com/ru-ru/dotnet/standard/parallel-programming/how-to-write-a-simple-parallel-for-loop
            // Вариант 4 - на ХАБРе

            // Первоначальный вариант, Вариант 1 - для матриц 1000*1000 - 5909мс
            //// Умножение матриц тремя вложенными циклами, 2 верхних цикла работают параллельно
            //Parallel.For(0, matrixLength, raw =>
            //{
            //    Parallel.For(0, matrixLength, column =>
            //    {
            //        for (int j = 0; j < matrixLength; j++)
            //            matrixC[raw, column] += matrixA[raw, j] * matrixB[j, column];
            //    });
            //});

            // Вариант 2 - для матриц 1000*1000 - 5241мс
            // Умножение матриц тремя вложенными циклами, 1 цикл работает параллельно
            //Parallel.For(0, matrixLength, raw =>
            //{
            //    for(int column = 0; column < matrixLength; column++)
            //    {
            //        for (int j = 0; j < matrixLength; j++)
            //            matrixC[raw, column] += matrixA[raw, j] * matrixB[j, column];
            //    };
            //});

            //  Вариант 3 - для матриц 1000*1000 - 3945мс
            // Запись в массив С через временную переменную
            //Parallel.For(0, matrixLength, raw =>
            //{
            //    for (int column = 0; column < matrixLength; column++)
            //    {
            //        int temp = 0;

            //        for (int j = 0; j < matrixLength; j++)
            //            temp += matrixA[raw, j] * matrixB[j, column];

            //        matrixC[raw, column] = temp;
            //    };
            //});

            //  Вариант 4 - итог - для матриц 1000*1000 - 2616мс
            // Транспонирование матрицы для использования кэш возможностей процессора
            // 
            int[,] matrixTB = new int[matrixLength, matrixLength];

            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    matrixTB[i, j] = matrixB[j, i];
                }
            }

            Parallel.For(0, matrixLength, raw =>
            {
                for (int column = 0; column < matrixLength; column++)
                {
                    int temp = 0;

                    for (int j = 0; j < matrixLength; j++)
                        temp += matrixA[raw, j] * matrixTB[column, j];

                    matrixC[raw, column] = temp;
                };
            });


            Span = DateTime.Now - _startTS;

            return matrixC;
        }

        // Просто печать матриц на экран
        public void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                    Console.Write($"{matrix[i, j]}\t");

                Console.WriteLine();
            }
        }




    }
}
