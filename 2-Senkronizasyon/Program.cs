using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2_Senkronizasyon
{
    internal class Program
    {
        static readonly Object kilit = new Object();
        static readonly Object kilit2 = new Object();
        static int _val1, _val2;
        static void Main(string[] args)
        {
            /*
             Bizim 4 tane senkronizasyon nesnemiz vardır.
            1-lock = monitor
            2-Mutex
            3-Semaphore

            Kilitlemek belirtiğimiz alana Semaphore dışında sadece 1 tane thread sokarız o alandan çıktığında sırada bekleyen thread içeri girer böylece yalnızca 1 tane thread erişmesini sağlarız.

            Semaphorda ise bizim belirtiğimiz kadar thread alana girebilir.

            Çalışma Süreleri -> 
                lock/monitor ->     20
                Mutex ->            1000
                SemaphoreSlime->    200
                semaphore->         1000
                
            ******GLOBAL YANİ BİR DEĞERE BİRDEN FAZLA THREAD DEĞİŞİKLİK YAPIYOSA AYNI ANDA BU ALANDA SENKRONİZASYON NESNELERİ KULLANILMALIDIR.******
            */


            //Lock:
            //kritik alana yalnızca 1 tane thredi sokar o ii bitiğinde çıkar tanımlaması basitir object tanımlarsın bir tane kilit diye direk olarak kritik alanı içine alırsın.

            /************************** 1-Lock ***************************************************/

        }
        static void _lock()
        {
            lock (kilit) //direk olarak kilitleriz.
            {
                if(_val2 != 0)
                    Console.WriteLine(_val1 / _val2);
                _val2 = 0;
            }

            //iç içe lock atılabilir
            lock (kilit) 
            {
                lock (kilit)
                {
                    if (_val2 != 0)
                        Console.WriteLine(_val1 / _val2);
                    _val2 = 0;
                }
            }
        }

        static void _monitor()
        {
            //lock ile aynıdır tanımlamasında ise:
            //Monitor.Enter(kilit)  -> ile kritik alan belirlenir.
            //Monitor.Exit(kilit)   -> ile kritik alandan çıktığını belirtir.   

            Monitor.Enter(kilit);

            if (_val2 != 0)
                Console.WriteLine(_val1 / _val2);
            _val2 = 0;

            Monitor.Exit(kilit);
        }

        static void _deadlock()
        {
            /*
             deadlock düşer isek program kitlenir dışaran müdahale ile kapatmak zorunda kalırız.
                nasıl olur peki:
                    En az 2 tane lock lazımdır. Bunlar açılmak için birbirinden komut bekler isek hiçbir zaman açılmazlar sıkıntı bir durumdur.
             */ 
            new Thread(() =>
            {
                lock (kilit)
                {
                    Thread.Sleep(1000);
                    lock (kilit2) ; //kilit 2 nin açılmasını bekliyor
                }
            }).Start();

            lock (kilit2)
            {
                Thread.Sleep(1000);
                lock (kilit) ; //kilit 1 in açılmasını bekliyor
            }
        }
    }
}
