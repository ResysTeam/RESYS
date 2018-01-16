using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RESYS.BIZ.Extensions;
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
    public class NewsCategoryProvider : DataAccessBase, INewsCategoryProvider
    {
        public NewsCategory Get(NewsCategory dummy)
        {
            var comm = this.GetCommand("sp_NewsCategory_Get");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", dummy.NewsCategoryId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<NewsCategory>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }
        public List<NewsCategory> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<NewsCategoryBase> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_NewsCategory_GetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            var listGroupNews = EntityBase.ParseListFromTable<NewsCategory>(dt);
            //return EntityBase.ParseListFromTable<NewsCategory>(dt);
            try
            {
                var toGroupNewsTree = NewsCategoryExtensions.ToCategoryTree(GetHtmlPageCategoryBaseList(listGroupNews));
                var toFlatGroupNewsTree = NewsCategoryExtensions.ToFlatCategoryTree(toGroupNewsTree);
                return toFlatGroupNewsTree;
            }
            catch (Exception)
            {

                //throw;
            }
            return null;
        }
        public List<NewsCategory> GetAllActiveByPrId(int parentid, string culture)
        {
            var comm = this.GetCommand("sp_NewsCategory_GetAllActiveByPrId");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "ParentId", parentid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<NewsCategory>(dt);
        }

        public List<NewsCategory> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_NewsCategory_GetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<NewsCategory>(dt);
        }

        public NewsCategory GetByShortName(NewsCategory dummy, string culture)
        {
            var comm = this.GetCommand("sp_NewsCategory_GetByShortName");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "NewsCategoryShortName", dummy.NewsCategoryShortName);
            var dt = this.GetTable(comm);
            var htmlPageCate = EntityBase.ParseListFromTable<NewsCategory>(dt).FirstOrDefault();
            return htmlPageCate ?? null;
        }

        public List<NewsCategory> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_NewsCategory_Search");
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
            return EntityBase.ParseListFromTable<NewsCategory>(dt);
        }
        public static List<NewsCategoryBase> GetHtmlPageCategoryBaseList(List<NewsCategory> s)
        {
            var listPageBase = new List<NewsCategoryBase>();
            if (s != null)
            {
                listPageBase.AddRange(s.Cast<NewsCategoryBase>());
            }

            return listPageBase;
        }
        public void Add(NewsCategory item)
        {
            //var comm = this.GetCommand("sp_NewsCategory_Insert");
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

        public void Add(NewsCategory item, string culture)
        {
            var comm = this.GetCommand("sp_NewsCategory_Insert");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "NewsCategoryTitle", item.NewsCategoryTitle);
            comm.AddParameter<string>(this.Factory, "NewsCategorySummary", item.NewsCategorySummary);
            comm.AddParameter<string>(this.Factory, "NewsCategoryKeyword", item.NewsCategoryKeyword);
            comm.AddParameter<string>(this.Factory, "NewsCategoryDescription", item.NewsCategoryDescription);
            comm.AddParameter<string>(this.Factory, "NewsCategoryShortName", item.NewsCategoryShortName);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(NewsCategory @new, NewsCategory old)
        {
            var item = @new;
            item.NewsCategoryId = old.NewsCategoryId;
            var comm = this.GetCommand("sp_NewsCategory_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", item.NewsCategoryId);
            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "NewsCategoryTitle", item.NewsCategoryTitle);
            comm.AddParameter<string>(this.Factory, "NewsCategoryShortName", item.NewsCategoryShortName);
            comm.AddParameter<string>(this.Factory, "NewsCategorySummary", item.NewsCategorySummary);
            comm.AddParameter<string>(this.Factory, "NewsCategoryKeyword", item.NewsCategoryKeyword);
            comm.AddParameter<string>(this.Factory, "NewsCategoryDescription", item.NewsCategoryDescription);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(NewsCategory item)
        {
            var comm = this.GetCommand("sp_NewsCategory_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", item.NewsCategoryId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
