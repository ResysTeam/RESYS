using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESYS.BIZ.Services;

namespace RESYS.WEB.Utils
{
	public class NewsUtils
	{
		public static IEnumerable<string> GetNewsTagList()
		{
			yield return "nổi bật";
            yield return "trang chủ";
			yield return "nổi bật chuyên mục";
			yield return "danh sách bên phải";

            //var airportList= ServiceFactory.AirportManager.GetByCountryCode("VN");

            //foreach (var ap in airportList)
            //{
            //    yield return string.Format("{0}({1})", ap.CityName, ap.AirportCode);
            //}


		}
	}
}