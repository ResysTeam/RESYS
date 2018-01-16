using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class ImageManager : DataManagerBase<Image>
    {
        public ImageManager()
            : base()
        { }

        public ImageManager(IDataProvider<Image> provider)
            : base(provider)
        {
        }

        private IImageProvider ImageProvider
        {
            get { return (IImageProvider)Provider; }
        }

        public void Add(Image model, string culture)
        {
            ImageProvider.Add(model, culture);
        }

        public List<Image> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return ImageProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<Image> GetAllActive(string culture)
        {
            return ImageProvider.GetAllActive(culture);
        }

        public List<Image> GetHot(string culture)
        {
            return ImageProvider.GetHot(culture);
        }

        public List<Image> GetTop(int topcount, string culture)
        {
            return ImageProvider.GetTop(topcount, culture);
        }
        public List<Image> GetTopHot(int topcount, string culture)
        {
            return ImageProvider.GetTopHot(topcount,culture);
        }

    }
}
