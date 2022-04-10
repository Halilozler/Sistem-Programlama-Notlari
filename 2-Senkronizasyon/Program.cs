using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Senkronizasyon
{
    internal class Program
    {
        static readonly Object obj1 = new Object();
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
            */

            /************************** 1-Lock ***************************************************/

        }
    }
}
