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
    public interface IVideoProvider : IDataProvider<Video>
    {
        void Add(Video model, string culture);
        List<Video> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<Video> GetAllActive(string culture);
        List<Video> GetTop(int topcount, string culture);
        List<Video> GetTopHot(int topcount, string culture);
        List<Video> GetHot(string culture);
    }
}
