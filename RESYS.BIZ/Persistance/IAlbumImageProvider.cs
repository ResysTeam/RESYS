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
    public interface IAlbumImageProvider : IDataProvider<AlbumImage>
    {
        void Add(AlbumImage model, string culture);
        List<AlbumImage> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<AlbumImage> GetAllActive(string culture);
        List<AlbumImage> GetTop(int topcount, string culture);
        List<AlbumImage> GetByAlbum(int newsid, string culture);
        List<AlbumImage> GetByAlbumActive(int newsid, string culture);
    }
}
