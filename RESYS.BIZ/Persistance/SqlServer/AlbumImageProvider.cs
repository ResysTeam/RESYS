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
    public class AlbumImageProvider : DataAccessBase, IAlbumImageProvider
    {
        public AlbumImage Get(AlbumImage dummy)
        {
            var comm = this.GetCommand("sp_ImageInAlbumGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "AlbumImageId", dummy.AlbumImageId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<AlbumImage>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }
        public List<AlbumImage> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<AlbumImage> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_ImageInAlbumGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<AlbumImage>(dt);
        }

        public List<AlbumImage> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_ImageInAlbumGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<AlbumImage>(dt);
        }

        public List<AlbumImage> GetByAlbum(int newsid, string culture)
        {
            var comm = this.GetCommand("sp_ImageInAlbumGetByAlbum");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "AlbumId", newsid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<AlbumImage>(dt);
        }

        public List<AlbumImage> GetByAlbumActive(int newsid, string culture)
        {
            var comm = this.GetCommand("sp_ImageInAlbumGetByAlbumActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "AlbumId", newsid);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<AlbumImage>(dt);
        }

        public List<AlbumImage> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_ImageInAlbumSearch");
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
            return EntityBase.ParseListFromTable<AlbumImage>(dt);
        }

        public void Add(AlbumImage item)
        {
            //var comm = this.GetCommand("sp_AlbumImage_Insert");
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

        public void Add(AlbumImage item, string culture)
        {
            var comm = this.GetCommand("sp_ImageInAlbumInsert");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "AlbumId", item.AlbumId);
            comm.AddParameter<string>(this.Factory, "AlbumImageTitle", item.AlbumImageTitle);
            comm.AddParameter<string>(this.Factory, "AlbumImageUrl", item.AlbumImageUrl);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(AlbumImage @new, AlbumImage old)
        {
            var item = @new;
            item.AlbumImageId = old.AlbumImageId;
            var comm = this.GetCommand("sp_ImageInAlbumUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "AlbumImageId", item.AlbumImageId);
            comm.AddParameter<int>(this.Factory, "AlbumId", item.AlbumId);
            comm.AddParameter<string>(this.Factory, "AlbumImageTitle", item.AlbumImageTitle);
            comm.AddParameter<string>(this.Factory, "AlbumImageUrl", item.AlbumImageUrl);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(AlbumImage item)
        {
            var comm = this.GetCommand("sp_ImageInAlbumDelete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "AlbumImageId", item.AlbumImageId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
