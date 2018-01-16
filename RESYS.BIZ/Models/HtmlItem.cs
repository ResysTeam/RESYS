using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;


namespace RESYS.BIZ.Models
{
	public class HtmlItem : EntityBase
	{
		[DataColum]
		public int Id { get; set; }

		[DataColum]
		public string Code { get; set; }
		[DataColum]
		public string Category { get; set; }
		[DataColum]
		public string Description { get; set; }
		[DataColum]
		public string Culture { get; set; }
		[DataColum]
		public string Detail { get; set; }


		public List<HtmlItemField> ItemFields { get; set; }


		public string this[string fieldName]
		{
			get
			{
				if (ItemFields == null) ItemFields = new List<HtmlItemField>();

				var field = ItemFields.Where(f => f.FieldName.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();


				if (field != null) return field.GetDataValue();


				return null;
			}
		}
	}
}
