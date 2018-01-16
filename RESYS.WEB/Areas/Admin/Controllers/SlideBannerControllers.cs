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

namespace RESYS.WEB.Areas.Admin.Controllers
{
    [RequireAuthorization("sysadmin")]
    public class SlideBannerController : AdminControllerBase
    {
        private const int Pagesize = 20;
        // GET: /SliderBanner/
        [HttpGet]
        public ActionResult Search()
        {
            var total = 0;
            var listSlideBanner = ServiceFactory.SlideBannerManager.Search(0,1000,ref total,Culture);
            return View(listSlideBanner);
        }

        [HttpGet]
        public ActionResult Create()
        {
           SlideBanner data = new SlideBanner();
            return View("Update",data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(SlideBanner model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBy = UserState.SysUser.Fullname;
                    ServiceFactory.SlideBannerManager.Add(model,Culture);
                    return RedirectToAction("Search", "SlideBanner");
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
                var obj = ServiceFactory.SlideBannerManager.Get(new SlideBanner { SlideBannerId = (int)Id });
                if (obj != null)
                {
                    ViewBag.IsEdit = true;
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost]
        public ActionResult Update(SlideBanner model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.SlideBannerManager.Get(new SlideBanner { SlideBannerId = model.SlideBannerId });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.SlideBannerManager.Update(model, obj);

                        return RedirectToAction("Search", "SlideBanner");
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
                var obj = ServiceFactory.SlideBannerManager.Get(new SlideBanner { SlideBannerId = (int)Id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.SlideBannerManager.Remove(obj);
                        return RedirectToAction("Search", "SlideBanner");
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("Search", "SlideBanner");
                    }
                }
            }
            return RedirectToAction("Search", "SlideBanner");
        }

    }
}
