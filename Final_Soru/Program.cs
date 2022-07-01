using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Final_Soru
{
    internal class Program
    {
        static int adet = 10;
        static CountdownEvent _count = new CountdownEvent(10);
        static void Main(string[] args)
        {
            //10 adet task oluşturun bunu waitAll(), Sleep() kullanmadan main bu 10 adet taskı beklesin sonra çalışmaya devam etsin.
            //2 yöntem ile yapınız.

            //1. Yöntem (Interlock ile)
            for (int i = 0; i < 10; i++)
            {
                Task t1 = new Task(YontemBir);
                t1.Start();
            }

            Console.WriteLine("Bekliyor");

            while (Interlocked.CompareExchange(ref adet, 1, 20) != 1) ;

            Console.WriteLine("Çıktı-1");
            /***************************************************************************************/

            //2.yöntem CountDownEvent() ile.
            for (int i = 0; i < 10; i++)
            {
                Task t2 = new Task(Yontemİki);
                t2.Start();
            }

            Console.WriteLine("Bekliyor");

            _count.Wait();

            Console.WriteLine("Çıktı-2");

            Console.ReadLine();
        }

        static void YontemBir()
        {
            Console.WriteLine("Task Bitti");
            Interlocked.Increment(ref adet);
        }

        static void Yontemİki()
        {
            Console.WriteLine("Task Bitti");
            _count.Signal();
        }
    }
}
