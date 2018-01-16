using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.BIZ.Models
{
    public class AlbumImage : EntityBase
    {
        [DataColum]
        public int AlbumImageId { get; set; }

        [DataColum]
        public int AlbumId { get; set; }

        [DataColum]
        public string AlbumImageUrl { get; set; }



        [DataColum]
        public string AlbumImageTitle { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public string Culture { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }
    }
}
