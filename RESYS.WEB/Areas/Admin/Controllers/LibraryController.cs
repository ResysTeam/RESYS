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
    public class LibraryController : AdminControllerBase
    {
        // LibraryVideo

        public ActionResult SearchVideo()
        {
            var total = 0;
            var listVideo = ServiceFactory.LibraryManager.VideoGetAll(0, 1000, ref total, Culture);
            return View(listVideo);
        }

        [HttpGet]
        public ActionResult CreateVideo()
        {
            Library data = new Library();
            var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
            ViewBag.ListCompany = new SelectList(listcompany, "CompanyName", "CompanyName");
            return View("UpdateVideo", data);
            
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateVideo(Library model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBy = UserState.SysUser.Fullname;
                    if (model.IsAll)
                    {
                        model.CompanyId = 999999999;
                    }
                    ServiceFactory.LibraryManager.VideoAdd(model, Culture);                   
                    return RedirectToAction("SearchVideo", "Library");
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
            ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName");
            return View("UpdateVideo", model);

        }

        [HttpGet]
        public ActionResult UpdateVideo(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.LibraryManager.Get(new Library { LibraryId = (int)Id });
                if (obj != null)
                {
                    ViewBag.IsEdit = true;
                    var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
                    ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName");
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost]
        public ActionResult UpdateVideo(Library model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.LibraryManager.Get(new Library { LibraryId = model.LibraryId });
                if (obj != null)
                {
                    try
                    {
                        if (model.IsAll)
                        {
                            model.CompanyId = 999999999;
                        }
                        ServiceFactory.LibraryManager.VideoUpdate(model, obj);
                        return RedirectToAction("SearchVideo", "Library");
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
            }
            var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
            ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName");
            ViewBag.IsEdit = true;
            return View(model);
        }


        public ActionResult DeleteVideo(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.LibraryManager.Get(new Library { LibraryId = (int)Id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.LibraryManager.Remove(obj);
                        return RedirectToAction("SearchVideo", "Library");
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("SearchVideo", "Library");
                    }
                }
            }
            return RedirectToAction("SearchVideo", "Library");
        }


        // LibraryImage

        public ActionResult SearchImage()
        {
            var total = 0;
            var listImage = ServiceFactory.LibraryManager.ImageGetAll(0, 1000, ref total, Culture);
            return View(listImage);
        }

        [HttpGet]
        public ActionResult CreateImage()
        {
            Library data = new Library();
            var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
            ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName");
            return View("UpdateImage", data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateImage(Library model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.IsAll)
                    {
                        model.CompanyId = 999999999;
                    }
                    model.CreateBy = UserState.SysUser.Fullname;
                    ServiceFactory.LibraryManager.ImageAdd(model, Culture);
                    return RedirectToAction("SearchImage", "Library");
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
            ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName");
            return View("UpdateImage", model);

        }

        [HttpGet]
        public ActionResult UpdateImage(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.LibraryManager.Get(new Library { LibraryId = (int)Id });
                if (obj != null)
                {
                    ViewBag.IsEdit = true;
                    var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
                    ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName");
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost]
        public ActionResult UpdateImage(Library model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.LibraryManager.Get(new Library { LibraryId = model.LibraryId });
                if (obj != null)
                {
                    try
                    {
                        if (model.IsAll)
                        {
                            model.CompanyId = 999999999;
                        }
                        ServiceFactory.LibraryManager.ImageUpdate(model, obj);
                        return RedirectToAction("SearchImage", "Library");
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
            }
            var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
            ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName");
            ViewBag.IsEdit = true;
            return View(model);
        }


        public ActionResult DeleteImage(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.LibraryManager.Get(new Library { LibraryId = (int)Id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.LibraryManager.Remove(obj);
                        return RedirectToAction("SearchImage", "Library");
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("SearchImage", "Library");
                    }
                }
            }
            return RedirectToAction("SearchImage", "Library");
        }
    }


}