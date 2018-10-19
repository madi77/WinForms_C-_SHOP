using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1
{
    class Calculate
    {


        public static bool DiscountCheck(string code)
        {
            string[] coupons = FileHandler.WordsFrom(@"Coupons.csv");
            bool result = false;
            foreach (string couponCode in coupons)
            {
                if (couponCode == code)
                {
                    result = true;
                }
            }
            return result;
        }
        
    }
}
