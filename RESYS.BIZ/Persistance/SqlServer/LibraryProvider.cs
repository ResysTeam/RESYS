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
    public class LibraryProvider : DataAccessBase, ILibraryProvider
    {
        public Library Get(Library dummy)
        {
            var comm = this.GetCommand("sp_LibraryGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "LibraryId", dummy.LibraryId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<Library>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }
        public List<Library> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }
        public List<Library> VideoGetAll(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_LibraryVideoGetAll");
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
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> ImageGetAll(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_LibraryImageGetAll");
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
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_LibraryGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> ImageGetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_LibraryImageGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> VideoGetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_LibraryVideoGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> GetHot(string culture)
        {
            var comm = this.GetCommand("sp_LibraryGetHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> ImageGetHot(string culture)
        {
            var comm = this.GetCommand("sp_LibraryImageGetHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> VideoGetHot(string culture)
        {
            var comm = this.GetCommand("sp_LibraryVideoGetHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_LibraryGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> ImageGetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_LibraryImageGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> VideoGetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_LibraryVideoGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> GetTopHot(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_LibraryGetTopHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> GetTopHotByTag(int topcount, int companyid,string culture)
        {
            var comm = this.GetCommand("sp_LibraryGetTopHotByTag");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            comm.AddParameter<int>(this.Factory, "CompanyId", companyid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> ImageGetTopHot(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_LibraryImageGetTopHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> VideoGetTopHot(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_LibraryVideoGetTopHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_LibrarySearch");
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
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> SearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            var comm = this.GetCommand("sp_LibrarySearchByTag");
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
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> ImageSearch(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_LibraryImageSearch");
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
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> ImageSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            var comm = this.GetCommand("sp_LibraryImageSearchByTag");
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
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> VideoSearch(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_LibraryVideoSearch");
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
            return EntityBase.ParseListFromTable<Library>(dt);
        }

        public List<Library> VideoSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            var comm = this.GetCommand("sp_LibraryVideoSearchByTag");
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
            return EntityBase.ParseListFromTable<Library>(dt);
        }
        public void Add(Library item)
        {
            //var comm = this.GetCommand("sp_Library_Insert");
            //if (comm == null) return;
            //comm.AddParameter<string>(this.Factory, "Url", item.Url);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            ////comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            ////comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            //comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            //comm.AddParameter<string>(this.Factory, "Library", item.Library);
            //comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            //comm.SafeExecuteNonQuery();
            throw new NotImplementedException();
        }
     
        public void Add(Library item, string culture)
        {
            var comm = this.GetCommand("sp_LibraryImageInsert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "ImageTitle", item.LibraryTitle);
            comm.AddParameter<string>(this.Factory, "ImageUrl", item.LibraryUrl);
            comm.AddParameter<string>(this.Factory, "ImageDescription", item.LibraryDescription);
            comm.AddParameter<string>(this.Factory, "ImageKeyword", item.LibraryKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotImage", item.IsHotLibrary);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(Library @new, Library old)
        {
            var item = @new;
            item.LibraryId = old.LibraryId;
            var comm = this.GetCommand("sp_LibraryImageUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ImageId", item.LibraryId);
            comm.AddParameter<string>(this.Factory, "ImageTitle", item.LibraryTitle);
            comm.AddParameter<string>(this.Factory, "ImageUrl", item.LibraryUrl);
            comm.AddParameter<string>(this.Factory, "ImageDescription", item.LibraryDescription);
            comm.AddParameter<string>(this.Factory, "ImageKeyword", item.LibraryKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotImage", item.IsHotLibrary);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void ImageAdd(Library item, string culture)
        {
            var comm = this.GetCommand("sp_LibraryImageInsert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "ImageTitle", item.LibraryTitle);
            comm.AddParameter<string>(this.Factory, "ImageUrl", item.LibraryUrl);
            comm.AddParameter<string>(this.Factory, "ImageDescription", item.LibraryDescription);
            comm.AddParameter<string>(this.Factory, "ImageKeyword", item.LibraryKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotImage", item.IsHotLibrary);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void ImageUpdate(Library @new, Library old)
        {
            var item = @new;
            item.LibraryId = old.LibraryId;
            var comm = this.GetCommand("sp_LibraryImageUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ImageId", item.LibraryId);
            comm.AddParameter<string>(this.Factory, "ImageTitle", item.LibraryTitle);
            comm.AddParameter<string>(this.Factory, "ImageUrl", item.LibraryUrl);
            comm.AddParameter<string>(this.Factory, "ImageDescription", item.LibraryDescription);
            comm.AddParameter<string>(this.Factory, "ImageKeyword", item.LibraryKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotImage", item.IsHotLibrary);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void VideoAdd(Library item, string culture)
        {
            var comm = this.GetCommand("sp_LibraryVideoInsert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "VideoTitle", item.LibraryTitle);
            comm.AddParameter<string>(this.Factory, "VideoUrl", item.LibraryUrl);
            comm.AddParameter<string>(this.Factory, "VideoDescription", item.LibraryDescription);
            comm.AddParameter<string>(this.Factory, "VideoKeyword", item.LibraryKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotVideo", item.IsHotLibrary);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void VideoUpdate(Library @new, Library old)
        {
            var item = @new;
            item.LibraryId = old.LibraryId;
            var comm = this.GetCommand("sp_LibraryVideoUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "VideoId", item.LibraryId);
            comm.AddParameter<string>(this.Factory, "VideoTitle", item.LibraryTitle);
            comm.AddParameter<string>(this.Factory, "VideoUrl", item.LibraryUrl);
            comm.AddParameter<string>(this.Factory, "VideoDescription", item.LibraryDescription);
            comm.AddParameter<string>(this.Factory, "VideoKeyword", item.LibraryKeyword);
            comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
            comm.AddParameter<bool>(this.Factory, "IsHotVideo", item.IsHotLibrary);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(Library item)
        {
            var comm = this.GetCommand("sp_LibraryDelete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LibraryId", item.LibraryId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
