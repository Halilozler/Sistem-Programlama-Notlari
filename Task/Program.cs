using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            TASK = Hazır olarak bize verilmiş Thread havuzudur.
            Kısa süreli anlık işlerde kullanmak daha hızlıdır.

            Threadlerde t.join() metodu => Threadin işini bitirmesini bekler sonra çalışır. 
            Tasklarda t.wait() metudu aynı işlevdedir.

            Tasklar => Background threadlerdir main threadlerin bitmesini beklemez.
             */

            //task creat edip çalıştırdıkaa
            Task t = Task.Factory.StartNew(() =>
            {
                int ctr = 0;
                for (ctr = 0; ctr < 1000000; ctr++) {}
                Console.WriteLine("Finished {0} loop iterations",ctr);
            });
            t.Wait();
            //main thread t threadinin işinin bitirmesini bekler.

            //3 dizi bir task oluşturmak istiyorsak:
            var tasks = new Task[3];
            var rnd = new Random();

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() => Thread.Sleep(rnd.Next(100,1000)));
            }

            int index = Task.WaitAny(tasks); //ilk çıkanın indexini verir.
             
            Task.WaitAll(tasks); //bütün tasks bitmesini bekler.

            Console.ReadLine();
        }
    }
}
