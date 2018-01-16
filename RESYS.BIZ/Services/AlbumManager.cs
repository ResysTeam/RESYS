using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class AlbumManager : DataManagerBase<Album>
    {
        public AlbumManager()
            : base()
        { }

        public AlbumManager(IDataProvider<Album> provider)
            : base(provider)
        {
        }

        private IAlbumProvider AlbumProvider
        {
            get { return (IAlbumProvider)Provider; }
        }

        public void Add(Album model, string culture)
        {
            AlbumProvider.Add(model, culture);
        }

        public void ImageAdd(Album model, string culture)
        {
            AlbumProvider.ImageAdd(model, culture);
        }

        public void VideoAdd(Album model, string culture)
        {
            AlbumProvider.VideoAdd(model, culture);
        }

        public void ImageUpdate(Album @new, Album old)
        {
            AlbumProvider.ImageUpdate(@new, old);
        }

        public void VideoUpdate(Album @new, Album old)
        {
            AlbumProvider.VideoUpdate(@new, old);
        }

        public List<Album> ImageGetAll(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return AlbumProvider.ImageGetAll(startIndex, lenght, ref totalItem, culture);
        }

        public List<Album> VideoGetAll(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return AlbumProvider.VideoGetAll(startIndex, lenght, ref totalItem, culture);
        }

        public List<Album> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return AlbumProvider.Search(startIndex, lenght, ref totalItem, culture);
        }
        public List<Album> SearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            return AlbumProvider.SearchByTag(startIndex, lenght, ref totalItem, culture, companyid);
        }
        public List<Album> ImageSearch(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return AlbumProvider.ImageSearch(startIndex, lenght, ref totalItem, culture);
        }
        public List<Album> ImageSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            return AlbumProvider.ImageSearchByTag(startIndex, lenght, ref totalItem, culture, companyid);
        }
        public List<Album> VideoSearch(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return AlbumProvider.VideoSearch(startIndex, lenght, ref totalItem, culture);
        }
        public List<Album> VideoSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            return AlbumProvider.VideoSearchByTag(startIndex, lenght, ref totalItem, culture, companyid);
        }
        public List<Album> GetAllActive(string culture)
        {
            return AlbumProvider.GetAllActive(culture);
        }
        public List<Album> ImageGetAllActive(string culture)
        {
            return AlbumProvider.ImageGetAllActive(culture);
        }
        public List<Album> VideoGetAllActive(string culture)
        {
            return AlbumProvider.VideoGetAllActive(culture);
        }
        public List<Album> GetHot(string culture)
        {
            return AlbumProvider.GetHot(culture);
        }
        public List<Album> ImageGetHot(string culture)
        {
            return AlbumProvider.ImageGetHot(culture);
        }
        public List<Album> VideoGetHot(string culture)
        {
            return AlbumProvider.VideoGetHot(culture);
        }
        public List<Album> GetTop(int topcount, string culture)
        {
            return AlbumProvider.GetTop(topcount, culture);
        }
        public List<Album> ImageGetTop(int topcount, string culture)
        {
            return AlbumProvider.ImageGetTop(topcount, culture);
        }
        public List<Album> VideoGetTop(int topcount, string culture)
        {
            return AlbumProvider.VideoGetTop(topcount, culture);
        }

        public List<Album> GetTopHot(int topcount, string culture)
        {
            return AlbumProvider.GetTopHot(topcount, culture);
        }

        public List<Album> GetTopHotByTag(int topcount, int companyid, string culture)
        {
            return AlbumProvider.GetTopHotByTag(topcount, companyid, culture);
        }

        public List<Album> ImageGetTopHot(int topcount, string culture)
        {
            return AlbumProvider.ImageGetTopHot(topcount, culture);
        }
        public List<Album> VideoGetTopHot(int topcount, string culture)
        {
            return AlbumProvider.VideoGetTopHot(topcount, culture);
        }

    }
}
