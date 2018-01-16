using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RESYS.BIZ.Models;
using RESYS.BIZ.Services;
using RESYS.WEB.Filters;

namespace RESYS.WEB.Controllers
{
	public class HomeController : FrontControllerBase
	{
		public ActionResult Index()
		{
			//ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			//ViewBag.Title = "aaa";
		 //   var listslide = ServiceFactory.SlideBannerManager.SelectTop(10, Culture);
   //         ViewData["ListSlide"] = listslide;
   //         var listcompanycate = ServiceFactory.CompanyCateManager.GetTopHot(2, Culture);
   //         ViewData["ListCompanyCate"] = listcompanycate;
   //         var listnewshot = ServiceFactory.NewsManager.GetTopHot(2, Culture);
   //         ViewData["ListNewsHot"] = listnewshot;
   //         var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
   //         ViewData["ListCompany"] = listcompany;
            return View();
		}
		public ActionResult Flight()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

			return View();
		}
		public ActionResult Flight1()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

			return View();
		}
		public ActionResult Flight2()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

			return View();
		}
		public ActionResult Finish()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

			return View();
		}
		public ActionResult DetailOrder()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

			return View();
		}
		public ActionResult Flight3()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

			return View();
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}
        [HttpGet]
        public ActionResult Map()
        {

            return View();
        }
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

       

		public ActionResult GoodTicketSocials(string code)
		{
			ViewBag.Code = code;
			return View();
		}
        [HttpGet]
        public ActionResult HomeSearch(string key)
        {
            string keyword = ConfigurationManager.AppSettings["keyword"];
            string decsription = ConfigurationManager.AppSettings["description"];
            ViewBag.keysearch = key;
            ViewBag.Keywords = keyword;
            ViewBag.Desciption = decsription;
            return View();
        }
	}
}
