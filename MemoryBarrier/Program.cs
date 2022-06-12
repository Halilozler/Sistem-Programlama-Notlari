using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryBarrier1
{
    internal class Program
    {
        int _answer;
        bool _complete;
        static void Main(string[] args)
        {
            //memoryBarrier ile sıra ile çalıştırmayı sağlarız kodları. Yani burada _answer = 123 ile kaydedikten sonra _complete = true yapıcak. 
        }
        void A()
        {
            _answer = 123;
            Thread.MemoryBarrier();     // Barrier 1
            _complete = true;
        }
        void B()
        {
            if (_complete)
            {
                Thread.MemoryBarrier();       // Barrier 2
                Console.WriteLine(_answer);     
            }
        }
    }
}
