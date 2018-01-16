using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;


namespace  RESYS.BIZ.Models
{
	public class SysUserInGroup : EntityBase
	{
		[DataColum]
		public string Username { get; set; }
		[DataColum]
		public string GroupCode { get; set; }


		[DataEx]
		public SysGroup Group { get; set; }



	}
}
