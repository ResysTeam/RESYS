using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class AlbumImageManager : DataManagerBase<AlbumImage>
    {
        public AlbumImageManager()
            : base()
        { }

        public AlbumImageManager(IDataProvider<AlbumImage> provider)
            : base(provider)
        {
        }

        private IAlbumImageProvider AlbumImageProvider
        {
            get { return (IAlbumImageProvider)Provider; }
        }

        public void Add(AlbumImage model, string culture)
        {
            AlbumImageProvider.Add(model, culture);
        }

        public List<AlbumImage> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return AlbumImageProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<AlbumImage> GetAllActive(string culture)
        {
            return AlbumImageProvider.GetAllActive(culture);
        }

        public List<AlbumImage> GetTop(int topcount, string culture)
        {
            return AlbumImageProvider.GetTop(topcount, culture);
        }
        public List<AlbumImage> GetByAlbumActive(int newsid, string culture)
        {
            return AlbumImageProvider.GetByAlbumActive(newsid, culture);
        }

        public List<AlbumImage> GetByAlbum(int newsid, string culture)
        {
            return AlbumImageProvider.GetByAlbum(newsid, culture);
        }
    }
}
