using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;


namespace RESYS.BIZ.Models
{
	public enum HtmlItemFieldTypes
	{
		TEXT=0,
		HTML=1,
		INT=2,
		DOUBLE=3,
		IMAGE=4,
		SCRIPT = 5,
		AIRPORT=6,
		DATE = 7,

	}


	public class HtmlItemField : EntityBase
	{	
		[DataColum]
		public int ItemId { get; set; }
		[DataColum]
		public string FieldName { get; set; }
		[DataColum]
		public HtmlItemFieldTypes DataType { get; set; }
		[DataColum]
		public string DataValue { get; set; }


		public string GetDataValue()
		{
			return DataValue;
		}


	

		
		
	}
}
