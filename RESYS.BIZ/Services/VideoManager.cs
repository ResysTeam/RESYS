using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class VideoManager : DataManagerBase<Video>
    {
        public VideoManager()
            : base()
        { }

        public VideoManager(IDataProvider<Video> provider)
            : base(provider)
        {
        }

        private IVideoProvider VideoProvider
        {
            get { return (IVideoProvider)Provider; }
        }

        public void Add(Video model, string culture)
        {
            VideoProvider.Add(model, culture);
        }

        public List<Video> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return VideoProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<Video> GetAllActive(string culture)
        {
            return VideoProvider.GetAllActive(culture);
        }

        public List<Video> GetHot(string culture)
        {
            return VideoProvider.GetHot(culture);
        }

        public List<Video> GetTop(int topcount, string culture)
        {
            return VideoProvider.GetTop(topcount, culture);
        }
        public List<Video> GetTopHot(int topcount, string culture)
        {
            return VideoProvider.GetTopHot(topcount, culture);
        }

    }
}
