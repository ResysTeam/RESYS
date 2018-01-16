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
    public interface INewsImageProvider : IDataProvider<NewsImage>
    {
        void Add(NewsImage model, string culture);
        List<NewsImage> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<NewsImage> GetAllActive(string culture);
        List<NewsImage> GetTop(int topcount, string culture);
        List<NewsImage> GetByNews(int newsid, string culture);
        List<NewsImage> GetByNewsActive(int newsid, string culture);
    }
}
