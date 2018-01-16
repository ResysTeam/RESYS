using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.BIZ.Models
{
    public class Library : EntityBase
    {
        [DataColum]
        public int LibraryId { get; set; }

        [DataColum]
        public string LibraryTitle { get; set; }

        [DataColum]
        public string LibraryUrl { get; set; }

        [DataColum]
        public string LibraryDescription { get; set; }

        [DataColum]
        public string LibraryKeyword { get; set; }

        [DataColum]
        public int CompanyId { get; set; }

        [DataColum]
        public string CompanyName { get; set; }

        [DataColum]
        public string CompanyShortName { get; set; }


        [DataColum]
        public bool IsAll { get; set; }

        [DataColum]
        public bool IsHotLibrary { get; set; }

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
    }
}
