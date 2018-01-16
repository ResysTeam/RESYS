using System.Web.Mvc;

namespace RESYS.WEB.Areas.Admin
{
	public class AdminAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "Admin";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{

			

			context.MapRoute(
				"Admin_default",
				"{culture}/admin/{controller}/{action}/{id}",
				new {culture="vi", controller="home", action = "Index", id = UrlParameter.Optional },
				new[] { "RESYS.WEB.Areas.Admin.Controllers" }
			);
            context.MapRoute(
                "Admin_vi",
                "admin/{controller}/{action}/{id}",
                new { culture = "vi", controller = "home", action = "Index", id = UrlParameter.Optional },
                new[] { "RESYS.WEB.Areas.Admin.Controllers" }
            );
			
		}
	}
}
