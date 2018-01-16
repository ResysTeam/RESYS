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

    public interface ISlideBannerProvider : IDataProvider<SlideBanner>
    {
        void Add(SlideBanner model, string culture);
        List<SlideBanner> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<SlideBanner> SelectTop(int topcount, string culture);
    }
}
