using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RESYS.BIZ.Models;
using RESYS.BIZ.Services;
using RESYS.WEB.Filters;
using RESYS.WEB.Helpers;
namespace RESYS.WEB.Controllers
{
    public class SiteMapController : FrontControllerBase
    {
        //
        // GET: /SiteMap/

        public ActionResult Index()
        {
            var listcompanycate = ServiceFactory.CompanyCateManager.GetTopHot(2, Culture);
            ViewData["ListCompanyCate"] = listcompanycate;
            var listintroduction = ServiceFactory.IntroductionManager.GetAllActive(Culture);
            ViewData["ListIntroduction"] = listintroduction;
            var listnewscate = ServiceFactory.NewsCategoryManager.GetAllActiveByPrId(0, Culture);
            ViewData["ListNewsCate"] = listnewscate;
            return View();
        }

    }
}
