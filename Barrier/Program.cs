using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Barrier3
{
    internal class Program
    {
        //private static Barrier barrier = new Barrier(4);
        static void Main(string[] args)
        {
            /*
            new Thread(start).Start();
            new Thread(start).Start();
            new Thread(start).Start();
            */
            int count = 0;
            Barrier barrier = new Barrier(4, (b) =>
            {
                Console.WriteLine("Post-Phase action: count={0}, phase={1}", count, b.CurrentPhaseNumber);
                if (b.CurrentPhaseNumber == 2) throw new Exception("D'oh!");
            });

            Action action = () =>
            {
                Interlocked.Increment(ref count);
                barrier.SignalAndWait(); 
                Interlocked.Increment(ref count);
                barrier.SignalAndWait(); 

                Interlocked.Increment(ref count);
                try
                {
                    barrier.SignalAndWait();
                }
                catch (BarrierPostPhaseException bppe)
                {
                    Console.WriteLine("Caught BarrierPostPhaseException: {0}", bppe.Message);
                }

                Interlocked.Increment(ref count);
                barrier.SignalAndWait();
            };
            Parallel.Invoke(action, action, action, action);
            barrier.Dispose();

            Console.ReadLine();
        }

        static void start()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write(i + " ");
                //barrier.SignalAndWait();
                //SignalAndWait: ile belirtiğimiz 3 thradi beklemesini sağlarız.
            }
        }
    }
}
