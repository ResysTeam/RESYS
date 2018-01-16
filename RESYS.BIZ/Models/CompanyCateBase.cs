using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;


namespace RESYS.BIZ.Models
{
    public class CompanyCateBase : EntityBase
    {
        [DataColum]
        public int CompanyCateId { get; set; }

        [DataColum]
        public int ParentId { get; set; }

        [DataColum]
        public string CompanyCateName { get; set; }

        private CompanyCateBase _parent;
        public CompanyCateBase Parent
        {
            get
            {
                return _parent ?? (_parent = new CompanyCateBase()
                {
                    CompanyCateId = ParentId
                });
            }
            set { _parent = value; }
        }

        public List<CompanyCateBase> Children { get; set; }

        public int HLevel
        {
            get;
            set;
        }

        public string HlevelTitle
        {
            get
            {
                if (HLevel > 0)
                {
                    var l = "";
                    for (var i = 1; i <= HLevel; ++i)
                    {
                        l += "|--";
                    }
                    return string.Format("{0}{1}", l, CompanyCateName);

                }

                return CompanyCateName;
            }
        }
    }
}
