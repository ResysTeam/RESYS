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
    public class NewsProvider : DataAccessBase, INewsProvider
    {
        public News Get(News dummy)
        {
            var comm = this.GetCommand("sp_News_Get");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "NewsId", dummy.NewsId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<News>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }

        public News GetDetail(News dummy, string culture)
        {
            var comm = this.GetCommand("sp_NewsGetDetail");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "NewsId", dummy.NewsId);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<News>(dt).FirstOrDefault();
            return htmlPage ?? null;
            //throw new NotImplementedException();
        }

        public List<News> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<News> GetAllActive(int startIndex, int lenght, ref int totalItem, string culture, string shortname)
        {
            var comm = this.GetCommand("sp_News_GetAllActive");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", lenght);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "ShortName", shortname);
            var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItem = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public List<News> GetByCateId(int startIndex, int lenght, ref int totalItem, string culture, int newscateid)
        {
            var comm = this.GetCommand("sp_News_GetByCateId");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", lenght);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", newscateid);
            var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItem = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<News>(dt);
        }              

        public List<News> GetByCateParentId(int newscateid, string culture)
        {
            var comm = this.GetCommand("sp_News_GetByCateParentId");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", newscateid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public List<News> GetByShortName(string shortname, string culture)
        {
            var comm = this.GetCommand("sp_News_GetByShortName");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "ShortName", shortname);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public List<News> GetByShortNameCate(int topcount,string shortname, string culture)
        {
            var comm = this.GetCommand("sp_News_GetByShortNameCate");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "NewsCategoryShortName", shortname);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public List<News> GetOther(int topcount,string culture, int newsid,int companyid)
        {
            var comm = this.GetCommand("sp_News_GetOtherbyCate");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "CompanyId", companyid);
            comm.AddParameter<int>(this.Factory, "NewsId", newsid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public List<News> GetOtherNews(int topcount, string culture, int newsid)
        {
            var comm = this.GetCommand("sp_News_GetOther");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "NewsId", newsid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public List<News> GetHot(string culture)
        {
            var comm = this.GetCommand("sp_News_GetHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public List<News> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_News_GetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public List<News> GetTopHot(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_News_GetTopHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<News>(dt);
        }
        public List<News> GetTopHotByTag(int topcount, int companyid, string culture)
        {
            var comm = this.GetCommand("sp_News_GetTopHotByTag");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            comm.AddParameter<int>(this.Factory, "CompanyId", companyid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<News>(dt);
        }
        public List<News> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_News_Search");
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
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public List<News> SearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            var comm = this.GetCommand("sp_News_SearchByTag");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", lenght);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "CompanyId", companyid);
            var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItem = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public List<News> SearchByCateParentId(int catenewsid, int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_News_SearchByCateParentId");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", catenewsid);
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
            return EntityBase.ParseListFromTable<News>(dt);
            //throw new NotImplementedException();
        }
        public void Add(News item)
        {
            //var comm = this.GetCommand("sp_News_Insert");
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

        public void Add(News item, string culture)
        {
            var comm = this.GetCommand("sp_News_Insert");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", item.NewsCategoryId);
            comm.AddParameter<string>(this.Factory, "NewsTitle", item.NewsTitle);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<string>(this.Factory, "NewsBody", item.NewsBody);
            comm.AddParameter<string>(this.Factory, "NewsDescription", item.NewsDescription);
            comm.AddParameter<string>(this.Factory, "NewsKeyword", item.NewsKeyword);
            comm.AddParameter<string>(this.Factory, "NewsImage", item.NewsImage);
            comm.AddParameter<string>(this.Factory, "NewsShortName", item.NewsShortName);                  
            comm.AddParameter<DateTime>(this.Factory, "NewsPublishDate", item.NewsPublishDate);
            comm.AddParameter<bool>(this.Factory, "IsHotNews", item.IsHotNews);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(News @new, News old)
        {
            var item = @new;
            item.NewsId = old.NewsId;
            var comm = this.GetCommand("sp_News_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewsId", item.NewsId);
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", item.NewsCategoryId);
            comm.AddParameter<string>(this.Factory, "NewsTitle", item.NewsTitle);
            comm.AddParameter<string>(this.Factory, "NewsShortName", item.NewsShortName);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<string>(this.Factory, "NewsBody", item.NewsBody);
            comm.AddParameter<string>(this.Factory, "NewsDescription", item.NewsDescription);
            comm.AddParameter<string>(this.Factory, "NewsKeyword", item.NewsKeyword);
            comm.AddParameter<string>(this.Factory, "NewsImage", item.NewsImage);
            comm.AddParameter<DateTime>(this.Factory, "NewsPublishDate", item.NewsPublishDate);
            comm.AddParameter<bool>(this.Factory, "IsHotNews", item.IsHotNews);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(News item)
        {
            var comm = this.GetCommand("sp_News_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewsId", item.NewsId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
