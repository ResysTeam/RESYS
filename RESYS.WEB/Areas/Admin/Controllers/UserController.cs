using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RESYS.BIZ.Models;
using RESYS.BIZ.Services;
using RESYS.WEB.Filters;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.WEB.Areas.Admin.Controllers
{
	[RequireAuthorization("sysadmin")]
	public class UserController : AdminControllerBase
	{
		//
		// GET: /Admin/User/


		public ActionResult Index()
		{


			var list = ServiceFactory.SysUserManager.GetAll();
			return View(list);
		}
		#region users

		private List<SysGroup> GetGroupListFromRequest()
		{
			List<SysGroup> list = new List<SysGroup>();

			var all = ServiceFactory.SysGroupManager.GetAll();


			all.ForEach(p =>
			{
				string key = string.Format("group_{0}", p.Code);

				if (Request[key] == "true")
				{
					list.Add(p);
				}
			});

			return list;




		}
		[HttpGet]
		public ActionResult UserEdit(string id)
		{
			SysUser model = ServiceFactory.SysUserManager.Get(new SysUser()
			{
				Username = id
			});
			ViewBag.AllGroups = ServiceFactory.SysGroupManager.GetAll();
			return View("UserEdit", model);
		}

		public ActionResult ResetPassword(string username, string password)
		{

			var user = ServiceFactory.SysUserManager.Get(new SysUser() { Username=username});

			user.Password = password;
			ServiceFactory.SysUserManager.Update(user, true);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult UserEdit(SysUser model)
		{
			if (ModelState.IsValid)
			{
				try
				{

					
					var old = ServiceFactory.SysUserManager.Get(model);
					old.Groups = GetGroupListFromRequest();

					old.Fullname = model.Fullname;
					old.Active = model.Active;
					old.SysAdmin = model.SysAdmin;
					ServiceFactory.SysUserManager.Update(old);

					return RedirectToAction("Index");
				}
				catch (ValidationException ex)
				{
					AddErrors(ModelState, ex);

				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex);
				}
			}


			ViewBag.AllPermissions = ServiceFactory.SysPermissionManager.GetAll();
			return View("UserEdit", model);
		}


		[HttpGet]
		public ActionResult UserCreate()
		{
			SysUser model = new SysUser()
			{
				
			};
			ViewBag.AllGroups = ServiceFactory.SysGroupManager.GetAll();
			return View(model);
		}

		[HttpPost]
		public ActionResult UserCreate(SysUser model)
		{
			if (ModelState.IsValid)
			{
				try
				{


					
					model.Groups = GetGroupListFromRequest();

					
					ServiceFactory.SysUserManager.Add(model);

					return RedirectToAction("Index");
				}
				catch (ValidationException ex)
				{
					AddErrors(ModelState, ex);

				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex);
				}
			}


			ViewBag.AllPermissions = ServiceFactory.SysPermissionManager.GetAll();
			return View("UserEdit", model);
		}


		#endregion


		#region group
		public ActionResult Groups()
		{

			var list = ServiceFactory.SysGroupManager.GetAll();
			return View(list);
		}


		[NonAction]
		private List<SysPermission> GetPermissionListFromRequest()
		{
			List<SysPermission> list = new List<SysPermission>();

			var all= ServiceFactory.SysPermissionManager.GetAll();


			all.ForEach(p =>
			{
				string key = string.Format("permission_{0}", p.Code);

				if (Request[key] == "true")
				{
					list.Add(p);
				}
			});

			return list;



		}


		[HttpGet]
		public ActionResult GroupCreate()
		{
			SysGroup model = new SysGroup();
			ViewBag.AllPermissions = ServiceFactory.SysPermissionManager.GetAll();
			return View("GroupEdit", model);
		}

		[HttpGet]
		public ActionResult GroupEdit(string id)
		{
			SysGroup model = ServiceFactory.SysGroupManager.Get(new SysGroup()
			{
				Code=id
			});
			ViewBag.AllPermissions = ServiceFactory.SysPermissionManager.GetAll();
			return View("GroupEdit", model);
		}




		public ActionResult GroupDelete(string id)
		{
			ServiceFactory.SysGroupManager.Remove(new SysGroup()
			{
				Code = id
			});

			return RedirectToAction("Groups");

		}

		[HttpPost]
		public ActionResult GroupCreate(SysGroup model)
		{
			if (ModelState.IsValid)
			{
				try
				{

					model.Permissions = GetPermissionListFromRequest();
					ServiceFactory.SysGroupManager.Add(model);

					return RedirectToAction("Groups");
				}
				catch (ValidationException ex)
				{
					AddErrors(ModelState, ex);

				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex);
				}
			}


			ViewBag.AllPermissions = ServiceFactory.SysPermissionManager.GetAll();
			return View("GroupEdit", model);
		}



		[HttpPost]
		public ActionResult GroupEdit(SysGroup model)
		{
			if (ModelState.IsValid)
			{
				try
				{

					model.Permissions = GetPermissionListFromRequest();
					ServiceFactory.SysGroupManager.Update(model);

					return RedirectToAction("Groups");
				}
				catch (ValidationException ex)
				{
					AddErrors(ModelState, ex);

				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex);
				}
			}


			ViewBag.AllPermissions = ServiceFactory.SysPermissionManager.GetAll();
			return View("GroupEdit", model);
		}




		#endregion

	}
}
