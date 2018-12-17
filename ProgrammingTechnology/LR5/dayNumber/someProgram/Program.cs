using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using someLib;

namespace someProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            someClass some = new someClass();
            Console.WriteLine(some.sum(2, 2));
            Console.WriteLine(some.div(4, 2));
            Console.WriteLine(some.div(4, 0));
            Console.WriteLine(some.div(4.0, 0));
            Console.ReadLine();
        }
    }
}
