using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3._1._1_Onekler
{
    internal class Program
    {
        static EventWaitHandle _TekautoReset = new AutoResetEvent(true);
        static EventWaitHandle _CiftautoReset = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            new Thread(tek).Start();
            new Thread(cift).Start();

            Console.ReadLine();
        }
        static void tek()
        {
            for (int i = 1; i < 100; i = i + 2)
            {
                _TekautoReset.WaitOne();
                Console.WriteLine(i);
                _CiftautoReset.Set();
            }
        }
        static void cift()
        {
            for (int i = 2; i < 100; i = i + 2)
            {
                _CiftautoReset.WaitOne();
                Console.WriteLine(i);
                _TekautoReset.Set();
            }
        }
    }
}
