using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace someLib
{
    public class DayNumber
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
    }
}