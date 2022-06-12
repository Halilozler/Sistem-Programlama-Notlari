using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3_Event_Wait_Handles
{
    internal class Program
    {
        static EventWaitHandle _autoReset = new AutoResetEvent(false);
        //(false) olması ilk başta kapımız kapalı olsun sonra biz bilet vererek içeri alalım.
        //(true) olsaydı direk olarak biri geçer sonra kaanırdı sistemimiz.
        static void Main(string[] args)
        {
            /*
             Event wait Handles ile threada verdiğimiz sinyal ile kritik alana girmesini sağlarız.
            2 Yöntem vardır:
                    1-AutoResetEvent:
                            tam olarak turnike gibidir kapı ilk başta kapalıdır bilet aldığında yalnızca tek kişinin geçmesine izin verir o işini bitirdikten sonra bilet alan başkası geçer.
                    2-ManuelResetEvent
                            AutoResetEvent ile tek farkı kapı açıldığında bekleyen bütün theadler geçer bunu bilemeyiz.
                            !!!yani kapı bir kere açıldığında kapanana kadar hepsi geçer.

                            Reset ile kapıyı kapatmamız lazım yoksa kapı hep açık kalır.

             */

                //waitOne   -> ile turnike koyarız.
                //set       -> ile bilet veririz.

            /******************************** AutoResetEvent ********************************************/
            
            new Thread(_AutoResetEvent).Start();

            Thread.Sleep(3000);

            _autoReset.Set(); //bileti gönderdik

            Console.ReadLine();
        }

        static void _AutoResetEvent()
        {
            Console.WriteLine("...bekliyoruz");
            
            _autoReset.WaitOne(); //turnikemiz bileti bekliyoruz

            Console.WriteLine("girdik.");
        }
    }
}
