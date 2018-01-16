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
    public class IntroductionProvider : DataAccessBase, IIntroductionProvider
    {
        public Introduction Get(Introduction dummy)
        {
            var comm = this.GetCommand("sp_IntroductionGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "IntroductionId", dummy.IntroductionId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<Introduction>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }
        public List<Introduction> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<Introduction> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_IntroductionGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Introduction>(dt);
        }

        public List<Introduction> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_IntroductionGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Introduction>(dt);
        }

        public List<Introduction> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_IntroductionSearch");
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
            return EntityBase.ParseListFromTable<Introduction>(dt);
        }
        public Introduction GetByShortName(string shortname, string culture)
        {
            var comm = this.GetCommand("sp_IntroductionGetByShortName");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "ShortName", shortname);

            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<Introduction>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //return EntityBase.ParseListFromTable<Introduction>(dt);
        }

        public void Add(Introduction item)
        {
            //var comm = this.GetCommand("sp_Introduction_Insert");
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

        public void Add(Introduction item, string culture)
        {
            var comm = this.GetCommand("sp_IntroductionInsert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "IntroductionName", item.IntroductionName);
            comm.AddParameter<string>(this.Factory, "IntroductionShortName", item.IntroductionShortName);
            comm.AddParameter<string>(this.Factory, "IntroductionImage", item.IntroductionImage);
            comm.AddParameter<string>(this.Factory, "IntroductionBackground", item.IntroductionBackground);
            comm.AddParameter<string>(this.Factory, "IntroductionDescription", item.IntroductionDescription);
            comm.AddParameter<string>(this.Factory, "IntroductionTitle", item.IntroductionTitle);
            comm.AddParameter<string>(this.Factory, "IntroductionBanner", item.IntroductionBanner);
            comm.AddParameter<string>(this.Factory, "IntroductionBody", item.IntroductionBody);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(Introduction @new, Introduction old)
        {
            var item = @new;
            item.IntroductionId = old.IntroductionId;
            var comm = this.GetCommand("sp_IntroductionUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "IntroductionId", item.IntroductionId);
            comm.AddParameter<string>(this.Factory, "IntroductionName", item.IntroductionName);
            comm.AddParameter<string>(this.Factory, "IntroductionShortName", item.IntroductionShortName);
            comm.AddParameter<string>(this.Factory, "IntroductionImage", item.IntroductionImage);
            comm.AddParameter<string>(this.Factory, "IntroductionBackground", item.IntroductionBackground);
            comm.AddParameter<string>(this.Factory, "IntroductionDescription", item.IntroductionDescription);
            comm.AddParameter<string>(this.Factory, "IntroductionTitle", item.IntroductionTitle);
            comm.AddParameter<string>(this.Factory, "IntroductionBanner", item.IntroductionBanner);
            comm.AddParameter<string>(this.Factory, "IntroductionBody", item.IntroductionBody);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(Introduction item)
        {
            var comm = this.GetCommand("sp_IntroductionDelete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "IntroductionId", item.IntroductionId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
