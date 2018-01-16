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
    public class ImageProvider : DataAccessBase, IImageProvider
    {
        public Image Get(Image dummy)
        {
            var comm = this.GetCommand("sp_ImageGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "ImageId", dummy.ImageId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<Image>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }
        public List<Image> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<Image> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_ImageGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Image>(dt);
        }

        public List<Image> GetHot( string culture)
        {
            var comm = this.GetCommand("sp_ImageGetHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Image>(dt);
        }

        public List<Image> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_ImageGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Image>(dt);
        }

        public List<Image> GetTopHot(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_ImageGetTopHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Image>(dt);
        }

        public List<Image> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_ImageSearch");
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
            return EntityBase.ParseListFromTable<Image>(dt);
        }

        public void Add(Image item)
        {
            //var comm = this.GetCommand("sp_Image_Insert");
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

        public void Add(Image item, string culture)
        {
            var comm = this.GetCommand("sp_ImageInsert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "ImageTitle", item.ImageTitle);
            comm.AddParameter<string>(this.Factory, "ImageUrl", item.ImageUrl);
            comm.AddParameter<string>(this.Factory, "ImageDescription", item.ImageDescription);
            comm.AddParameter<string>(this.Factory, "ImageKeyword", item.ImageKeyword);
            comm.AddParameter<bool>(this.Factory, "IsHotImage", item.IsHotImage);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(Image @new, Image old)
        {
            var item = @new;
            item.ImageId = old.ImageId;
            var comm = this.GetCommand("sp_ImageUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ImageId", item.ImageId);
            comm.AddParameter<string>(this.Factory, "ImageTitle", item.ImageTitle);
            comm.AddParameter<string>(this.Factory, "ImageUrl", item.ImageUrl);
            comm.AddParameter<string>(this.Factory, "ImageDescription", item.ImageDescription);
            comm.AddParameter<string>(this.Factory, "ImageKeyword", item.ImageKeyword);
            comm.AddParameter<bool>(this.Factory, "IsHotImage", item.IsHotImage);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(Image item)
        {
            var comm = this.GetCommand("sp_ImageDelete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ImageId", item.ImageId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
