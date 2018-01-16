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
    public interface IImageProvider : IDataProvider<Image>
    {
        void Add(Image model, string culture);
        List<Image> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<Image> GetAllActive(string culture);
        List<Image> GetTop(int topcount, string culture);
        List<Image> GetTopHot(int topcount, string culture);
        List<Image> GetHot(string culture);
    }
}
