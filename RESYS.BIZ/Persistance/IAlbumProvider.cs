using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;
using RESYS.BIZ.Models;

namespace RESYS.BIZ.Persistance
{
    public interface IAlbumProvider : IDataProvider<Album>
    {
        void Add(Album model, string culture);
        void ImageAdd(Album model, string culture);
        void VideoAdd(Album model, string culture);
        void ImageUpdate(Album @new, Album old);
        void VideoUpdate(Album @new, Album old);
        List<Album> VideoGetAll(int startIndex, int lenght, ref int totalItem, string culture);
        List<Album> ImageGetAll(int startIndex, int lenght, ref int totalItem, string culture);
        List<Album> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<Album> SearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid);
        List<Album> ImageSearch(int startIndex, int lenght, ref int totalItem, string culture);
        List<Album> ImageSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid);
        List<Album> VideoSearch(int startIndex, int lenght, ref int totalItem, string culture);
        List<Album> VideoSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid);
        List<Album> GetAllActive(string culture);
        List<Album> ImageGetAllActive(string culture);
        List<Album> VideoGetAllActive(string culture);
        List<Album> GetTop(int topcount, string culture);
        List<Album> ImageGetTop(int topcount, string culture);
        List<Album> VideoGetTop(int topcount, string culture);
        List<Album> GetTopHot(int topcount, string culture);
        List<Album> GetTopHotByTag(int topcount, int companyid, string culture);
        List<Album> ImageGetTopHot(int topcount, string culture);
        List<Album> VideoGetTopHot(int topcount, string culture);
        List<Album> GetHot(string culture);
        List<Album> ImageGetHot(string culture);
        List<Album> VideoGetHot(string culture);
    }
}
