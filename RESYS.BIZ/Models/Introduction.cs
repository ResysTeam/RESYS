using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;

namespace RESYS.BIZ.Models
{
    public class Introduction : EntityBase
    {
        [DataColum]
        public int IntroductionId { get; set; }

        [DataColum]
        public string IntroductionName { get; set; }


        [DataColum]
        public string IntroductionShortName { get; set; }

        [DataColum]
        public string IntroductionImage { get; set; }
  
        [DataColum]
        public string IntroductionBackground { get; set; }
      
        [DataColum]
        public string IntroductionDescription { get; set; }

        [DataColum]
        public string IntroductionTitle { get; set; }

        [DataColum]
        public string IntroductionBanner { get; set; }

        [DataColum]
        public string IntroductionBody { get; set; }

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
