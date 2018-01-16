using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;


namespace RESYS.BIZ.Models
{
	public class UrlPageInfo : EntityBase
	{	
		[DataColum]
		public string Url { get; set; }
		[DataColum]
		public string PageTitle { get; set; }
		[DataColum]
		public string MetaKeyword { get; set; }
		[DataColum]
		public string MetaDescription { get; set; }

        [DataColum]
        public string MetaRobots { get; set; }
		
	}
}
