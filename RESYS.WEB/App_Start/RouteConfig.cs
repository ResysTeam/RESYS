using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RESYS.WEB
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
			 "NetAdvImage",
			 "{scriptPath}/tinymce/plugins/netadvimage/{action}",
			 new { controller = "NetAdvImage" },
             new[] { "RESYS.WEB.Controllers" }
		 );


            routes.MapRoute(
               "news-detail",
               "{culture}/nd/{category}/{shortname}/{newsid}",
               new { culture = "vi", controller = "News", action = "Detail", category = UrlParameter.Optional, shortname = UrlParameter.Optional, newsid = UrlParameter.Optional },
                new[] { "RESYS.WEB.Controllers" }
              );



            routes.MapRoute(
                 "front_news_list",
                 "{culture}/ln/{shortname}/{page}",
                 new { culture = "vi", controller = "News", action = "NewsCategory", shortname = UrlParameter.Optional, page = UrlParameter.Optional },
                 new[] { "RESYS.WEB.Controllers" }
             );

           

            #region Library
            routes.MapRoute(
                "Library_movie",
                "{culture}/lb/Movie-View/{shortname}/{page}",
                new { culture = "vi", controller = "Library", action = "IndexVideo", page = UrlParameter.Optional, shortname = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "RESYS.WEB.Controllers" }
            );

            routes.MapRoute(
                 "Library_image",
                 "{culture}/lb/Image-View/{shortname}/{page}",
                 new { culture = "vi", controller = "Library", action = "IndexImage", page = UrlParameter.Optional, shortname = UrlParameter.Optional, id = UrlParameter.Optional },
                 new[] { "RESYS.WEB.Controllers" }
             );

            routes.MapRoute(
                "Library_all",
                "{culture}/lb/All-View/{shortname}/{page}",
                new { culture = "vi", controller = "Library", action = "Index", page = UrlParameter.Optional, shortname = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "RESYS.WEB.Controllers" }
            );

            #endregion

            #region Company
            routes.MapRoute(
                "Company_detail",
                "{culture}/Affiliates/{shortname}-{id}",
                new { culture = "vi", controller = "Company", action = "Company", id = UrlParameter.Optional, shortname = UrlParameter.Optional },
                new[] { "RESYS.WEB.Controllers" }
            );

            routes.MapRoute(
                "company",
                "{culture}/Affiliates/{action}",
                new { culture = "vi", controller = "Company", action = "Index" },
                new[] { "RESYS.WEB.Controllers" }
            );

            #endregion

            #region Introduction
            routes.MapRoute(
                "introduction_detail",
                "{culture}/About-Us/{shortname}-{id}",
                new { culture = "vi", controller = "Introduction", action = "Introduction", id = UrlParameter.Optional, shortname = UrlParameter.Optional },
                new[] { "RESYS.WEB.Controllers" }
            );

            routes.MapRoute(
                "introduction_develop",
                "{culture}/History",
                new { culture = "vi", controller = "Introduction", action = "Develop", id = UrlParameter.Optional },
                new[] { "RESYS.WEB.Controllers" }
            );
            routes.MapRoute(
                "introduction",
                "{culture}/About-Us/{action}",
                new { culture = "vi", controller = "Introduction",action="Index" },
                new[] { "RESYS.WEB.Controllers" }
            );

            #endregion

            routes.MapRoute(
				"front_default",
				"{culture}/{controller}/{action}/{id}",
				new {culture="vi", controller="Home", action = "Index", id = UrlParameter.Optional },
				new[] { "RESYS.WEB.Controllers" }
			);
		}
	}
}