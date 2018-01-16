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
    public interface ILibraryProvider : IDataProvider<Library>
    {
        void Add(Library model, string culture);
        void ImageAdd(Library model, string culture);
        void VideoAdd(Library model, string culture);
        void ImageUpdate(Library @new, Library old);
        void VideoUpdate(Library @new, Library old);
        List<Library> VideoGetAll(int startIndex, int lenght, ref int totalItem, string culture);
        List<Library> ImageGetAll(int startIndex, int lenght, ref int totalItem, string culture);
        List<Library> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<Library> SearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid);
        List<Library> ImageSearch(int startIndex, int lenght, ref int totalItem, string culture);
        List<Library> ImageSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid);
        List<Library> VideoSearch(int startIndex, int lenght, ref int totalItem, string culture);
        List<Library> VideoSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid);
        List<Library> GetAllActive(string culture);
        List<Library> ImageGetAllActive(string culture);
        List<Library> VideoGetAllActive(string culture);
        List<Library> GetTop(int topcount, string culture);
        List<Library> ImageGetTop(int topcount, string culture);
        List<Library> VideoGetTop(int topcount, string culture);
        List<Library> GetTopHot(int topcount, string culture);
        List<Library> GetTopHotByTag(int topcount, int companyid, string culture);
        List<Library> ImageGetTopHot(int topcount, string culture);
        List<Library> VideoGetTopHot(int topcount, string culture);
        List<Library> GetHot(string culture);
        List<Library> ImageGetHot(string culture);
        List<Library> VideoGetHot(string culture);
    }
}
