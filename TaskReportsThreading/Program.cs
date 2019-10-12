using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TaskReportsThreading
{
    class Program
    {

        static void Main(string[] args)
        {
           
            // ТЕСТ с матрицей 3*3

            int[,] matrixA = new int[3, 3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            int[,] matrixB = new int[3, 3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };

            MatrixMux matrixMux = new MatrixMux(3);
            int[,] matrixC = matrixMux.ParallelMatrixMux(matrixA, matrixB);

            Console.WriteLine("3 элементов требует на параллельные вычисления:" + matrixMux.Span.TotalMilliseconds + "ms");
            matrixMux.Print(matrixC);

            // ТЕСТ
            // 100 элементов
            matrixMux = new MatrixMux(100);
            // конструктор по умолчанию использует матрицы со случайными числами
            matrixC = matrixMux.ParallelMatrixMux();

            Console.WriteLine("100 Элементов требует на параллельные вычисления:" + matrixMux.Span.TotalMilliseconds + "ms");

            // 500 элементов
            matrixMux = new MatrixMux(500);
            // конструктор по умолчанию использует матрицы со случайными числами
            matrixC = matrixMux.ParallelMatrixMux();

            Console.WriteLine("500 Элементов требует на параллельные вычисления:" + matrixMux.Span.TotalMilliseconds + "ms");

            // 1000 элементов
            matrixMux = new MatrixMux(1000);
            // конструктор по умолчанию использует матрицы со случайными числами
            matrixC = matrixMux.ParallelMatrixMux();

            Console.WriteLine("1000 Элементов требует на параллельные вычисления:" + matrixMux.Span.TotalMilliseconds + "ms");

            Console.ReadKey();



        }







    }



}
