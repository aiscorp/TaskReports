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
        static void Main(string[] args)
        {
            Thread current_tread = Thread.CurrentThread;
            Console.WriteLine("Thread {0}(id:{1}) running", current_tread.Name, current_tread.ManagedThreadId);

            var clock_thread = new Thread(ClockUpdater);
            clock_thread.Start();
            clock_thread.Priority = ThreadPriority.Lowest;

            Console.ReadKey();

            clock_thread.Abort();
        }


        private static void ClockUpdater()
        {
            Thread current_tread = Thread.CurrentThread;
            Console.WriteLine("Thread {0}(id:{1}) running", current_tread.Name, current_tread.ManagedThreadId);
            while (true)
            {
                Console.Title = DateTime.Now.ToString("yyyy-MM-dd - hh:mm:ss");
                Thread.Sleep(100);
            }
        }


    }

    class ThreadTimer
    {


    }


}
