using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using RESYS.WEB.Models;

namespace RESYS.WEB.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		//
		// GET: /Account/Login

		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		
	}
}
