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
	public class FrontAdminController : FrontControllerBase
	{
		[HttpPost]
		[RequireAuthorization("SEO")]
		public ActionResult UpdateUrlPageInfo(UrlPageInfo model, string returnUrl)
		{

			var oldData = ServiceFactory.UrlPageInfoManager.Get(new UrlPageInfo() { Url = model.Url });


			if (oldData != null)
			{

				if (string.IsNullOrEmpty(model.PageTitle) && string.IsNullOrEmpty(model.MetaDescription) && string.IsNullOrEmpty(model.MetaKeyword))
				{

					//delete
					ServiceFactory.UrlPageInfoManager.Remove(model);

				}
				ServiceFactory.UrlPageInfoManager.Update(model, model);
			}
			else
				ServiceFactory.UrlPageInfoManager.Add(model);


			return Redirect(returnUrl);
		}


		[RequireAuthorization("FRONT_EDIT")]
		public ActionResult EditHtmlItem(string code, string returnUrl, string field = null)
		{
			var item = ServiceFactory.HtmlItemManager.Get(new HtmlItem() { Code = code, Culture = Culture });


			if (!string.IsNullOrEmpty(field))
			{
				for (int i = item.ItemFields.Count - 1; i >= 0; --i)
				{
					if (!item.ItemFields[i].FieldName.Equals(field))
					{
						item.ItemFields.Remove(item.ItemFields[i]);
					}
				}
			}
			ViewBag.ReturnUrl = returnUrl;

			return View(item);
		}

		
		[RequireAuthorization("FRONT_EDIT")]
		[HttpPost, ValidateInput(false)]
		[ValidateAntiForgeryToken]
		public ActionResult EditHtmlItem(HtmlItem model, string returnUrl)
		{
			model.Culture = Culture;
			var item = ServiceFactory.HtmlItemManager.Get(model);

			if (item != null )
			{
				foreach (var field in item.ItemFields)
				{
					string val = Request[field.FieldName];
					if (!string.IsNullOrEmpty(val))
					{
						field.DataValue = val;
						field.ItemId = item.Id;
						ServiceFactory.HtmlItemFieldManager.Update(field, field);
					}
				}
			}

			return Redirect(returnUrl);
		}


        //public ActionResult AirportSearch(string q)
        //{
        //    var list= ServiceFactory.AirportManager.Search(q, 20);


        //    return Json(list.Select(a=>new {code= a.AirportCode, city= a.CityName}), JsonRequestBehavior.AllowGet);
        //}

		



	}
}
