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
        TimeSpan timeSpan;
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
            matrixLength = 100;
            int[,] matrixA = new int[matrixLength, matrixLength];
            int[,] matrixB = new int[matrixLength, matrixLength];            

            // Заполнение матриц случайными числами (0-255)
            Random rnd = new Random();
            for (int i = 0; i < matrixLength; i++)
                for (int j = 0; j < matrixLength; j++)
                {
                    matrixA[i, j] = rnd.Next(0, 256);
                    matrixB[i, j] = rnd.Next(0, 256);
                }
        }

        public int[,] ParallelMatrixMux(int[,] matrixA, int[,] matrixB)
        {
            _startTS = DateTime.Now;

            // Умножение матриц

            
            timeSpan = DateTime.Now - _startTS;
            
            return matrixC;            
        }





    }
}
