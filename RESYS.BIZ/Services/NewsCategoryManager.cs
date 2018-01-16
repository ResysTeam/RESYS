using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class NewsCategoryManager : DataManagerBase<NewsCategory>
    {
        public NewsCategoryManager()
            : base()
        { }

        public NewsCategoryManager(IDataProvider<NewsCategory> provider)
            : base(provider)
        {
        }

        private INewsCategoryProvider NewsCategoryProvider
        {
            get { return (INewsCategoryProvider)Provider; }
        }

        public void Add(NewsCategory model, string culture)
        {
            NewsCategoryProvider.Add(model, culture);
        }

        public List<NewsCategory> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return NewsCategoryProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<NewsCategoryBase> GetAllActive(string culture)
        {
            return NewsCategoryProvider.GetAllActive(culture);
        }

        public List<NewsCategory> GetTop(int topcount, string culture)
        {
            return NewsCategoryProvider.GetTop(topcount, culture);
        }

        public NewsCategory GetByShortName(NewsCategory dummy, string culture)
        {
            return NewsCategoryProvider.GetByShortName(dummy, culture);
        }
        public List<NewsCategory> GetAllActiveByPrId(int parentid, string culture)
        {
            return NewsCategoryProvider.GetAllActiveByPrId(parentid, culture);
        }

    }
}
