using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    class _8_TaskFactory
    {
        public static void Main(string[] args)
        {
            Task<List<int>> parent = Task.Run(() =>
            {
               // var results = new Int32[3];
                List<int> results = new List<int>();

                TaskFactory tf = new TaskFactory(
                    TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously);

                //tf.StartNew(() => results[0] = 0);
                //tf.StartNew(() => results[1] = 1);
                //tf.StartNew(() => results[2] = 2);

                tf.StartNew(() => results.Add(0));
                tf.StartNew(() => results.Add(1));
                tf.StartNew(() => results.Add(2));

                return results;
            });

            var finalTask = parent.ContinueWith(
                parentTask =>
                {
                    foreach (int i in parentTask.Result.ToArray())
                        Console.WriteLine(i);
                });

            finalTask.Wait();

            Console.ReadLine();
        }
    }
}
