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
    public class AlbumController : AdminControllerBase
    {
        // AlbumVideo

        public ActionResult SearchVideo()
        {
            var total = 0;
            var listVideo = ServiceFactory.AlbumManager.VideoGetAll(0, 1000, ref total, Culture);
            return View(listVideo);
        }

        [HttpGet]
        public ActionResult CreateVideo()
        {
            Album data = new Album();
            var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
            ViewBag.ListCompany = new SelectList(listcompany, "CompanyName", "CompanyName");
            return View("UpdateVideo", data);

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateVideo(Album model)
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
                    ServiceFactory.AlbumManager.VideoAdd(model, Culture);
                    return RedirectToAction("SearchVideo", "Album");
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
                var obj = ServiceFactory.AlbumManager.Get(new Album { AlbumId = (int)Id });
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
        public ActionResult UpdateVideo(Album model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.AlbumManager.Get(new Album { AlbumId = model.AlbumId });
                if (obj != null)
                {
                    try
                    {
                        if (model.IsAll)
                        {
                            model.CompanyId = 999999999;
                        }
                        ServiceFactory.AlbumManager.VideoUpdate(model, obj);
                        return RedirectToAction("SearchVideo", "Album");
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
                var obj = ServiceFactory.AlbumManager.Get(new Album { AlbumId = (int)Id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.AlbumManager.Remove(obj);
                        return RedirectToAction("SearchVideo", "Album");
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("SearchVideo", "Album");
                    }
                }
            }
            return RedirectToAction("SearchVideo", "Album");
        }


        // AlbumImage

        public ActionResult SearchImage()
        {
            var total = 0;
            var listImage = ServiceFactory.AlbumManager.ImageGetAll(0, 1000, ref total, Culture);
            return View(listImage);
        }

        [HttpGet]
        public ActionResult CreateImage()
        {
            Album data = new Album();
            var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
            ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName");
            return View("UpdateImage", data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateImage(Album model)
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
                    ServiceFactory.AlbumManager.ImageAdd(model, Culture);
                    return RedirectToAction("SearchImage", "Album");
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
                var obj = ServiceFactory.AlbumManager.Get(new Album { AlbumId = (int)Id });
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
        public ActionResult UpdateImage(Album model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.AlbumManager.Get(new Album { AlbumId = model.AlbumId });
                if (obj != null)
                {
                    try
                    {
                        if (model.IsAll)
                        {
                            model.CompanyId = 999999999;
                        }
                        ServiceFactory.AlbumManager.ImageUpdate(model, obj);
                        return RedirectToAction("SearchImage", "Album");
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
                var obj = ServiceFactory.AlbumManager.Get(new Album { AlbumId = (int)Id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.AlbumManager.Remove(obj);
                        return RedirectToAction("SearchImage", "Album");
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("SearchImage", "Album");
                    }
                }
            }
            return RedirectToAction("SearchImage", "Album");
        }

        // GET: /AlbumImage/

        [HttpGet]
        public ActionResult SearchAlbumImage(int albumid)
        {
            Album Album = ServiceFactory.AlbumManager.Get(new Album { AlbumId = albumid });
            List<AlbumImage> listAlbumImage = new List<AlbumImage>();
            listAlbumImage = ServiceFactory.AlbumImageManager.GetByAlbum(albumid, Culture);
            Album.ListAlbumImage = listAlbumImage;
            return View(Album);
        }

        [HttpGet]
        public ActionResult CreateAlbumImage(int albumid)
        {
            AlbumImage data = new AlbumImage();
            data.AlbumId = albumid;
            return View("UpdateAlbumImage", data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateAlbumImage(AlbumImage model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBy = UserState.SysUser.Fullname;
                    ServiceFactory.AlbumImageManager.Add(model, Culture);
                    return RedirectToAction("SearchAlbumImage", "Album", new { AlbumId = model.AlbumId });
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            return View("UpdateAlbumImage", model);

        }

        [HttpGet]
        public ActionResult UpdateAlbumImage(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.AlbumImageManager.Get(new AlbumImage { AlbumImageId = (int)Id });
                if (obj != null)
                {
                    ViewBag.IsEdit = true;
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateAlbumImage(AlbumImage model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.AlbumImageManager.Get(new AlbumImage { AlbumImageId = model.AlbumImageId });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.AlbumImageManager.Update(model, obj);

                        return RedirectToAction("SearchAlbumImage", "Album", new { AlbumId = model.AlbumId });
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


        public ActionResult DeleteAlbumImage(int id, int albumid)
        {
            var obj = ServiceFactory.AlbumImageManager.Get(new AlbumImage { AlbumImageId = id });
            if (obj != null)
            {
                try
                {
                    ServiceFactory.AlbumImageManager.Remove(obj);
                    return RedirectToAction("SearchAlbumImage", "Album", new { AlbumId = albumid });
                }
                catch (Exception)
                {

                    return RedirectToAction("SearchAlbumImage", "Album", new { AlbumId = albumid });
                }
            }
            return RedirectToAction("SearchAlbumImage", "Album", new { AlbumId = albumid });

        }
    }
}