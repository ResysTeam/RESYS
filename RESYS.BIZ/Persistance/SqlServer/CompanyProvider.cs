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
    public class CompanyProvider : DataAccessBase, ICompanyProvider
    {
        public Company Get(Company dummy)
        {
            var comm = this.GetCommand("sp_CompanyGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "CompanyId", dummy.CompanyId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<Company>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }

        public Company GetByShortName(Company dummy)
        {
            var comm = this.GetCommand("sp_CompanyGetByShortName");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<string>(this.Factory, "CompanyShortName", dummy.CompanyShortName);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<Company>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }

        public List<Company> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_CompanyGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Company>(dt);
        }

        public List<Company> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_CompanyGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Company>(dt);
        }

        public List<Company> GetByCateId(int companycateid, string culture)
        {
            var comm = this.GetCommand("sp_CompanyGetByCateId");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "CompanyCateId", companycateid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Company>(dt);
        }

        public List<Company> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_CompanySearch");
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
            return EntityBase.ParseListFromTable<Company>(dt);
        }

        public void Add(Company item)
        {
            //var comm = this.GetCommand("sp_Company_Insert");
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

        public void Add(Company item, string culture)
        {
            var comm = this.GetCommand("sp_CompanyInsert");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "CompanyCateId", item.CompanyCateId);
            comm.AddParameter<string>(this.Factory, "CompanyName", item.CompanyName);
            comm.AddParameter<string>(this.Factory, "CompanyShortName", item.CompanyShortName);
            comm.AddParameter<string>(this.Factory, "CompanyBackground", item.CompanyBackground);
            comm.AddParameter<string>(this.Factory, "CompanyBanner", item.CompanyBanner);
            comm.AddParameter<string>(this.Factory, "CompanyLogo", item.CompanyLogo);
            comm.AddParameter<string>(this.Factory, "CompanyAddress", item.CompanyAddress);
            comm.AddParameter<string>(this.Factory, "CompanyContact", item.CompanyContact);
            comm.AddParameter<string>(this.Factory, "CompanyWeb", item.CompanyWeb);
            comm.AddParameter<string>(this.Factory, "CompanyTwitter", item.CompanyTwitter);
            comm.AddParameter<string>(this.Factory, "CompanyFace", item.CompanyFace);
            comm.AddParameter<string>(this.Factory, "CompanyYoutube", item.CompanyYoutube);
            comm.AddParameter<string>(this.Factory, "CompanyGoogle", item.CompanyGoogle);
            comm.AddParameter<string>(this.Factory, "CompanyBody", item.CompanyBody);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(Company @new, Company old)
        {
            var item = @new;
            item.CompanyId = old.CompanyId;
            var comm = this.GetCommand("sp_CompanyUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<int>(this.Factory, "CompanyCateId", item.CompanyCateId);
            comm.AddParameter<string>(this.Factory, "CompanyName", item.CompanyName);
            comm.AddParameter<string>(this.Factory, "CompanyShortName", item.CompanyShortName);
            comm.AddParameter<string>(this.Factory, "CompanyBackground", item.CompanyBackground);
            comm.AddParameter<string>(this.Factory, "CompanyBanner", item.CompanyBanner);
            comm.AddParameter<string>(this.Factory, "CompanyLogo", item.CompanyLogo);
            comm.AddParameter<string>(this.Factory, "CompanyAddress", item.CompanyAddress);
            comm.AddParameter<string>(this.Factory, "CompanyContact", item.CompanyContact);
            comm.AddParameter<string>(this.Factory, "CompanyWeb", item.CompanyWeb);
            comm.AddParameter<string>(this.Factory, "CompanyTwitter", item.CompanyTwitter);
            comm.AddParameter<string>(this.Factory, "CompanyFace", item.CompanyFace);
            comm.AddParameter<string>(this.Factory, "CompanyYoutube", item.CompanyYoutube);
            comm.AddParameter<string>(this.Factory, "CompanyGoogle", item.CompanyGoogle);
            comm.AddParameter<string>(this.Factory, "CompanyBody", item.CompanyBody);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(Company item)
        {
            var comm = this.GetCommand("sp_CompanyDelete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
