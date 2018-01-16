using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class NewsManager : DataManagerBase<News>
    {
        public NewsManager()
            : base()
        { }

        public NewsManager(IDataProvider<News> provider)
            : base(provider)
        {
        }

        private INewsProvider NewsProvider
        {
            get { return (INewsProvider)Provider; }
        }

        public void Add(News model, string culture)
        {
            NewsProvider.Add(model, culture);
        }
        public News GetDetail(News model, string culture)
        {
            return NewsProvider.GetDetail(model, culture);
        }
        public List<News> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return NewsProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<News> SearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid)
        {
            return NewsProvider.SearchByTag(startIndex, lenght, ref totalItem, culture, companyid);
        }

        public List<News> SearchByCateParentId(int catenewsid, int startIndex, int lenght, ref int totalItem,
                                               string culture)
        {
            return NewsProvider.SearchByCateParentId(catenewsid, startIndex, lenght, ref totalItem, culture);
        }

        public List<News> GetAllActive(int startIndex, int lenght, ref int totalItem, string culture, string shortname)
        {
            return NewsProvider.GetAllActive(startIndex, lenght, ref totalItem, culture, shortname);
        }     

        public List<News> GetHot(string culture)
        {
            return NewsProvider.GetHot(culture);
        }

        public List<News> GetTop(int topcount, string culture)
        {
            return NewsProvider.GetTop(topcount, culture);
        }
        public List<News> GetTopHot(int topcount, string culture)
        {
            return NewsProvider.GetTopHot(topcount, culture);
        }
        public List<News> GetTopHotByTag(int topcount, int companyid, string culture)
        {
            return NewsProvider.GetTopHotByTag(topcount, companyid,culture);
        }
        public List<News> GetByCateId(int startIndex, int lenght, ref int totalItem, string culture, int newscateid)
        {
            return NewsProvider.GetByCateId(startIndex, lenght, ref totalItem, culture, newscateid);
        }  
        public List<News> GetByShortName(string shortname, string culture)
        {
            return NewsProvider.GetByShortName(shortname, culture);
        }
        public List<News> GetOther(int topcount, string culture, int newsid, int companyid)
        {
            return NewsProvider.GetOther(topcount, culture, newsid, companyid);
        }
        public List<News> GetOtherNews(int topcount, string culture, int newsid)
        {
            return NewsProvider.GetOtherNews(topcount, culture, newsid);
        }
        public List<News> GetByShortNameCate(int topcount,string shortname, string culture)
        {
            return NewsProvider.GetByShortNameCate(topcount,shortname, culture);
        }
         public List<News> GetByCateParentId(int newscateid, string culture)
         {
             return NewsProvider.GetByCateParentId(newscateid, culture);
         }
    }
}
