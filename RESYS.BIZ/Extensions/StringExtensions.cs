using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RESYS.BIZ.Models;
using RESYS.BIZ.Services;
namespace RESYS.BIZ.Extensions
{
	public static class StringExtensions
	{
		public static string HtmlItem(this string defaultVal, string culture, string itemCode, string fieldName, HtmlItemFieldTypes fieldType)
		{
			var htmlItem = ServiceFactory.HtmlItemManager.Get(new HtmlItem() { Code = itemCode, Culture= culture });
			if (htmlItem == null)
			{
				htmlItem = new HtmlItem()
				{
					Code = itemCode,
					Culture = culture,
					ItemFields = new List<HtmlItemField>()

				};

				ServiceFactory.HtmlItemManager.Add(htmlItem);
			}

			var field = htmlItem.ItemFields.Where(f => f.FieldName.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();


			if (field != null)
			{

				if (fieldType != field.DataType)
				{
					htmlItem.ItemFields.Remove(field);

					var newField = new HtmlItemField()
					{
						ItemId = htmlItem.Id,
						FieldName = fieldName,
						DataType = fieldType,
						DataValue = defaultVal,
					};

					htmlItem.ItemFields.Add(newField);

					ServiceFactory.HtmlItemFieldManager.Update(newField, field);
					

				}

			}
			else
			{
				var newField= new HtmlItemField()
				{
					ItemId = htmlItem.Id,
					FieldName = fieldName,
					DataType = fieldType,
					DataValue = defaultVal,
				};
				htmlItem.ItemFields.Add(newField);

				ServiceFactory.HtmlItemFieldManager.Add(newField);
			}


			return htmlItem[fieldName];
		}


	}
}
