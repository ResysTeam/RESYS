using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;


namespace RESYS.BIZ.Models
{
	public class GroupPermission : EntityBase
	{	
		[DataColum]
		public string GroupCode { get; set; }
		[DataColum]
		public string PermissionCode { get; set; }
		
		
		
	}
}
