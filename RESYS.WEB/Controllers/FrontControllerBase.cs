using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESYS.BIZ.Models;
using RESYS.BIZ.Services;

namespace RESYS.WEB.Controllers
{
	public class FrontControllerBase : ControllerBase
	{

		#region url page info

		public string GetUrlId()
		{
			string controler = (string)this.ControllerContext.RouteData.Values["controller"];
			string action = (string)this.ControllerContext.RouteData.Values["action"];


			var otherparams = this.ControllerContext.RouteData.Values.Where(v => !(v.Key.Equals("controller", StringComparison.InvariantCultureIgnoreCase) || v.Key.Equals("action", StringComparison.InvariantCultureIgnoreCase))).OrderBy(v => v.Key.ToLower()).ToList();

			var _params = otherparams.Select(p => p.Value.ToString()).ToList();

			_params.Insert(0, action);
			_params.Insert(0, controler);

			return string.Join("$", _params).ToLower();
		}
		public UrlPageInfo GetPageInfo()
		{
			var id = GetUrlId();
			var data = ServiceFactory.UrlPageInfoManager.Get(new UrlPageInfo() { Url = id });
			return data;
		}

		public void UpdatePageInfo(string pageTitle, string metaKeyword, string metaDescription)
		{
		}

		#endregion


		protected override void Init()
		{
			base.Init();

			ViewBag.PageTitle = "Thành Công Group";
            ViewBag.MetaKeyword = "Thành Công Group";
            ViewBag.MetaDescription = "Thành Công Group";

			ViewBag.UrlPageId = GetUrlId();
			ViewBag.UrlPageInfo = GetPageInfo();

		
           
		}
	}
}