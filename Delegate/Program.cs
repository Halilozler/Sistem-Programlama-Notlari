using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Program
    {
        delegate int dortislem(int a, int b);  
       
        static int topla(int a1, int b1) { return a1 + b1; }
        static int carp(int a1, int b1) { return a1 * b1; }
        static void myMethod(int a, int b, dortislem di) { Console.WriteLine(di(a,b)); }

        static void Main(string[] args)
        {
            /* Delaget ile pointer bir işaretçi oluştururuz.
             
                Action ve function diye 2 tane microsoftun bize sunudğu hazır pointer vardır 
                Action -> geriye değer döndürmeyen(void)
                function -> geriye değer döndüren.

             * Her Gelegatenin kendine özgü imzası vardır.
             */

            dortislem di = topla;
            di(2, 3); //5

            di = carp;
            di(3, 2); //6

            myMethod(3, 2, di); //6
            myMethod(3, 2, topla);  //5

            //a,b,sonuç çıktısı 
            Func<int, int, int> d1 = topla;
            //a , b , di direk istenen verileri alır.
            Action<int, int, dortislem> d2 = myMethod;

            //yada lamba ile metod oluşturabiliriz.
            Func<int, int> square = x => x * x;

            Console.WriteLine(square(5)); //5 çıktı

            Func<int, int, int> topla2 = (a,b) => a + b;

            Console.ReadLine();
        }

    }
}
