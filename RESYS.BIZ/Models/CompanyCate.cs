using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;


namespace RESYS.BIZ.Models
{
    public class CompanyCate: CompanyCateBase

    {
        public CompanyCate()
            : base()
        {
            
        }

        public CompanyCate(int id)
            : this()
        {
            this.CompanyCateId = id;
        }

        public CompanyCate(string name)
            : this()
        {
            this.CompanyCateName = name;
        }

        [DataColum]
        public string CompanyCateShortName { get; set; }

        [DataColum]
        public string CompanyCateImage { get; set; }

        [DataColum]
        public string CompanyCateIcon { get; set; }

        [DataColum]
        public bool IsHotCompanyCate { get; set; }

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

        

        public List<Company> ListCompany { get; set; }
    }
}
