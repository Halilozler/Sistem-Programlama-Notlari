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
        private static int _count2 = 4;
        private static int _count3 = 0;
        static Object obj1 = new Object();
        static void Main(string[] args)
        {
            //semephore beklemesini interlocked ile yapalım mesela bizim kritik alana 3 nesne girsin
                                                                                        
            for (int i = 0; i < 6; i++)
            {
                Thread t = new Thread(go);
                t.Name = "Thread: " + i.ToString();
                //Thread.Sleep(100);
                t.Start();
            }

            Console.ReadLine();
        }
        static void go()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " geldi");
            /*3 tane girebilsin
            
            if(Interlocked.Increment(ref _count2) >= 4)
            {
                Interlocked.Exchange(ref _count, 0);
            }
            Thread.Sleep(100);
            //count -> 0 ise bekliyor
            //count -> 1 ise beklemeden geçiyor veya 2 de
            while (Interlocked.CompareExchange(ref _count, 0, 0) == 0)
            {
                Thread.Sleep(50);
            }

            if (Interlocked.CompareExchange(ref _count, 2, 2) == 2)
            {
                Interlocked.Increment(ref _count2);
            }


            Console.WriteLine(Thread.CurrentThread.Name + " içeri girdi kritik alanda");
            Thread.Sleep(2000);

            
            Console.WriteLine(Thread.CurrentThread.Name + " kritik alandan çıktı");
            //Console.WriteLine("düşürdüm: " + Interlocked.Decrement(ref _count));

            
            Interlocked.Exchange(ref _count, 2);
            Interlocked.Decrement(ref _count2);

            //if(Interlocked.Decrement(ref _count2) < 4)
            //{
            //    Interlocked.Exchange(ref _count, 2);
            //}
            //else
            //{
            //    Interlocked.Exchange(ref _count, 0);
            //}
            */

            Interlocked.Decrement(ref _count2);
            Interlocked.CompareExchange(ref _count2, 1, -1);

            while (Interlocked.CompareExchange(ref _count,0,_count2) <= 0)
            {
                Thread.Sleep(10);
            }
            

            Console.WriteLine(Thread.CurrentThread.Name + " içeri girdi kritik alanda");
            Thread.Sleep(2000);

            Console.WriteLine(Thread.CurrentThread.Name + " kritik alandan çıktı");
            
            Interlocked.Exchange(ref _count, 1);
            Interlocked.Exchange(ref _count3, 1);
            Interlocked.Increment(ref _count2);
        }
    }
}
