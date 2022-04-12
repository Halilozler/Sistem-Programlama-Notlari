using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._2_Semaphore
{
    internal class Program
    {
        private static Semaphore _pool;
        private static int _padding;
        static void Main(string[] args)
        {
            _pool = new Semaphore(0, 3);
            for (int i = 0; i < 5; i++)
            {
                new Thread(Worker).Start();
            }

            Thread.Sleep(500);

            Console.WriteLine("Main thread calls Release(3).");
            _pool.Release(3);
            //3 elemanı biz burada kritik alana alıyoruz demektir
            //bu olmaz ise kritik alana giremeyiz.

            Console.WriteLine("Main thread exits.");
            Console.ReadLine();
        }
        private static void Worker(object num)
        {
            Console.WriteLine("Thread {0} begins " + "and waits for the semaphore.", num);
            _pool.WaitOne(); //waitone ile kritik alanı başlatırız.

            int padding = Interlocked.Add(ref _padding, 100);

            Console.WriteLine("Thread {0} enters the semaphore.", num);

            Thread.Sleep(1000 + padding);

            Console.WriteLine("Thread {0} releases the semaphore.", num);
            Console.WriteLine("Thread {0} previous semaphore count: {1}",
                num, _pool.Release());
            //release. ile kritik alandan çıktığını ifade ediyoruz.
        }
    }
}
