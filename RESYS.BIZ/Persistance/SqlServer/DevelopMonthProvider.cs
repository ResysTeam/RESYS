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
    public class DevelopMonthProvider : DataAccessBase, IDevelopMonthProvider
    {
        public DevelopMonth Get(DevelopMonth dummy)
        {
            var comm = this.GetCommand("sp_DevelopMonthGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "DevelopMonthId", dummy.DevelopMonthId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<DevelopMonth>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }
        public List<DevelopMonth> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<DevelopMonth> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_DevelopMonthGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<DevelopMonth>(dt);
        }

        public List<DevelopMonth> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_DevelopMonthGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<DevelopMonth>(dt);
        }

        public List<DevelopMonth> GetByYear(int developyearid, string culture)
        {
            var comm = this.GetCommand("sp_DevelopMonthGetByYear");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "DevelopYearId", developyearid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<DevelopMonth>(dt);
        }
        public List<DevelopMonth> GetByYearActive(int developyearid, string culture)
        {
            var comm = this.GetCommand("sp_DevelopMonthGetByYearActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "DevelopYearId", developyearid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<DevelopMonth>(dt);
        }

        public List<DevelopMonth> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_DevelopMonthSearch");
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
            return EntityBase.ParseListFromTable<DevelopMonth>(dt);
        }

        public void Add(DevelopMonth item)
        {
            //var comm = this.GetCommand("sp_DevelopMonth_Insert");
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

        public void Add(DevelopMonth item, string culture)
        {
            var comm = this.GetCommand("sp_DevelopMonthInsert");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "DevelopYearId", item.DevelopYearId);
            comm.AddParameter<int>(this.Factory, "DevelopMonthName", item.DevelopMonthName);
            comm.AddParameter<string>(this.Factory, "DevelopMonthTitle", item.DevelopMonthTitle);
            comm.AddParameter<string>(this.Factory, "DevelopMonthDescription", item.DevelopMonthDescription);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(DevelopMonth @new, DevelopMonth old)
        {
            var item = @new;
            item.DevelopMonthId = old.DevelopMonthId;
            var comm = this.GetCommand("sp_DevelopMonthUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "DevelopMonthId", item.DevelopMonthId);
            comm.AddParameter<int>(this.Factory, "DevelopYearId", item.DevelopYearId);
            comm.AddParameter<int>(this.Factory, "DevelopMonthName", item.DevelopMonthName);
            comm.AddParameter<string>(this.Factory, "DevelopMonthTitle", item.DevelopMonthTitle);
            comm.AddParameter<string>(this.Factory, "DevelopMonthDescription", item.DevelopMonthDescription);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(DevelopMonth item)
        {
            var comm = this.GetCommand("sp_DevelopMonthDelete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "DevelopMonthId", item.DevelopMonthId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
