using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RESYS.WEB.Extensions
{
	public static class UrlExtensions
	{


        public static string LocalizedUrl(this string url)
		{

            var culture = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;



            //	string defaultCulture = Portal.Configuration.SiteConfiguration.Current.DefaultCultureName;

            var cList = idocNet.Client.Core.Configuration.SiteConfiguration.Current.AcceptedCultures;



            if (url.StartsWith("/" + culture)) return url;


            foreach (var dc in cList)
            {
                if (url.StartsWith("/" + dc.TwoLetterISOLanguageName))
                {
                    url = url.Replace("/" + dc.TwoLetterISOLanguageName, "/");
                    break;
                }
            }

            return string.Format("/{0}{1}", culture, url);
		}



        public static string ActionLocalized(this UrlHelper url, string actionName)
        {

            return url.Action(actionName).LocalizedUrl();

        }

        public static string ActionLocalized(this UrlHelper url, string actionName, object routeValues)
        {

            return url.Action(actionName, routeValues).LocalizedUrl();
        }

        public static string ActionLocalized(this UrlHelper url, string actionName, System.Web.Routing.RouteValueDictionary routeValues)
        {


            return url.Action(actionName, routeValues).LocalizedUrl();
        }




        public static string ActionLocalized(this UrlHelper url, string actionName, string controllerName)
        {

            return url.Action(actionName, controllerName).LocalizedUrl();

        }


        public static string ActionLocalized(this UrlHelper url, string actionName, string controllerName, object routeValues)
        {

            return url.Action(actionName, controllerName, routeValues).LocalizedUrl();

        }

        public static string ActionLocalized(this UrlHelper url, string actionName, string controllerName, System.Web.Routing.RouteValueDictionary routeValues)
        {


            return url.Action(actionName, controllerName, routeValues).LocalizedUrl();

        }



        public static string ActionLocalized(this UrlHelper url, string actionName, string controllerName, object routeValues, string protocol)
        {


            return url.Action(actionName, controllerName, routeValues, protocol).LocalizedUrl();

        }


        public static string ActionLocalized(this UrlHelper url, string actionName, string controllerName, System.Web.Routing.RouteValueDictionary routeValues, string protocol)
        {


            return url.Action(actionName, controllerName, routeValues, protocol).LocalizedUrl();

        }

        public static string ActionLocalized(this UrlHelper url, string actionName, string controllerName, System.Web.Routing.RouteValueDictionary routeValues, string protocol, string hostName)
        {


            return url.Action(actionName, controllerName, routeValues, protocol, hostName).LocalizedUrl();

        }

	}
}