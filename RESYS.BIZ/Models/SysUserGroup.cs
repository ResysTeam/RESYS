using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;


namespace  RESYS.BIZ.Models
{
	public class SysGroup : EntityBase
	{	
		[DataColum]
		[DataColumEx("GroupCode")]
		[RequireField]
		public string Code { get; set; }
		
		[DataColum]
		[RequireField]
		[DataColumEx("GroupName")]
		public string Name { get; set; }



		public List<SysPermission> Permissions
		{
			get;
			set;
		}
		
		
	}
}
