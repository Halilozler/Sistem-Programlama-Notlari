using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3._1_CountDownEvent
{
    internal class Program
    {
        static CountdownEvent _count = new CountdownEvent(3);
        //CountdownEvent sayaç gibidir yukarıda biz o işi 3 kere yap dedik.
        static void Main(string[] args)
        {
            /*
             Bir işi n kez yaptırmak istiyorsak kullanılır.
             */
            for (int i = 0; i < 3; i++)
            {
                //3 kere yapılacağı için biz burda 3 thread göndermemiz lazım.
                new Thread(yaz).Start("Ben thread: " + i);
            }

            _count.Wait();
            //main thredi beklemye aldık 3 kere signal gelirse çalışmaya başlıcak

            Console.WriteLine("İş bitti");
            Console.ReadLine();
        }
        static void yaz(object mesaj)
        {
            Thread.Sleep(100);
            Console.WriteLine(mesaj);

            _count.Signal();
            //signal ile verilen göreven 1 tane yaptık düş demek.
        }
    }
}
