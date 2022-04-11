using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._2._1_SemaphoreInterlockOrnek
{
    internal class Program
    {
        private static int _count = 1;
        private static int _count2 = 0;
        static Object obj1 = new Object();
        static void Main(string[] args)
        {
            //semephore beklemesini interlocked ile yapalım mesela bizim kritik alana 3 nesne girsin
                                                                                        
            for (int i = 0; i < 6; i++)
            {
                Thread t = new Thread(go);
                t.Name = "Thread: " + i.ToString();
                Thread.Sleep(100);
                t.Start();
            }

            Console.ReadLine();
        }
        static void go()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " geldi");
            //3 tane girebilsin
            
            if(Interlocked.Increment(ref _count2) >= 4)
            {
                Interlocked.Exchange(ref _count, 0);
            }
            //Thread.Sleep(100);
            while (Interlocked.CompareExchange(ref _count, 0, 0) == 0)
            {
                Thread.Sleep(5);
            }
            Interlocked.CompareExchange(ref _count, 0, 2);


            Console.WriteLine(Thread.CurrentThread.Name + " içeri girdi kritik alanda");
            Thread.Sleep(2000);

            
            Console.WriteLine(Thread.CurrentThread.Name + " kritik alandan çıktı");
            //Console.WriteLine("düşürdüm: " + Interlocked.Decrement(ref _count));
            if(Interlocked.Decrement(ref _count) < 4)
            {
                Interlocked.Exchange(ref _count, 2);
            }
            else
            {
                Interlocked.Exchange(ref _count, 0);
            }

        }
    }
}
