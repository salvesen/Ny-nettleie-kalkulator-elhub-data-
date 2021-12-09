using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nettleieKalkulator1._0._0.bkk
{
    public static class relatedFunctions
    {
        public static double? weekendPower(List<DateTime> fromDate, List<double> hourlyConsumption)
        {
            try
            {
                double weekendPower = 0;
                int measurmentCounter = -1;
                //weekend saturday & sunday
                foreach (DateTime timeStamp in fromDate)
                {
                    //Increment measurment counter as we go trough them
                    measurmentCounter++;
                    if ((timeStamp.DayOfWeek == DayOfWeek.Saturday) || (timeStamp.DayOfWeek == DayOfWeek.Sunday))
                    {
                        weekendPower += hourlyConsumption.ElementAt(measurmentCounter);
                    }
                }
                return weekendPower;
            }
            catch
            {
                return null;
            }
        }


        public static double? nightTimePower(List<DateTime> fromDate, List<double> hourlyConsumption)
        {
            try
            {
                //Night >22:00 || > 00:00 && < 06:00
                double nightPower = 0;
                int measurmentCounter = -1;
                foreach (DateTime timeStamp in fromDate)
                {
                    //Increment measurment counter as we go trough them
                    measurmentCounter++;
                    //Not weekend
                    if (!((timeStamp.DayOfWeek == DayOfWeek.Saturday) || (timeStamp.DayOfWeek == DayOfWeek.Sunday)))
                    {
                        //Hour is part of the night
                        if ((timeStamp.Hour >= 22) || ((timeStamp.Hour >= 0) && (timeStamp.Hour < 6)))
                        {
                            nightPower += hourlyConsumption.ElementAt(measurmentCounter);
                        }
                    }
                }
                return nightPower;
            }
            catch
            {
                return null;
            }
        }

        public static double? dayTimePower(List<DateTime> fromDate, List<double> hourlyConsumption)
        {
            try
            {
                //Day >= 06:00 && < 22:00
                double dayPower = 0;
                int measurmentCounter = -1;
                foreach (DateTime timeStamp in fromDate)
                {
                    //Increment measurment counter as we go trough them
                    measurmentCounter++;
                    //Not weekend
                    if (!((timeStamp.DayOfWeek == DayOfWeek.Saturday) || (timeStamp.DayOfWeek == DayOfWeek.Sunday)))
                    {
                        //Hour is part of the night
                        if (((timeStamp.Hour >= 6) && (timeStamp.Hour < 22)))
                        {
                            dayPower += hourlyConsumption.ElementAt(measurmentCounter);
                        }
                    }
                }
                return dayPower;
            }
            catch
            {
                return null;
            }
        }
    }
}
