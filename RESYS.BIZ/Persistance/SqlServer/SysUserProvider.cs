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
	class SysUserProvider : DataAccessBase, ISysUserProvider
	{
		public void Add(Models.SysUser item)
		{
			DbCommand comm = this.GetCommand("SysUser_Insert");

			comm.AddParameter<string>(this.Factory, "Username", item.Username);
			comm.AddParameter<string>(this.Factory, "Fullname", item.Fullname);
			comm.AddParameter<string>(this.Factory, "Password", item.Password);
			comm.AddParameter<string>(this.Factory, "PasswordSalt", item.PasswordSalt);
			comm.AddParameter<bool>(this.Factory, "Active", item.Active);
			comm.AddParameter<bool>(this.Factory, "SysAdmin", item.SysAdmin);
			
			this.SafeExecuteNonQuery(comm);
		}

		public Models.SysUser Get(Models.SysUser dummy)
		{
			DbCommand comm = this.GetCommand("SysUser_Get");

			

			comm.AddParameter<string>(this.Factory, "Username", dummy.Username);
			

			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<SysUser>(dt).FirstOrDefault();
		}

		public List<Models.SysUser> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("SysUser_GetAll");

			comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
			comm.AddParameter<int>(this.Factory, "Count", count);

			DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
			totalItemsParam.Direction = ParameterDirection.Output;

			DataTable dt = this.GetTable(comm);

			if (totalItemsParam.Value != DBNull.Value)
			{
				totalItems = Convert.ToInt32(totalItemsParam.Value);
			}

			return EntityBase.ParseListFromTable<SysUser>(dt);
		}

		public void Remove(Models.SysUser item)
		{
			DbCommand comm = this.GetCommand("SysUser_Delete");



			comm.AddParameter<string>(this.Factory, "Username", item.Username);


			DataTable dt = this.GetTable(comm);

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(Models.SysUser @new, Models.SysUser old)
		{

			var item = @new;
			item.Username = old.Username;
			
			

			DbCommand comm = this.GetCommand("SysUser_Update");

			comm.AddParameter<string>(this.Factory, "Username", item.Username);
			comm.AddParameter<string>(this.Factory, "Fullname", item.Fullname);
			comm.AddParameter<string>(this.Factory, "Password", item.Password);
			comm.AddParameter<string>(this.Factory, "PasswordSalt", item.PasswordSalt);
			comm.AddParameter<bool>(this.Factory, "Active", item.Active);
			comm.AddParameter<bool>(this.Factory, "SysAdmin", item.SysAdmin);
			


			this.SafeExecuteNonQuery(comm);
		}



		public void Import(List<Models.SysUser> list, bool deleteExist)
		{


			DbCommand comm = this.GetCommandSQL("");
			DbTransaction trans = null;
			bool opened = false;

			try
			{
				StringBuilder sb = new StringBuilder();


				if (deleteExist)
				{
					sb.Append("delete from [SysUser];");
				}

				int i = 0;
				foreach (var item in list)
				{

					item.ValidateFields();
					sb.AppendFormat(@"
				IF NOT EXISTS (SELECT * FROM [SysUser]  Where 
				  [Username]=@Username_{0}		

				)
				BEGIN
				insert into [SysUser] 
				(
                  Username,
			      Fullname,
			      Password,
			      PasswordSalt,
			      Active,
			      SysAdmin,
			      InsertDate,
			      UpdateDate
				  
				 ) 
				 values(
                 @Username_{0},
			      @Fullname_{0},
			      @Password_{0},
			      @PasswordSalt_{0},
			      @Active_{0},
			      @SysAdmin_{0},
			      @InsertDate_{0},
			      @UpdateDate_{0}
				  
				  )

				END 
				ELSE BEGIN
					update [SysUser]  
					SET 

					[Username]=@Username_{0},
				  [Fullname]=@Fullname_{0},
				  [Password]=@Password_{0},
				  [PasswordSalt]=@PasswordSalt_{0},
				  [Active]=@Active_{0},
				  [SysAdmin]=@SysAdmin_{0},
				  [InsertDate]=@InsertDate_{0},
				  [UpdateDate]=@UpdateDate_{0}
							
					
					Where 
					[Username]=@Username_{0}	
				END;", i);


					
			comm.AddParameter<string>(this.Factory, string.Format("Username_{0}", i), item.Username);
			comm.AddParameter<string>(this.Factory, string.Format("Fullname_{0}", i), item.Fullname);
			comm.AddParameter<string>(this.Factory, string.Format("Password_{0}", i), item.Password);
			comm.AddParameter<string>(this.Factory, string.Format("PasswordSalt_{0}", i), item.PasswordSalt);
			comm.AddParameter<bool>(this.Factory, string.Format("Active_{0}", i), item.Active);
			comm.AddParameter<bool>(this.Factory, string.Format("SysAdmin_{0}", i), item.SysAdmin);
			comm.AddParameter<DateTime>(this.Factory, string.Format("InsertDate_{0}", i), DateTime.Now);
			comm.AddParameter<DateTime>(this.Factory, string.Format("UpdateDate_{0}", i), DateTime.Now);
			
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
