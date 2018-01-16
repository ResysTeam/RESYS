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
	class PotentialCustomerProvider : DataAccessBase, IPotentialCustomerProvider
	{
		public void Add(Models.PotentialCustomer item)
		{
			DbCommand comm = this.GetCommand("PotentialCustomer_Insert");

			comm.AddParameter<string>(this.Factory, "CusName", item.CusName);
			comm.AddParameter<string>(this.Factory, "CusPhone", item.CusPhone);
			comm.AddParameter<string>(this.Factory, "CusEmail", item.CusEmail);
			
			comm.SafeExecuteNonQuery();
		}

		public Models.PotentialCustomer Get(Models.PotentialCustomer dummy)
		{
			DbCommand comm = this.GetCommand("PotentialCustomer_Get");



            comm.AddParameter<int>(this.Factory, "Id", dummy.Id);
			

			DataTable dt = this.GetTable(comm);

			return EntityBase.ParseListFromTable<PotentialCustomer>(dt).FirstOrDefault();
		}

		public List<Models.PotentialCustomer> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("PotentialCustomer_GetAll");

			comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
			comm.AddParameter<int>(this.Factory, "Count", count);

			DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
			totalItemsParam.Direction = ParameterDirection.Output;

			DataTable dt = this.GetTable(comm);

			if (totalItemsParam.Value != DBNull.Value)
			{
				totalItems = Convert.ToInt32(totalItemsParam.Value);
			}

			return EntityBase.ParseListFromTable<PotentialCustomer>(dt);
		}

		public void Remove(Models.PotentialCustomer item)
		{
			DbCommand comm = this.GetCommand("PotentialCustomer_Delete");



            comm.AddParameter<int>(this.Factory, "Id", item.Id);
			

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(Models.PotentialCustomer @new, Models.PotentialCustomer old)
		{

			var item = @new;
			item.Id = old.Id;
			
			

			DbCommand comm = this.GetCommand("PotentialCustomer_Update");

            comm.AddParameter<int>(this.Factory, "Id", item.Id);
			comm.AddParameter<string>(this.Factory, "CusName", item.CusName);
			comm.AddParameter<string>(this.Factory, "CusPhone", item.CusPhone);
			comm.AddParameter<string>(this.Factory, "CusEmail", item.CusEmail);
			


			this.SafeExecuteNonQuery(comm);
		}



		public void Import(List<Models.PotentialCustomer> list, bool deleteExist)
		{


			DbCommand comm = this.GetCommandSQL("");
			DbTransaction trans = null;
			bool opened = false;

			try
			{
				StringBuilder sb = new StringBuilder();


				if (deleteExist)
				{
					sb.Append("delete from [PotentialCustomer];");
				}

				int i = 0;
				foreach (var item in list)
				{

					item.ValidateFields();
					sb.AppendFormat(@"
				IF NOT EXISTS (SELECT * FROM [PotentialCustomer]  Where 
				  [Id]=@Id_{0}		

				)
				BEGIN
				insert into [PotentialCustomer] 
				(
                  Id,
			      CusName,
			      CusPhone,
			      CusEmail
				  
				 ) 
				 values(
                 @Id_{0},
			      @CusName_{0},
			      @CusPhone_{0},
			      @CusEmail_{0}
				  
				  )

				END 
				ELSE BEGIN
					update [PotentialCustomer]  
					SET 

					[Id]=@Id_{0},
				  [CusName]=@CusName_{0},
				  [CusPhone]=@CusPhone_{0},
				  [CusEmail]=@CusEmail_{0}
							
					
					Where 
					[Id]=@Id_{0}	
				END;", i);


					
			comm.AddParameter<int>(this.Factory, string.Format("Id_{0}", i), item.Id);
			comm.AddParameter<string>(this.Factory, string.Format("CusName_{0}", i), item.CusName);
			comm.AddParameter<string>(this.Factory, string.Format("CusPhone_{0}", i), item.CusPhone);
			comm.AddParameter<string>(this.Factory, string.Format("CusEmail_{0}", i), item.CusEmail);
			
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
