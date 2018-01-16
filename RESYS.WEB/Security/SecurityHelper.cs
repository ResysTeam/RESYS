using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using RESYS.BIZ.Models;
using RESYS.BIZ.Services;
using RESYS.WEB.State;

namespace RESYS.WEB.Security
{
	public class SecurityHelper
	{

		/// <summary>
		/// Checks if a external provider is trying to post a login on this website.
		/// </summary>
		public static bool TryLoginFromProviders(SessionWrapper session, CacheWrapper cache, HttpContextBase context)
		{
			bool logged = false;

			if (TryFinishMembershipLogin(context, session))
			{
				logged = true;
			}
			return logged;
		}

		#region Membership

		/// <summary>
		/// If enabled by configuration, tries to login the current membership user (reading cookie / identity) as nearforums user
		/// </summary>
		public static bool TryFinishMembershipLogin(HttpContextBase context, SessionWrapper session)
		{
			if (!String.IsNullOrEmpty(context.User.Identity.Name))
			{
				return TryFinishMembershipLogin(session, Membership.GetUser());
			}
			else
			{
				return false;
			}


		}
		/// <summary>
		/// Logs the user in or creates the a site user account if the user does not exist, based on membership user.
		/// Sets the logged user in the session.
		/// </summary>
		/// <exception cref="ValidationException"></exception>
		public static bool TryFinishMembershipLogin(SessionWrapper session, MembershipUser MembershipUser)
		{
			bool logged = false;

			if (MembershipUser != null)
			{


				var user = ServiceFactory.SysUserManager.Get(new SysUser() { Username = MembershipUser.UserName });
				session.UserState = new UserState(user);

				logged = true;
			}

			return logged;
		}



		#endregion
	}
}