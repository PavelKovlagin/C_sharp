using System;
using someLib;

namespace someProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Без параллелизма");
            classEvenNumber.notParallelFor();

            Console.WriteLine("С параллелизмом");
            classEvenNumber.ParallelFor();

            Console.ReadLine();
        }
    }
}
