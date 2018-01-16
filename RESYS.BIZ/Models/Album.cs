using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.BIZ.Models
{
    public class Album : EntityBase
    {
        [DataColum]
        public int AlbumId { get; set; }

        [DataColum]
        public string AlbumTitle { get; set; }

        [DataColum]
        public string AlbumUrl { get; set; }

        [DataColum]
        public string AlbumDescription { get; set; }

        [DataColum]
        public string AlbumKeyword { get; set; }

        [DataColum]
        public int CompanyId { get; set; }

        [DataColum]
        public string CompanyName { get; set; }

        [DataColum]
        public string CompanyShortName { get; set; }


        [DataColum]
        public bool IsAll { get; set; }

        [DataColum]
        public bool IsHotAlbum { get; set; }

        [DataColum]
        public bool IsVideo { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public string Culture { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }

        public List<AlbumImage> ListAlbumImage
        {
            get;
            set;
        }
    }
}
