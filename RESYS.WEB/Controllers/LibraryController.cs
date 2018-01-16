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
    public class LibraryController : FrontControllerBase
    {
        private int _userPageSize = 24;
        //
        // GET: /Library/
        [HttpGet]
        public ActionResult Index(string shortname, int page = 0)
        {
            var total = 0;
            var listcompanycate = ServiceFactory.CompanyCateManager.GetAllActive(Culture);
            ViewBag.ListCompanyCate = listcompanycate;
            if (shortname == "all")
            {
                var listlibrary = ServiceFactory.LibraryManager.Search(page * _userPageSize, _userPageSize, ref total,
                                                                    Culture);
                ViewBag.ListLibrary = listlibrary;
            }
            else
            {
                var company = ServiceFactory.CompanyManager.GetByShortName(new Company { CompanyShortName = shortname });
                var listlibrary = ServiceFactory.LibraryManager.SearchByTag(page * _userPageSize, _userPageSize, ref total,
                                                                    Culture, company.CompanyId);
                ViewBag.ListLibrary = listlibrary;
                
                ViewData["Company"] = company;
            }
            ViewData["Tag"] = shortname;
            ViewData["Page"] = page;
            ViewData["TotalItems"] = total;
            ViewBag.PageSize = _userPageSize;
            ViewBag.shortname = shortname;
            return View();
        }
        public ActionResult IndexImage(string shortname, int page = 0)
        {
            var total = 0;
            var listcompanycate = ServiceFactory.CompanyCateManager.GetAllActive(Culture);
            ViewBag.ListCompanyCate = listcompanycate;
            if (shortname == "all")
            {
                var listimage = ServiceFactory.LibraryManager.ImageSearch(page * _userPageSize, _userPageSize, ref total,
                                                                          Culture);
                ViewBag.ListImage = listimage;
            }
            else
            {
                var company = ServiceFactory.CompanyManager.GetByShortName(new Company { CompanyShortName = shortname });
                var listimage = ServiceFactory.LibraryManager.ImageSearchByTag(page * _userPageSize, _userPageSize, ref total,
                                                                    Culture, company.CompanyId);
                ViewBag.ListImage = listimage;
                
                ViewData["Company"] = company;
            }
            ViewData["Tag"] = shortname;
            ViewData["Page"] = page;
            ViewData["TotalItems"] = total;
            ViewBag.PageSize = _userPageSize;
            ViewBag.shortname = shortname;
            return View();
        }
        public ActionResult IndexVideo(string shortname, int page = 0)
        {
            var total = 0;
            var listcompanycate = ServiceFactory.CompanyCateManager.GetAllActive(Culture);
            ViewBag.ListCompanyCate = listcompanycate;
            if (shortname == "all")
            {
                var listvideo = ServiceFactory.LibraryManager.VideoSearch(page * _userPageSize, _userPageSize, ref total,
                                                                          Culture);
                ViewBag.ListVideo = listvideo;
            }
            else
            {
                var company = ServiceFactory.CompanyManager.GetByShortName(new Company { CompanyShortName = shortname });
                var listvideo = ServiceFactory.LibraryManager.VideoSearchByTag(page * _userPageSize, _userPageSize, ref total,
                                                                    Culture, company.CompanyId);
                ViewBag.ListVideo = listvideo;
                
                ViewData["Company"] = company;
            }
            ViewData["Tag"] = shortname;
            ViewData["Page"] = page;
            ViewData["TotalItems"] = total;
            ViewBag.PageSize = _userPageSize;
            ViewBag.shortname = shortname;
            return View();
        }
    }
}
