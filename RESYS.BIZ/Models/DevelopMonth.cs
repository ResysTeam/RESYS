using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.BIZ.Models
{
    public class DevelopMonth:EntityBase
    {
        [DataColum]
        public int DevelopMonthId { get; set; }

        [DataColum]
        public int DevelopYearId { get; set; }

        [DataColum]
        public int DevelopMonthName { get; set; }

        [DataColum]
        public string DevelopMonthTitle { get; set; }

        [DataColum]
        public string DevelopMonthDescription { get; set; }

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
    }
}
