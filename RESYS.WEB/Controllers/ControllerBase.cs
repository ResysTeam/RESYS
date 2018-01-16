using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RESYS.BIZ.Models;
using RESYS.BIZ.Services;
using RESYS.WEB.State;
using idocNet.Client.Core.Configuration;
using System.Globalization;
using System.Threading;
using System.IO;

namespace RESYS.WEB.Controllers
{
	public class ControllerBase : Controller
	{

		public string Culture
		{
			get
			{
				return System.Globalization.CultureInfo.CurrentCulture.ToString();
			}
		}
        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }


        }

        public string RenderRazorViewToString(string viewName, string masterName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindView(ControllerContext,
                                                                         viewName, masterName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }


        }


        public ActionResult JsonView(string viewname, string masterName, object model)
        {


            if (string.IsNullOrEmpty(viewname))
                viewname = (string)ControllerContext.RouteData.Values["action"];
            string html = "";

            try
            {
                html = RenderRazorViewToString(viewname, masterName, model);
                var data = new
                {
                    Success = true,
                    Html = html
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }

            catch (Exception e)
            {
                var data = new
                {
                    Success = false,
                    Message = e.Message,
                    Detail = e.StackTrace
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult JsonView(string viewname, object model,bool status)
        {


            if (string.IsNullOrEmpty(viewname))
                viewname = (string)ControllerContext.RouteData.Values["action"];
            string html = "";

            try
            {
                html = RenderRazorViewToString(viewname, model);
                var data = new
                {
                    Success = true,
                    Html = html,
                    Status=status
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }

            catch (Exception e)
            {
                var data = new
                {
                    Success = false,
                    Message = e.Message,
                    Detail = e.StackTrace
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult JsonView(object model = null)
        {



            return JsonView("", model,true);
        }
		#region State management
 
		private SessionWrapper _session;
		public new SessionWrapper Session
		{
			get
			{
				if (_session == null)
				{
					_session = new SessionWrapper(ControllerContext.HttpContext.Session);
				}
				return _session;
			}
			set
			{
				_session = value;
			}
		}

		private CacheWrapper _cache;
		public CacheWrapper Cache
		{
			get
			{
				if (_cache == null)
				{
					_cache = new CacheWrapper(this.ControllerContext.HttpContext.Cache);
				}
				return _cache;
			}
			set
			{
				_cache = value;
			}
		}

		/// <summary>
		/// Gets the current user in session
		/// </summary>
		public UserState UserState
		{
			get
			{
				return Session.UserState;
			}
		}

		#endregion


	

		

		#region Init
		protected override void Initialize(System.Web.Routing.RequestContext requestContext)
		{
			base.Initialize(requestContext);
			this.Init();
		}

		protected virtual void Init()
		{

			string culture = (string)RouteData.Values["CultureName"];


			if (string.IsNullOrEmpty(culture))
			{
				culture = (string)RouteData.Values["Culture"];


				var cList = idocNet.Client.Core.Configuration.SiteConfiguration.Current.AcceptedCultures;


				foreach (var c in cList)
				{
					if (c.TwoLetterISOLanguageName.Equals(culture, StringComparison.InvariantCultureIgnoreCase))
					{
						culture = c.Name;
						break;
					}
				}

			}

			if (string.IsNullOrEmpty(culture))
			{



				culture = SiteConfiguration.Current.DefaultCultureName;
			}

			CultureInfo ci = new CultureInfo(culture);
			Thread.CurrentThread.CurrentUICulture = ci;
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);


		

			if (!string.IsNullOrEmpty(User.Identity.Name) && (Session.UserState == null || !Session.UserState.SysUser.Username.Equals(User.Identity.Name, StringComparison.InvariantCultureIgnoreCase)))
			{
				var user = ServiceFactory.SysUserManager.Get(new SysUser() { Username = User.Identity.Name });


				Session.UserState = new UserState(user);
			}
			else if(string.IsNullOrEmpty(User.Identity.Name))
			{
				Session.UserState = null;

			}

		}
        
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);


          

        }
		#endregion
	}
}
