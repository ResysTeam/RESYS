using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RESYS.BIZ.Models;
using RESYS.BIZ.Services;
using RESYS.WEB.Filters;


namespace RESYS.WEB.Controllers
{
    public class CompanyController : FrontControllerBase
    {
        //
        // GET: /CompanyCate/

        public ActionResult Index()
        {
            var listcompanycate = ServiceFactory.CompanyCateManager.GetAllActive(Culture);
            ViewData["ListCompanyCate"] = listcompanycate;
            return View();
        }
        public ActionResult Company(string shortname, int id)
        {
            var company = ServiceFactory.CompanyManager.Get(new Company { CompanyId = id });
            var listnews = ServiceFactory.NewsManager.GetTopHotByTag(2, id, Culture);
            ViewData["ListNews"] = listnews;
            var listlibrary = ServiceFactory.AlbumManager.GetTopHotByTag(2, id, Culture);
            ViewData["ListLibrary"] = listlibrary;
            ViewBag.PageTitle = company.CompanyName+" - Thành Công Group";
            return View(company);
        }
        public ActionResult Detail(int comid, int albumid, int count, string idpre, string idnxt, int countlist)
        {
            var Album = ServiceFactory.AlbumManager.Get(new Album { AlbumId = albumid });
            var listAlbumImage = new List<AlbumImage>();
            listAlbumImage = ServiceFactory.AlbumImageManager.GetByAlbum(albumid, Culture);
            Album.ListAlbumImage = listAlbumImage;
            var listlibrary = ServiceFactory.AlbumManager.GetTopHotByTag(2, comid, Culture);
            if (listlibrary != null && listlibrary.Count > 0)
            {
                if (countlist >= 2)
                {
                    if (!string.IsNullOrEmpty(idpre))
                    {
                        ViewBag.IdPre = idpre;
                        ViewBag.IdPreNxt = listlibrary[count - 1].AlbumId;                                             
                    }
                    if (!string.IsNullOrEmpty(idnxt))
                    {
                        ViewBag.IdNxt = idnxt;
                        ViewBag.IdNxtPre = listlibrary[count - 1].AlbumId;                       
                    }
                }
            }
            ViewBag.Count = count;
            ViewBag.CountList = countlist;
            ViewBag.ComId = comid;
            return View(Album);
        }

    }
}
