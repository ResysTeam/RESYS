using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.DataAccess;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Utils;
using System.Data;
using System.Data.Common;
using idocNet.Client.Core.Data.Serialization;
using RESYS.BIZ.Models;

namespace RESYS.BIZ.Persistance.SqlServer
{
	class HtmlItemFieldProvider : DataAccessBase, IHtmlItemFieldProvider
	{
		public void Add(Models.HtmlItemField item)
		{
			DbCommand comm = this.GetCommand("HtmlItemField_Insert");

			comm.AddParameter<int>(this.Factory, "ItemId", item.ItemId);
			comm.AddParameter<string>(this.Factory, "FieldName", item.FieldName);
			comm.AddParameter<int>(this.Factory, "DataType", (int)item.DataType);
			comm.AddParameter<string>(this.Factory, "DataValue", item.DataValue);

			comm.SafeExecuteNonQuery();
		}

		public Models.HtmlItemField Get(Models.HtmlItemField dummy)
		{
			throw new NotImplementedException();
		}

		public List<Models.HtmlItemField> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("HtmlItemField_GetAll");

			comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
			comm.AddParameter<int>(this.Factory, "Count", count);

			DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
			totalItemsParam.Direction = ParameterDirection.Output;

			DataTable dt = this.GetTable(comm);

			if (totalItemsParam.Value != DBNull.Value)
			{
				totalItems = Convert.ToInt32(totalItemsParam.Value);
			}

			return EntityBase.ParseListFromTable<HtmlItemField>(dt);
		}

		public void Remove(Models.HtmlItemField item)
		{
			DbCommand comm = this.GetCommand("HtmlItemField_Delete");

			comm.AddParameter<int>(this.Factory, "ItemId", item.ItemId);
			comm.AddParameter<string>(this.Factory, "Fieldname", item.FieldName);

			comm.SafeExecuteNonQuery();

			
		}

		public void Update(Models.HtmlItemField @new, Models.HtmlItemField old)
		{

			throw new NotImplementedException();
		}



		public void Import(List<Models.HtmlItemField> list, bool deleteExist)
		{
			throw new NotImplementedException();
		}

		public List<HtmlItemField> GetByItem(HtmlItem item)
		{
			DbCommand comm = this.GetCommand("HtmlItemField_GetByItem");

			comm.AddParameter<int>(this.Factory, "ItemId", item.Id);

			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<HtmlItemField>(dt);
		}
	}
}
