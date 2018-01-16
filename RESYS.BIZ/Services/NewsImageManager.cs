using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class NewsImageManager : DataManagerBase<NewsImage>
    {
        public NewsImageManager()
            : base()
        { }

        public NewsImageManager(IDataProvider<NewsImage> provider)
            : base(provider)
        {
        }

        private INewsImageProvider NewsImageProvider
        {
            get { return (INewsImageProvider)Provider; }
        }

        public void Add(NewsImage model, string culture)
        {
            NewsImageProvider.Add(model, culture);
        }

        public List<NewsImage> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return NewsImageProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<NewsImage> GetAllActive(string culture)
        {
            return NewsImageProvider.GetAllActive(culture);
        }

        public List<NewsImage> GetTop(int topcount, string culture)
        {
            return NewsImageProvider.GetTop(topcount, culture);
        }
        public List<NewsImage> GetByNewsActive(int newsid, string culture)
        {
            return NewsImageProvider.GetByNewsActive(newsid, culture);
        }

        public List<NewsImage> GetByNews(int newsid, string culture)
        {
            return NewsImageProvider.GetByNews(newsid, culture);
        }
    }
}
