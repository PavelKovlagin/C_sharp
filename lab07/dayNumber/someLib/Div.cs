using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace someLib
{
    public class Div
    {
        public int div(int x, int y)
        {
            try
            {
                return x / y;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public double div(double x, double y)
        {
            if (y == 0) throw new DivideByZeroException();
            return x / y;
        }
    }
}
