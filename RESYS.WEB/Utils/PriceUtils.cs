using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESYS.WEB.Utils
{
    public class PriceUtils
    {
        public static double RoundTo(decimal input)
        {
            double Tien = Convert.ToDouble(input) / 1000;
            Tien = Math.Round(Tien, 0) * 1000;
            return Tien;
        }
    }
}