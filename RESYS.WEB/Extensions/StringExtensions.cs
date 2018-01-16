using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using RESYS.BIZ.Models;
using RESYS.BIZ.Extensions;
using System.Web.Mvc;

namespace RESYS.WEB.Extensions
{
	public static class StringExtensions
	{

		public static string HtmlItemObject(this string defaultVal, HtmlItemFieldTypes fieldType, string itemCode = "", string fieldName = "")
		{

			string culture = System.Globalization.CultureInfo.CurrentCulture.ToString();


			if (string.IsNullOrEmpty(itemCode)) itemCode = "global";
			if (string.IsNullOrEmpty(fieldName)) fieldName = "defaultVal";


			return defaultVal.HtmlItem(culture, itemCode, fieldName, fieldType);
		}


		public static string HtmlItemString(this string defaultVal, string itemCode = "", string fieldName = "")
		{
			HtmlItemFieldTypes fieldType = HtmlItemFieldTypes.TEXT;
			return defaultVal.HtmlItemObject(fieldType, itemCode, fieldName);
		}

        public static string SubstringSummary(this string defaultVal, int count)
        {
            if (defaultVal == null || defaultVal.Length < count)
                return defaultVal;
            int iNextSpace = defaultVal.LastIndexOf(" ", count);
            return string.Format("{0}...", defaultVal.Substring(0, (iNextSpace > 0) ? iNextSpace : count).Trim());
        }

		public static HtmlString HtmlItemImageUrl(this string defaultVal, string itemCode = "", string fieldName = "")
		{
			HtmlItemFieldTypes fieldType = HtmlItemFieldTypes.IMAGE;

			return new HtmlString(defaultVal.HtmlItemObject(fieldType, itemCode, fieldName));
		}

		public static HtmlString HtmlItemHTML(this string defaultVal, string itemCode = "", string fieldName = "")
		{
			HtmlItemFieldTypes fieldType = HtmlItemFieldTypes.HTML;

			return new HtmlString(defaultVal.HtmlItemObject(fieldType, itemCode, fieldName));
		}

		

		public static HtmlString HtmlItemScript(this string defaultVal, string itemCode = "", string fieldName = "")
		{
			HtmlItemFieldTypes fieldType = HtmlItemFieldTypes.SCRIPT;

			return new HtmlString(defaultVal.HtmlItemObject(fieldType, itemCode, fieldName));
		}

		



		public static HtmlString EditHtmlItem(this string itemCode, string fieldName = "")
		{
			return new HtmlString(string.Format("rel=\"htmlitemeditor\" item-code=\"{0}\" item-field=\"{1}\"", itemCode, fieldName));
		}
        public static string ConvertOrderStatus(this string value)
        {
            var returnvalue = "";
            if (value.Equals(OrderStatus.Pending.ToString()))
            {
                returnvalue = "Chờ xác nhận";
            }
            if (value.Equals(OrderStatus.Active.ToString()))
            {
                returnvalue = "Đang xử lý";
            }
            if (value.Equals(OrderStatus.Complete.ToString()))
            {
                returnvalue = "Đã xử lý";
            }
            if (value.Equals(OrderStatus.Finish.ToString()))
            {
                returnvalue = "Đã xuất vé";
            }
            if (value.Equals(OrderStatus.Cancel.ToString()))
            {
                returnvalue = "Đã hủy";
            }
            return returnvalue;
        }
        public static string ConvertCustomType(this string value)
        {
            var returnvalue = "";
            if (value.Equals(OrderCustomType.Adult.ToString()))
            {
                returnvalue = "Người lớn";
            }
            if (value.Equals(OrderCustomType.Child.ToString()))
            {
                returnvalue = "Trẻ em";
            }
            if (value.Equals(OrderCustomType.Infan.ToString()))
            {
                returnvalue = "Em bé";
            }
           
            return returnvalue;
        }
        public static string ConvertPaymentMethod(this string value)
        {
            var returnvalue = "";
            if (value.Equals("pay-bank"))
            {
                returnvalue = "Thanh toán qua ngân hàng";
            }
            if (value.Equals("pay-money"))
            {
                returnvalue = "Thanh toán tại văn phòng Long Quang";
            }
            if (value.Equals("pay-card"))
            {
                returnvalue = "Thanh toán qua thẻ tín dụng";
            }

            return returnvalue;
        }
        public static MvcHtmlString CanonicalUrl(this HtmlHelper html, string path)
        {
            if (String.IsNullOrWhiteSpace(path))
            {
                var rawUrl = html.ViewContext.RequestContext.HttpContext.Request.Url;
                path = String.Format("{0}://{1}{2}", rawUrl.Scheme, rawUrl.Host, rawUrl.AbsolutePath);
            }

            path = path.ToLower();

            if (path.Count(c => c == '/') > 3)
            {
                path = path.TrimEnd('/');
            }

            if (path.EndsWith("/index"))
            {
                path = path.Substring(0, path.Length - 6);
            }

            var canonical = new TagBuilder("link");
            canonical.MergeAttribute("rel", "canonical");
            canonical.MergeAttribute("href", path);
            return new MvcHtmlString(canonical.ToString(TagRenderMode.SelfClosing));
        }
        public static MvcHtmlString CanonicalUrl(this HtmlHelper html)
        {
            var rawUrl = html.ViewContext.RequestContext.HttpContext.Request.Url;
            if (rawUrl.Host.Contains("www"))
            {
                return CanonicalUrl(html, String.Format("{0}://{1}{2}", rawUrl.Scheme, rawUrl.Host.Substring(4), rawUrl.AbsolutePath));
            }
            else
            {
                return CanonicalUrl(html, String.Format("{0}://{1}{2}", rawUrl.Scheme, rawUrl.Host, rawUrl.AbsolutePath));
            }
        }
	}
}