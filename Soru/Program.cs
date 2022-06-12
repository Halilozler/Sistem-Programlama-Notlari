using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Soru
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread((object obj) => { Console.WriteLine(obj); });
            t.Start("selam");
            t.Join();
            Console.ReadLine();
        }
    }
}
