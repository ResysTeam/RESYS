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
    public class CompanyController : AdminControllerBase
    {
        // CompanyCate

        public ActionResult SearchCate()
        {
            var total = 0;
            var listCompanyCate = ServiceFactory.CompanyCateManager.Search(0, 1000, ref total, Culture);
            return View(listCompanyCate);
        }

        [HttpGet]
        public ActionResult CreateCate()
        {
            CompanyCate data = new CompanyCate();
            return View("UpdateCate", data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateCate(CompanyCate model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBy = UserState.SysUser.Fullname;
                    model.CompanyCateShortName = model.CompanyCateName.ToUrlSegment(250).ToLower();
                    ServiceFactory.CompanyCateManager.Add(model, Culture);
                    return RedirectToAction("SearchCate", "Company");
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            return View("UpdateCate", model);

        }

        [HttpGet]
        public ActionResult UpdateCate(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.CompanyCateManager.Get(new CompanyCate { CompanyCateId = (int)Id });
                if (obj != null)
                {
                    ViewBag.IsEdit = true;
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost]
        public ActionResult UpdateCate(CompanyCate model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.CompanyCateManager.Get(new CompanyCate { CompanyCateId = model.CompanyCateId });
                if (obj != null)
                {
                    try
                    {
                        model.CompanyCateShortName = model.CompanyCateName.ToUrlSegment(250).ToLower();
                        ServiceFactory.CompanyCateManager.Update(model, obj);

                        return RedirectToAction("SearchCate", "Company");
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


        public ActionResult DeleteCate(int? Id)
        {
            if (Id.HasValue)
            {
                var obj = ServiceFactory.CompanyCateManager.Get(new CompanyCate { CompanyCateId = (int)Id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.CompanyCateManager.Remove(obj);
                        return RedirectToAction("SearchCate", "Company");
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("SearchCate", "Company");
                    }
                }
            }
            return RedirectToAction("SearchCate", "Company");
        }


        // Company

        public ActionResult Search()
        {
            var total = 0;
            var listCompany = ServiceFactory.CompanyManager.Search(0, 1000, ref total, Culture);
            return View(listCompany);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Company data = new Company();
            var categories = ServiceFactory.CompanyCateManager.GetAllActive(Culture);
            ViewBag.Categories = new SelectList(categories, "CompanyCateId", "HlevelTitle");
            return View("Update", data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Company model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBy = UserState.SysUser.Fullname;
                    model.CompanyShortName = model.CompanyName.ToUrlSegment(250).ToLower();
                    ServiceFactory.CompanyManager.Add(model, Culture);
                    return RedirectToAction("Search", "Company");
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
                var obj = ServiceFactory.CompanyManager.Get(new Company { CompanyId = (int)Id });
                if (obj != null)
                {
                    var categories = ServiceFactory.CompanyCateManager.GetAllActive(Culture);
                    ViewBag.Categories = new SelectList(categories, "CompanyCateId", "HlevelTitle");
                    ViewBag.IsEdit = true;
                    return View(obj);
                }
            }
            return ResultHelper.NotFoundResult(this);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Update(Company model)
        {
            if (ModelState.IsValid)
            {
                var obj = ServiceFactory.CompanyManager.Get(new Company { CompanyId = model.CompanyId });
                if (obj != null)
                {
                    try
                    {
                        model.CompanyShortName = model.CompanyName.ToUrlSegment(250).ToLower();
                        ServiceFactory.CompanyManager.Update(model, obj);

                        return RedirectToAction("Search", "Company");
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
                var obj = ServiceFactory.CompanyManager.Get(new Company { CompanyId = (int)Id });
                if (obj != null)
                {
                    try
                    {
                        ServiceFactory.CompanyManager.Remove(obj);
                        return RedirectToAction("Search", "Company");
                    }
                    catch (Exception)
                    {

                        return RedirectToAction("Search", "Company");
                    }
                }
            }
            return RedirectToAction("Search", "Company");
        }
    }
}