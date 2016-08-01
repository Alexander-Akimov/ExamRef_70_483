using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    class _4_VariablesAndThread
    {
        public static ThreadLocal<int> _field = new ThreadLocal<int>(() =>
         {
             return Thread.CurrentThread.ManagedThreadId;
         });

        public static void Main3(string[] args)
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine($"Thread A: {x}");
                }
            }).Start();

            new Thread(() =>
             {
                 for (int x = 0; x < _field.Value; x++)
                 {
                     Console.WriteLine($"Thread B: {x}");
                 }
             }).Start();

            bool stopped = false;

            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));

            t.Start();
            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
            stopped = true;
            t.Join();
        }
    }
}
