using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RESYS.BIZ.Services;
using RESYS.BIZ.Models;
using RESYS.WEB.Helpers;
using RESYS.WEB.Filters;

namespace RESYS.WEB.Areas.Admin.Controllers
{
    public class PotentialCustomerController : AdminControllerBase
    {
        //
        // GET: /Admin/PotentialCustomer/

        public ActionResult Index()
        {
            var list = ServiceFactory.PotentialCustomerManager.GetAll();
            return View(list);
        }

    }
}
