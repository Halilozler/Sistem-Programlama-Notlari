using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._1_Mutex
{
    internal class Program
    {
        static Mutex mutex = new Mutex();
        static void Main(string[] args)
        {
            /*
             Mutex Lock sınıfından 50 kat daha yavaştır.
                        Kilitlmek için -> WaitOne
                        Kilidi açmak için -> ReleaseMutex 
            yöntemleri kullanılır.
             */

            for (int i = 0; i < 3; i++)
            {
                Thread t = new Thread(_mutex);
                t.Name = i.ToString();
                t.Start();
            }

            Console.ReadLine();
        }
        static void _mutex()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " geldi");

            mutex.WaitOne(); //kritik alanı belirtiyoruz tek bir thread girebiliyor diğerleri sırada

            Console.WriteLine(Thread.CurrentThread.Name + " kritik alana girdi");
            Thread.Sleep(1000);

            mutex.ReleaseMutex(); //kritik alandan çıktığını belirtiyoruz.
            Console.WriteLine(Thread.CurrentThread.Name + " kritik alandan çıktı");
        } 
    }
}
