using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;


namespace RESYS.BIZ.Models
{
	public class PotentialCustomer : EntityBase
	{	
		[DataColum]
		public int Id { get; set; }
		[DataColum]
		public string CusName { get; set; }
		[DataColum]
		public string CusPhone { get; set; }
		[DataColum]
		public string CusEmail { get; set; }
		
		
		
	}
}
