using System.Collections.Generic;
using System.Threading.Tasks;

namespace someLib
{
    public class classEvenNumber
    {
        static public void EvenNumber (int number)
        {
            if (number % 2 == 0)
            {
                System.Threading.Thread.Sleep(400);
                System.Console.WriteLine("Число {0} чётное",number);
            }
        }

        static public void notParallelFor()
        {
            for (int i = 1; i <= 30; i++)
            {
                EvenNumber(i);
            }
        }

        static public void ParallelFor()
        {
            Parallel.For(1, 31, EvenNumber);
        }

        static public void ParallelForEach()
        {
            List<int> listNumber = new List<int>();
            for (int i = 1; i <= 20; i++)
                listNumber.Add(i);
            Parallel.ForEach<int>(listNumber, EvenNumber);
        }
    }
}
