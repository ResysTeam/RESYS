using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;


namespace RESYS.BIZ.Services
{
    public class SlideBannerManager : DataManagerBase<SlideBanner>
    {
        public SlideBannerManager()
            : base()
        { }

        public SlideBannerManager(IDataProvider<SlideBanner> provider)
            : base(provider)
        {
        }

        private ISlideBannerProvider SlideBannerProvider
        {
            get { return (ISlideBannerProvider)Provider; }
        }

        public List<SlideBanner> SelectTop(int topcount, string culture)
        {
            return SlideBannerProvider.SelectTop(topcount, culture);
        }
        public List<SlideBanner> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return SlideBannerProvider.Search(startIndex, lenght, ref totalItem, culture);
        }
        public void Add(SlideBanner model, string culture)
        {
            SlideBannerProvider.Add(model, culture);
        }
    }
}
