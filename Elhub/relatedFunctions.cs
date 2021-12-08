using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nettleieKalkulator1._0._0.Elhub
{
    public static class relatedFunctions
    {
        public static double? getMaxPower(List<double> hourlyConsumption)
        {
            try
            {
                return hourlyConsumption.Max();
            }
            catch
            {
                return null;
            }
        }

        public static double? getTotalPower(List<double> hourlyConsumption)
        {
            try
            {
                double totalPower = 0;
                foreach (double powerHour in hourlyConsumption)
                {
                    totalPower += powerHour;
                }
                return totalPower;
            }
            catch
            {
                return null;
            }
        }

        public static bool completeMonth(List<DateTime> fromDate, List<DateTime> toDate)
        {
            try
            {
                DateTime startDate = fromDate.Min();
                DateTime endDate = toDate.Max();
                if (startDate.AddMonths(1) == endDate)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false; ;
            }
        }

        public static string getFromToDateAsString(List<DateTime> fromDate, List<DateTime> toDate)
        {
            try
            {
                DateTime startDate = fromDate.Min();
                DateTime endDate = toDate.Max();
                return startDate.ToString() + " - " + endDate.ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}
