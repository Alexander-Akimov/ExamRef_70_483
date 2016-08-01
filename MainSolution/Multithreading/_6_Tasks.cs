using System;
using System.Threading.Tasks;

namespace Multithreading
{
    public class _6_Tasks
    {
        public static void Main5(string[] args)
        {
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.WriteLine("*");
                }
            });
            t.Wait();
            //ReturnValue();
            //ContinuationTask();
            ContinuationTask2();

            Console.ReadLine();
        }

        public static void ReturnValue()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });
            Console.WriteLine(t.Result);
        }

        public static void ContinuationTask()
        {
            Task<int> t = Task.Run(() =>
             {
                 return 42;
             }).ContinueWith((i) =>
             {
                 return i.Result * 2;
             });
            Console.WriteLine(t.Result);
        }
        public static void ContinuationTask2()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith(i => {
                Console.WriteLine($"Completed {i.Result}");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();
        }
    }
}