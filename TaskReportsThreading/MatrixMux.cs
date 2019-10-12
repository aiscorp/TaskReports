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
        public TimeSpan timeSpan { get; private set; }
        DateTime _startTS;
        DateTime _endTS;

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

            // Умножение матриц тремя вложенными циклами, 2 верхних цикла работают параллельно
            Parallel.For(0, matrixLength, raw =>
            {
                //Parallel.For(0, matrixLength, column => Multiply(matrixC, column, raw, matrixLength));
                Parallel.For(0, matrixLength, column =>
                {
                    for (int j = 0; j < matrixLength; j++)
                        matrixC[raw, column] += matrixA[raw, j] * matrixB[j, column];
                });
            });

            timeSpan = DateTime.Now - _startTS;

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
