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
    public class AlbumController : FrontControllerBase
    {
        private int _userPageSize = 20;
        //
        // GET: /Album/
        [HttpGet]
        public ActionResult Index(string shortname, int page = 0)
        {
            var total = 0;
            var listcompanycate = ServiceFactory.CompanyCateManager.GetAllActive(Culture);
            ViewBag.ListCompanyCate = listcompanycate;
            if (shortname == "all")
            {
                var listlibrary = ServiceFactory.AlbumManager.Search(page * _userPageSize, _userPageSize, ref total,
                                                                    Culture);
                ViewBag.ListAlbum = listlibrary;
            }
            else
            {
                var company = ServiceFactory.CompanyManager.GetByShortName(new Company { CompanyShortName = shortname });
                var listlibrary = ServiceFactory.AlbumManager.SearchByTag(page * _userPageSize, _userPageSize, ref total,
                                                                    Culture, company.CompanyId);
                ViewBag.ListAlbum = listlibrary;

                ViewData["Company"] = company;
            }
            ViewData["Tag"] = shortname;
            ViewData["Page"] = page;
            ViewData["TotalItems"] = total;
            ViewBag.PageSize = _userPageSize;
            ViewBag.ShortName = shortname;
            return View();
        }
        public ActionResult IndexImage(string shortname, int page = 0)
        {
            var total = 0;
            var listcompanycate = ServiceFactory.CompanyCateManager.GetAllActive(Culture);
            ViewBag.ListCompanyCate = listcompanycate;
            if (shortname == "all")
            {
                var listimage = ServiceFactory.AlbumManager.ImageSearch(page * _userPageSize, _userPageSize, ref total,
                                                                          Culture);
                ViewBag.ListImage = listimage;
            }
            else
            {
                var company = ServiceFactory.CompanyManager.GetByShortName(new Company { CompanyShortName = shortname });
                var listimage = ServiceFactory.AlbumManager.ImageSearchByTag(page * _userPageSize, _userPageSize, ref total,
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
                var listvideo = ServiceFactory.AlbumManager.VideoSearch(page * _userPageSize, _userPageSize, ref total,
                                                                          Culture);
                ViewBag.ListVideo = listvideo;
            }
            else
            {
                var company = ServiceFactory.CompanyManager.GetByShortName(new Company { CompanyShortName = shortname });
                var listvideo = ServiceFactory.AlbumManager.VideoSearchByTag(page * _userPageSize, _userPageSize, ref total,
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
        public ActionResult Detail(string shortname, int albumid, int count, string row, string idpre, string idnxt, int countlist, string show, int page = 0)
        {
            var total = 0;
            Album Album = ServiceFactory.AlbumManager.Get(new Album { AlbumId = albumid });
            List<AlbumImage> listAlbumImage = new List<AlbumImage>();
            listAlbumImage = ServiceFactory.AlbumImageManager.GetByAlbum(albumid, Culture);
            Album.ListAlbumImage = listAlbumImage;
            List<Album> listlibrary = null;
            if (shortname == "all")
            {
                if (string.IsNullOrEmpty(show))
                {
                    listlibrary = ServiceFactory.AlbumManager.Search(page*_userPageSize, _userPageSize, ref total,
                                                                     Culture);
                }
                else if (show == "image")
                {
                    listlibrary = ServiceFactory.AlbumManager.ImageSearch(page * _userPageSize, _userPageSize, ref total,
                                                                     Culture);
                }
                else if (show == "video")
                {
                    listlibrary = ServiceFactory.AlbumManager.VideoSearch(page * _userPageSize, _userPageSize, ref total,
                                                                     Culture);
                }
            }
            else
            {
                var company = ServiceFactory.CompanyManager.GetByShortName(new Company { CompanyShortName = shortname });
                if (company != null)
                {
                    if (string.IsNullOrEmpty(show))
                    {
                        listlibrary = ServiceFactory.AlbumManager.SearchByTag(page*_userPageSize, _userPageSize,
                                                                              ref total,
                                                                              Culture, company.CompanyId);
                    }
                    else if (show == "image")
                    {
                        listlibrary = ServiceFactory.AlbumManager.ImageSearchByTag(page * _userPageSize, _userPageSize,
                                                                              ref total,
                                                                              Culture, company.CompanyId);
                    }
                    else if (show == "video")
                    {
                        listlibrary = ServiceFactory.AlbumManager.VideoSearchByTag(page * _userPageSize, _userPageSize,
                                                                              ref total,
                                                                              Culture, company.CompanyId);
                    }
                }
            }
            if (listlibrary != null && listlibrary.Count > 0)
            {
                if (countlist >= 2)
                {
                    if (!string.IsNullOrEmpty(idpre))
                    {
                        ViewBag.IdPre = idpre;
                        var countpre = count - 1;
                        //ViewBag.CountPre = countpre;
                        ViewBag.IdPreNxt = listlibrary[countpre].AlbumId;
                        if (countpre >= 2)
                        {
                            ViewBag.IdPrePre = listlibrary[countpre - 2].AlbumId;
                        }
                        if (countpre%4 == 0)
                        {
                            ViewBag.RowAlbumPre = countpre/4;
                        }
                        else
                        {
                            ViewBag.RowAlbumPre = (countpre - countpre%4)/4 + 1;
                        }
                    }
                    if (!string.IsNullOrEmpty(idnxt))
                    {
                        ViewBag.IdNxt = idnxt;
                        var countnxt = count + 1;
                        //ViewBag.CountNxt = countnxt;
                        ViewBag.IdNxtPre = listlibrary[countnxt - 2].AlbumId;
                        if (countnxt < countlist)
                        {
                            ViewBag.IdNxtNxt = listlibrary[countnxt].AlbumId;
                        }
                        if (countnxt%4 == 0)
                        {
                            ViewBag.RowAlbumNxt = countnxt/4;
                        }
                        else
                        {
                            ViewBag.RowAlbumNxt = (countnxt - countnxt%4)/4 + 1;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(row))
            {
                ViewBag.Row = row;
            }
            ViewBag.Count = count;
            ViewBag.Page = page;
            ViewBag.CountList = countlist;
            ViewBag.ShortName = shortname;
            return View(Album);
        }
    }
}
