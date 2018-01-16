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
using  RESYS.BIZ.Models;

namespace  RESYS.BIZ.Persistance.SqlServer
{
	class SysGroupProvider : DataAccessBase, ISysGroupProvider
	{
		public void Add(Models.SysGroup item)
		{
			DbCommand comm = this.GetCommand("SysGroup_Insert");

			comm.AddParameter<string>(this.Factory, "Code", item.Code);
			comm.AddParameter<string>(this.Factory, "Name", item.Name);
			
			this.SafeExecuteNonQuery(comm);
		}

		public Models.SysGroup Get(Models.SysGroup dummy)
		{
			DbCommand comm = this.GetCommand("SysGroup_Get");

			

			comm.AddParameter<string>(this.Factory, "Code", dummy.Code);
			

			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<SysGroup>(dt).FirstOrDefault();
		}

		public List<Models.SysGroup> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("SysGroup_GetAll");

			comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
			comm.AddParameter<int>(this.Factory, "Count", count);

			DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
			totalItemsParam.Direction = ParameterDirection.Output;

			DataTable dt = this.GetTable(comm);

			if (totalItemsParam.Value != DBNull.Value)
			{
				totalItems = Convert.ToInt32(totalItemsParam.Value);
			}

			return EntityBase.ParseListFromTable<SysGroup>(dt);
		}

		public void Remove(Models.SysGroup item)
		{
			DbCommand comm = this.GetCommand("SysGroup_Delete");

			comm.AddParameter<string>(this.Factory, "Code", item.Code);

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(Models.SysGroup @new, Models.SysGroup old)
		{

			var item = @new;
			item.Code = old.Code;
			
			

			DbCommand comm = this.GetCommand("SysGroup_Update");

			comm.AddParameter<string>(this.Factory, "Code", item.Code);
			comm.AddParameter<string>(this.Factory, "Name", item.Name);
			


			this.SafeExecuteNonQuery(comm);
		}



		public void Import(List<Models.SysGroup> list, bool deleteExist)
		{


			DbCommand comm = this.GetCommandSQL("");
			DbTransaction trans = null;
			bool opened = false;

			try
			{
				StringBuilder sb = new StringBuilder();


				if (deleteExist)
				{
					sb.Append("delete from [SysGroup];");
				}

				int i = 0;
				foreach (var item in list)
				{

					item.ValidateFields();
					sb.AppendFormat(@"
				IF NOT EXISTS (SELECT * FROM [SysGroup]  Where 
				  [Code]=@Code_{0}		

				)
				BEGIN
				insert into [SysGroup] 
				(
                  Code,
			      Name
				  
				 ) 
				 values(
                 @Code_{0},
			      @Name_{0}
				  
				  )

				END 
				ELSE BEGIN
					update [SysGroup]  
					SET 

					[Code]=@Code_{0},
				  [Name]=@Name_{0}
							
					
					Where 
					[Code]=@Code_{0}	
				END;", i);


					
			comm.AddParameter<string>(this.Factory, string.Format("Code_{0}", i), item.Code);
			comm.AddParameter<string>(this.Factory, string.Format("Name_{0}", i), item.Name);
			
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
