using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1_Thread
{
    internal class Program
    {
        static readonly Object obj1 = new Object();
        static bool dogru;
        static int adt;
        static int d;
        static void Main(string[] args)
        {
            /*
            new Thread(go).Start();
            go();*/

            /****************************** Join - Sleep ****************************************/
            /* Join (threadimizin işlemini bitirmesini bekleriz)*/
            Thread t = new Thread(joinVsleep);
            t.Start();
            t.Join();   //t threadimizin bitmesini bekleriz.

            //2.Yöntem.
            //Thread.Sleep(10000);
            //main threadimizi uykuya alabiliriz.

            //3.Yöntem.
            //while (d < 0) ;
            //bu yöntem ile diğer taraftan d değişkeni değişesiye kadar main thredi meşgul ederiz kötü bir yoldur. main thread hep çalışmak durumundadır.

            //eğer beklemeseydik maininmiz direk olarak buraya gelirdi diğer thread daha işini bitirmeden main işini bitirir adt = 0 yazardı.
            Console.WriteLine(adt);
            /**********************************************************************/


            /******************************* thread metoduna veri göndermek ***************************************/
            new Thread(() => veriVer("selammmm")).Start();

            //direk olarak metoduda yazabiliriz.
            new Thread(() =>
            {
                Console.WriteLine("mesaj merhaba");
            }).Start();

            //başka bir yol olarak start() kısmındanda mesajı gönderebiliriz.
            new Thread(veriVer).Start("start kısmından gönderdim daha rahat oldu be AMA BURADA OBJECT E VERİ GÖNDERİLİR UNUTMA");
            /**********************************************************************/


            /******************************* thread adlandırma ***************************************/
            Thread t2 = new Thread(yaz);
            t2.Name = "adi";
            t2.Start();
            //ad vermiş olduk bu ile çağıramayız tabikide ama kontrol edebiliriz.

            //adını sorarak öğrenmeliyiz:
            Console.WriteLine(t2.CurrentCulture.Name);
            //sorduk ve bize adını söyledi

            Console.WriteLine("********************************************************");
            //örnek: 10 tane thread oluştur ve bunlara ad ver 0 sayısından başlayarak 100 e kadar threadler sıra ile saydıralım
            for (int i = 0; i < 10; i++)
            {
                Thread t3 = new Thread(saydirma);
                t3.Name = i.ToString();
                t3.Start();
            }

            /**********************************************************************/



            /******************************** Hata Yönetimi **************************************/

            //hata yöneetimi her thread içinde kendi olur yani main içine try except yazıp thredin metodunda hata arayamayız hangi thread hangi metodu çalıştırıyorsa ona göre o metodun içinde hata yönetimi yapmalıyız.

            /**********************************************************************/


            /********************************* FATEGROUND VE BACKGROUND *************************************/
            //Fateground: default olan threadeki değerimiz yani anlamı işi bitince thread kapanır main kapansa bile devam eder.
            //Background: main kapandığı an kapanır işim varmış yokmuş bakmaz.

            //backgroun tanımlamak için.
            Thread t4 = new Thread(() => { Thread.Sleep(3000); Console.WriteLine("bura girdim çalıştırdım"); });
            t4.IsBackground = true;
            /*********************************************************************
            Thread.Sleep(2500);
            for (int i = 0; i < 10; i++)
            {
                new Thread(saydirma2).Start();
            }*/
            t4.Start();
            t4.Join();

            //Console.ReadLine();
        }

        static void go()
        {
            //lock ile kritik alana sadece 1 thread sokarız o thread işini bitirincee diğer sırada bekleyen thread alana girer.
            lock (obj1)
                if (!dogru)
                {
                    dogru = true;
                    Console.WriteLine("girdi");
                }

        }

        static void joinVsleep()
        {
            //join: ile belirtilen threadın bitmesini bekleriz.
            //sleep: ile threadımızı uyutabiliriz.
            for (int i = 0; i < 10000000; i++)
            {
                adt++;
            }
            d++;
        }

        static void veriVer(object mesaj)
        {
            Console.WriteLine("mesaj " + mesaj);
        }

        static void yaz()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Merhaba");
        }

        static void saydirma()
        {
            int name = Int32.Parse(Thread.CurrentThread.Name);
            Thread.Sleep(name * 10);
            Console.WriteLine(name);
        }

        static int sayi = 0;
        static int sayi2 = 0;
        static int sayi3 = 0;
        static object obj2 = new object();
        static AutoResetEvent _event = new AutoResetEvent(true);
        static void saydirma2()
        {
            /*
            lock (obj2)
            {
                Console.WriteLine(sayi);
                Interlocked.Increment(ref sayi);
            }*/

            /*yada

            _event.WaitOne();
            Console.WriteLine(sayi);
            Interlocked.Increment(ref sayi);
            _event.Set();*/

            while (Interlocked.CompareExchange(ref sayi, 0, sayi2) != 0) ;
            Interlocked.Increment(ref sayi);

            Console.WriteLine(sayi3);
            Interlocked.Increment(ref sayi3);

            Interlocked.Exchange(ref sayi2, 1);
        }
    }
}
