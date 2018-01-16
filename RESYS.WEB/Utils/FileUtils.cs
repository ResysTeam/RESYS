using idocNet.Client.Core.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RESYS.WEB.Utils
{
	public class FileUtils
	{

		public static string GetTempDir()
		{
			return "TempFiles";
		}

		public static string GetUploadDir()
		{
			return "Uploads";
		}

		public static string GetTempDirPhysicalPath()
		{
			return HttpContext.Current.Server.MapPath(string.Format("~/{0}", GetUploadDir()));
		}
		public static string GetUploadDirPhysicalPath()
		{
			return HttpContext.Current.Server.MapPath(string.Format("~/{0}", GetUploadDir()));
		}

		public static string GetTempFilePhysicalPath(string fileId, string extension)
		{
			return HttpContext.Current.Server.MapPath(string.Format("~/{0}/{1}{2}", GetTempDir(), fileId, extension));
		}

		public static string GetUploadFilePhysicalPath(string fileId, string extension)
		{
			return HttpContext.Current.Server.MapPath(string.Format("~/{0}/{1}{2}", GetUploadDir(), fileId, extension));
		}

		public static string GetTempFileVirtualPath(string fileId, string extension)
		{
			return string.Format("~/{0}/{1}{2}", GetTempDir(), fileId, extension);
		}


		public static string GetUploadFileVirtualPath(string fileId, string extension)
		{
			return string.Format("~/{0}/{1}{2}", GetUploadDir(), fileId, extension);
		}


		public static string SaveTempFile(HttpPostedFileWrapper file, string fileId, string extension)
		{
			IOUtility.EnsureDirectoryExists(FileUtils.GetTempDirPhysicalPath());

			var filePath = GetTempFilePhysicalPath(fileId, extension);
			file.SaveAs(filePath);
			return filePath;
		}

		public static string SaveUploadFile(HttpPostedFileWrapper file, string fileId, string extension)
		{
			IOUtility.EnsureDirectoryExists(FileUtils.GetUploadDirPhysicalPath());

			var filePath = GetUploadFilePhysicalPath(fileId, extension);
			file.SaveAs(filePath);
			return filePath;
		}
        protected static string GetPhysicalFilePath(string virtualFilePath)
        {
            if (!string.IsNullOrEmpty(virtualFilePath))
            {
                virtualFilePath = virtualFilePath.Replace("/", "\\").Trim();
                if (virtualFilePath.StartsWith("\\"))
                    virtualFilePath = virtualFilePath.Substring(1);
                return Path.Combine(HttpRuntime.AppDomainAppPath, virtualFilePath);
            }
            else
                return string.Empty;
        }
        protected static string GetContentFromPhysicalFile(string physicalFilePath)
        {
            string content = string.Empty;
            if (File.Exists(physicalFilePath))
                content = File.ReadAllText(physicalFilePath);
            return content;
        }
        public static string GetContentFromFile(string virtualFilePath)
        {
            return GetContentFromPhysicalFile(GetPhysicalFilePath(virtualFilePath));
        }
	}
}