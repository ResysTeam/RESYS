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
	class GroupPermissionProvider : DataAccessBase, IGroupPermissionProvider
	{
		public void Add(Models.GroupPermission item)
		{
			DbCommand comm = this.GetCommand("GroupPermission_Insert");

			comm.AddParameter<string>(this.Factory, "GroupCode", item.GroupCode);
			comm.AddParameter<string>(this.Factory, "PermissionCode", item.PermissionCode);
			
			this.SafeExecuteNonQuery(comm);
		}

		public Models.GroupPermission Get(Models.GroupPermission dummy)
		{
			DbCommand comm = this.GetCommand("GroupPermission_Get");

			

			comm.AddParameter<string>(this.Factory, "GroupCode", dummy.GroupCode);
			

			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<GroupPermission>(dt).FirstOrDefault();
		}

		public List<Models.GroupPermission> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("GroupPermission_GetAll");

			comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
			comm.AddParameter<int>(this.Factory, "Count", count);

			DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
			totalItemsParam.Direction = ParameterDirection.Output;

			DataTable dt = this.GetTable(comm);

			if (totalItemsParam.Value != DBNull.Value)
			{
				totalItems = Convert.ToInt32(totalItemsParam.Value);
			}

			return EntityBase.ParseListFromTable<GroupPermission>(dt);
		}

		public void Remove(Models.GroupPermission item)
		{
			throw new NotImplementedException();
		}

		public void Update(Models.GroupPermission @new, Models.GroupPermission old)
		{

			var item = @new;
			item.GroupCode = old.GroupCode;
			
			

			DbCommand comm = this.GetCommand("GroupPermission_Update");

			comm.AddParameter<string>(this.Factory, "GroupCode", item.GroupCode);
			comm.AddParameter<string>(this.Factory, "PermissionCode", item.PermissionCode);
			


			this.SafeExecuteNonQuery(comm);
		}



		public void Import(List<Models.GroupPermission> list, bool deleteExist)
		{


			DbCommand comm = this.GetCommandSQL("");
			DbTransaction trans = null;
			bool opened = false;

			try
			{
				StringBuilder sb = new StringBuilder();


				if (deleteExist)
				{
					sb.Append("delete from [GroupPermission];");
				}

				int i = 0;
				foreach (var item in list)
				{

					item.ValidateFields();
					sb.AppendFormat(@"
				IF NOT EXISTS (SELECT * FROM [GroupPermission]  Where 
				  [GroupCode]=@GroupCode_{0}		

				)
				BEGIN
				insert into [GroupPermission] 
				(
                  GroupCode,
			      PermissionCode
				  
				 ) 
				 values(
                 @GroupCode_{0},
			      @PermissionCode_{0}
				  
				  )

				END 
				ELSE BEGIN
					update [GroupPermission]  
					SET 

					[GroupCode]=@GroupCode_{0},
				  [PermissionCode]=@PermissionCode_{0}
							
					
					Where 
					[GroupCode]=@GroupCode_{0}	
				END;", i);


					
			comm.AddParameter<string>(this.Factory, string.Format("GroupCode_{0}", i), item.GroupCode);
			comm.AddParameter<string>(this.Factory, string.Format("PermissionCode_{0}", i), item.PermissionCode);
			
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

		public void DeleteByGroup(SysGroup group)
		{
			DbCommand comm = this.GetCommand("GroupPermission_DeleteByGroup");

			comm.AddParameter<string>(this.Factory, "GroupCode", group.Code);

			this.SafeExecuteNonQuery(comm);
		}
	}
}
