using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESYS.BIZ.Models;

namespace RESYS.WEB.State
{
	public class UserState
	{

		public SysUser SysUser
		{
			get;
			set;
		}

		public UserState(SysUser user)
		{
			this.SysUser = user;
		}


	
	}
}