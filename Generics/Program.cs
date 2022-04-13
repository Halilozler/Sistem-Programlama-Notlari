using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            araba _a = new araba();
            araba _b = new araba();

            bisiklet _c = new bisiklet();
            bisiklet _d = new bisiklet();

            birlesim<araba,bisiklet> _birlesim = new birlesim<araba,bisiklet>();
            _birlesim._araba = _a;
            _birlesim._bisiklet = _d;

            _birlesim.surdum<string>("bu mesajı yazdım");
            _birlesim.surdum<int>(6);
        }
        interface bin { }
        class araba : bin { }
        class bisiklet : bin { }

        class birlesim<T, B> 
            where T : araba, bin
            where B : bisiklet, bin
        {
            public T _araba { get; set; }
            public B _bisiklet { get; set; }

            public void surdum<A>(A yaz)
            {
                Console.WriteLine(yaz);
            }
        }
    }
}
