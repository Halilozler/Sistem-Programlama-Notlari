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
        private static int _count2 = 3;
        private static int _count3 = 0;
        static Object obj1 = new Object();
        static void Main(string[] args)
        {
            //semephore beklemesini interlocked ile yapalım mesela bizim kritik alana 3 nesne girsin
                                                                                        
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(go);
                t.Name = (i + 1).ToString();
                t.Start();
            }

            Console.ReadLine();
        }
        static void go()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " geldi");
            
            Interlocked.Decrement(ref _count2);
            Interlocked.CompareExchange(ref _count2, -1, -2);


            while (Interlocked.CompareExchange(ref _count2, _count2, _count2) < 0)
            {
                Thread.Sleep(Int32.Parse(Thread.CurrentThread.Name) * 20);
            }
            lock (obj1)
            {
                if (_count3 == 1)
                {
                    Interlocked.Decrement(ref _count2);
                }
            }
            
            Console.WriteLine(Thread.CurrentThread.Name + " içeri girdi kritik alanda");
            Thread.Sleep(1000);

            Console.WriteLine(Thread.CurrentThread.Name + " kritik alandan çıktı");
            
            Interlocked.Exchange(ref _count3,1);
            Interlocked.Increment(ref _count2);
        }
    }
}
