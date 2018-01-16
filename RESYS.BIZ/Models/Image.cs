using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.BIZ.Models
{
    public class Image : EntityBase
    {
        [DataColum]
        public int ImageId { get; set; }

        [DataColum]
        public string ImageTitle { get; set; }

        [DataColum]
        public string ImageUrl { get; set; }

        [DataColum]
        public string ImageDescription { get; set; }

        [DataColum]
        public string ImageKeyword { get; set; }

        [DataColum]
        public bool IsHotImage { get; set; }

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
    }
}
