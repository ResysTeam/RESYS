using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RESYS.BIZ.Models;
using RESYS.BIZ.Services;
using RESYS.WEB.Extensions;
using RESYS.WEB.Filters;
using RESYS.WEB.Helpers;

namespace RESYS.WEB.Controllers
{
    public class IntroductionController : FrontControllerBase
    {
        //
        // GET: /Introduction/

        public ActionResult Index()
        {
            var listintroduction = ServiceFactory.IntroductionManager.GetAllActive(Culture);
            ViewBag.ListIntroduction = listintroduction;
            return View();
        }


        public ActionResult Develop()
        {
            var develop = ServiceFactory.IntroductionManager.GetByShortName(("qua-trinh-phat-trien".HtmlItemString("navbar", "shortname-history")), Culture);
            var listyear = ServiceFactory.DevelopYearManager.GetAllActive(Culture);
            ViewBag.ListYear = listyear;
            return View(develop);
        }
        public ActionResult Introduction(string shortname,int id)
        {
            var introduction = ServiceFactory.IntroductionManager.Get(new Introduction { IntroductionId = id });
            ViewBag.PageTitle = introduction.IntroductionName;
            return View(introduction);
        }
    }
}
