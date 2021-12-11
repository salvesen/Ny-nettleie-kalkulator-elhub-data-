using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nettleieKalkulator1._0._0.pricing
{
    public static class relatedFunctions
    {
        public static bool zeroPricing()
        {
            try
            {
                ConfigurationManager.AppSettings["oldEnergyPrice"] = "0";
                ConfigurationManager.AppSettings["oldMonthlyPrice"] = "0";
                ConfigurationManager.AppSettings["newDayPrice"] = "0";
                ConfigurationManager.AppSettings["newNightPrice"] = "0";
                ConfigurationManager.AppSettings["newMonthlyPrice"] = "0";
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool setPricing(string oldEnergyPrice, string oldMonthlyPrice, string newDayPrice, string newNightPrice, string newMonthlyPrice)
        {
            try
            {
                ConfigurationManager.AppSettings["oldEnergyPrice"] = oldEnergyPrice;
                ConfigurationManager.AppSettings["oldMonthlyPrice"] = oldMonthlyPrice;
                ConfigurationManager.AppSettings["newDayPrice"] = newDayPrice;
                ConfigurationManager.AppSettings["newNightPrice"] = newNightPrice;
                ConfigurationManager.AppSettings["newMonthlyPrice"] = newMonthlyPrice;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
