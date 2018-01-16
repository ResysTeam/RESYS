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
    public class AlbumProvider : DataAccessBase, IAlbumProvider
    {
        public Album Get(Album dummy)
        {
            var comm = this.GetCommand("sp_AlbumGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "AlbumId", dummy.AlbumId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<Album>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }
        public List<Album> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }
        public List<Album> VideoGetAll(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_AlbumVideoGetAll");
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
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> ImageGetAll(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_AlbumImageGetAll");
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
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_AlbumGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> ImageGetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_AlbumImageGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> VideoGetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_AlbumVideoGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> GetHot(string culture)
        {
            var comm = this.GetCommand("sp_AlbumGetHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> ImageGetHot(string culture)
        {
            var comm = this.GetCommand("sp_AlbumImageGetHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> VideoGetHot(string culture)
        {
            var comm = this.GetCommand("sp_AlbumVideoGetHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_AlbumGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> ImageGetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_AlbumImageGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> VideoGetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_AlbumVideoGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> GetTopHot(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_AlbumGetTopHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> GetTopHotByTag(int topcount, int companyid, string culture)
        {
            var comm = this.GetCommand("sp_AlbumGetTopHotByTag");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            comm.AddParameter<int>(this.Factory, "CompanyId", companyid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> ImageGetTopHot(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_AlbumImageGetTopHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> VideoGetTopHot(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_AlbumVideoGetTopHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_AlbumSearch");
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
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> SearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            var comm = this.GetCommand("sp_AlbumSearchByTag");
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
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> ImageSearch(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_AlbumImageSearch");
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
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> ImageSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            var comm = this.GetCommand("sp_AlbumImageSearchByTag");
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
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> VideoSearch(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_AlbumVideoSearch");
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
            return EntityBase.ParseListFromTable<Album>(dt);
        }

        public List<Album> VideoSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            var comm = this.GetCommand("sp_AlbumVideoSearchByTag");
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
            return EntityBase.ParseListFromTable<Album>(dt);
        }
        public void Add(Album item)
        {
            //var comm = this.GetCommand("sp_Album_Insert");
            //if (comm == null) return;
            //comm.AddParameter<string>(this.Factory, "Url", item.Url);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            ////comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            ////comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            //comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            //comm.AddParameter<string>(this.Factory, "Album", item.Album);
            //comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            //comm.SafeExecuteNonQuery();
            throw new NotImplementedException();
        }

        public void Add(Album item, string culture)
        {
            var comm = this.GetCommand("sp_AlbumImageInsert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "ImageTitle", item.AlbumTitle);
            comm.AddParameter<string>(this.Factory, "ImageUrl", item.AlbumUrl);
            comm.AddParameter<string>(this.Factory, "ImageDescription", item.AlbumDescription);
            comm.AddParameter<string>(this.Factory, "ImageKeyword", item.AlbumKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotImage", item.IsHotAlbum);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(Album @new, Album old)
        {
            var item = @new;
            item.AlbumId = old.AlbumId;
            var comm = this.GetCommand("sp_AlbumImageUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ImageId", item.AlbumId);
            comm.AddParameter<string>(this.Factory, "ImageTitle", item.AlbumTitle);
            comm.AddParameter<string>(this.Factory, "ImageUrl", item.AlbumUrl);
            comm.AddParameter<string>(this.Factory, "ImageDescription", item.AlbumDescription);
            comm.AddParameter<string>(this.Factory, "ImageKeyword", item.AlbumKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotImage", item.IsHotAlbum);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void ImageAdd(Album item, string culture)
        {
            var comm = this.GetCommand("sp_AlbumImageInsert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "ImageTitle", item.AlbumTitle);
            comm.AddParameter<string>(this.Factory, "ImageUrl", item.AlbumUrl);
            comm.AddParameter<string>(this.Factory, "ImageDescription", item.AlbumDescription);
            comm.AddParameter<string>(this.Factory, "ImageKeyword", item.AlbumKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotImage", item.IsHotAlbum);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void ImageUpdate(Album @new, Album old)
        {
            var item = @new;
            item.AlbumId = old.AlbumId;
            var comm = this.GetCommand("sp_AlbumImageUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ImageId", item.AlbumId);
            comm.AddParameter<string>(this.Factory, "ImageTitle", item.AlbumTitle);
            comm.AddParameter<string>(this.Factory, "ImageUrl", item.AlbumUrl);
            comm.AddParameter<string>(this.Factory, "ImageDescription", item.AlbumDescription);
            comm.AddParameter<string>(this.Factory, "ImageKeyword", item.AlbumKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotImage", item.IsHotAlbum);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void VideoAdd(Album item, string culture)
        {
            var comm = this.GetCommand("sp_AlbumVideoInsert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "VideoTitle", item.AlbumTitle);
            comm.AddParameter<string>(this.Factory, "VideoUrl", item.AlbumUrl);
            comm.AddParameter<string>(this.Factory, "VideoDescription", item.AlbumDescription);
            comm.AddParameter<string>(this.Factory, "VideoKeyword", item.AlbumKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotVideo", item.IsHotAlbum);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void VideoUpdate(Album @new, Album old)
        {
            var item = @new;
            item.AlbumId = old.AlbumId;
            var comm = this.GetCommand("sp_AlbumVideoUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "VideoId", item.AlbumId);
            comm.AddParameter<string>(this.Factory, "VideoTitle", item.AlbumTitle);
            comm.AddParameter<string>(this.Factory, "VideoUrl", item.AlbumUrl);
            comm.AddParameter<string>(this.Factory, "VideoDescription", item.AlbumDescription);
            comm.AddParameter<string>(this.Factory, "VideoKeyword", item.AlbumKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotVideo", item.IsHotAlbum);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(Album item)
        {
            var comm = this.GetCommand("sp_AlbumDelete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "AlbumId", item.AlbumId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
