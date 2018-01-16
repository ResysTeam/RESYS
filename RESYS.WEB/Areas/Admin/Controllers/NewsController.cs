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
    public class NewsController : AdminControllerBase
    {
        // GET: /NewsCate/
        [HttpGet]
        public ActionResult SearchCate()
        {
            var total = 0;
            var listNews = ServiceFactory.NewsCategoryManager.Search(0, 1000, ref total, Culture);
            return View(listNews);
        }

        [HttpGet]
        public ActionResult CreateCate()
        {
            NewsCategory data = new NewsCategory();
            var categories = ServiceFactory.NewsCategoryManager.GetAllActive(Culture);
            ViewBag.Categories = new SelectList(categories, "NewsCategoryId", "HlevelTitle");
            return View("UpdateCate", data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateCate(NewsCategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBy = UserState.SysUser.Fullname;
                    model.NewsCategoryShortName = model.NewsCategoryTitle.ToUrlSegment(250).ToLower();
                    ServiceFactory.NewsCategoryManager.Add(model, Culture);
                    return RedirectToAction("SearchCate", "News");
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            var categories = ServiceFactory.NewsCategoryManager.GetAllActive(Culture);
            ViewBag.Categories = new SelectList(categories, "NewsCategoryId", "HlevelTitle");
            return View("UpdateCate", model);


        }

        [HttpGet]
        public ActionResult UpdateCate(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.NewsCategoryManager.Get(new NewsCategory { NewsCategoryId = (int)Id });
                if (obj != null)
                {
                    var categories = ServiceFactory.NewsCategoryManager.GetAllActive(Culture);
                    ViewBag.Categories = new SelectList(categories, "NewsCategoryId", "HlevelTitle");
                    ViewBag.IsEdit = true;
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateCate(NewsCategory model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.NewsCategoryManager.Get(new NewsCategory { NewsCategoryId = model.NewsCategoryId });
                if (obj != null)
                {
                    try
                    {
                        model.NewsCategoryShortName = model.NewsCategoryTitle.ToUrlSegment(250).ToLower();
                        ServiceFactory.NewsCategoryManager.Update(model, obj);

                        return RedirectToAction("SearchCate", "News");
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
            }
            var categories = ServiceFactory.NewsCategoryManager.GetAllActive(Culture);
            ViewBag.Categories = new SelectList(categories, "NewsCategoryId", "HlevelTitle");
            ViewBag.IsEdit = true;
            return View(model);
        }


        public ActionResult DeleteCate(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.NewsCategoryManager.Get(new NewsCategory { NewsCategoryId = (int)Id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.NewsCategoryManager.Remove(obj);
                        return RedirectToAction("SearchCate", "News");
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("SearchCate", "News");
                    }
                }
            }
            return RedirectToAction("SearchCate", "News");
        }

        // GET: /News/

        [HttpGet]
        public ActionResult SearchNews()
        {
            var total = 0;
            var listNews = ServiceFactory.NewsManager.Search(0, 1000, ref total, Culture);
            return View(listNews);
        }

        [HttpGet]
        public ActionResult CreateNews()
        {
            News data = new News()
            {
                NewsPublishDate = DateTime.Now
            };
            var categories = ServiceFactory.NewsCategoryManager.GetAllActive(Culture);
            var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
            ViewBag.Categories = new SelectList(categories, "NewsCategoryId", "HlevelTitle");
            ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName");
            return View("UpdateNews", data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateNews(News model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBy = UserState.SysUser.Fullname;
                    model.NewsShortName = model.NewsTitle.ToUrlSegment(250).ToLower();
                    ServiceFactory.NewsManager.Add(model, Culture);
                    return RedirectToAction("SearchNews", "News");
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
            var categories = ServiceFactory.NewsCategoryManager.GetAllActive(Culture);
            ViewBag.Categories = new SelectList(categories, "NewsCategoryId", "HlevelTitle");
            ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName");
            return View("UpdateNews", model);

        }

        [HttpGet]
        public ActionResult UpdateNews(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.NewsManager.Get(new News { NewsId = (int)Id });
                if (obj != null)
                {
                    var categories = ServiceFactory.NewsCategoryManager.GetAllActive(Culture);
                    var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
                    ViewBag.Categories = new SelectList(categories, "NewsCategoryId", "HlevelTitle");
                    ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName");
                    ViewBag.IsEdit = true;
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateNews(News model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.NewsManager.Get(new News { NewsId = model.NewsId });
                if (obj != null)
                {
                    try
                    {
                        model.NewsShortName = model.NewsTitle.ToUrlSegment(250).ToLower();
                        ServiceFactory.NewsManager.Update(model, obj);
                        return RedirectToAction("SearchNews", "News");
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
            }
            var categories = ServiceFactory.NewsCategoryManager.GetAllActive(Culture);
            var listcompany = ServiceFactory.CompanyManager.GetAllActive(Culture);
            ViewBag.Categories = new SelectList(categories, "NewsCategoryId", "HlevelTitle");
            ViewBag.ListCompany = new SelectList(listcompany, "CompanyId", "CompanyName"); ;
            ViewBag.IsEdit = true;
            return View(model);
        }


        public ActionResult DeleteNews(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.NewsManager.Get(new News { NewsId = (int)Id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.NewsManager.Remove(obj);
                        return RedirectToAction("SearchNews", "News");
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("SearchNews", "News");
                    }
                }
            }
            return RedirectToAction("SearchNews", "News");
        }
        // GET: /NewsImage/

        [HttpGet]
        public ActionResult SearchNewsImage(int NewsId)
        {
            News News = ServiceFactory.NewsManager.Get(new News { NewsId = NewsId });
            List<NewsImage> listNewsImage = new List<NewsImage>();
            listNewsImage = ServiceFactory.NewsImageManager.GetByNews(NewsId, Culture);
            News.ListNewsImage = listNewsImage;
            return View(News);
        }

        [HttpGet]
        public ActionResult CreateNewsImage(int newsid)
        {
            NewsImage data = new NewsImage();
            data.NewsId = newsid;
            return View("UpdateNewsImage", data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateNewsImage(NewsImage model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBy = UserState.SysUser.Fullname;
                    ServiceFactory.NewsImageManager.Add(model, Culture);
                    return RedirectToAction("SearchNewsImage", "News", new { NewsId = model.NewsId });
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            return View("UpdateNewsImage", model);

        }

        [HttpGet]
        public ActionResult UpdateNewsImage(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.NewsImageManager.Get(new NewsImage { NewsImageId = (int)Id });
                if (obj != null)
                {
                    ViewBag.IsEdit = true;
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateNewsImage(NewsImage model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.NewsImageManager.Get(new NewsImage { NewsImageId = model.NewsImageId });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.NewsImageManager.Update(model, obj);

                        return RedirectToAction("SearchNewsImage", "News", new { NewsId = model.NewsId });
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


        public ActionResult DeleteNewsImage(int id, int Newsid)
        {
            var obj = ServiceFactory.NewsImageManager.Get(new NewsImage { NewsImageId = id });
            if (obj != null)
            {
                try
                {
                    ServiceFactory.NewsImageManager.Remove(obj);
                    return RedirectToAction("SearchNewsImage", "News", new { NewsId = Newsid });
                }
                catch (Exception)
                {

                    return RedirectToAction("SearchNewsImage", "News", new { NewsId = Newsid });
                }
            }
            return RedirectToAction("SearchNewsImage", "News", new { NewsId = Newsid });

        }
    }
}
