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
            // При работе с матрицей будем выводить результат в файл
            StreamWriter outputFile = new StreamWriter("log.txt");



            MatrixMux matrixMux = new MatrixMux();


            //int[,] matrixC = matrixMux.ParallelMatrixMux();



            Console.ReadKey();



        }


        




    }



}
