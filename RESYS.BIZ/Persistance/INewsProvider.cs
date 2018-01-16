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
    public interface INewsProvider : IDataProvider<News>
    {
        void Add(News model, string culture);
        List<News> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<News> SearchByTag(int startIndex, int lenght, ref int totalItem, string culture, int companyid);
        List<News> SearchByCateParentId(int catenewsid, int startIndex, int lenght, ref int totalItem, string culture);
        List<News> GetAllActive(int startIndex, int lenght, ref int totalItem, string culture, string shortname);
        List<News> GetTop(int topcount, string culture);
        List<News> GetByCateId(int startIndex, int lenght, ref int totalItem, string culture, int newscateid);
        List<News> GetByCateParentId(int newscateid, string culture);
        List<News> GetByShortName(string shortname, string culture);
        List<News> GetOther(int topcount, string culture, int newsid, int companyid);
        List<News> GetOtherNews(int topcount, string culture, int newsid);
        News GetDetail(News model, string culture);
        List<News> GetHot(string culture);
        List<News> GetTopHot(int topcount, string culture);
        List<News> GetTopHotByTag(int topcount, int companyid, string culture);
        List<News> GetByShortNameCate(int topcount, string shortname, string culture);
    }
}
