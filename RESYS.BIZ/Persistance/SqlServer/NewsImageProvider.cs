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
    public class NewsImageProvider : DataAccessBase, INewsImageProvider
    {
        public NewsImage Get(NewsImage dummy)
        {
            var comm = this.GetCommand("sp_NewsImageGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "NewsImageId", dummy.NewsImageId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<NewsImage>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }
        public List<NewsImage> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<NewsImage> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_NewsImageGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<NewsImage>(dt);
        }

        public List<NewsImage> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_NewsImageGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<NewsImage>(dt);
        }

        public List<NewsImage> GetByNews(int newsid, string culture)
        {
            var comm = this.GetCommand("sp_NewsImageGetByNews");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "newsid", newsid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<NewsImage>(dt);
        }

        public List<NewsImage> GetByNewsActive(int newsid, string culture)
        {
            var comm = this.GetCommand("sp_NewsImageGetByNewsActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "newsid", newsid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<NewsImage>(dt);
        }

        public List<NewsImage> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_NewsImageSearch");
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
            return EntityBase.ParseListFromTable<NewsImage>(dt);
        }

        public void Add(NewsImage item)
        {
            //var comm = this.GetCommand("sp_NewsImage_Insert");
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

        public void Add(NewsImage item, string culture)
        {
            var comm = this.GetCommand("sp_NewsImageInsert");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewsId", item.NewsId);
            comm.AddParameter<string>(this.Factory, "NewsImageTitle", item.NewsImageTitle);
            comm.AddParameter<string>(this.Factory, "NewsImageUrl", item.NewsImageUrl);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(NewsImage @new, NewsImage old)
        {
            var item = @new;
            item.NewsImageId = old.NewsImageId;
            var comm = this.GetCommand("sp_NewsImageUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewsImageId", item.NewsImageId);
            comm.AddParameter<int>(this.Factory, "NewsId", item.NewsId);
            comm.AddParameter<string>(this.Factory, "NewsImageTitle", item.NewsImageTitle);
            comm.AddParameter<string>(this.Factory, "NewsImageUrl", item.NewsImageUrl);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(NewsImage item)
        {
            var comm = this.GetCommand("sp_NewsImageDelete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewsImageId", item.NewsImageId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
