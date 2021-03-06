﻿using System;
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
    public class CompanyCateProvider : DataAccessBase, ICompanyCateProvider
    {
        public CompanyCate Get(CompanyCate dummy)
        {
            var comm = this.GetCommand("sp_CompanyCateGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "CompanyCateId", dummy.CompanyCateId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<CompanyCate>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }
        public List<CompanyCate> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<CompanyCate> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_CompanyCateGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<CompanyCate>(dt);
        }

        public List<CompanyCate> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_CompanyCateGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<CompanyCate>(dt);
        }

        public List<CompanyCate> GetTopHot(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_CompanyCateGetTopHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<CompanyCate>(dt);
        }

        public List<CompanyCate> GetHot(string culture)
        {
            var comm = this.GetCommand("sp_CompanyCateGetHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<CompanyCate>(dt);
        }

        public List<CompanyCate> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_CompanyCateSearch");
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
            return EntityBase.ParseListFromTable<CompanyCate>(dt);
        }

        public void Add(CompanyCate item)
        {
            //var comm = this.GetCommand("sp_CompanyCate_Insert");
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

        public void Add(CompanyCate item, string culture)
        {
            var comm = this.GetCommand("sp_CompanyCateInsert");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "CompanyCateName", item.CompanyCateName);
            comm.AddParameter<string>(this.Factory, "CompanyCateShortName", item.CompanyCateShortName);
            comm.AddParameter<string>(this.Factory, "CompanyCateImage", item.CompanyCateImage);
            comm.AddParameter<string>(this.Factory, "CompanyCateIcon", item.CompanyCateImage);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsHotCompanyCate", item.IsHotCompanyCate);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(CompanyCate @new, CompanyCate old)
        {
            var item = @new;
            item.CompanyCateId = old.CompanyCateId;
            var comm = this.GetCommand("sp_CompanyCateUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "CompanyCateId", item.CompanyCateId);
            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "CompanyCateName", item.CompanyCateName);
            comm.AddParameter<string>(this.Factory, "CompanyCateShortName", item.CompanyCateShortName);
            comm.AddParameter<string>(this.Factory, "CompanyCateImage", item.CompanyCateImage);
            comm.AddParameter<string>(this.Factory, "CompanyCateIcon", item.CompanyCateIcon);
            comm.AddParameter<bool>(this.Factory, "IsHotCompanyCate", item.IsHotCompanyCate);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(CompanyCate item)
        {
            var comm = this.GetCommand("sp_CompanyCateDelete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "CompanyCateId", item.CompanyCateId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        
    }
}
