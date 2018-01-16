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
	class UrlPageInfoProvider : DataAccessBase, IUrlPageInfoProvider
	{
		public void Add(Models.UrlPageInfo item)
		{
			DbCommand comm = this.GetCommand("UrlPageInfo_Insert");

			comm.AddParameter<string>(this.Factory, "Url", item.Url);
			comm.AddParameter<string>(this.Factory, "PageTitle", item.PageTitle);
			comm.AddParameter<string>(this.Factory, "MetaKeyword", item.MetaKeyword);
			comm.AddParameter<string>(this.Factory, "MetaDescription", item.MetaDescription);
            comm.AddParameter<string>(this.Factory, "MetaRobots", item.MetaRobots);
			
			this.SafeExecuteNonQuery(comm);
		}

		public Models.UrlPageInfo Get(Models.UrlPageInfo dummy)
		{
			DbCommand comm = this.GetCommand("UrlPageInfo_Get");

			

			comm.AddParameter<string>(this.Factory, "Url", dummy.Url);
			

			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<UrlPageInfo>(dt).FirstOrDefault();
		}

		public List<Models.UrlPageInfo> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("UrlPageInfo_GetAll");

			comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
			comm.AddParameter<int>(this.Factory, "Count", count);

			DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
			totalItemsParam.Direction = ParameterDirection.Output;

			DataTable dt = this.GetTable(comm);

			if (totalItemsParam.Value != DBNull.Value)
			{
				totalItems = Convert.ToInt32(totalItemsParam.Value);
			}

			return EntityBase.ParseListFromTable<UrlPageInfo>(dt);
		}

		public void Remove(Models.UrlPageInfo item)
		{
			DbCommand comm = this.GetCommand("UrlPageInfo_Delete");

			

			comm.AddParameter<string>(this.Factory, "Url", item.Url);
			

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(Models.UrlPageInfo @new, Models.UrlPageInfo old)
		{

			var item = @new;
			item.Url = old.Url;
			
			

			DbCommand comm = this.GetCommand("UrlPageInfo_Update");

			comm.AddParameter<string>(this.Factory, "Url", item.Url);
			comm.AddParameter<string>(this.Factory, "PageTitle", item.PageTitle);
			comm.AddParameter<string>(this.Factory, "MetaKeyword", item.MetaKeyword);
			comm.AddParameter<string>(this.Factory, "MetaDescription", item.MetaDescription);
            comm.AddParameter<string>(this.Factory, "MetaRobots", item.MetaRobots);
			


			this.SafeExecuteNonQuery(comm);
		}



		public void Import(List<Models.UrlPageInfo> list, bool deleteExist)
		{


			DbCommand comm = this.GetCommandSQL("");
			DbTransaction trans = null;
			bool opened = false;

			try
			{
				StringBuilder sb = new StringBuilder();


				if (deleteExist)
				{
					sb.Append("delete from [UrlPageInfo];");
				}

				int i = 0;
				foreach (var item in list)
				{

					item.ValidateFields();
					sb.AppendFormat(@"
				IF NOT EXISTS (SELECT * FROM [UrlPageInfo]  Where 
				  [Url]=@Url_{0}		

				)
				BEGIN
				insert into [UrlPageInfo] 
				(
                  Url,
			      PageTitle,
			      MetaKeyword,
			      MetaDescription
				  
				 ) 
				 values(
                 @Url_{0},
			      @PageTitle_{0},
			      @MetaKeyword_{0},
			      @MetaDescription_{0}
				  
				  )

				END 
				ELSE BEGIN
					update [UrlPageInfo]  
					SET 

					[Url]=@Url_{0},
				  [PageTitle]=@PageTitle_{0},
				  [MetaKeyword]=@MetaKeyword_{0},
				  [MetaDescription]=@MetaDescription_{0}
							
					
					Where 
					[Url]=@Url_{0}	
				END;", i);


					
			comm.AddParameter<string>(this.Factory, string.Format("Url_{0}", i), item.Url);
			comm.AddParameter<string>(this.Factory, string.Format("PageTitle_{0}", i), item.PageTitle);
			comm.AddParameter<string>(this.Factory, string.Format("MetaKeyword_{0}", i), item.MetaKeyword);
			comm.AddParameter<string>(this.Factory, string.Format("MetaDescription_{0}", i), item.MetaDescription);
			
					i++;


				}



				comm.Connection.Open();
				opened = true;
				trans = comm.Connection.BeginTransaction();
				comm.Transaction = trans;

				comm.CommandText = sb.ToString();
				comm.ExecuteNonQuery();


				trans.Commit();


			}
			catch (Exception ex)
			{
				if (opened)
				trans.Rollback();


				throw ex;
			}

			finally
			{
				if (opened)	
				comm.Connection.Close();
			}

		}
	}
}
