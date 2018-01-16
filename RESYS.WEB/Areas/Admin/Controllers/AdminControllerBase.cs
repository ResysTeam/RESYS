using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RESYS.WEB.State;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.WEB.Areas.Admin.Controllers
{
	[Authorize]
    public class AdminControllerBase : RESYS.WEB.Controllers.ControllerBase
    {
	
		



		#region Init
		protected override void Initialize(System.Web.Routing.RequestContext requestContext)
		{
			base.Initialize(requestContext);
			this.Init();
		}

		protected override void Init()
		{
			base.Init();

		}

		#endregion



		protected void AddErrors(ModelStateDictionary modelState, idocNet.Client.Core.Data.Entities.Validation.ValidationException ex)
		{
			foreach (ValidationError error in ex.ValidationErrors)
			{
				modelState.AddModelError(error.FieldName, error);
			}
		}




		public string GenExcelExportFilePath(string prefix, ref string virualPath)
		{

			String subpath = string.Format("/TempFiles/{0}", DateTime.Now.ToString("yyyy-MM-dd"));

			string filename = string.Format("{0}_{1}", prefix, DateTime.Now.ToString("yyMMddHHmmss"));



			string subpathPhys = Server.MapPath(subpath);

			if (!Directory.Exists(subpathPhys))
			{
				Directory.CreateDirectory(subpathPhys);
			}


			virualPath = string.Format("{0}/{1}.xlsx", subpath, filename);
			string filePath = Server.MapPath(virualPath);


			int i = 0;
			while (System.IO.File.Exists(filePath))
			{

				virualPath = string.Format("{0}/{1}_{2}.xlsx", subpath, filename, ++i);
				filePath = Server.MapPath(virualPath);
			}


			return filePath;
		}

    }


}
