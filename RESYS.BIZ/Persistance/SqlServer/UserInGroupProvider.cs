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
	class SysUserInGroupProvider : DataAccessBase, ISysUserInGroupProvider
	{
		public void Add(Models.SysUserInGroup item)
		{
			DbCommand comm = this.GetCommand("SysUserInGroup_Insert");

			comm.AddParameter<string>(this.Factory, "Username", item.Username);
			comm.AddParameter<string>(this.Factory, "GroupCode", item.GroupCode);
			
			this.SafeExecuteNonQuery(comm);
		}

		public Models.SysUserInGroup Get(Models.SysUserInGroup dummy)
		{
			DbCommand comm = this.GetCommand("SysUserInGroup_Get");

			

			comm.AddParameter<string>(this.Factory, "Username", dummy.Username);
			

			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<SysUserInGroup>(dt).FirstOrDefault();
		}

		public List<Models.SysUserInGroup> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("SysUserInGroup_GetAll");

			comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
			comm.AddParameter<int>(this.Factory, "Count", count);

			DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
			totalItemsParam.Direction = ParameterDirection.Output;

			DataTable dt = this.GetTable(comm);

			if (totalItemsParam.Value != DBNull.Value)
			{
				totalItems = Convert.ToInt32(totalItemsParam.Value);
			}

			return EntityBase.ParseListFromTable<SysUserInGroup>(dt);
		}

		public void Remove(Models.SysUserInGroup item)
		{
			throw new NotImplementedException();
		}

		public void Update(Models.SysUserInGroup @new, Models.SysUserInGroup old)
		{

			var item = @new;
			item.Username = old.Username;
			
			

			DbCommand comm = this.GetCommand("SysUserInGroup_Update");

			comm.AddParameter<string>(this.Factory, "Username", item.Username);
			comm.AddParameter<string>(this.Factory, "GroupCode", item.GroupCode);
			


			this.SafeExecuteNonQuery(comm);
		}



		public void Import(List<Models.SysUserInGroup> list, bool deleteExist)
		{


			DbCommand comm = this.GetCommandSQL("");
			DbTransaction trans = null;
			bool opened = false;

			try
			{
				StringBuilder sb = new StringBuilder();


				if (deleteExist)
				{
					sb.Append("delete from [SysUserInGroup];");
				}

				int i = 0;
				foreach (var item in list)
				{

					item.ValidateFields();
					sb.AppendFormat(@"
				IF NOT EXISTS (SELECT * FROM [SysUserInGroup]  Where 
				  [Username]=@Username_{0}		

				)
				BEGIN
				insert into [SysUserInGroup] 
				(
                  Username,
			      GroupCode
				  
				 ) 
				 values(
                 @Username_{0},
			      @GroupCode_{0}
				  
				  )

				END 
				ELSE BEGIN
					update [SysUserInGroup]  
					SET 

					[Username]=@Username_{0},
				  [GroupCode]=@GroupCode_{0}
							
					
					Where 
					[Username]=@Username_{0}	
				END;", i);


					
			comm.AddParameter<string>(this.Factory, string.Format("Username_{0}", i), item.Username);
			comm.AddParameter<string>(this.Factory, string.Format("GroupCode_{0}", i), item.GroupCode);
			
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

		public List<SysUserInGroup> GetByUser(SysUser user)
		{
			DbCommand comm = this.GetCommand("SysUserInGroup_GetByUser");



			comm.AddParameter<string>(this.Factory, "Username", user.Username);


			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<SysUserInGroup>(dt);
		}

		public void DeleteByUser(SysUser user)
		{
			DbCommand comm = this.GetCommand("SysUserInGroup_DeleteByUser");



			comm.AddParameter<string>(this.Factory, "Username", user.Username);
			this.SafeExecuteNonQuery(comm);

		}
	}
}
