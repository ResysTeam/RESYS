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
    public class DevelopYearProvider : DataAccessBase, IDevelopYearProvider
    {
        public DevelopYear Get(DevelopYear dummy)
        {
            var comm = this.GetCommand("sp_DevelopYearGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "DevelopYearId", dummy.DevelopYearId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<DevelopYear>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }
        public List<DevelopYear> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<DevelopYear> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_DevelopYearGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<DevelopYear>(dt);
        }

        public List<DevelopYear> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_DevelopYearGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<DevelopYear>(dt);
        }

        public List<DevelopYear> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_DevelopYearSearch");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", lenght);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItem = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<DevelopYear>(dt);
        }

        public void Add(DevelopYear item)
        {
            //var comm = this.GetCommand("sp_DevelopYear_Insert");
            //if (comm == null) return;
            //comm.AddParameter<string>(this.Factory, "Url", item.Url);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            ////comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            ////comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            //comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            //comm.AddParameter<string>(this.Factory, "Image", item.Image);
            //comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            //comm.SafeExecuteNonQuery();
            throw new NotImplementedException();
        }

        public void Add(DevelopYear item, string culture)
        {
            var comm = this.GetCommand("sp_DevelopYearInsert");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "DevelopYearName", item.DevelopYearName);
            comm.AddParameter<string>(this.Factory, "DevelopYearBg", item.DevelopYearBg); 
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(DevelopYear @new, DevelopYear old)
        {
            var item = @new;
            item.DevelopYearId = old.DevelopYearId;
            var comm = this.GetCommand("sp_DevelopYearUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "DevelopYearId", item.DevelopYearId);
            comm.AddParameter<int>(this.Factory, "DevelopYearName", item.DevelopYearName);
            comm.AddParameter<string>(this.Factory, "DevelopYearBg", item.DevelopYearBg); 
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(DevelopYear item)
        {
            var comm = this.GetCommand("sp_DevelopYearDelete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "DevelopYearId", item.DevelopYearId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
