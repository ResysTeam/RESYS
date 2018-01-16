using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class LibraryManager : DataManagerBase<Library>
    {
        public LibraryManager()
            : base()
        { }

        public LibraryManager(IDataProvider<Library> provider)
            : base(provider)
        {
        }

        private ILibraryProvider LibraryProvider
        {
            get { return (ILibraryProvider)Provider; }
        }

        public void Add(Library model, string culture)
        {
            LibraryProvider.Add(model, culture);
        }

        public void ImageAdd(Library model, string culture)
        {
            LibraryProvider.ImageAdd(model, culture);
        }

        public void VideoAdd(Library model, string culture)
        {
            LibraryProvider.VideoAdd(model, culture);
        }

        public void ImageUpdate(Library @new, Library old)
        {
            LibraryProvider.ImageUpdate(@new,old);
        }

        public void VideoUpdate(Library @new, Library old)
        {
            LibraryProvider.VideoUpdate(@new, old);
        }

        public List<Library> ImageGetAll(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return LibraryProvider.ImageGetAll(startIndex, lenght, ref totalItem, culture);
        }

        public List<Library> VideoGetAll(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return LibraryProvider.VideoGetAll(startIndex, lenght, ref totalItem, culture);
        }

        public List<Library> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return LibraryProvider.Search(startIndex, lenght, ref totalItem, culture);
        }
        public List<Library> SearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            return LibraryProvider.SearchByTag(startIndex, lenght, ref totalItem, culture, companyid);
        }
        public List<Library> ImageSearch(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return LibraryProvider.ImageSearch(startIndex, lenght, ref totalItem, culture);
        }
        public List<Library> ImageSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            return LibraryProvider.ImageSearchByTag(startIndex, lenght, ref totalItem, culture, companyid);
        }
        public List<Library> VideoSearch(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return LibraryProvider.VideoSearch(startIndex, lenght, ref totalItem, culture);
        }
        public List<Library> VideoSearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            return LibraryProvider.VideoSearchByTag(startIndex, lenght, ref totalItem, culture, companyid);
        }
        public List<Library> GetAllActive(string culture)
        {
            return LibraryProvider.GetAllActive(culture);
        }
        public List<Library> ImageGetAllActive(string culture)
        {
            return LibraryProvider.ImageGetAllActive(culture);
        }
        public List<Library> VideoGetAllActive(string culture)
        {
            return LibraryProvider.VideoGetAllActive(culture);
        }
        public List<Library> GetHot(string culture)
        {
            return LibraryProvider.GetHot(culture);
        }
        public List<Library> ImageGetHot(string culture)
        {
            return LibraryProvider.ImageGetHot(culture);
        }
        public List<Library> VideoGetHot(string culture)
        {
            return LibraryProvider.VideoGetHot(culture);
        }
        public List<Library> GetTop(int topcount, string culture)
        {
            return LibraryProvider.GetTop(topcount, culture);
        }
        public List<Library> ImageGetTop(int topcount, string culture)
        {
            return LibraryProvider.ImageGetTop(topcount, culture);
        }
        public List<Library> VideoGetTop(int topcount, string culture)
        {
            return LibraryProvider.VideoGetTop(topcount, culture);
        }

        public List<Library> GetTopHot(int topcount, string culture)
        {
            return LibraryProvider.GetTopHot(topcount, culture);
        }

        public List<Library> GetTopHotByTag(int topcount, int companyid, string culture)
        {
            return LibraryProvider.GetTopHotByTag(topcount, companyid,culture);
        }

        public List<Library> ImageGetTopHot(int topcount, string culture)
        {
            return LibraryProvider.ImageGetTopHot(topcount, culture);
        }
        public List<Library> VideoGetTopHot(int topcount, string culture)
        {
            return LibraryProvider.VideoGetTopHot(topcount, culture);
        }

    }
}
