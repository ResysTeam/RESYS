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
    public class VideoProvider : DataAccessBase, IVideoProvider
    {
        public Video Get(Video dummy)
        {
            var comm = this.GetCommand("sp_VideoGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "VideoId", dummy.VideoId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<Video>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }
        public List<Video> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<Video> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_VideoGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Video>(dt);
        }

        public List<Video> GetHot(string culture)
        {
            var comm = this.GetCommand("sp_VideoGetHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Video>(dt);
        }

        public List<Video> GetTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_VideoGetTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Video>(dt);
        }

        public List<Video> GetTopHot(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_VideoGetTopHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Video>(dt);
        }

        public List<Video> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_VideoSearch");
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
            return EntityBase.ParseListFromTable<Video>(dt);
        }

        public void Add(Video item)
        {
            //var comm = this.GetCommand("sp_Video_Insert");
            //if (comm == null) return;
            //comm.AddParameter<string>(this.Factory, "Url", item.Url);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            ////comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            ////comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            //comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            //comm.AddParameter<string>(this.Factory, "Video", item.Video);
            //comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            //comm.SafeExecuteNonQuery();
            throw new NotImplementedException();
        }

        public void Add(Video item, string culture)
        {
            var comm = this.GetCommand("sp_VideoInsert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "VideoTitle", item.VideoTitle);
            comm.AddParameter<string>(this.Factory, "VideoUrl", item.VideoUrl);
            comm.AddParameter<string>(this.Factory, "VideoDescription", item.VideoDescription);
            comm.AddParameter<string>(this.Factory, "VideoKeyword", item.VideoKeyword);
            comm.AddParameter<bool>(this.Factory, "IsHotVideo", item.IsHotVideo);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(Video @new, Video old)
        {
            var item = @new;
            item.VideoId = old.VideoId;
            var comm = this.GetCommand("sp_VideoUpdate");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "VideoId", item.VideoId);
            comm.AddParameter<string>(this.Factory, "VideoTitle", item.VideoTitle);
            comm.AddParameter<string>(this.Factory, "VideoUrl", item.VideoUrl);
            comm.AddParameter<string>(this.Factory, "VideoDescription", item.VideoDescription);
            comm.AddParameter<string>(this.Factory, "VideoKeyword", item.VideoKeyword);
            comm.AddParameter<bool>(this.Factory, "IsHotVideo", item.IsHotVideo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(Video item)
        {
            var comm = this.GetCommand("sp_VideoDelete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "VideoId", item.VideoId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }


    }
}
