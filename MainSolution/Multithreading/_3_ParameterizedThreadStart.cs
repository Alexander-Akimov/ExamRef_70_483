using System;
using System.Threading;

namespace Multithreading
{
    public class _3_ParameterizedThreadStart
    {
        public static void ThreadMethod(object objNum)
        {
            for (int i = 0; i < (int)objNum; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(1000);
            }
        }

        public static void Main(string[] args)
        {
            Thread t= new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);
            t.Join();
        }
    }
}