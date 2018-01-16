using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;


namespace RESYS.BIZ.Models
{
	public class SysUser : EntityBase
	{
		[DataColum]
		[RequireField(ErrorMessage = "Bạn phải nhập Tên đăng nhập")]
		public string Username { get; set; }
		[DataColum]
		[RequireField(ErrorMessage = "Bạn phải nhập Họ tên")]
		public string Fullname { get; set; }
		[DataColum]
		[RequireField(ErrorMessage = "Bạn phải nhập Mật khẩu")]
		public string Password { get; set; }
		[DataColum]
		public string PasswordSalt { get; set; }
		[DataColum]
		public bool Active { get; set; }
		[DataColum]
		public bool SysAdmin { get; set; }
		[DataColum]
		public DateTime InsertDate { get; set; }
		[DataColum]
		public DateTime UpdateDate { get; set; }


		public List<SysGroup> Groups { get; set; }
		public List<SysPermission> Permissions { get; set; }



		public bool HasPermission(string permissionCode)
		{
			if (!this.Active) return false;
			if (this.SysAdmin) return true;
			if (this.Permissions == null) return false;

			return this.Permissions.Exists(p => p.Code.Equals(permissionCode, StringComparison.InvariantCultureIgnoreCase));

		}

	}
}
