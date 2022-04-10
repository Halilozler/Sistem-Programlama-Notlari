using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemCalisma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 100, (i) =>
              {
                  Console.WriteLine(i);
              });
            Console.ReadLine();
        }
    }
}
