using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.BIZ.Models
{
    public class Company : EntityBase
    {
        [DataColum]
        public int CompanyId { get; set; }

        [DataColum]
        public int CompanyCateId { get; set; }

        [DataColum]
        public string CompanyCateName { get; set; }

        [DataColum]
        public string CompanyName { get; set; }

        [DataColum]
        public string CompanyShortName { get; set; }

        [DataColum]
        public string CompanyBackground { get; set; }

        [DataColum]
        public string CompanyBanner { get; set; }

        [DataColum]
        public string CompanyLogo { get; set; }

        [DataColum]
        public string CompanyAddress { get; set; }

        [DataColum]
        public string CompanyContact { get; set; }

        [DataColum]
        public string CompanyWeb { get; set; }

        [DataColum]
        public string CompanyTwitter { get; set; }

        [DataColum]
        public string CompanyFace { get; set; }

        [DataColum]
        public string CompanyYoutube { get; set; }

        [DataColum]
        public string CompanyGoogle { get; set; }

        [DataColum]
        public string CompanyBody { get; set; }

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
