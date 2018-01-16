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
	class SysPermissionProvider : DataAccessBase, ISysPermissionProvider
	{
		public void Add(Models.SysPermission item)
		{
			DbCommand comm = this.GetCommand("SysPermission_Insert");

			comm.AddParameter<string>(this.Factory, "Code", item.Code);
			comm.AddParameter<string>(this.Factory, "Name", item.Name);
			
			this.SafeExecuteNonQuery(comm);
		}

		public Models.SysPermission Get(Models.SysPermission dummy)
		{
			DbCommand comm = this.GetCommand("SysPermission_Get");

			

			comm.AddParameter<string>(this.Factory, "Code", dummy.Code);
			

			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<SysPermission>(dt).FirstOrDefault();
		}

		public List<Models.SysPermission> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("SysPermission_GetAll");

			comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
			comm.AddParameter<int>(this.Factory, "Count", count);

			DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
			totalItemsParam.Direction = ParameterDirection.Output;

			DataTable dt = this.GetTable(comm);

			if (totalItemsParam.Value != DBNull.Value)
			{
				totalItems = Convert.ToInt32(totalItemsParam.Value);
			}

			return EntityBase.ParseListFromTable<SysPermission>(dt);
		}

		public void Remove(Models.SysPermission item)
		{
			throw new NotImplementedException();
		}

		public void Update(Models.SysPermission @new, Models.SysPermission old)
		{

			var item = @new;
			item.Code = old.Code;
			
			

			DbCommand comm = this.GetCommand("SysPermission_Update");

			comm.AddParameter<string>(this.Factory, "Code", item.Code);
			comm.AddParameter<string>(this.Factory, "Name", item.Name);
			


			this.SafeExecuteNonQuery(comm);
		}



		public void Import(List<Models.SysPermission> list, bool deleteExist)
		{


			DbCommand comm = this.GetCommandSQL("");
			DbTransaction trans = null;
			bool opened = false;

			try
			{
				StringBuilder sb = new StringBuilder();


				if (deleteExist)
				{
					sb.Append("delete from [SysPermission];");
				}

				int i = 0;
				foreach (var item in list)
				{

					item.ValidateFields();
					sb.AppendFormat(@"
				IF NOT EXISTS (SELECT * FROM [SysPermission]  Where 
				  [Code]=@Code_{0}		

				)
				BEGIN
				insert into [SysPermission] 
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
					update [SysPermission]  
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

		public List<SysPermission> GetByGroup(SysGroup group)
		{
			DbCommand comm = this.GetCommand("SysPermission_GetByGroup");



			comm.AddParameter<string>(this.Factory, "GroupCode", group.Code);


			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<SysPermission>(dt);
		}


		public List<SysPermission> GetByUser(SysUser user)
		{
			DbCommand comm = this.GetCommand("SysPermission_GetByUser");



			comm.AddParameter<string>(this.Factory, "Username", user.Username);


			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<SysPermission>(dt);
		}
	}
}
