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
    public class NewsController : FrontControllerBase
    {
        private int _userPageSize = 6;
        //
        // GET: /NewsCategory/

        [HttpGet]
        public ActionResult Index(int page=0)
        {
            var total = 0;
            var listnewscate = ServiceFactory.NewsCategoryManager.GetAllActiveByPrId(0, Culture);
            var listnews = ServiceFactory.NewsManager.GetAllActive(page * _userPageSize, _userPageSize, ref total,
                                                                    Culture, "tuyen-dung");
            ViewData["Page"] = page;
            ViewData["TotalItems"] = total;
            ViewBag.PageSize = _userPageSize;
            ViewData["ListCate"] = listnewscate;
            ViewBag.ListNews = listnews;
            return View();

        }

        public ActionResult IndexCategory(int id, string shortname, int page = 0)
        {
            var total = 0;
            var listnewscate = ServiceFactory.NewsCategoryManager.GetAllActiveByPrId(0, Culture);
            var listnews = ServiceFactory.NewsManager.GetByCateId(page * _userPageSize, _userPageSize, ref total,
                                                                    Culture, id);
            
            ViewData["Page"] = page;
            ViewData["TotalItems"] = total;
            ViewData["ShortName"] = shortname;
            ViewBag.PageSize = _userPageSize;
            ViewData["ListCate"] = listnewscate;
            ViewBag.ListNews = listnews;
            ViewBag.shortname = shortname;
            ViewBag.Id = id;
            return View();

        }

        public ActionResult NewsTag(int id,string shortname, int page = 0)
        {
            var total = 0;
            var company = ServiceFactory.CompanyManager.GetByShortName(new Company { CompanyShortName = shortname });
            var listnews = ServiceFactory.NewsManager.SearchByTag(page * _userPageSize, _userPageSize, ref total,
                                                                    Culture, company.CompanyId);

            ViewData["Page"] = page;
            ViewData["TotalItems"] = total;
            ViewBag.PageSize = _userPageSize;
            ViewBag.shortname = shortname;
            ViewBag.ListNews = listnews;
            ViewBag.Title = company.CompanyName;
            ViewBag.Id = id;
            return View();
        }


        public ActionResult NewsCategory(string shortname, int page = 0)
        {

            var list = ServiceFactory.NewsCategoryManager.GetAllActive(Culture);
            var total = 0;
            var category = ServiceFactory.NewsCategoryManager.GetByShortName(new NewsCategory { NewsCategoryShortName = shortname }, Culture);
            if (category != null)
            {
                category.ListNews = ServiceFactory.NewsManager.SearchByCateParentId(category.NewsCategoryId, page * _userPageSize, _userPageSize, ref total, Culture);
                ViewBag.Keywords = category.NewsCategoryKeyword;
                if (page != 0)
                {
                    ViewBag.Desciption = category.NewsCategoryDescription + " - " + page;
                }
                else
                {
                    ViewBag.Desciption = category.NewsCategoryDescription;
                }
            }
            else
            {
                return ResultHelper.NotFoundResult(this);
            }
            //var data = ServiceFactory.NewsManager.get
            ViewBag.PageTitle = category.NewsCategoryTitle;
            ViewBag.MetaKeyword = category.NewsCategoryKeyword;
            ViewBag.MetaDescription = category.NewsCategoryDescription;
            ViewData["Page"] = page;
            ViewData["TotalItems"] = total;
            ViewBag.PageSize = _userPageSize;
            ViewBag.ListCates = list;
            ViewBag.shortname = category.NewsCategoryShortName;

            return View(category);
        }
        public ActionResult Detail(string category, string shortname, int newsid)
        {
            var cate =
                ServiceFactory.NewsCategoryManager.GetByShortName(new NewsCategory { NewsCategoryShortName = category },
                                                                  Culture);
            var data = ServiceFactory.NewsManager.GetDetail(new News { NewsId = newsid },Culture);
           
            if (data !=null)
            {
                var other = ServiceFactory.NewsManager.GetOther(3, Culture, data.NewsId, data.CompanyId);
                var othernews = ServiceFactory.NewsManager.GetOtherNews(2, Culture, data.NewsId);
                data.ListNewsImage = ServiceFactory.NewsImageManager.GetByNewsActive(data.NewsId, Culture);
                ViewBag.ListOther = other;
                ViewBag.OtherNews = othernews;
                ViewBag.Keywords = data.NewsKeyword;
                ViewBag.Desciption = data.NewsDescription;
                ViewBag.Category = cate;
                ViewBag.categoryshortname = category;
                
            }
            return View(data);                 
        }
    }
}
