using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.BIZ.Models
{
    public class Video : EntityBase
    {
        [DataColum]
        public int VideoId { get; set; }

        [DataColum]
        public string VideoTitle { get; set; }

        [DataColum]
        public string VideoUrl { get; set; }

        [DataColum]
        public string VideoDescription { get; set; }

        [DataColum]
        public string VideoKeyword { get; set; }

        [DataColum]
        public bool IsHotVideo { get; set; }

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
