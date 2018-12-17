using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace someLib
{
    public class someClass
    {

        public string getDatByWeek(int dayNumber)
        {
            Hashtable week = new Hashtable();
            week[1] = "Понедельник";
            week[2] = "Вторник";
            week[3] = "Среда";
            week[4] = "Четверг";
            week[5] = "Пятница";
            week[6] = "Суббота";
            week[7] = "Воскресенье";
            return week[dayNumber] as string;
        }

        public int sum(int x, int y)
        {
            return x + y;
        }

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

        public double div (double x, double y)
        {
            if (y == 0) throw new DivideByZeroException();
            return x / y;
        }
    }

}
