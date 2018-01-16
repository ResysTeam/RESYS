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
    public interface INewsCategoryProvider : IDataProvider<NewsCategory>
    {
        void Add(NewsCategory model, string culture);
        List<NewsCategory> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<NewsCategoryBase> GetAllActive(string culture);
        List<NewsCategory> GetTop(int topcount, string culture);
        NewsCategory GetByShortName(NewsCategory dummy, string culture);
        List<NewsCategory> GetAllActiveByPrId(int parentid, string culture);
    }
}
