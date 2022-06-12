using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Denemeler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Parallel.For: main threade bloke atar for döngüsü bittikten sonra main çalışmaya başlar.
            /*
            Console.WriteLine("girdi");
            Parallel.For(0, 8, (i) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("çıktı");
            });

            Console.WriteLine("Main  bitti");
            Console.ReadLine();
            */

            object locker1 = new object();
            object locker2 = new object();
            Console.WriteLine("1");
            new Thread(() =>
            {
                lock (locker2)
                {
                    Console.WriteLine("2");
                    Thread.Sleep(1000);
                    lock (locker1) ;
                    Console.WriteLine("3");
                }
            }).Start();

            lock (locker2)
            {
                Console.WriteLine("4");
                Thread.Sleep(1000);
                lock (locker2) ;
                Console.WriteLine("5");
            }

            Console.WriteLine("6");

            Console.ReadLine();
        }
    }
}
