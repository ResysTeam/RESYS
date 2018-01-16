using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RESYS.BIZ.Models;
using RESYS.BIZ.Services;
using RESYS.WEB.Filters;
using RESYS.WEB.Helpers;
using idocNet.Client.Core.Data.Entities.Validation;
using idocNet.Client.Core.Extensions;

namespace RESYS.WEB.Areas.Admin.Controllers
{
    [RequireAuthorization("sysadmin")]
    public class IntroductionController : AdminControllerBase
    {
        // GET: /Introduction/
        [HttpGet]
        public ActionResult Search()
        {
            var total = 0;
            var listIntroduction = ServiceFactory.IntroductionManager.Search(0, 1000, ref total, Culture);
            return View(listIntroduction);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Introduction data = new Introduction();
            return View("Update", data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Introduction model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBy = UserState.SysUser.Fullname;
                    model.IntroductionShortName = model.IntroductionName.ToUrlSegment(250).ToLower();
                    ServiceFactory.IntroductionManager.Add(model, Culture);
                    return RedirectToAction("Search", "Introduction");
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            return View("Update", model);

        }

        [HttpGet]
        public ActionResult Update(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.IntroductionManager.Get(new Introduction { IntroductionId = (int)Id });
                if (obj != null)
                {
                    ViewBag.IsEdit = true;
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Update(Introduction model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.IntroductionManager.Get(new Introduction { IntroductionId = model.IntroductionId });
                if (obj != null)
                {
                    try
                    {
                        model.IntroductionShortName = model.IntroductionName.ToUrlSegment(250).ToLower();
                        ServiceFactory.IntroductionManager.Update(model, obj);

                        return RedirectToAction("Search", "Introduction");
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
            }
            ViewBag.IsEdit = true;
            return View(model);
        }


        public ActionResult Delete(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.IntroductionManager.Get(new Introduction { IntroductionId = (int)Id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.IntroductionManager.Remove(obj);
                        return RedirectToAction("Search", "Introduction");
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("Search", "Introduction");
                    }
                }
            }
            return RedirectToAction("Search", "Introduction");
        }

        // GET: /DevelopYear/

        [HttpGet]
        public ActionResult SearchYear()
        {
            var total = 0;
            var listDevelopYear = ServiceFactory.DevelopYearManager.Search(0, 1000, ref total, Culture);
            return View(listDevelopYear);
        }

        [HttpGet]
        public ActionResult CreateYear()
        {
            DevelopYear data = new DevelopYear();
            return View("UpdateYear", data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateYear(DevelopYear model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBy = UserState.SysUser.Fullname;
                    ServiceFactory.DevelopYearManager.Add(model, Culture);
                    return RedirectToAction("SearchYear", "Introduction");
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            return View("UpdateYear", model);

        }

        [HttpGet]
        public ActionResult UpdateYear(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.DevelopYearManager.Get(new DevelopYear { DevelopYearId = (int)Id });
                if (obj != null)
                {
                    ViewBag.IsEdit = true;
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateYear(DevelopYear model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.DevelopYearManager.Get(new DevelopYear { DevelopYearId = model.DevelopYearId });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.DevelopYearManager.Update(model, obj);

                        return RedirectToAction("SearchYear", "Introduction");
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
            }
            ViewBag.IsEdit = true;
            return View(model);
        }


        public ActionResult DeleteYear(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.DevelopYearManager.Get(new DevelopYear { DevelopYearId = (int)Id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.DevelopYearManager.Remove(obj);
                        return RedirectToAction("SearchYear", "Introduction");
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("SearchYear", "Introduction");
                    }
                }
            }
            return RedirectToAction("SearchYear", "Introduction");
        }
        // GET: /DevelopMonth/

        [HttpGet]
        public ActionResult SearchMonth(int DevelopYearId)
        {
            DevelopYear developyear = ServiceFactory.DevelopYearManager.Get(new DevelopYear { DevelopYearId = DevelopYearId });
            List<DevelopMonth> listmonth=new List<DevelopMonth>();
            listmonth = ServiceFactory.DevelopMonthManager.GetByYear(DevelopYearId, Culture);
            developyear.ListMonth = listmonth;
            return View(developyear);
        }

        [HttpGet]
        public ActionResult CreateMonth(int yearid)
        {
            DevelopMonth data = new DevelopMonth();
            data.DevelopYearId = yearid;
            return View("UpdateMonth", data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateMonth(DevelopMonth model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBy = UserState.SysUser.Fullname;
                    ServiceFactory.DevelopMonthManager.Add(model, Culture);
                    return RedirectToAction("SearchMonth", "Introduction", new { DevelopYearId = model.DevelopYearId });
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            return View("UpdateMonth", model);

        }

        [HttpGet]
        public ActionResult UpdateMonth(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.DevelopMonthManager.Get(new DevelopMonth { DevelopMonthId = (int)Id });
                if (obj != null)
                {
                    ViewBag.IsEdit = true;
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateMonth(DevelopMonth model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.DevelopMonthManager.Get(new DevelopMonth { DevelopMonthId = model.DevelopMonthId });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.DevelopMonthManager.Update(model, obj);

                        return RedirectToAction("SearchMonth", "Introduction", new { DevelopYearId = model.DevelopYearId });
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
            }
            ViewBag.IsEdit = true;
            return View(model);
        }


        public ActionResult DeleteMonth(int id,int yearid)
        {
                var obj = ServiceFactory.DevelopMonthManager.Get(new DevelopMonth { DevelopMonthId = id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.DevelopMonthManager.Remove(obj);
                        return RedirectToAction("SearchMonth", "Introduction", new { DevelopYearId = yearid });
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("SearchMonth", "Introduction", new { DevelopYearId = yearid });
                    }
                }
                return RedirectToAction("SearchMonth", "Introduction", new { DevelopYearId = yearid });

        }
    }
}
