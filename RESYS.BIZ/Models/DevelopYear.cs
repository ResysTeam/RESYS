using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.BIZ.Models
{
   public class DevelopYear:EntityBase
    {
        [DataColum]
        public int DevelopYearId { get; set; }

        [DataColum]
        public int DevelopYearName { get; set; }
        [DataColum]

        public string DevelopYearBg { get; set; }
        [DataColum]

        public bool IsActive { get; set; }

        [DataColum]
        public string Culture { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }

        public List<DevelopMonth> ListMonth { get; set; }
    }
}
