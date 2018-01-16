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
	class HtmlItemProvider : DataAccessBase, IHtmlItemProvider
	{
		public void Add(Models.HtmlItem item)
		{
			DbCommand comm = this.GetCommand("HtmlItem_Insert");

			comm.AddParameter<string>(this.Factory, "Code", item.Code);
			comm.AddParameter<string>(this.Factory, "Category", item.Category);
			comm.AddParameter<string>(this.Factory, "Description", item.Description);
			comm.AddParameter<string>(this.Factory, "Culture", item.Culture);
			comm.AddParameter<string>(this.Factory, "Detail", item.Detail);


			DbParameter itemIdParam = comm.AddParameter(this.Factory, "itemId", DbType.Int32, null);
			itemIdParam.Direction = ParameterDirection.Output;

			this.SafeExecuteNonQuery(comm);


			item.Id = Convert.ToInt32(itemIdParam.Value);
		}

		public Models.HtmlItem Get(Models.HtmlItem dummy)
		{
			DbCommand comm = this.GetCommand("HtmlItem_Get");

			

			comm.AddParameter<string>(this.Factory, "Code", dummy.Code);
			comm.AddParameter<string>(this.Factory, "Culture", dummy.Culture);
			

			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<HtmlItem>(dt).FirstOrDefault();
		}

		public List<Models.HtmlItem> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("HtmlItem_GetAll");

			comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
			comm.AddParameter<int>(this.Factory, "Count", count);

			DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
			totalItemsParam.Direction = ParameterDirection.Output;

			DataTable dt = this.GetTable(comm);

			if (totalItemsParam.Value != DBNull.Value)
			{
				totalItems = Convert.ToInt32(totalItemsParam.Value);
			}

			return EntityBase.ParseListFromTable<HtmlItem>(dt);
		}

		public void Remove(Models.HtmlItem item)
		{
			DbCommand comm = this.GetCommand("HtmlItem_Delete");

			

			comm.AddParameter<string>(this.Factory, "Code", item.Code);
			comm.AddParameter<string>(this.Factory, "Culture", item.Culture);
			

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(Models.HtmlItem @new, Models.HtmlItem old)
		{

			var item = @new;
			item.Code = old.Code;
			
			

			DbCommand comm = this.GetCommand("HtmlItem_Update");

			comm.AddParameter<string>(this.Factory, "Code", item.Code);
			comm.AddParameter<string>(this.Factory, "Culture", item.Culture);
			comm.AddParameter<string>(this.Factory, "Category", item.Category);
			comm.AddParameter<string>(this.Factory, "Description", item.Description);			
			comm.AddParameter<string>(this.Factory, "Detail", item.Detail);
			


			this.SafeExecuteNonQuery(comm);
		}



		public void Import(List<Models.HtmlItem> list, bool deleteExist)
		{
			throw new NotImplementedException();
		}
	}
}
