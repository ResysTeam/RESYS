using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.BIZ.Models
{
    public class SlideBanner : EntityBase
    {
        [DataColum]
        public int SlideBannerId { get; set; }

        [DataColum]
        public string SlideBannerUrl { get; set; }

        [DataColum]
        public string SlideBannerImage { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public string Culture { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

    }
}
